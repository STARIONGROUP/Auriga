// ------------------------------------------------------------------------------------------------
// <copyright file="RenderingBuilder.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;

    using Autofac;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The fluent entry point that composes the rendering services — the <see cref="IDiagramBuilder"/>
    /// and the exporters built alongside it — through the Autofac container owned by a
    /// <see cref="RenderingScope"/>, mirroring <c>XmiReaderBuilder</c>. <see cref="Create"/> opens the
    /// scope, the fluent methods register caller-supplied services on it, and a terminal method
    /// (<see cref="BuildDiagramBuilder"/>, <see cref="BuildTableBuilder"/>,
    /// <see cref="BuildSvgExporter"/>, <see cref="BuildXlsxTableExporter"/>) resolves the requested
    /// service. The scope is disposable; disposing it releases every service built from it.
    /// </summary>
    /// <example>
    /// <code>
    /// using var scope = RenderingBuilder.Create();
    /// var diagrams = scope.BuildDiagramBuilder().BuildAll(result.Elements.Values);
    /// scope.BuildSvgExporter().ExportToFile(diagrams[0], "diagram.svg");
    /// </code>
    /// </example>
    public static class RenderingBuilder
    {
        /// <summary>
        /// Creates a new <see cref="RenderingScope"/> carrying the default registrations, ready to be
        /// configured with the fluent methods and consumed by a terminal <c>Build*</c> method.
        /// </summary>
        /// <returns>the scope</returns>
        public static RenderingScope Create()
        {
            return new RenderingScope();
        }

        /// <summary>
        /// Configures the composed services to log through the supplied <see cref="ILoggerFactory"/>,
        /// replacing the no-op default.
        /// </summary>
        /// <remarks>
        /// Rendering degrades rather than throws, and the supplied factory is where those
        /// degradations surface: at Debug, the workspace images and label icons no registry
        /// resolved, the representations skipped for want of a persisted layout, and the malformed
        /// bendpoints and anchor ids that fell back to view centres; at Trace, each unresolved
        /// image path as the registries see it and each style value that did not parse. Turning on
        /// Debug therefore explains every visual difference between what Capella shows and what
        /// Auriga exported, while a well-formed model stays silent at Information and above.
        /// </remarks>
        /// <param name="scope">the scope to register the logger factory on</param>
        /// <param name="loggerFactory">the logger factory</param>
        /// <returns>the same scope, for chaining</returns>
        /// <exception cref="ArgumentNullException">the scope or the logger factory is null</exception>
        public static RenderingScope WithLogger(this RenderingScope scope, ILoggerFactory loggerFactory)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            scope.ContainerBuilder.RegisterInstance(loggerFactory).As<ILoggerFactory>();
            return scope;
        }

        /// <summary>
        /// Configures the composed services to resolve workspace-image paths through the supplied
        /// <see cref="IIconRegistry"/>, replacing the default <see cref="CapellaIconRegistry"/> — the
        /// override a caller uses to add the project-local artwork of a loaded model, typically through
        /// a <see cref="CompositeIconRegistry"/>.
        /// </summary>
        /// <param name="scope">the scope to register the registry on</param>
        /// <param name="iconRegistry">the icon registry</param>
        /// <returns>the same scope, for chaining</returns>
        /// <exception cref="ArgumentNullException">the scope or the registry is null</exception>
        public static RenderingScope UsingIconRegistry(this RenderingScope scope, IIconRegistry iconRegistry)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            if (iconRegistry == null)
            {
                throw new ArgumentNullException(nameof(iconRegistry));
            }

            scope.ContainerBuilder.RegisterInstance(iconRegistry).As<IIconRegistry>();
            return scope;
        }

        /// <summary>
        /// Configures the composed services to seed their style defaults from the supplied
        /// <see cref="ICapellaDefaultPalette"/>, replacing the default Capella palette.
        /// </summary>
        /// <param name="scope">the scope to register the palette on</param>
        /// <param name="palette">the palette seeding the defaults of every resolved property</param>
        /// <returns>the same scope, for chaining</returns>
        /// <exception cref="ArgumentNullException">the scope or the palette is null</exception>
        public static RenderingScope UsingPalette(this RenderingScope scope, ICapellaDefaultPalette palette)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            if (palette == null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            scope.ContainerBuilder.RegisterInstance(palette).As<ICapellaDefaultPalette>();
            return scope;
        }

        /// <summary>
        /// Configures the composed builders to resolve their styles through the supplied
        /// <see cref="IStyleResolver"/>, replacing the default <see cref="StyleResolver"/>. A resolver
        /// registered here supersedes any palette registered with
        /// <see cref="UsingPalette"/> — the palette seeds the default resolver, which is no longer in
        /// the graph.
        /// </summary>
        /// <param name="scope">the scope to register the resolver on</param>
        /// <param name="styleResolver">the resolver producing each built item's resolved style</param>
        /// <returns>the same scope, for chaining</returns>
        /// <exception cref="ArgumentNullException">the scope or the resolver is null</exception>
        public static RenderingScope UsingStyleResolver(this RenderingScope scope, IStyleResolver styleResolver)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            if (styleResolver == null)
            {
                throw new ArgumentNullException(nameof(styleResolver));
            }

            scope.ContainerBuilder.RegisterInstance(styleResolver).As<IStyleResolver>();
            return scope;
        }

        /// <summary>
        /// Builds a fully-wired <see cref="IDiagramBuilder"/> — the dispatcher over the
        /// per-representation-kind builders, and the entry point of the rendering pipeline.
        /// </summary>
        /// <param name="scope">the configured scope</param>
        /// <returns>the diagram builder</returns>
        /// <exception cref="ArgumentNullException">the scope is null</exception>
        public static IDiagramBuilder BuildDiagramBuilder(this RenderingScope scope)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            return scope.Resolve<IDiagramBuilder>();
        }

        /// <summary>
        /// Builds a fully-wired <see cref="ITableBuilder"/> — the builder of the grid a Sirius table
        /// representation does not persist. <see cref="BuildDiagramBuilder"/> already dispatches
        /// tables to it; this terminal is for a caller that holds a table and wants its grid
        /// directly.
        /// </summary>
        /// <param name="scope">the configured scope</param>
        /// <returns>the table builder</returns>
        /// <exception cref="ArgumentNullException">the scope is null</exception>
        public static ITableBuilder BuildTableBuilder(this RenderingScope scope)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            return scope.Resolve<ITableBuilder>();
        }

        /// <summary>
        /// Builds a fully-wired <see cref="ISvgExporter"/> — the serializer of an intermediate
        /// <see cref="Diagram"/> to an SVG document.
        /// </summary>
        /// <param name="scope">the configured scope</param>
        /// <returns>the SVG exporter</returns>
        /// <exception cref="ArgumentNullException">the scope is null</exception>
        public static ISvgExporter BuildSvgExporter(this RenderingScope scope)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            return scope.Resolve<ISvgExporter>();
        }

        /// <summary>
        /// Builds a fully-wired <see cref="IXlsxTableExporter"/> — the serializer of Sirius table
        /// representations to an Excel workbook.
        /// </summary>
        /// <param name="scope">the configured scope</param>
        /// <returns>the XLSX table exporter</returns>
        /// <exception cref="ArgumentNullException">the scope is null</exception>
        public static IXlsxTableExporter BuildXlsxTableExporter(this RenderingScope scope)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            return scope.Resolve<IXlsxTableExporter>();
        }
    }
}
