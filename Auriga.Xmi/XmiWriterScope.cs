// ------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterScope.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    using Autofac;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using DiagramWriters = Auriga.Xmi.Diagram.AutoGenXmiWriters;
    using ModelWriters = Auriga.Xmi.Model.AutoGenXmiWriters;

    /// <summary>
    /// The default <see cref="IXmiWriterScope"/>: an Autofac container holding the composition of the
    /// XMI writing services — the two generated metamodel writer facades behind a
    /// <see cref="CompositeXmiElementWriterFacade"/>, the formatting settings and the
    /// <see cref="XmiWriter"/>. Created by <see cref="XmiWriterBuilder.Create"/> and configured through
    /// the fluent <see cref="XmiWriterBuilder"/> extension methods; <see cref="XmiWriterBuilder.Build"/>
    /// resolves the writer from a fresh child lifetime scope. Disposing the scope disposes the container
    /// and every graph built from it. The writer counterpart of <see cref="XmiReaderScope"/> — uml4net,
    /// whose pattern this follows, has no writer side.
    /// </summary>
    public sealed class XmiWriterScope : IXmiWriterScope
    {
        /// <summary>
        /// The container built lazily from <see cref="ContainerBuilder"/> on the first
        /// <see cref="BeginScope"/> call; further fluent registrations are rejected by Autofac after
        /// this point.
        /// </summary>
        private IContainer? container;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWriterScope"/> class, declaring the default
        /// registrations. The settings and logger factory registrations are the overridable defaults the
        /// fluent <see cref="XmiWriterBuilder"/> methods replace with caller-supplied instances.
        /// Constructors with optional parameters are registered through explicit lambdas so Autofac's
        /// constructor selection never surprises.
        /// </summary>
        internal XmiWriterScope()
        {
            // Overridable defaults (the last registration for a service wins in Autofac).
            this.ContainerBuilder.RegisterType<XmiWriterSettings>().As<IXmiWriterSettings>().InstancePerLifetimeScope();
            this.ContainerBuilder.RegisterInstance(NullLoggerFactory.Instance).As<ILoggerFactory>();

            this.ContainerBuilder.RegisterInstance(this).As<IXmiWriterScope>();

            this.ContainerBuilder
                .Register(context => new ModelWriters.XmiElementWriterFacade(context.Resolve<ILoggerFactory>()))
                .AsSelf()
                .InstancePerLifetimeScope();

            this.ContainerBuilder
                .Register(context => new DiagramWriters.XmiElementWriterFacade(context.Resolve<ILoggerFactory>()))
                .AsSelf()
                .InstancePerLifetimeScope();

            this.ContainerBuilder
                .Register(context => new CompositeXmiElementWriterFacade(
                    context.Resolve<ModelWriters.XmiElementWriterFacade>(),
                    context.Resolve<DiagramWriters.XmiElementWriterFacade>()))
                .As<IXmiElementWriterFacade>()
                .InstancePerLifetimeScope();

            this.ContainerBuilder
                .Register(context => new XmiWriter(
                    context.Resolve<IXmiElementWriterFacade>(),
                    context.Resolve<IXmiWriterSettings>(),
                    context.Resolve<ILoggerFactory>()))
                .As<IXmiWriter>();
        }

        /// <summary>
        /// Gets the Autofac builder the fluent <see cref="XmiWriterBuilder"/> methods register
        /// caller-supplied instances (settings, logger factory) on, before the container is built.
        /// </summary>
        internal ContainerBuilder ContainerBuilder { get; } = new ContainerBuilder();

        /// <summary>
        /// Builds the container on first use and opens a fresh child lifetime scope, so each built
        /// writer gets its own collaborators.
        /// </summary>
        /// <returns>a new child lifetime scope to resolve a service from</returns>
        internal ILifetimeScope BeginScope()
        {
            this.container ??= this.ContainerBuilder.Build();

            return this.container.BeginLifetimeScope();
        }

        /// <summary>
        /// Disposes the container — and with it every child lifetime scope and writer graph built from
        /// this scope. Safe to call when no <c>Build</c> was ever invoked.
        /// </summary>
        public void Dispose()
        {
            this.container?.Dispose();
        }
    }
}
