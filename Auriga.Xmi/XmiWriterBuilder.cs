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
    using System;

    using Autofac;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The fluent entry point that composes an <see cref="IXmiWriter"/> through the Autofac container
    /// owned by an <see cref="XmiWriterScope"/> — the writer counterpart of
    /// <see cref="XmiReaderBuilder"/>. <see cref="Create"/> opens the scope, the fluent methods register
    /// caller-supplied services on it, and <see cref="Build"/> resolves the writer from a fresh child
    /// lifetime scope. The built writer serializes both the Capella semantic elements and the Sirius
    /// diagram elements, routing each element to the metamodel facade that owns its runtime type. The
    /// scope is disposable; disposing it releases every graph built from it.
    /// </summary>
    public static class XmiWriterBuilder
    {
        /// <summary>
        /// Creates a new <see cref="XmiWriterScope"/> carrying the default registrations, ready to be
        /// configured with the fluent methods and consumed by <see cref="Build"/>.
        /// </summary>
        /// <returns>the scope</returns>
        public static XmiWriterScope Create()
        {
            return new XmiWriterScope();
        }

        /// <summary>
        /// Configures the composed services to log through the supplied <see cref="ILoggerFactory"/>,
        /// replacing the no-op default.
        /// </summary>
        /// <param name="scope">the scope to register the logger factory on</param>
        /// <param name="loggerFactory">the logger factory</param>
        /// <returns>the same scope, for chaining</returns>
        public static XmiWriterScope WithLogger(this XmiWriterScope scope, ILoggerFactory loggerFactory)
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
        /// Configures the writer with the supplied formatting settings, replacing the defaults.
        /// </summary>
        /// <param name="scope">the scope to register the settings on</param>
        /// <param name="writerSettings">the settings</param>
        /// <returns>the same scope, for chaining</returns>
        public static XmiWriterScope WithSettings(this XmiWriterScope scope, IXmiWriterSettings writerSettings)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            if (writerSettings == null)
            {
                throw new ArgumentNullException(nameof(writerSettings));
            }

            scope.ContainerBuilder.RegisterInstance(writerSettings).As<IXmiWriterSettings>();
            return scope;
        }

        /// <summary>
        /// Builds a fully-wired <see cref="IXmiWriter"/> from a fresh child lifetime scope of the
        /// container.
        /// </summary>
        /// <param name="scope">the configured scope</param>
        /// <returns>the writer</returns>
        public static IXmiWriter Build(this XmiWriterScope scope)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            return scope.BeginScope().Resolve<IXmiWriter>();
        }
    }
}
