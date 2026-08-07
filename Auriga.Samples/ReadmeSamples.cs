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
        /// Renders the diagrams of a Sirius session to SVG and PNG, and exports its tables to Excel.
        /// </summary>
        public static void RenderAndExportDiagrams()
        {
            using var reporting = ReportingBuilder.Create();
            using var reader = XmiReaderBuilder.Create();
            var session = reader.BuildAirdModelLoader().Load("In-Flight Entertainment System/In-Flight Entertainment System.aird");

            var svgExporter = reporting.BuildSvgExporter();
            var rasterExporter = reporting.BuildRasterExporter();

            foreach (var diagram in reporting.BuildDiagramBuilder().BuildAll(session.Elements.Values))
            {
                svgExporter.ExportToFile(diagram, $"out/{diagram.Name}.svg");
                rasterExporter.ExportToFile(diagram, $"out/{diagram.Name}.png", new RasterOptions { Scale = 2 });
            }

            // Tables export to Excel the same way, one worksheet per table.
            var xlsxExporter = reporting.BuildXlsxTableExporter();
            foreach (var table in session.Elements.Values.OfType<Auriga.Diagram.Table.IDTable>())
            {
                xlsxExporter.Export(table, $"out/{table.Uid}.xlsx");
            }
        }
    }
}
