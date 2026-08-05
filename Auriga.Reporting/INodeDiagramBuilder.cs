// ------------------------------------------------------------------------------------------------
// <copyright file="INodeDiagramBuilder.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting
{
    using System;

    using SiriusDiagramModel = Auriga.Diagram.Diagram;

    /// <summary>
    /// The service that builds intermediate <see cref="Diagram"/> models from parsed Sirius
    /// <b>node-and-edge</b> representations — Capella's architecture and data-flow blank diagrams
    /// (LAB, PAB, OAB, SAB, xDFB, …) and any other kind without layout rules of its own. The default
    /// implementation, <see cref="NodeDiagramBuilder"/>, consumes the persisted GMF geometry as the
    /// complete layout.
    /// </summary>
    /// <remarks>
    /// This is the kind <see cref="IDiagramBuilder"/> dispatches to when no more specific builder
    /// applies; it is a separate service so a container composes the dispatcher from substitutable
    /// per-kind builders rather than from a fixed graph of concrete ones.
    /// </remarks>
    public interface INodeDiagramBuilder
    {
        /// <summary>
        /// Builds the intermediate model of the supplied node-and-edge representation.
        /// </summary>
        /// <param name="siriusDiagram">the parsed Sirius representation (e.g. a <c>DSemanticDiagram</c>)</param>
        /// <param name="name">
        /// the diagram name, or <c>null</c>; the name lives on the <c>DRepresentationDescriptor</c>
        /// in the <c>DAnalysis</c> rather than on the representation, so the caller supplies it
        /// </param>
        /// <returns>the intermediate diagram model</returns>
        /// <exception cref="ArgumentNullException">the representation is null</exception>
        /// <exception cref="InvalidOperationException">the representation carries no GMF notation diagram</exception>
        Diagram Build(SiriusDiagramModel.IDDiagram siriusDiagram, string? name = null);
    }
}
