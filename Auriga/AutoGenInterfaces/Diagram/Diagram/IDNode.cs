// ------------------------------------------------------------------------------------------------
// <copyright file="IDNode.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// A node.
    /// </summary>
    public partial interface IDNode : Auriga.Diagram.Diagram.IAbstractDNode, Auriga.Diagram.Diagram.IEdgeTarget, Auriga.Diagram.Diagram.IDragAndDropTarget
    {
        /// <summary>
        /// The actual mapping of this node.
        /// </summary>
        Auriga.Diagram.Diagram.Description.INodeMapping ActualMapping { get; set; }

        /// <summary>
        /// The candidates mapping of this node.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.INodeMapping> CandidatesMapping { get; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        int? Height { get; set; }

        /// <summary>
        /// The position of the label :
        /// BORDER : The label is around the node, on the border.
        /// NODE : the label is in the node.
        /// </summary>
        Auriga.Diagram.Diagram.LabelPosition? LabelPosition { get; set; }

        /// <summary>
        /// The instance of style that is contained by the mapping. The ownedStyle reference should be a copy of this style.
        /// </summary>
        Auriga.Diagram.Viewpoint.IStyle OriginalStyle { get; set; }

        /// <summary>
        /// The style of the node.
        /// </summary>
        Auriga.Diagram.Diagram.INodeStyle OwnedStyle { get; set; }

        /// <summary>
        /// <code>true</code> if the node is resizable.
        /// </summary>
        Auriga.Diagram.Diagram.ResizeKind? ResizeKind { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        int? Width { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
