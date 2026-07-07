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
    using Auriga.Xmi.AutoGenXmiReaders;
    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Namespaces;
    using Auriga.Xmi.ReferenceResolver;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Fluent factory that wires together the collaborators of an <see cref="IXmiReader"/> — the element
    /// cache, the generated namespace registry and reader facade, and the reference resolver — without
    /// requiring a dependency-injection container. The analogue of uml4net's <c>XmiReaderBuilder</c>.
    /// </summary>
    public sealed class XmiReaderBuilder
    {
        private ILoggerFactory? loggerFactory;

        /// <summary>
        /// Creates a new <see cref="XmiReaderBuilder"/>.
        /// </summary>
        /// <returns>the builder</returns>
        public static XmiReaderBuilder Create()
        {
            return new XmiReaderBuilder();
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
        /// Builds a fully-wired <see cref="IXmiReader"/>.
        /// </summary>
        /// <returns>the reader</returns>
        public IXmiReader Build()
        {
            var cache = new XmiElementCache();
            var namespaceResolver = new NamespaceResolver(AutoGenNamespaceRegistry.NamespaceToPackage);
            var facade = new XmiReaderFacade(cache, namespaceResolver);
            var referenceResolver = new ReferenceResolver.ReferenceResolver(this.loggerFactory);

            return new XmiReader(cache, facade, namespaceResolver, referenceResolver, this.loggerFactory);
        }
    }
}
