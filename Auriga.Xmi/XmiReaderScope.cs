// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderScope.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    using Autofac;

    using Auriga.Xmi.Core;
    using Auriga.Xmi.Core.Cache;
    using Auriga.Xmi.Core.Namespaces;
    using Auriga.Xmi.Core.Readers;
    using Auriga.Xmi.Core.ReferenceResolver;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using DiagramReaders = Auriga.Xmi.Diagram.AutoGenXmiReaders;
    using ModelReaders = Auriga.Xmi.Model.AutoGenXmiReaders;

    /// <summary>
    /// The default <see cref="IXmiReaderScope"/>: an Autofac container holding the composition of the
    /// XMI reading services — the element cache, the union namespace resolver, the two generated
    /// metamodel facades behind a <see cref="CompositeXmiReaderFacade"/>, the reference resolver, the
    /// <see cref="XmiReader"/> and the model loaders. Created by <see cref="XmiReaderBuilder.Create"/>
    /// and configured through the fluent <see cref="XmiReaderBuilder"/> extension methods; each terminal
    /// <c>Build*</c> call resolves its service from a fresh child lifetime scope, so every built reader
    /// owns an independent stateful graph (cache and facades are per-lifetime-scope). Disposing the
    /// scope disposes the container and every graph built from it.
    /// </summary>
    public sealed class XmiReaderScope : IXmiReaderScope
    {
        /// <summary>
        /// The container built lazily from <see cref="ContainerBuilder"/> on the first
        /// <see cref="BeginScope"/> call; further fluent registrations are rejected by Autofac after
        /// this point.
        /// </summary>
        private IContainer? container;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReaderScope"/> class, declaring the default
        /// registrations. The settings and logger factory registrations are the overridable defaults the
        /// fluent <see cref="XmiReaderBuilder"/> methods replace with caller-supplied instances. Every
        /// stateful collaborator (cache, facades) is registered per lifetime scope, so each terminal
        /// <c>Build*</c> call yields an independent reader graph. Constructors with optional parameters
        /// are registered through explicit lambdas — reflection-based registration would let Autofac
        /// inject an empty collection into <see cref="XmiReader"/>'s optional fragment-extensions
        /// parameter and silently disable fragment following.
        /// </summary>
        internal XmiReaderScope()
        {
            // Overridable defaults (the last registration for a service wins in Autofac).
            this.ContainerBuilder.RegisterType<XmiReaderSettings>().As<IXmiReaderSettings>().InstancePerLifetimeScope();
            this.ContainerBuilder.RegisterInstance(NullLoggerFactory.Instance).As<ILoggerFactory>();

            this.ContainerBuilder.RegisterInstance(this).As<IXmiReaderScope>();

            this.ContainerBuilder.RegisterType<XmiElementCache>().As<IXmiElementCache>().InstancePerLifetimeScope();

            // Shared, per read session, by the reader (which discovers library documents to load) and the
            // reference resolver (which keys the collected tokens against them), so both derive the same
            // canonical name for a platform:/resource library href.
            this.ContainerBuilder
                .Register(context => new WorkspaceProjectRegistry(context.Resolve<ILoggerFactory>()))
                .AsSelf()
                .InstancePerLifetimeScope();

            this.ContainerBuilder
                .Register(context =>
                {
                    var namespaceResolver = new NamespaceResolver(ModelReaders.AutoGenNamespaceRegistry.NamespaceToPackage);
                    foreach (var pair in DiagramReaders.AutoGenNamespaceRegistry.NamespaceToPackage)
                    {
                        namespaceResolver.RegisterNamespace(pair.Key, pair.Value);
                    }

                    return namespaceResolver;
                })
                .As<INamespaceResolver>()
                .InstancePerLifetimeScope();

            this.ContainerBuilder
                .Register(context => new ModelReaders.XmiReaderFacade(
                    context.Resolve<IXmiElementCache>(),
                    context.Resolve<INamespaceResolver>(),
                    context.Resolve<IXmiReaderSettings>(),
                    context.Resolve<ILoggerFactory>()))
                .AsSelf()
                .InstancePerLifetimeScope();

            this.ContainerBuilder
                .Register(context => new DiagramReaders.XmiReaderFacade(
                    context.Resolve<IXmiElementCache>(),
                    context.Resolve<INamespaceResolver>(),
                    context.Resolve<IXmiReaderSettings>(),
                    context.Resolve<ILoggerFactory>()))
                .AsSelf()
                .InstancePerLifetimeScope();

            this.ContainerBuilder
                .Register(context => new CompositeXmiReaderFacade(
                    context.Resolve<ModelReaders.XmiReaderFacade>(),
                    context.Resolve<DiagramReaders.XmiReaderFacade>()))
                .As<IXmiReaderFacade>()
                .InstancePerLifetimeScope();

            this.ContainerBuilder
                .Register(context => new ReferenceResolver(context.Resolve<WorkspaceProjectRegistry>(), context.Resolve<ILoggerFactory>()))
                .As<IReferenceResolver>()
                .InstancePerLifetimeScope();

            this.ContainerBuilder
                .Register(context => new XmiReader(
                    context.Resolve<IXmiElementCache>(),
                    context.Resolve<IXmiReaderFacade>(),
                    context.Resolve<INamespaceResolver>(),
                    context.Resolve<IReferenceResolver>(),
                    context.Resolve<WorkspaceProjectRegistry>(),
                    context.Resolve<ILoggerFactory>()))
                .As<IXmiReader>();

            this.ContainerBuilder
                .Register(context => new CapellaModelLoader(
                    context.Resolve<IXmiReader>(),
                    context.Resolve<ILoggerFactory>()))
                .As<ICapellaModelLoader>();

            this.ContainerBuilder
                .Register(context => new AirdModelLoader(
                    context.Resolve<IXmiReader>(),
                    context.Resolve<ILoggerFactory>()))
                .As<IAirdModelLoader>();
        }

        /// <summary>
        /// Gets the Autofac builder the fluent <see cref="XmiReaderBuilder"/> methods register
        /// caller-supplied instances (settings, logger factory) on, before the container is built.
        /// </summary>
        internal ContainerBuilder ContainerBuilder { get; } = new ContainerBuilder();

        /// <summary>
        /// Builds the container on first use and opens a fresh child lifetime scope. Every terminal
        /// <c>Build*</c> call goes through here, so each built service gets its own per-lifetime-scope
        /// collaborators (cache, facades) and built readers never share mutable state.
        /// </summary>
        /// <returns>a new child lifetime scope to resolve a service from</returns>
        internal ILifetimeScope BeginScope()
        {
            this.container ??= this.ContainerBuilder.Build();

            return this.container.BeginLifetimeScope();
        }

        /// <summary>
        /// Disposes the container — and with it every child lifetime scope and reader graph built from
        /// this scope. Safe to call when no terminal <c>Build*</c> method was ever invoked.
        /// </summary>
        public void Dispose()
        {
            this.container?.Dispose();
        }
    }
}
