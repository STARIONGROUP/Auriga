// ------------------------------------------------------------------------------------------------
// <copyright file="WorkspaceProjectRegistry.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// Maps Eclipse workspace project names to their folders so a <c>platform:/resource/&lt;projectName&gt;/…</c>
    /// href — the form Capella uses to reference elements in a library project — resolves to a document on
    /// disk. Such a library lives in a sibling project folder outside the referencing project's root, and the
    /// <c>&lt;projectName&gt;</c> is the name declared in that sibling's <c>.project</c> file (its
    /// <c>&lt;name&gt;</c> element), which routinely differs from the folder name — so the target cannot be
    /// found by document-relative resolution and the name cannot be derived from the path.
    /// </summary>
    /// <remarks>
    /// The registry is seeded two ways, explicit registrations taking precedence: a caller may
    /// <see cref="Register"/> a project explicitly, and — anchored at the model's own project folder via
    /// <see cref="SetAnchorDirectory"/> — it lazily scans the sibling folders of that project (the Eclipse
    /// workspace root) for <c>.project</c> files, reading each declared name. A name that resolves to no
    /// registered project leaves the href unresolved: it is reported, never silently dropped (issue #54).
    /// One instance is shared, per read session, by the reader (which discovers the library documents to
    /// load) and the reference resolver (which keys the collected tokens against the loaded elements), so
    /// both derive the same canonical document name for a given library href.
    /// </remarks>
    public sealed class WorkspaceProjectRegistry
    {
        /// <summary>
        /// The name of an Eclipse project-description file, whose <c>&lt;name&gt;</c> element carries the
        /// declared project name referenced by <c>platform:/resource</c> hrefs.
        /// </summary>
        private const string ProjectDescriptionFileName = ".project";

        /// <summary>
        /// Projects registered explicitly by a caller, keyed by declared name. These take precedence over
        /// the scanned projects, so a caller can override or supplement the workspace scan.
        /// </summary>
        private readonly Dictionary<string, string> explicitProjects = new Dictionary<string, string>(StringComparer.Ordinal);

        /// <summary>
        /// Projects discovered by scanning the anchor's sibling folders for <c>.project</c> files, keyed by
        /// declared name. Populated lazily on the first library-href lookup and reset when the anchor moves.
        /// </summary>
        private readonly Dictionary<string, string> scannedProjects = new Dictionary<string, string>(StringComparer.Ordinal);

        /// <summary>
        /// The logger used to report scan failures and duplicate declared names.
        /// </summary>
        private readonly ILogger<WorkspaceProjectRegistry> logger;

        /// <summary>
        /// The absolute path of the model's own project folder, against which library documents are named
        /// (canonicalized) and whose parent is scanned for sibling projects. Null until an anchor is set.
        /// </summary>
        private string? anchorDirectory;

        /// <summary>
        /// Whether the anchor's sibling folders have been scanned for the current <see cref="anchorDirectory"/>.
        /// </summary>
        private bool scanned;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceProjectRegistry"/> class.
        /// </summary>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public WorkspaceProjectRegistry(ILoggerFactory? loggerFactory = null)
        {
            this.logger = (loggerFactory ?? NullLoggerFactory.Instance).CreateLogger<WorkspaceProjectRegistry>();
        }

        /// <summary>
        /// Registers a workspace project explicitly, mapping its declared name to its folder. An explicit
        /// registration takes precedence over any same-named project found by the sibling scan.
        /// </summary>
        /// <param name="projectName">the declared project name (as it appears in a <c>platform:/resource</c> href)</param>
        /// <param name="projectDirectory">the absolute or relative path of the project folder</param>
        public void Register(string projectName, string projectDirectory)
        {
            if (string.IsNullOrEmpty(projectName))
            {
                throw new ArgumentException("The project name must be provided.", nameof(projectName));
            }

            if (string.IsNullOrEmpty(projectDirectory))
            {
                throw new ArgumentException("The project directory must be provided.", nameof(projectDirectory));
            }

            this.explicitProjects[projectName] = Path.GetFullPath(projectDirectory);
        }

        /// <summary>
        /// Anchors the registry at the model's own project folder: library documents are named relative to
        /// it, and its sibling folders (the Eclipse workspace root) are scanned for <c>.project</c> files.
        /// Moving the anchor discards the previous sibling scan so a reused registry resolves against the
        /// new model's workspace.
        /// </summary>
        /// <param name="directory">the model's project folder (the directory of its main document)</param>
        public void SetAnchorDirectory(string? directory)
        {
            var resolved = string.IsNullOrEmpty(directory) ? null : Path.GetFullPath(directory);

            if (!string.Equals(resolved, this.anchorDirectory, StringComparison.OrdinalIgnoreCase))
            {
                this.anchorDirectory = resolved;
                this.scannedProjects.Clear();
                this.scanned = false;
            }
        }

        /// <summary>
        /// Resolves a <c>platform:/resource</c> document path to the referenced library document, when the
        /// path names a known workspace project. The canonical name matches the source document the reader
        /// tags the library's elements with, so the two agree on the cache key.
        /// </summary>
        /// <param name="documentPath">the document part of the href (the <c>#id</c> already stripped)</param>
        /// <param name="canonicalName">the library document's name relative to the anchor, forward-slashed</param>
        /// <param name="fullPath">the absolute path of the library document on disk</param>
        /// <returns>
        /// true when the path is a <c>platform:/resource</c> reference to a known project; false for any
        /// other href form or an unknown project (the reference then stays unresolved, and is reported)
        /// </returns>
        public bool TryResolveDocument(string? documentPath, out string canonicalName, out string fullPath)
        {
            canonicalName = string.Empty;
            fullPath = string.Empty;

            if (!HrefReference.TryParsePlatformResource(documentPath, out var projectName, out var projectRelativePath))
            {
                return false;
            }

            if (!this.TryGetProjectDirectory(projectName, out var projectDirectory))
            {
                return false;
            }

            var relative = Uri.UnescapeDataString(projectRelativePath).Replace('\\', '/');
            fullPath = Path.GetFullPath(Path.Combine(projectDirectory, relative));
            canonicalName = this.Canonicalize(fullPath);
            return true;
        }

        /// <summary>
        /// Looks up a project folder by declared name, preferring an explicit registration and falling back
        /// to the (lazily performed) sibling scan.
        /// </summary>
        /// <param name="projectName">the declared project name</param>
        /// <param name="projectDirectory">the resolved absolute project folder</param>
        /// <returns>true when a project with the name is known</returns>
        private bool TryGetProjectDirectory(string projectName, out string projectDirectory)
        {
            if (this.explicitProjects.TryGetValue(projectName, out projectDirectory))
            {
                return true;
            }

            this.EnsureSiblingsScanned();
            return this.scannedProjects.TryGetValue(projectName, out projectDirectory);
        }

        /// <summary>
        /// Names a library document relative to the anchor, forward-slashed — the same form the reader
        /// records as the elements' source document — so a resolved reference keys against them. With no
        /// anchor the absolute path (forward-slashed) is used as a stable stand-in.
        /// </summary>
        /// <param name="fullPath">the absolute path of the library document</param>
        /// <returns>the canonical document name</returns>
        private string Canonicalize(string fullPath)
        {
            if (string.IsNullOrEmpty(this.anchorDirectory))
            {
                return fullPath.Replace(Path.DirectorySeparatorChar, '/');
            }

            return Path.GetRelativePath(this.anchorDirectory, fullPath).Replace(Path.DirectorySeparatorChar, '/');
        }

        /// <summary>
        /// Scans the sibling folders of the anchor (the workspace root) for <c>.project</c> files once per
        /// anchor, mapping each declared project name to its folder. Failures — an unreadable directory or a
        /// malformed <c>.project</c> — are logged and skipped so one bad sibling does not abort resolution.
        /// </summary>
        private void EnsureSiblingsScanned()
        {
            if (this.scanned)
            {
                return;
            }

            this.scanned = true;

            if (string.IsNullOrEmpty(this.anchorDirectory))
            {
                return;
            }

            var workspaceRoot = Path.GetDirectoryName(this.anchorDirectory);
            if (string.IsNullOrEmpty(workspaceRoot) || !Directory.Exists(workspaceRoot))
            {
                return;
            }

            IEnumerable<string> siblingDirectories;
            try
            {
                siblingDirectories = Directory.EnumerateDirectories(workspaceRoot);
            }
            catch (Exception exception) when (exception is IOException or UnauthorizedAccessException)
            {
                this.logger.LogWarning(exception, "Could not enumerate workspace projects under {Workspace}", workspaceRoot);
                return;
            }

            foreach (var directory in siblingDirectories)
            {
                this.ScanSiblingProject(directory);
            }
        }

        /// <summary>
        /// Reads the declared name from a sibling folder's <c>.project</c> file, if present, and records the
        /// name-to-folder mapping. A folder with no <c>.project</c>, or whose file carries no declared name,
        /// is not a workspace project and is ignored; the first declaration of a name wins.
        /// </summary>
        /// <param name="directory">the sibling folder to inspect</param>
        private void ScanSiblingProject(string directory)
        {
            var descriptor = Path.Combine(directory, ProjectDescriptionFileName);
            if (!File.Exists(descriptor))
            {
                return;
            }

            string? declaredName;
            try
            {
                declaredName = XDocument.Load(descriptor).Root?.Element("name")?.Value.Trim();
            }
            catch (Exception exception) when (exception is IOException or System.Xml.XmlException)
            {
                this.logger.LogWarning(exception, "Could not read the project descriptor {Descriptor}", descriptor);
                return;
            }

            if (string.IsNullOrEmpty(declaredName))
            {
                return;
            }

            if (this.scannedProjects.TryGetValue(declaredName!, out var existing))
            {
                this.logger.LogWarning("Workspace project name {Name} is declared by both {First} and {Second}; keeping {First}", declaredName, existing, directory);
                return;
            }

            this.scannedProjects[declaredName!] = Path.GetFullPath(directory);
        }
    }
}
