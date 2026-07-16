// ------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterBuilder.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    using Auriga.Xmi.Model.AutoGenXmiWriters;
    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Fluent factory that wires together the collaborators of an <see cref="IXmiWriter"/> — the generated
    /// writer facade and the formatting settings — without requiring a dependency-injection container. The
    /// inverse of <see cref="XmiReaderBuilder"/>.
    /// </summary>
    public sealed class XmiWriterBuilder
    {
        private ILoggerFactory? loggerFactory;

        private IXmiWriterSettings settings = new XmiWriterSettings();

        /// <summary>
        /// Creates a new <see cref="XmiWriterBuilder"/>.
        /// </summary>
        /// <returns>the builder</returns>
        public static XmiWriterBuilder Create()
        {
            return new XmiWriterBuilder();
        }

        /// <summary>
        /// Configures the writer to log through the supplied <see cref="ILoggerFactory"/>.
        /// </summary>
        /// <param name="factory">the logger factory</param>
        /// <returns>the builder</returns>
        public XmiWriterBuilder WithLogger(ILoggerFactory factory)
        {
            this.loggerFactory = factory;
            return this;
        }

        /// <summary>
        /// Configures the writer with the supplied formatting settings.
        /// </summary>
        /// <param name="writerSettings">the settings</param>
        /// <returns>the builder</returns>
        public XmiWriterBuilder WithSettings(IXmiWriterSettings writerSettings)
        {
            this.settings = writerSettings;
            return this;
        }

        /// <summary>
        /// Builds a fully-wired <see cref="IXmiWriter"/>.
        /// </summary>
        /// <returns>the writer</returns>
        public IXmiWriter Build()
        {
            var facade = new XmiElementWriterFacade(this.loggerFactory);

            return new XmiWriter(facade, this.settings, this.loggerFactory);
        }
    }
}
