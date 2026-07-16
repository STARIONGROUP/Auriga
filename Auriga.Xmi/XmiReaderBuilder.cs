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

    using Auriga.Xmi.Model.AutoGenXmiReaders;
    using Auriga.Xmi.Core.Cache;
    using Auriga.Xmi.Core.Namespaces;
    using Auriga.Xmi.Core.Readers;
    using Auriga.Xmi.Core.ReferenceResolver;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Fluent factory that wires together the collaborators of an <see cref="IXmiReader"/> — the element
    /// cache, the generated namespace registry and reader facade, and the reference resolver — without
    /// requiring a dependency-injection container. The analogue of uml4net's <c>XmiReaderBuilder</c>.
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
        /// Builds a fully-wired <see cref="IXmiReader"/>.
        /// </summary>
        /// <returns>the reader</returns>
        public IXmiReader Build()
        {
            var cache = new XmiElementCache();
            var namespaceResolver = new NamespaceResolver(AutoGenNamespaceRegistry.NamespaceToPackage);
            var facade = new XmiReaderFacade(cache, namespaceResolver, this.settings, this.loggerFactory);
            var referenceResolver = new ReferenceResolver(this.loggerFactory);

            return new XmiReader(cache, facade, namespaceResolver, referenceResolver, this.loggerFactory);
        }
    }
}
