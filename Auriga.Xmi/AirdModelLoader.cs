// ------------------------------------------------------------------------------------------------
// <copyright file="AirdModelLoader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    using System;
    using System.IO;
    using System.Linq;

    using Auriga.Xmi.Core.Readers;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// The default <see cref="IAirdModelLoader"/>. It resolves the supplied path to the project's Sirius
    /// diagram file — the file itself, or the single <c>.aird</c> in a project directory — and reads it
    /// (and its referenced <c>.airdfragment</c>s) through an <see cref="IXmiReader"/>. Unlike calling
    /// <see cref="IXmiReader.Read(string)"/> directly, it fails fast with a clear exception when the path
    /// does not exist, names a non-diagram file, or names a directory that holds no — or more than one —
    /// <c>.aird</c> file. The diagram counterpart of <see cref="CapellaModelLoader"/>.
    /// </summary>
    /// <remarks>
    /// The <c>.aird</c> root is a multi-root <c>xmi:XMI</c> wrapper whose first typed element is the
    /// <c>viewpoint:DAnalysis</c>; the reader returns that analysis as the graph root. Referenced
    /// sub-analyses (<c>referencedAnalysis</c> hrefs into <c>.airdfragment</c> siblings) are loaded
    /// transitively into the same graph. The semantic <c>.capella</c> documents the diagrams point into
    /// are not co-loaded here — those hrefs stay reported-unresolved in a diagram-only load.
    /// </remarks>
    public sealed class AirdModelLoader : IAirdModelLoader
    {
        /// <summary>
        /// The extension of a Sirius diagram model file. Matched case-insensitively. An
        /// <c>.airdfragment</c> is deliberately excluded: it is a referenced sub-analysis loaded
        /// transitively, never a project's entry point.
        /// </summary>
        private const string DiagramModelExtension = ".aird";

        /// <summary>
        /// The reader that reads the resolved diagram file into the object graph.
        /// </summary>
        private readonly IXmiReader reader;

        /// <summary>
        /// The logger used to report which file was resolved and loaded.
        /// </summary>
        private readonly ILogger<AirdModelLoader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirdModelLoader"/> class.
        /// </summary>
        /// <param name="reader">the reader used to read the resolved diagram file</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="reader"/> is <c>null</c></exception>
        public AirdModelLoader(IXmiReader reader, ILoggerFactory? loggerFactory = null)
        {
            this.reader = reader ?? throw new ArgumentNullException(nameof(reader));
            this.logger = (loggerFactory ?? NullLoggerFactory.Instance).CreateLogger<AirdModelLoader>();
        }

        /// <summary>
        /// Creates a loader over a default, fully-wired <see cref="IXmiReader"/> (via
        /// <see cref="XmiReaderBuilder"/>). This is the one-call convenience entry point:
        /// <c>AirdModelLoader.Create().Load(path)</c>.
        /// </summary>
        /// <param name="loggerFactory">the logger factory the loader and reader log through, or <c>null</c></param>
        /// <returns>the loader</returns>
        public static AirdModelLoader Create(ILoggerFactory? loggerFactory = null)
        {
            var builder = XmiReaderBuilder.Create();
            if (loggerFactory != null)
            {
                builder = builder.WithLogger(loggerFactory);
            }

            return new AirdModelLoader(builder.Build(), loggerFactory);
        }

        /// <summary>
        /// Loads the Sirius diagram model identified by <paramref name="path"/> (an <c>.aird</c> file or
        /// the project directory that contains one) into a fully resolved object graph.
        /// </summary>
        /// <param name="path">the <c>.aird</c> file path, or the project directory path</param>
        /// <returns>the fully resolved object graph, including any referenced <c>.airdfragment</c>s</returns>
        /// <exception cref="ArgumentException">thrown when <paramref name="path"/> is null or blank</exception>
        /// <exception cref="FileNotFoundException">
        /// thrown when the path exists as neither a file nor a directory, or a directory holds no
        /// <c>.aird</c> file
        /// </exception>
        /// <exception cref="InvalidDataException">
        /// thrown when the path names a non-diagram file, or a directory holds more than one <c>.aird</c>
        /// file
        /// </exception>
        public XmiReaderResult Load(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("The path must be provided.", nameof(path));
            }

            var diagramFile = this.ResolveDiagramFile(path);

            this.logger.LogInformation("Loading Sirius diagram model from {File}", diagramFile);

            return this.reader.Read(diagramFile);
        }

        /// <summary>
        /// Resolves the supplied path to the absolute path of an existing <c>.aird</c> file: the file
        /// itself when it is one, or the single <c>.aird</c> in a project directory.
        /// </summary>
        /// <param name="path">the <c>.aird</c> file path, or the project directory path</param>
        /// <returns>the absolute path of the diagram file to read</returns>
        private string ResolveDiagramFile(string path)
        {
            if (Directory.Exists(path))
            {
                return ResolveDiagramFileInDirectory(path);
            }

            if (File.Exists(path))
            {
                var extension = Path.GetExtension(path);
                if (!string.Equals(extension, DiagramModelExtension, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidDataException(
                        $"The file '{path}' is not a Sirius diagram model (expected a {DiagramModelExtension} file).");
                }

                return Path.GetFullPath(path);
            }

            throw new FileNotFoundException(
                $"No Sirius diagram file or project directory was found at '{path}'.", path);
        }

        /// <summary>
        /// Finds the single <c>.aird</c> file directly in the supplied project directory.
        /// </summary>
        /// <param name="directory">the project directory</param>
        /// <returns>the absolute path of the diagram file</returns>
        /// <exception cref="FileNotFoundException">thrown when the directory holds no <c>.aird</c> file</exception>
        /// <exception cref="InvalidDataException">thrown when the directory holds more than one</exception>
        private static string ResolveDiagramFileInDirectory(string directory)
        {
            // Enumerate every file and match the extension explicitly rather than passing a "*.aird"
            // search pattern, whose legacy 8.3 short-name matching on Windows would also match unrelated
            // extensions such as .airdfragment.
            var candidates = Directory.EnumerateFiles(directory)
                .Where(file => string.Equals(Path.GetExtension(file), DiagramModelExtension, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (candidates.Count == 0)
            {
                throw new FileNotFoundException(
                    $"The directory '{directory}' contains no Sirius diagram file (a {DiagramModelExtension} file).");
            }

            if (candidates.Count > 1)
            {
                var names = string.Join(", ", candidates.Select(Path.GetFileName));
                throw new InvalidDataException(
                    $"The directory '{directory}' contains more than one Sirius diagram file ({names}); load one by its file path.");
            }

            return Path.GetFullPath(candidates[0]);
        }
    }
}
