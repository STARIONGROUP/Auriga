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

namespace Auriga.Sirius.Diagram
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The referenced ViewPoint.
    /// </summary>
    public partial interface IDDiagramElementContainer : Auriga.Sirius.Diagram.IAbstractDNode, Auriga.Sirius.Diagram.IEdgeTarget, Auriga.Sirius.Diagram.IDragAndDropTarget
    {
        /// <summary>
        /// The actual mapping of this node.
        /// </summary>
        Auriga.Sirius.Diagram.Description.IContainerMapping ActualMapping { get; set; }

        /// <summary>
        /// The candidates mapping of this node.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IContainerMapping> CandidatesMapping { get; }

        /// <summary>
        /// Containers owned by this container.
        /// </summary>
        IEnumerable<Auriga.Sirius.Diagram.IDDiagramElementContainer> Containers { get; }

        /// <summary>
        /// elements owned by this container.
        /// </summary>
        IEnumerable<Auriga.Sirius.Diagram.IDDiagramElement> Elements { get; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        int? Height { get; set; }

        /// <summary>
        /// Nodes owned by this container.
        /// </summary>
        IEnumerable<Auriga.Sirius.Diagram.IDNode> Nodes { get; }

        /// <summary>
        /// The instance of style that is contained by the mapping. The ownedStyle reference should be a copy of
        /// this style.
        /// </summary>
        Auriga.Sirius.Viewpoint.IStyle OriginalStyle { get; set; }

        /// <summary>
        /// The style of the container.
        /// </summary>
        Auriga.Sirius.Diagram.IContainerStyle OwnedStyle { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        int? Width { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
