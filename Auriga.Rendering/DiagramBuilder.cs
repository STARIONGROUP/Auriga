// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramBuilder.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using SiriusDiagramModel = Auriga.Diagram.Diagram;
    using SiriusViewpoint = Auriga.Diagram.Viewpoint;

    /// <summary>
    /// The facade over the per-representation-kind builders: dispatches a parsed Sirius
    /// representation to the builder of its kind — <see cref="SequenceDiagramBuilder"/> for a
    /// sequence representation (a Capella scenario), <see cref="NodeDiagramBuilder"/> otherwise —
    /// which builds the intermediate <see cref="Diagram"/> model from the representation's
    /// persisted GMF layout. All diagram-kind-specific knowledge lives in the builders, expressed
    /// as intermediate-model data, so <see cref="SvgExporter"/> and <see cref="StyleResolver"/>
    /// stay kind-agnostic.
    /// </summary>
    public static class DiagramBuilder
    {
        /// <summary>
        /// Builds the intermediate model of the supplied Sirius representation, using the builder
        /// of the representation's kind.
        /// </summary>
        /// <param name="siriusDiagram">the parsed Sirius representation (e.g. a <c>DSemanticDiagram</c>)</param>
        /// <param name="name">
        /// the diagram name, or <c>null</c>; the name lives on the <c>DRepresentationDescriptor</c>
        /// in the <c>DAnalysis</c> rather than on the representation, so the caller supplies it
        /// </param>
        /// <returns>the intermediate diagram model</returns>
        /// <exception cref="ArgumentNullException">the representation is null</exception>
        /// <exception cref="InvalidOperationException">the representation carries no GMF notation diagram</exception>
        public static Diagram Build(SiriusDiagramModel.IDDiagram siriusDiagram, string? name = null)
        {
            return CreateBuilder(siriusDiagram).Build(siriusDiagram, name);
        }

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
        public static IReadOnlyList<Diagram> BuildAll(IEnumerable<Auriga.Core.IAurigaElement> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            var snapshot = elements.ToList();

            var names = new Dictionary<string, string>(StringComparer.Ordinal);
            foreach (var descriptor in snapshot
                .OfType<SiriusViewpoint.IDRepresentationDescriptor>()
                .Where(descriptor => !string.IsNullOrEmpty(descriptor.RepPath) && !string.IsNullOrEmpty(descriptor.Name)))
            {
                names[descriptor.RepPath!.TrimStart('#')] = descriptor.Name!;
            }

            var diagrams = new List<Diagram>();
            foreach (var representation in snapshot.OfType<SiriusDiagramModel.IDDiagram>())
            {
                if (DiagramBuilderBase.FindNotationDiagram(representation) == null)
                {
                    continue;
                }

                var name = representation.Id != null && names.TryGetValue(representation.Id, out var descriptorName)
                    ? descriptorName
                    : null;

                diagrams.Add(Build(representation, name));
            }

            return diagrams;
        }

        /// <summary>
        /// Creates the builder of the representation's kind: a sequence representation gets the
        /// <see cref="SequenceDiagramBuilder"/>, every other kind the <see cref="NodeDiagramBuilder"/>.
        /// </summary>
        /// <param name="siriusDiagram">the parsed Sirius representation, or <c>null</c></param>
        /// <returns>the builder for the representation's kind</returns>
        private static DiagramBuilderBase CreateBuilder(SiriusDiagramModel.IDDiagram? siriusDiagram)
        {
            return siriusDiagram is Auriga.Diagram.Sequence.ISequenceDDiagram
                ? new SequenceDiagramBuilder()
                : new NodeDiagramBuilder();
        }
    }
}
