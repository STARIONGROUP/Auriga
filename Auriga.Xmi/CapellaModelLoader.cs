// ------------------------------------------------------------------------------------------------
// <copyright file="CapellaModelLoader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// The default <see cref="ICapellaModelLoader"/>. It resolves the supplied path to the project's
    /// semantic model file — the file itself, or the single <c>.capella</c> / <c>.melodymodeller</c> in a
    /// project directory — and reads it (and its referenced fragments) through an <see cref="IXmiReader"/>.
    /// Unlike calling <see cref="IXmiReader.Read(string)"/> directly, it fails fast with a clear exception
    /// when the path does not exist, names a non-model file, or names a directory that holds no — or more
    /// than one — semantic model file.
    /// </summary>
    /// <remarks>
    /// In current Capella the <c>.capella</c> file is itself the semantic model root (a
    /// <c>capellamodeller::Project</c>); there is no separate descriptor indirection, so resolving a
    /// project directory means finding that one semantic file. The diagram <c>.aird</c> and metadata
    /// <c>.afm</c> siblings are out of scope and ignored.
    /// </remarks>
    public sealed class CapellaModelLoader : ICapellaModelLoader
    {
        /// <summary>
        /// The extensions of a Capella semantic model file — the current <c>.capella</c> and the legacy
        /// <c>.melodymodeller</c>. Matched case-insensitively. A <c>.capellafragment</c> is deliberately
        /// excluded: it is a contained subtree loaded transitively, never a project's entry point.
        /// </summary>
        private static readonly string[] SemanticModelExtensions = { ".capella", ".melodymodeller" };

        /// <summary>
        /// The reader that reads the resolved semantic model file into the object graph.
        /// </summary>
        private readonly IXmiReader reader;

        /// <summary>
        /// The logger used to report which file was resolved and loaded.
        /// </summary>
        private readonly ILogger<CapellaModelLoader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CapellaModelLoader"/> class.
        /// </summary>
        /// <param name="reader">the reader used to read the resolved semantic model file</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="reader"/> is <c>null</c></exception>
        public CapellaModelLoader(IXmiReader reader, ILoggerFactory? loggerFactory = null)
        {
            this.reader = reader ?? throw new ArgumentNullException(nameof(reader));
            this.logger = (loggerFactory ?? NullLoggerFactory.Instance).CreateLogger<CapellaModelLoader>();
        }

        /// <summary>
        /// Creates a loader over a default, fully-wired <see cref="IXmiReader"/> (via
        /// <see cref="XmiReaderBuilder"/>). This is the one-call convenience entry point:
        /// <c>CapellaModelLoader.Create().Load(path)</c>.
        /// </summary>
        /// <param name="loggerFactory">the logger factory the loader and reader log through, or <c>null</c></param>
        /// <returns>the loader</returns>
        public static CapellaModelLoader Create(ILoggerFactory? loggerFactory = null)
        {
            var builder = XmiReaderBuilder.Create();
            if (loggerFactory != null)
            {
                builder = builder.WithLogger(loggerFactory);
            }

            return new CapellaModelLoader(builder.Build(), loggerFactory);
        }

        /// <summary>
        /// Loads the Capella project identified by <paramref name="path"/> (a semantic model file or the
        /// project directory that contains one) into a fully resolved object graph.
        /// </summary>
        /// <param name="path">the semantic model file path, or the project directory path</param>
        /// <returns>the fully resolved object graph, including any referenced fragments</returns>
        /// <exception cref="ArgumentException">thrown when <paramref name="path"/> is null or blank</exception>
        /// <exception cref="FileNotFoundException">
        /// thrown when the path exists as neither a file nor a directory, or a directory holds no semantic
        /// model file
        /// </exception>
        /// <exception cref="InvalidDataException">
        /// thrown when the path names a non-model file, a directory holds more than one semantic model
        /// file, or the model's root namespace is not a known Capella metamodel version
        /// </exception>
        public XmiReaderResult Load(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("The path must be provided.", nameof(path));
            }

            var modelFile = this.ResolveModelFile(path);

            this.logger.LogInformation("Loading Capella project from semantic model file {File}", modelFile);

            return this.reader.Read(modelFile);
        }

        /// <summary>
        /// Resolves the supplied path to the absolute path of an existing semantic model file: the file
        /// itself when it is one, or the single semantic model file in a project directory.
        /// </summary>
        /// <param name="path">the semantic model file path, or the project directory path</param>
        /// <returns>the absolute path of the semantic model file to read</returns>
        private string ResolveModelFile(string path)
        {
            if (Directory.Exists(path))
            {
                return ResolveModelFileInDirectory(path);
            }

            if (File.Exists(path))
            {
                var extension = Path.GetExtension(path);
                if (!SemanticModelExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
                {
                    throw new InvalidDataException(
                        $"The file '{path}' is not a Capella semantic model (expected a {DescribeExtensions()} file).");
                }

                return Path.GetFullPath(path);
            }

            throw new FileNotFoundException(
                $"No Capella model file or project directory was found at '{path}'.", path);
        }

        /// <summary>
        /// Finds the single semantic model file directly in the supplied project directory.
        /// </summary>
        /// <param name="directory">the project directory</param>
        /// <returns>the absolute path of the semantic model file</returns>
        /// <exception cref="FileNotFoundException">thrown when the directory holds no semantic model file</exception>
        /// <exception cref="InvalidDataException">thrown when the directory holds more than one</exception>
        private static string ResolveModelFileInDirectory(string directory)
        {
            // Enumerate every file and match the extension explicitly rather than passing a "*.capella"
            // search pattern, whose legacy 8.3 short-name matching on Windows would also match unrelated
            // extensions such as .capellafragment.
            var candidates = Directory.EnumerateFiles(directory)
                .Where(file => SemanticModelExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
                .ToList();

            if (candidates.Count == 0)
            {
                throw new FileNotFoundException(
                    $"The directory '{directory}' contains no Capella semantic model file (a {DescribeExtensions()} file).");
            }

            if (candidates.Count > 1)
            {
                var names = string.Join(", ", candidates.Select(Path.GetFileName));
                throw new InvalidDataException(
                    $"The directory '{directory}' contains more than one Capella semantic model file ({names}); load one by its file path.");
            }

            return Path.GetFullPath(candidates[0]);
        }

        /// <summary>
        /// Describes the accepted semantic model extensions for use in an error message (e.g.
        /// <c>.capella or .melodymodeller</c>).
        /// </summary>
        /// <returns>a human-readable list of the accepted extensions</returns>
        private static string DescribeExtensions()
        {
            return string.Join(" or ", (IEnumerable<string>)SemanticModelExtensions);
        }
    }
}
