// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderBuilder.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    using System;

    using Auriga.Xmi.Core.Cache;
    using Auriga.Xmi.Core.Namespaces;
    using Auriga.Xmi.Core.Readers;
    using Auriga.Xmi.Core.ReferenceResolver;

    using Microsoft.Extensions.Logging;

    using DiagramReaders = Auriga.Xmi.Diagram.AutoGenXmiReaders;
    using ModelReaders = Auriga.Xmi.Model.AutoGenXmiReaders;

    /// <summary>
    /// Fluent factory that wires together the collaborators of an <see cref="IXmiReader"/> — the element
    /// cache, the namespace registries and reader facades of both generated metamodels (the Capella
    /// semantic model and the Sirius/GMF diagram model), and the reference resolver — without requiring a
    /// dependency-injection container. The built reader reads <c>.capella</c> / <c>.melodymodeller</c> /
    /// <c>.capellafragment</c> semantic documents and <c>.aird</c> / <c>.airdfragment</c> diagram
    /// documents alike: the two metamodels' dispatch tables are unioned through a
    /// <see cref="CompositeXmiReaderFacade"/>, which is unambiguous because their package names and
    /// namespace URIs are disjoint. The analogue of uml4net's <c>XmiReaderBuilder</c>.
    /// </summary>
    public sealed class XmiReaderBuilder
    {
        /// <summary>
        /// The logger factory the built reader and its collaborators log through, or <c>null</c> to
        /// disable logging.
        /// </summary>
        private ILoggerFactory? loggerFactory;

        /// <summary>
        /// The settings that tune how the built reader behaves, configured through
        /// <see cref="UsingSettings"/>.
        /// </summary>
        private readonly XmiReaderSettings settings = new XmiReaderSettings();

        /// <summary>
        /// Creates a new <see cref="XmiReaderBuilder"/>.
        /// </summary>
        /// <returns>the builder</returns>
        public static XmiReaderBuilder Create()
        {
            return new XmiReaderBuilder();
        }

        /// <summary>
        /// Configures the reader's settings (e.g. <see cref="IXmiReaderSettings.UseStrictReading"/>).
        /// </summary>
        /// <param name="configure">an action that mutates the settings</param>
        /// <returns>the builder</returns>
        public XmiReaderBuilder UsingSettings(Action<XmiReaderSettings> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            configure(this.settings);
            return this;
        }

        /// <summary>
        /// Configures the reader to log through the supplied <see cref="ILoggerFactory"/>.
        /// </summary>
        /// <param name="factory">the logger factory</param>
        /// <returns>the builder</returns>
        public XmiReaderBuilder WithLogger(ILoggerFactory factory)
        {
            this.loggerFactory = factory;
            return this;
        }

        /// <summary>
        /// Builds a fully-wired <see cref="IXmiReader"/> that reads both the Capella semantic documents
        /// and the Sirius diagram documents. The namespace resolver is seeded with the union of the two
        /// generated namespace registries, and both generated facades share it (and the element cache),
        /// so either can resolve any document's type keys while the composite routes each key to the
        /// facade that owns it.
        /// </summary>
        /// <returns>the reader</returns>
        public IXmiReader Build()
        {
            var cache = new XmiElementCache();

            var namespaceResolver = new NamespaceResolver(ModelReaders.AutoGenNamespaceRegistry.NamespaceToPackage);
            foreach (var pair in DiagramReaders.AutoGenNamespaceRegistry.NamespaceToPackage)
            {
                namespaceResolver.RegisterNamespace(pair.Key, pair.Value);
            }

            var facade = new CompositeXmiReaderFacade(
                new ModelReaders.XmiReaderFacade(cache, namespaceResolver, this.settings, this.loggerFactory),
                new DiagramReaders.XmiReaderFacade(cache, namespaceResolver, this.settings, this.loggerFactory));
            var referenceResolver = new ReferenceResolver(this.loggerFactory);

            return new XmiReader(cache, facade, namespaceResolver, referenceResolver, this.loggerFactory);
        }
    }
}
