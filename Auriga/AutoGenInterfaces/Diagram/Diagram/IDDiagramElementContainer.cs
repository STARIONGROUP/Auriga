// ------------------------------------------------------------------------------------------------
// <copyright file="IDDiagramElementContainer.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The referenced ViewPoint.
    /// </summary>
    public partial interface IDDiagramElementContainer : Auriga.Diagram.Diagram.IAbstractDNode, Auriga.Diagram.Diagram.IEdgeTarget, Auriga.Diagram.Diagram.IDragAndDropTarget
    {
        /// <summary>
        /// The actual mapping of this node.
        /// </summary>
        Auriga.Diagram.Diagram.Description.IContainerMapping ActualMapping { get; set; }

        /// <summary>
        /// The candidates mapping of this node.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.IContainerMapping> CandidatesMapping { get; }

        /// <summary>
        /// Containers owned by this container.
        /// </summary>
        IEnumerable<Auriga.Diagram.Diagram.IDDiagramElementContainer> Containers { get; }

        /// <summary>
        /// elements owned by this container.
        /// </summary>
        IEnumerable<Auriga.Diagram.Diagram.IDDiagramElement> Elements { get; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        int? Height { get; set; }

        /// <summary>
        /// Nodes owned by this container.
        /// </summary>
        IEnumerable<Auriga.Diagram.Diagram.IDNode> Nodes { get; }

        /// <summary>
        /// The instance of style that is contained by the mapping. The ownedStyle reference should be a copy of this style.
        /// </summary>
        Auriga.Diagram.Viewpoint.IStyle OriginalStyle { get; set; }

        /// <summary>
        /// The style of the container.
        /// </summary>
        Auriga.Diagram.Diagram.IContainerStyle OwnedStyle { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        int? Width { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
