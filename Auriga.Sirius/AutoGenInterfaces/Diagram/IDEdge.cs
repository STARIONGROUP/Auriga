// ------------------------------------------------------------------------------------------------
// <copyright file="IDEdge.cs" company="Starion Group S.A.">
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
    /// A view edge. It is a connection between two EdgeTarget.
    /// </summary>
    public partial interface IDEdge : Auriga.Sirius.Diagram.IDDiagramElement, Auriga.Sirius.Diagram.IEdgeTarget
    {
        /// <summary>
        /// The mapping that has created the view edge.
        /// </summary>
        Auriga.Sirius.Diagram.Description.IIEdgeMapping ActualMapping { get; set; }

        /// <summary>
        /// Gets the arrange constraints.
        /// </summary>
        List<Auriga.Sirius.Diagram.ArrangeConstraint> ArrangeConstraints { get; }

        /// <summary>
        /// The name of the representation.
        /// </summary>
        string BeginLabel { get; set; }

        /// <summary>
        /// The name of the representation.
        /// </summary>
        string EndLabel { get; set; }

        /// <summary>
        /// <code>true</code> if the view edge is folded.
        /// </summary>
        bool? IsFold { get; set; }

        /// <summary>
        /// <code>true</code> if the edge is an edge that is displayed only to have the plus image to decollapse a branch.
        /// </summary>
        bool? IsMockEdge { get; set; }

        /// <summary>
        /// The instance of style that is contained by the mapping. The ownedStyle reference should be a copy of this style.
        /// </summary>
        Auriga.Sirius.Viewpoint.IStyle OriginalStyle { get; set; }

        /// <summary>
        /// The style of the connection.
        /// </summary>
        Auriga.Sirius.Diagram.IEdgeStyle OwnedStyle { get; set; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        List<Auriga.Sirius.Diagram.IEdgeTarget> Path { get; }

        /// <summary>
        /// The routing style of the edge.
        /// </summary>
        Auriga.Sirius.Diagram.EdgeRouting RoutingStyle { get; set; }

        /// <summary>
        /// The line width.
        /// </summary>
        int? Size { get; set; }

        /// <summary>
        /// The source of the connection.
        /// </summary>
        Auriga.Sirius.Diagram.IEdgeTarget SourceNode { get; set; }

        /// <summary>
        /// The target of the connection.
        /// </summary>
        Auriga.Sirius.Diagram.IEdgeTarget TargetNode { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
