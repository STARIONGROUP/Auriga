// ------------------------------------------------------------------------------------------------
// <copyright file="IDiagramElementMapping.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable disable

namespace Auriga.Sirius.Diagram.Description
{
    /// <summary>
    /// Represent the mapping of a ViewPointElement.
    /// </summary>
    public partial interface IDiagramElementMapping : Auriga.Sirius.Viewpoint.Description.IRepresentationElementMapping, Auriga.Sirius.Viewpoint.Description.IPasteTargetDescription
    {
        /// <summary>
        /// true if the init/refresh operations should create elements for this mapping.
        /// </summary>
        bool CreateElements { get; set; }

        /// <summary>
        /// The tool that describes how to delete this element.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Tool.IDeleteElementDescription DeletionDescription { get; set; }

        /// <summary>
        /// Gets or sets the double click description.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Tool.IDoubleClickDescription DoubleClickDescription { get; set; }

        /// <summary>
        /// The tool that describes what to do when the user edits the label of the elements.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Tool.IDirectEditLabel LabelDirectEdit { get; set; }

        /// <summary>
        /// An expression guarding the effect if evaluated to false.
        /// </summary>
        string PreconditionExpression { get; set; }

        /// <summary>
        /// In the default case, candidates of a mapping are all EObjet owned by the semantic element of the view container. The semanticCandidatesExpression is an expression that returns the list of EObject that are candidates of the mapping instead of the candidates of the default case. The context of the expression is the semantic element of the view container.
        /// </summary>
        string SemanticCandidatesExpression { get; set; }

        /// <summary>
        /// The elements that are represented by this connection.
        /// </summary>
        string SemanticElements { get; set; }

        /// <summary>
        /// Set to true to force the synchronization of the elements of this mapping when the current diagram is in an unsynchronized mode.
        /// This option is used only if createElements is true and the diagram which contain the elements of this mapping is unsynchronized.
        /// </summary>
        bool? SynchronizationLock { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
