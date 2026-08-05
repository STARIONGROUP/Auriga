// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramReportGenerator.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Generators
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Auriga.Reporting.Builders;
    using Auriga.Reporting.Drawing;
    using Auriga.Reporting.Model;
    using Auriga.Xmi;
    using Auriga.Xmi.Core.Readers;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using SiriusTable = Auriga.Diagram.Table;

    /// <summary>
    /// The default <see cref="IDiagramReportGenerator"/>: composes an <see cref="IAirdModelLoader"/>
    /// and the reporting pipeline per call, so a model's own artwork resolves against the directory
    /// the model was loaded from without the caller wiring it.
    /// </summary>
    public sealed class DiagramReportGenerator : IDiagramReportGenerator
    {
        /// <summary>
        /// The time the name filter may run before it is abandoned. The pattern a wildcard compiles
        /// to cannot backtrack pathologically, but the input is a model's data and the guard costs
        /// nothing.
        /// </summary>
        private static readonly TimeSpan FilterTimeout = TimeSpan.FromSeconds(1);

        /// <summary>
        /// The characters a file name may not carry. Deliberately not
        /// <see cref="Path.GetInvalidFileNameChars"/>, which is the running platform's answer —
        /// Linux objects only to <c>/</c> and NUL, so the same diagram would export as
        /// <c>Overview: pumps.svg</c> there and <c>Overview_ pumps.svg</c> on Windows. Exported
        /// diagrams get shared, committed and opened elsewhere, so the set is fixed at the strictest
        /// of the platforms and a name is the same wherever it was produced.
        /// </summary>
        private static readonly char[] InvalidInAName = { '<', '>', ':', '"', '/', '\\', '|', '?', '*' };

        /// <summary>
        /// The factory every composed service logs through.
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The logger reporting what each run loaded and wrote.
        /// </summary>
        private readonly ILogger<DiagramReportGenerator> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramReportGenerator"/> class.
        /// </summary>
        /// <param name="loggerFactory">the factory the generator and everything it composes log through</param>
        /// <exception cref="ArgumentNullException">the logger factory is null</exception>
        public DiagramReportGenerator(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            this.logger = loggerFactory.CreateLogger<DiagramReportGenerator>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramReportGenerator"/> class that logs
        /// nothing.
        /// </summary>
        public DiagramReportGenerator()
            : this(NullLoggerFactory.Instance)
        {
        }

        /// <summary>
        /// Loads the model, builds its representations and writes the requested artifacts.
        /// </summary>
        /// <param name="aird">the Sirius <c>.aird</c> file, or the project directory holding exactly one</param>
        /// <param name="output">the directory the artifacts are written to; created when absent</param>
        /// <param name="options">what to write and how, or <c>null</c> for an SVG and a PNG of every representation</param>
        /// <returns>the files written, in the order they were produced</returns>
        /// <exception cref="ArgumentNullException">the model path or the output directory is null</exception>
        /// <exception cref="ArgumentException">no format was asked for</exception>
        /// <exception cref="FileNotFoundException">the path names no readable Sirius model</exception>
        public IReadOnlyList<FileInfo> Generate(FileInfo aird, DirectoryInfo output, DiagramReportOptions? options = null)
        {
            if (aird == null)
            {
                throw new ArgumentNullException(nameof(aird));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            options ??= new DiagramReportOptions();

            if (options.Formats == DiagramFormats.None)
            {
                throw new ArgumentException("No format was requested, so there is nothing to write.", nameof(options));
            }

            var session = this.Load(aird);

            using var reporting = ReportingBuilder.Create()
                .UsingProjectImages(ProjectDirectoryOf(aird))
                .WithLogger(this.loggerFactory);

            var diagrams = Matching(reporting.BuildDiagramBuilder().BuildAll(session.Elements.Values), options);

            output.Create();

            var written = new List<FileInfo>();
            var svgExporter = reporting.BuildSvgExporter();
            var rasterExporter = reporting.BuildRasterExporter();

            foreach (var diagram in diagrams)
            {
                var name = FileNameOf(diagram);

                if (options.Formats.HasFlag(DiagramFormats.Svg))
                {
                    written.Add(Write(output, name, ".svg", path => svgExporter.ExportToFile(diagram, path)));
                }

                if (options.Formats.HasFlag(DiagramFormats.Png))
                {
                    written.Add(Write(output, name, ".png", path => rasterExporter.ExportToFile(diagram, path, options.Raster)));
                }

                if (options.Formats.HasFlag(DiagramFormats.Jpeg))
                {
                    written.Add(Write(output, name, ".jpg", path => rasterExporter.ExportToFile(diagram, path, options.Raster)));
                }
            }

            if (options.Formats.HasFlag(DiagramFormats.Xlsx))
            {
                written.AddRange(this.WriteWorkbook(session, reporting, output));
            }

            this.logger.LogInformation(
                "Wrote {Count} file(s) for {Diagrams} representation(s) of {Model} to {Output}",
                written.Count,
                diagrams.Count,
                aird.Name,
                output.FullName);

            return written;
        }

        /// <summary>
        /// The representations the model holds, without writing anything.
        /// </summary>
        /// <param name="aird">the Sirius <c>.aird</c> file, or the project directory holding exactly one</param>
        /// <param name="options">the options whose name filter narrows the list, or <c>null</c> for all of them</param>
        /// <returns>the representations, in the order the model holds them</returns>
        /// <exception cref="ArgumentNullException">the model path is null</exception>
        /// <exception cref="FileNotFoundException">the path names no readable Sirius model</exception>
        public IReadOnlyList<Diagram> Query(FileInfo aird, DiagramReportOptions? options = null)
        {
            if (aird == null)
            {
                throw new ArgumentNullException(nameof(aird));
            }

            var session = this.Load(aird);

            using var reporting = ReportingBuilder.Create()
                .UsingProjectImages(ProjectDirectoryOf(aird))
                .WithLogger(this.loggerFactory);

            return Matching(reporting.BuildDiagramBuilder().BuildAll(session.Elements.Values), options ?? new DiagramReportOptions());
        }

        /// <summary>
        /// The export file name of a representation, without an extension, so a representation's
        /// artifacts sort next to each other: its Capella name with filesystem-hostile characters
        /// replaced, suffixed with the uid because Capella allows two representations to share a
        /// name, and the uid alone when no descriptor named it. The same on every platform — see
        /// <see cref="InvalidInAName"/>.
        /// </summary>
        /// <param name="diagram">the representation</param>
        /// <returns>the file name, without an extension</returns>
        /// <exception cref="ArgumentNullException">the representation is null</exception>
        public static string FileNameOf(Diagram diagram)
        {
            if (diagram == null)
            {
                throw new ArgumentNullException(nameof(diagram));
            }

            var name = string.IsNullOrEmpty(diagram.Name)
                ? diagram.Identifier.TrimStart('_')
                : $"{diagram.Name} ({diagram.Identifier.TrimStart('_')})";

            return new string(name
                .Select(character => InvalidInAName.Contains(character) || char.IsControl(character) ? '_' : character)
                .ToArray());
        }

        /// <summary>
        /// The directory a model's own workspace images resolve against: the directory holding the
        /// <c>.aird</c>, or the project directory when that is what was supplied.
        /// </summary>
        /// <param name="aird">the path the caller supplied</param>
        /// <returns>the project directory</returns>
        private static string ProjectDirectoryOf(FileInfo aird)
        {
            return Directory.Exists(aird.FullName) ? aird.FullName : aird.DirectoryName ?? ".";
        }

        /// <summary>
        /// The representations whose name the filter admits, in the order the model holds them.
        /// </summary>
        /// <param name="diagrams">every representation the model built</param>
        /// <param name="options">the options carrying the filter</param>
        /// <returns>the admitted representations</returns>
        private static IReadOnlyList<Diagram> Matching(IReadOnlyList<Diagram> diagrams, DiagramReportOptions options)
        {
            if (string.IsNullOrEmpty(options.NameFilter))
            {
                return diagrams;
            }

            var pattern = "^" + Regex.Escape(options.NameFilter!).Replace("\\*", ".*").Replace("\\?", ".") + "$";

            return diagrams
                .Where(diagram => Regex.IsMatch(diagram.Name ?? string.Empty, pattern, RegexOptions.IgnoreCase, FilterTimeout))
                .ToList();
        }

        /// <summary>
        /// Writes one artifact and reports the file it produced.
        /// </summary>
        /// <param name="output">the output directory</param>
        /// <param name="name">the extensionless file name</param>
        /// <param name="extension">the extension, which the exporters read the format from</param>
        /// <param name="export">the export to run</param>
        /// <returns>the file written</returns>
        private static FileInfo Write(DirectoryInfo output, string name, string extension, Action<string> export)
        {
            var path = Path.Combine(output.FullName, name + extension);

            export(path);

            return new FileInfo(path);
        }

        /// <summary>
        /// Loads the Sirius model and the Capella documents its representations reference.
        /// </summary>
        /// <param name="aird">the path the caller supplied</param>
        /// <returns>the read session</returns>
        private XmiReaderResult Load(FileInfo aird)
        {
            using var readers = XmiReaderBuilder.Create().WithLogger(this.loggerFactory);

            return readers.BuildAirdModelLoader().Load(aird.FullName);
        }

        /// <summary>
        /// Writes the model's table representations to one workbook, a worksheet each. A model with
        /// no table writes nothing.
        /// </summary>
        /// <param name="session">the read session</param>
        /// <param name="reporting">the composed pipeline</param>
        /// <param name="output">the output directory</param>
        /// <returns>the workbook written, or nothing</returns>
        private IReadOnlyList<FileInfo> WriteWorkbook(XmiReaderResult session, ReportingScope reporting, DirectoryInfo output)
        {
            var tables = session.Elements.Values.OfType<SiriusTable.IDTable>().ToList();

            if (tables.Count == 0)
            {
                this.logger.LogDebug("The model carries no table representation, so no workbook was written");

                return Array.Empty<FileInfo>();
            }

            var path = Path.Combine(output.FullName, "tables.xlsx");

            reporting.BuildXlsxTableExporter().Export(
                tables.Select((table, index) => new KeyValuePair<string, SiriusTable.IDTable>(WorksheetName(table, index), table)),
                path);

            return new[] { new FileInfo(path) };
        }

        /// <summary>
        /// The worksheet a table takes: its name, or its position when it has none.
        /// </summary>
        /// <param name="table">the table representation</param>
        /// <param name="index">the table's position in the model</param>
        /// <returns>the worksheet name</returns>
        private static string WorksheetName(SiriusTable.IDTable table, int index)
        {
            return string.IsNullOrEmpty(table.Name) ? $"Table {index + 1}" : table.Name!;
        }
    }
}
