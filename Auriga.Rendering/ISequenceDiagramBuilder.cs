// ------------------------------------------------------------------------------------------------
// <copyright file="ISequenceDiagramBuilder.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;

    using SiriusDiagramModel = Auriga.Diagram.Diagram;

    /// <summary>
    /// The service that builds intermediate <see cref="Diagram"/> models from parsed Sirius
    /// <b>sequence</b> representations — Capella scenarios (ES, FS, IS). The default implementation,
    /// <see cref="SequenceDiagramBuilder"/>, adds the layout rules the persisted geometry does not
    /// carry: lifeline centerlines, horizontally flattened messages and combined-fragment frames.
    /// </summary>
    /// <remarks>
    /// This is the kind <see cref="IDiagramBuilder"/> dispatches to for an
    /// <c>ISequenceDDiagram</c>; it is a separate service so a container composes the dispatcher
    /// from substitutable per-kind builders rather than from a fixed graph of concrete ones.
    /// </remarks>
    public interface ISequenceDiagramBuilder
    {
        /// <summary>
        /// Builds the intermediate model of the supplied sequence representation.
        /// </summary>
        /// <param name="siriusDiagram">the parsed Sirius representation (a <c>SequenceDDiagram</c>)</param>
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
