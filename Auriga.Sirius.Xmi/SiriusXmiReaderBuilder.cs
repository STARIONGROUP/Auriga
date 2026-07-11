// ------------------------------------------------------------------------------------------------
// <copyright file="SiriusXmiReaderBuilder.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi
{
    using System;

    using Auriga.Sirius.Xmi.AutoGenXmiReaders;
    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Namespaces;
    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Fluent factory that wires together the collaborators of an <see cref="IXmiReader"/> for the Sirius /
    /// GMF metamodels — the element cache, the generated Sirius namespace registry and reader facade, and
    /// the reference resolver. It is the <c>.aird</c> analogue of Capella's <c>XmiReaderBuilder</c>:
    /// the same metamodel-agnostic <see cref="XmiReader"/> is used, only the facade and namespace registry
    /// differ. The reader's <c>xmi:XMI</c> multi-root handling reads every top-level representation of an
    /// <c>.aird</c> into one shared graph.
    /// </summary>
    public sealed class SiriusXmiReaderBuilder
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
        /// Creates a new <see cref="SiriusXmiReaderBuilder"/>.
        /// </summary>
        /// <returns>the builder</returns>
        public static SiriusXmiReaderBuilder Create()
        {
            return new SiriusXmiReaderBuilder();
        }

        /// <summary>
        /// Configures the reader's settings (e.g. <see cref="IXmiReaderSettings.UseStrictReading"/>).
        /// </summary>
        /// <param name="configure">an action that mutates the settings</param>
        /// <returns>the builder</returns>
        public SiriusXmiReaderBuilder UsingSettings(Action<XmiReaderSettings> configure)
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
        public SiriusXmiReaderBuilder WithLogger(ILoggerFactory factory)
        {
            this.loggerFactory = factory;
            return this;
        }

        /// <summary>
        /// Builds a fully-wired <see cref="IXmiReader"/> that reads Sirius <c>.aird</c> /
        /// <c>.airdfragment</c> documents into the <c>Auriga.Sirius</c> object model.
        /// </summary>
        /// <returns>the reader</returns>
        public IXmiReader Build()
        {
            var cache = new XmiElementCache();
            var namespaceResolver = new NamespaceResolver(AutoGenNamespaceRegistry.NamespaceToPackage);
            var facade = new XmiReaderFacade(cache, namespaceResolver, this.settings, this.loggerFactory);
            var referenceResolver = new Auriga.Xmi.ReferenceResolver.ReferenceResolver(this.loggerFactory);

            return new XmiReader(cache, facade, namespaceResolver, referenceResolver, this.loggerFactory);
        }
    }
}
