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

    using Autofac;

    using Auriga.Xmi.Core.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The fluent entry point that composes an <see cref="IXmiReader"/> — and the model loaders built on
    /// it — through the Autofac container owned by an <see cref="XmiReaderScope"/>, following uml4net's
    /// <c>XmiReaderBuilder</c>. <see cref="Create"/> opens the scope, the fluent methods register
    /// caller-supplied services on it, and a terminal method (<see cref="Build"/>,
    /// <see cref="BuildCapellaModelLoader"/>, <see cref="BuildAirdModelLoader"/>) resolves the requested
    /// service from a fresh child lifetime scope, so every built reader owns an independent stateful
    /// graph. The built reader reads <c>.capella</c> / <c>.melodymodeller</c> / <c>.capellafragment</c>
    /// semantic documents and <c>.aird</c> / <c>.airdfragment</c> diagram documents alike: the two
    /// metamodels' dispatch tables are unioned through a <see cref="CompositeXmiReaderFacade"/>. The
    /// scope is disposable; disposing it releases every graph built from it.
    /// </summary>
    public static class XmiReaderBuilder
    {
        /// <summary>
        /// Creates a new <see cref="XmiReaderScope"/> carrying the default registrations, ready to be
        /// configured with the fluent methods and consumed by a terminal <c>Build*</c> method.
        /// </summary>
        /// <returns>the scope</returns>
        public static XmiReaderScope Create()
        {
            return new XmiReaderScope();
        }

        /// <summary>
        /// Configures the reader's settings (e.g. <see cref="IXmiReaderSettings.UseStrictReading"/>):
        /// the configured instance is registered on the scope, replacing the default settings.
        /// </summary>
        /// <param name="scope">the scope to register the settings on</param>
        /// <param name="configure">an action that mutates the settings</param>
        /// <returns>the same scope, for chaining</returns>
        public static XmiReaderScope UsingSettings(this XmiReaderScope scope, Action<XmiReaderSettings> configure)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            var settings = new XmiReaderSettings();
            configure(settings);

            scope.ContainerBuilder.RegisterInstance(settings).As<IXmiReaderSettings>();
            return scope;
        }

        /// <summary>
        /// Configures the composed services to log through the supplied <see cref="ILoggerFactory"/>,
        /// replacing the no-op default.
        /// </summary>
        /// <param name="scope">the scope to register the logger factory on</param>
        /// <param name="loggerFactory">the logger factory</param>
        /// <returns>the same scope, for chaining</returns>
        public static XmiReaderScope WithLogger(this XmiReaderScope scope, ILoggerFactory loggerFactory)
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
        /// Builds a fully-wired <see cref="IXmiReader"/> from a fresh child lifetime scope of the
        /// container.
        /// </summary>
        /// <param name="scope">the configured scope</param>
        /// <returns>the reader</returns>
        public static IXmiReader Build(this XmiReaderScope scope)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            return scope.BeginScope().Resolve<IXmiReader>();
        }

        /// <summary>
        /// Builds a fully-wired <see cref="ICapellaModelLoader"/> — the project-level entry point for
        /// <c>.capella</c> / <c>.melodymodeller</c> files and project directories — from a fresh child
        /// lifetime scope of the container.
        /// </summary>
        /// <param name="scope">the configured scope</param>
        /// <returns>the loader</returns>
        public static ICapellaModelLoader BuildCapellaModelLoader(this XmiReaderScope scope)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            return scope.BeginScope().Resolve<ICapellaModelLoader>();
        }

        /// <summary>
        /// Builds a fully-wired <see cref="IAirdModelLoader"/> — the project-level entry point for
        /// Sirius <c>.aird</c> files and project directories — from a fresh child lifetime scope of the
        /// container.
        /// </summary>
        /// <param name="scope">the configured scope</param>
        /// <returns>the loader</returns>
        public static IAirdModelLoader BuildAirdModelLoader(this XmiReaderScope scope)
        {
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            return scope.BeginScope().Resolve<IAirdModelLoader>();
        }
    }
}
