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

namespace Auriga.Sirius.Diagram
{
    using System.Collections.Generic;

    /// <summary>
    /// A node.
    /// </summary>
    public partial interface IDNode : Auriga.Sirius.Diagram.IAbstractDNode, Auriga.Sirius.Diagram.IEdgeTarget, Auriga.Sirius.Diagram.IDragAndDropTarget
    {
        /// <summary>
        /// The actual mapping of this node.
        /// </summary>
        Auriga.Sirius.Diagram.Description.INodeMapping ActualMapping { get; set; }

        /// <summary>
        /// The candidates mapping of this node.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.INodeMapping> CandidatesMapping { get; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        int? Height { get; set; }

        /// <summary>
        /// The position of the label :BORDER : The label is around the node, on the border.NODE : the label is
        /// in the node.
        /// </summary>
        Auriga.Sirius.Diagram.LabelPosition? LabelPosition { get; set; }

        /// <summary>
        /// The instance of style that is contained by the mapping. The ownedStyle reference should be a copy of
        /// this style.
        /// </summary>
        Auriga.Sirius.Viewpoint.IStyle OriginalStyle { get; set; }

        /// <summary>
        /// The style of the node.
        /// </summary>
        Auriga.Sirius.Diagram.INodeStyle OwnedStyle { get; set; }

        /// <summary>
        /// true if the node is resizable.
        /// </summary>
        Auriga.Sirius.Diagram.ResizeKind? ResizeKind { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        int? Width { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
