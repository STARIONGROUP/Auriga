// ------------------------------------------------------------------------------------------------
// <copyright file="RenderingTestFixtureBase.cs" company="Starion Group S.A.">
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
    /// The base of the rendering fixtures: owns one <see cref="RenderingScope"/> for the lifetime of
    /// the fixture and exposes the services resolved from it. A fixture therefore composes its
    /// services the way a consumer does — through the container — instead of constructing the object
    /// graph by hand, so the default registrations are exercised by every test that runs.
    /// </summary>
    /// <remarks>
    /// A fixture that needs a non-default registration (a substituted icon registry, say) builds its
    /// own scope from <see cref="RenderingBuilder.Create"/> rather than deriving from this class.
    /// </remarks>
    public abstract class RenderingTestFixtureBase
    {
        /// <summary>
        /// The scope composing the services under test, disposed with the fixture.
        /// </summary>
        private readonly RenderingScope renderingScope = RenderingBuilder.Create();

        /// <summary>
        /// Gets the diagram builder composed by the fixture's rendering scope.
        /// </summary>
        protected IDiagramBuilder DiagramBuilder => this.renderingScope.BuildDiagramBuilder();

        /// <summary>
        /// Gets the table builder composed by the fixture's rendering scope.
        /// </summary>
        protected ITableBuilder TableBuilder => this.renderingScope.BuildTableBuilder();

        /// <summary>
        /// Gets the SVG exporter composed by the fixture's rendering scope.
        /// </summary>
        protected ISvgExporter SvgExporter => this.renderingScope.BuildSvgExporter();

        /// <summary>
        /// Gets the raster exporter composed by the fixture's rendering scope.
        /// </summary>
        protected IRasterExporter RasterExporter => this.renderingScope.BuildRasterExporter();

        /// <summary>
        /// Gets the XLSX table exporter composed by the fixture's rendering scope.
        /// </summary>
        protected IXlsxTableExporter XlsxTableExporter => this.renderingScope.BuildXlsxTableExporter();

        /// <summary>
        /// Disposes the fixture's rendering scope, and with it every service it composed. NUnit runs
        /// this after the derived fixture's own one-time teardown.
        /// </summary>
        [OneTimeTearDown]
        public void DisposeRenderingScope()
        {
            this.renderingScope.Dispose();
        }
    }
}
