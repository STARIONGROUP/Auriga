// ------------------------------------------------------------------------------------------------
// <copyright file="IDiagramBuilder.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;
    using System.Collections.Generic;

    using SiriusDiagramModel = Auriga.Diagram.Diagram;

    /// <summary>
    /// The service that builds intermediate <see cref="Diagram"/> models from parsed Sirius
    /// representations — the injectable entry point of the rendering pipeline. The default
    /// implementation, <see cref="DiagramBuilder"/>, dispatches each representation to the builder
    /// of its kind; register it (and the per-kind builders) in the application's container, or
    /// construct it directly.
    /// </summary>
    public interface IDiagramBuilder
    {
        /// <summary>
        /// Builds the intermediate model of the supplied Sirius representation.
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

        /// <summary>
        /// Builds the intermediate model of every representation in a parsed <c>.aird</c> session
        /// that carries a persisted GMF layout, naming each diagram from its
        /// <c>DRepresentationDescriptor</c> — the descriptor in the <c>DAnalysis</c> owns the
        /// human-readable name (<c>DRepresentation</c> itself does not serialize one) and points at
        /// its representation via <c>repPath</c>. A representation without a notation diagram or a
        /// descriptor without a resolvable representation is skipped, not an error.
        /// </summary>
        /// <param name="elements">
        /// the elements of the parsed session (e.g. the loader result's element index values),
        /// providing both the representations and their descriptors
        /// </param>
        /// <returns>the intermediate models, in element order</returns>
        /// <exception cref="ArgumentNullException">the element collection is null</exception>
        IReadOnlyList<Diagram> BuildAll(IEnumerable<Auriga.Core.IAurigaElement> elements);
    }
}
