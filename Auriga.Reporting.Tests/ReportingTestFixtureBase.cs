// ------------------------------------------------------------------------------------------------
// <copyright file="ReportingTestFixtureBase.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Tests
{
    using Auriga.Reporting;
    using Auriga.Reporting.Builders;
    using Auriga.Reporting.Drawing;
    using Auriga.Reporting.Generators;

    using NUnit.Framework;

    /// <summary>
    /// The base of the rendering fixtures: owns one <see cref="ReportingScope"/> for the lifetime of
    /// the fixture and exposes the services resolved from it. A fixture therefore composes its
    /// services the way a consumer does — through the container — instead of constructing the object
    /// graph by hand, so the default registrations are exercised by every test that runs.
    /// </summary>
    /// <remarks>
    /// A fixture that needs a non-default registration (a substituted icon registry, say) builds its
    /// own scope from <see cref="ReportingBuilder.Create"/> rather than deriving from this class.
    /// </remarks>
    public abstract class ReportingTestFixtureBase
    {
        /// <summary>
        /// The scope composing the services under test, disposed with the fixture.
        /// </summary>
        private readonly ReportingScope reportingScope = ReportingBuilder.Create();

        /// <summary>
        /// Gets the diagram builder composed by the fixture's rendering scope.
        /// </summary>
        protected IDiagramBuilder DiagramBuilder => this.reportingScope.BuildDiagramBuilder();

        /// <summary>
        /// Gets the table builder composed by the fixture's rendering scope.
        /// </summary>
        protected ITableBuilder TableBuilder => this.reportingScope.BuildTableBuilder();

        /// <summary>
        /// Gets the SVG exporter composed by the fixture's rendering scope.
        /// </summary>
        protected ISvgExporter SvgExporter => this.reportingScope.BuildSvgExporter();

        /// <summary>
        /// Gets the raster exporter composed by the fixture's rendering scope.
        /// </summary>
        protected IRasterExporter RasterExporter => this.reportingScope.BuildRasterExporter();

        /// <summary>
        /// Gets the XLSX table exporter composed by the fixture's rendering scope.
        /// </summary>
        protected IXlsxTableExporter XlsxTableExporter => this.reportingScope.BuildXlsxTableExporter();

        /// <summary>
        /// Disposes the fixture's rendering scope, and with it every service it composed. NUnit runs
        /// this after the derived fixture's own one-time teardown.
        /// </summary>
        [OneTimeTearDown]
        public void DisposeReportingScope()
        {
            this.reportingScope.Dispose();
        }
    }
}
