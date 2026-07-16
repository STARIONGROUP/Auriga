// ------------------------------------------------------------------------------------------------
// <copyright file="CapellaProject.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    using Auriga.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Auriga.Xmi.Core.Readers;
    using Auriga.Xmi.Core.ReferenceResolver;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// A convenience wrapper over a loaded Capella object graph that exposes the Arcadia architecture
    /// layers as first-class accessors. It turns the mechanical
    /// <c>project.OwnedModelRoots.OfType&lt;ISystemEngineering&gt;().Single().OwnedArchitectures.OfType&lt;…&gt;()</c>
    /// navigation into <c>project.LogicalArchitecture</c>, and so on for each layer.
    /// </summary>
    /// <remarks>
    /// A Capella model holds at most one architecture of each layer, under the project's
    /// <c>SystemEngineering</c>. Every layer accessor therefore returns that single architecture, or
    /// <c>null</c> when the model does not contain that layer (or has no <c>SystemEngineering</c> at all).
    /// </remarks>
    public sealed class CapellaProject
    {
        /// <summary>
        /// The underlying read result the wrapper exposes.
        /// </summary>
        private readonly XmiReaderResult result;

        /// <summary>
        /// Initializes a new instance of the <see cref="CapellaProject"/> class over a read result.
        /// </summary>
        /// <param name="result">the result of reading the Capella model</param>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="result"/> is <c>null</c></exception>
        public CapellaProject(XmiReaderResult result)
        {
            this.result = result ?? throw new ArgumentNullException(nameof(result));
            this.Project = result.Root as Auriga.Model.Capellamodeller.IProject;
            this.SystemEngineering = this.Project?.OwnedModelRoots
                .OfType<Auriga.Model.Capellamodeller.ISystemEngineering>()
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the typed project root, or <c>null</c> when the loaded model's root is not a
        /// <c>capellamodeller::Project</c>.
        /// </summary>
        public Auriga.Model.Capellamodeller.IProject? Project { get; }

        /// <summary>
        /// Gets the project's <c>SystemEngineering</c> — the container of the architecture layers — or
        /// <c>null</c> when the model has none.
        /// </summary>
        public Auriga.Model.Capellamodeller.ISystemEngineering? SystemEngineering { get; }

        /// <summary>
        /// Gets the operational analysis layer (the Arcadia OA), or <c>null</c> when the model has no
        /// operational analysis.
        /// </summary>
        public Auriga.Model.Oa.IOperationalAnalysis? OperationalAnalysis => this.Layer<Auriga.Model.Oa.IOperationalAnalysis>();

        /// <summary>
        /// Gets the system analysis layer (the Arcadia SA), or <c>null</c> when the model has no system
        /// analysis.
        /// </summary>
        public Auriga.Model.Ctx.ISystemAnalysis? SystemAnalysis => this.Layer<Auriga.Model.Ctx.ISystemAnalysis>();

        /// <summary>
        /// Gets the logical architecture layer (the Arcadia LA), or <c>null</c> when the model has no
        /// logical architecture.
        /// </summary>
        public Auriga.Model.La.ILogicalArchitecture? LogicalArchitecture => this.Layer<Auriga.Model.La.ILogicalArchitecture>();

        /// <summary>
        /// Gets the physical architecture layer (the Arcadia PA), or <c>null</c> when the model has no
        /// physical architecture.
        /// </summary>
        public Auriga.Model.Pa.IPhysicalArchitecture? PhysicalArchitecture => this.Layer<Auriga.Model.Pa.IPhysicalArchitecture>();

        /// <summary>
        /// Gets the end-product breakdown structure layer (the Arcadia EPBS), or <c>null</c> when the model
        /// has no EPBS.
        /// </summary>
        public Auriga.Model.Epbs.IEPBSArchitecture? Epbs => this.Layer<Auriga.Model.Epbs.IEPBSArchitecture>();

        /// <summary>
        /// Gets every element read from the model, keyed by its <c>xmi:id</c>.
        /// </summary>
        public IReadOnlyDictionary<string, IAurigaElement> Elements => this.result.Elements;

        /// <summary>
        /// Gets the references that could not be resolved because their target was not found in any loaded
        /// file. Empty when every reference resolved.
        /// </summary>
        public IReadOnlyList<UnresolvedReference> UnresolvedReferences => this.result.UnresolvedReferences;

        /// <summary>
        /// Loads the Capella project at <paramref name="path"/> (a <c>.capella</c> / <c>.melodymodeller</c>
        /// file or the project directory) and wraps it. The one-call native entry point:
        /// <c>CapellaProject.Load(path).LogicalArchitecture</c>.
        /// </summary>
        /// <param name="path">the semantic model file path, or the project directory path</param>
        /// <param name="loggerFactory">the logger factory the loader and reader log through, or <c>null</c></param>
        /// <returns>the wrapped, fully resolved project</returns>
        public static CapellaProject Load(string path, ILoggerFactory? loggerFactory = null)
        {
            using var scope = XmiReaderBuilder.Create();
            if (loggerFactory != null)
            {
                scope.WithLogger(loggerFactory);
            }

            return new CapellaProject(scope.BuildCapellaModelLoader().Load(path));
        }

        /// <summary>
        /// Returns the single architecture of the requested layer type held by the
        /// <see cref="SystemEngineering"/>, or <c>null</c> when the layer (or the
        /// <see cref="SystemEngineering"/>) is absent.
        /// </summary>
        /// <typeparam name="T">the layer's architecture interface type</typeparam>
        /// <returns>the layer's architecture, or <c>null</c></returns>
        private T? Layer<T>()
            where T : class
        {
            return this.SystemEngineering?.OwnedArchitectures.OfType<T>().FirstOrDefault();
        }
    }
}
