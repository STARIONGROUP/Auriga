// ------------------------------------------------------------------------------------------------
// <copyright file="ReadmeSamples.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Samples
{
    using System.Linq;

    using Auriga.Reporting.Drawing;
    using Auriga.Reporting.Model;

    using Auriga.Extensions;
    using Auriga.Reporting;
    using Auriga.Xmi;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The code samples of the repository README, compiled. None of these methods is executed — the
    /// point is that a signature change which would invalidate the documentation breaks the build.
    /// The bodies are kept identical to the fenced blocks in <c>README.md</c>, which
    /// <c>ReadmeSampleTestFixture</c> asserts; edit the two together.
    /// </summary>
    public static class ReadmeSamples
    {
        /// <summary>
        /// Loads a project, navigates the Arcadia layers, queries it, and writes it back.
        /// </summary>
        public static void LoadNavigateQueryAndWrite()
        {
            // 1) Load a project — pass the .capella / .melodymodeller file or the project directory.
            //    Referenced .capellafragment files are discovered and resolved into one object graph.
            var project = CapellaProject.Load("In-Flight Entertainment System/In-Flight Entertainment System.capella");

            // 2) Navigate the Arcadia layers as first-class properties (null when a layer is absent).
            var logical = project.LogicalArchitecture;
            var physical = project.PhysicalArchitecture;

            // 3) Query with LINQ and the Auriga.Extensions methods.
            foreach (var component in logical!.QueryAllComponents())
            {
                foreach (var function in component.QueryAllocatedFunctions())
                {
                    // function.IsAllocatedTo(component) == true
                }
            }

            // Any element can walk its own subtree; combine with LINQ for ad-hoc queries.
            var exchanges = project.Project!
                .QueryAllContainedElements()
                .OfType<Auriga.Model.Fa.IFunctionalExchange>();

            // 4) Write the (possibly modified) model back to disk — the fragment layout is preserved.
            var writer = XmiWriterBuilder.Create().Build();
            writer.Write(project.Project!, "out/In-Flight Entertainment System.capella");
        }

        /// <summary>
        /// Renders the diagrams of a Sirius session to SVG, serving the model's own artwork and
        /// reporting what the renderer had to fall back on.
        /// </summary>
        /// <param name="loggerFactory">the caller's logger factory</param>
        public static void RenderDiagramsToSvg(ILoggerFactory loggerFactory)
        {
            // The rendering services compose the same way the readers do: a disposable scope with
            // fluent overrides for the parts you want to replace. UsingProjectImages serves the
            // artwork the model carries itself, chained onto the vendored Capella icons; your own
            // logger factory reports what the renderer degraded — an image no registry resolved, a
            // representation with no persisted layout, geometry that did not parse — at Debug.
            using var reporting = ReportingBuilder.Create()
                .UsingProjectImages("In-Flight Entertainment System")
                .WithLogger(loggerFactory);

            using var reader = XmiReaderBuilder.Create();
            var session = reader.BuildAirdModelLoader().Load("In-Flight Entertainment System/In-Flight Entertainment System.aird");

            var svgExporter = reporting.BuildSvgExporter();

            foreach (var diagram in reporting.BuildDiagramBuilder().BuildAll(session.Elements.Values))
            {
                svgExporter.ExportToFile(diagram, $"out/{diagram.Name}.svg");
            }
        }

        /// <summary>
        /// Rasterizes the diagrams of a Sirius session to PNG, for the consumers that cannot take
        /// a vector document.
        /// </summary>
        public static void RasterizeDiagramsToPng()
        {
            using var reporting = ReportingBuilder.Create();
            using var reader = XmiReaderBuilder.Create();

            var session = reader.BuildAirdModelLoader().Load("In-Flight Entertainment System/In-Flight Entertainment System.aird");

            // The raster exporter draws the very SVG the SVG exporter produces, so the bitmap
            // carries the same palette, styles and artwork. The format comes from the extension.
            var rasterExporter = reporting.BuildRasterExporter();

            foreach (var diagram in reporting.BuildDiagramBuilder().BuildAll(session.Elements.Values))
            {
                // Twice the persisted size, on a white background instead of PNG's transparency.
                rasterExporter.ExportToFile(
                    diagram,
                    $"out/{diagram.Name}.png",
                    new RasterOptions { Scale = 2, Background = new Color(255, 255, 255) });

                // Or hand the bytes to whatever wanted the picture, at print resolution.
                var jpeg = rasterExporter.Export(diagram, RasterFormat.Jpeg, RasterOptions.FromDpi(300));
            }
        }

        /// <summary>
        /// Exports the table representations of a Sirius session to Excel.
        /// </summary>
        public static void ExportTablesToExcel()
        {
            using var reporting = ReportingBuilder.Create();
            using var reader = XmiReaderBuilder.Create();

            var session = reader.BuildAirdModelLoader().Load("In-Flight Entertainment System/In-Flight Entertainment System.aird");
            var tables = session.Elements.Values.OfType<Auriga.Diagram.Table.IDTable>().ToList();

            var xlsxExporter = reporting.BuildXlsxTableExporter();

            // One workbook per table, or pass a name-to-table sequence to get one workbook of many sheets.
            foreach (var table in tables)
            {
                xlsxExporter.Export(table, $"out/{table.Uid}.xlsx");
            }

            // The same table also lays out as a grid of boxes, which the SVG exporter renders.
            var grid = reporting.BuildTableBuilder().Build(tables.First());
        }
    }
}
