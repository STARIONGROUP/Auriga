// ------------------------------------------------------------------------------------------------
// <copyright file="RenderingScope.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using Autofac;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// The default <see cref="IRenderingScope"/>: an Autofac container holding the composition of the
    /// rendering services — the Capella default palette, the style resolver, the icon registry, the
    /// per-representation-kind builders behind the <see cref="DiagramBuilder"/> dispatcher, and the SVG,
    /// raster and XLSX exporters. Created by <see cref="RenderingBuilder.Create"/> and configured through the
    /// fluent <see cref="RenderingBuilder"/> extension methods; each terminal <c>Build*</c> call resolves
    /// its service from the container. Disposing the scope disposes the container and every service
    /// built from it.
    /// </summary>
    /// <remarks>
    /// Autofac is an implementation detail of this class: <see cref="IRenderingScope"/> declares no
    /// Autofac type and <see cref="ContainerBuilder"/> is internal, so no Autofac type reaches a
    /// consumer of the rendering API.
    /// </remarks>
    public sealed class RenderingScope : IRenderingScope
    {
        /// <summary>
        /// The container built lazily from <see cref="ContainerBuilder"/> on the first
        /// <see cref="Resolve{T}"/> call; further fluent registrations are rejected by Autofac after
        /// this point.
        /// </summary>
        private IContainer? container;

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderingScope"/> class, declaring the default
        /// registrations. The palette, style resolver, icon registry and logger factory registrations
        /// are the overridable defaults the fluent <see cref="RenderingBuilder"/> methods replace with
        /// caller-supplied instances.
        /// </summary>
        /// <remarks>
        /// Every service is a singleton, unlike the per-lifetime-scope registrations of
        /// <c>XmiReaderScope</c>. A reader accumulates per-read-session state (an element cache, the
        /// reader facades) and must therefore be scoped; a rendering service holds only <c>const</c>,
        /// <c>static readonly</c> and injected <c>readonly</c> members — except
        /// <see cref="CapellaIconRegistry"/>, whose only state is a concurrent cache — so they are
        /// stateless or already thread-safe, and sharing them lets the icon registry reuse its
        /// extracted artwork across render sessions instead of re-extracting it for each. A future
        /// rendering service that takes mutable per-render state must opt out of singleton explicitly.
        /// Reflection-based registration is safe for the services registered that way because each
        /// has exactly one constructor and none takes an optional parameter; the icon registry is
        /// registered through a lambda instead, since it is composed rather than constructed.
        /// </remarks>
        internal RenderingScope()
        {
            // Overridable defaults (the last registration for a service wins in Autofac).
            this.ContainerBuilder.RegisterType<CapellaDefaultPalette>().As<ICapellaDefaultPalette>().SingleInstance();
            this.ContainerBuilder.RegisterType<StyleResolver>().As<IStyleResolver>().SingleInstance();
            this.ContainerBuilder.RegisterType<TooltipResolver>().As<ITooltipResolver>().SingleInstance();
            this.ContainerBuilder.RegisterInstance(EmptyProjectImageRegistry.Instance).As<IProjectImageRegistry>();
            this.ContainerBuilder.RegisterInstance(NullLoggerFactory.Instance).As<ILoggerFactory>();

            // The icon registry is the vendored Capella artwork chained with the model's own
            // project images, so RenderingBuilder.UsingProjectImages fills its own slot instead of
            // replacing this one — the two overrides then compose rather than collide. Nothing
            // fills the project-image slot by default, so an unconfigured scope resolves exactly
            // what the vendored registry alone resolves.
            this.ContainerBuilder
                .Register(context => new CompositeIconRegistry(
                    new CapellaIconRegistry(context.Resolve<ILoggerFactory>()),
                    context.Resolve<IProjectImageRegistry>()))
                .As<IIconRegistry>()
                .SingleInstance();

            this.ContainerBuilder.RegisterType<NodeDiagramBuilder>().As<INodeDiagramBuilder>().SingleInstance();
            this.ContainerBuilder.RegisterType<SequenceDiagramBuilder>().As<ISequenceDiagramBuilder>().SingleInstance();
            this.ContainerBuilder.RegisterType<TableBuilder>().As<ITableBuilder>().SingleInstance();
            this.ContainerBuilder.RegisterType<DiagramBuilder>().As<IDiagramBuilder>().SingleInstance();

            this.ContainerBuilder.RegisterType<SvgExporter>().As<ISvgExporter>().SingleInstance();
            this.ContainerBuilder.RegisterType<XlsxTableExporter>().As<IXlsxTableExporter>().SingleInstance();
            this.ContainerBuilder.RegisterType<SkiaRasterExporter>().As<IRasterExporter>().SingleInstance();
        }

        /// <summary>
        /// Gets the Autofac builder the fluent <see cref="RenderingBuilder"/> methods register
        /// caller-supplied instances (palette, style resolver, icon registry, logger factory) on,
        /// before the container is built.
        /// </summary>
        internal ContainerBuilder ContainerBuilder { get; } = new ContainerBuilder();

        /// <summary>
        /// Builds the container on first use and resolves the requested service from it. Every terminal
        /// <c>Build*</c> method goes through here.
        /// </summary>
        /// <remarks>
        /// Resolution goes straight to the container rather than to a child lifetime scope, unlike
        /// <c>XmiReaderScope</c>. Nothing here is registered per lifetime scope, so a child would hand
        /// out the very same singletons while adding a scope the container tracks until it is itself
        /// disposed — cost without benefit.
        /// </remarks>
        /// <typeparam name="T">the service to resolve</typeparam>
        /// <returns>the composed service</returns>
        internal T Resolve<T>()
            where T : notnull
        {
            this.container ??= this.ContainerBuilder.Build();

            return this.container.Resolve<T>();
        }

        /// <summary>
        /// Disposes the container — and with it every service built from this scope. Safe to call when
        /// no terminal <c>Build*</c> method was ever invoked.
        /// </summary>
        public void Dispose()
        {
            this.container?.Dispose();
        }
    }
}
