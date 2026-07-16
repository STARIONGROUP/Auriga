// ------------------------------------------------------------------------------------------------
// <copyright file="IEdgeStyle.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// The style of an edge.
    /// </summary>
    public partial interface IEdgeStyle : Auriga.Diagram.Viewpoint.IStyle
    {
        /// <summary>
        /// Gets or sets the begin label style.
        /// </summary>
        Auriga.Diagram.Diagram.IBeginLabelStyle BeginLabelStyle { get; set; }

        /// <summary>
        /// Gets or sets the center label style.
        /// </summary>
        Auriga.Diagram.Diagram.ICenterLabelStyle CenterLabelStyle { get; set; }

        /// <summary>
        /// Gets or sets the centered.
        /// </summary>
        Auriga.Diagram.Diagram.Description.CenteringStyle Centered { get; set; }

        /// <summary>
        /// Gets or sets the end label style.
        /// </summary>
        Auriga.Diagram.Diagram.IEndLabelStyle EndLabelStyle { get; set; }

        /// <summary>
        /// Gets or sets the folding style.
        /// </summary>
        Auriga.Diagram.Diagram.Description.FoldingStyle FoldingStyle { get; set; }

        /// <summary>
        /// The style of the line.
        /// </summary>
        Auriga.Diagram.Diagram.LineStyle? LineStyle { get; set; }

        /// <summary>
        /// The routing style of the edge.
        /// </summary>
        Auriga.Diagram.Diagram.EdgeRouting RoutingStyle { get; set; }

        /// <summary>
        /// The line width.
        /// </summary>
        int? Size { get; set; }

        /// <summary>
        /// The source decoration.
        /// </summary>
        Auriga.Diagram.Diagram.EdgeArrows SourceArrow { get; set; }

        /// <summary>
        /// The color of the edge.
        /// </summary>
        string StrokeColor { get; set; }

        /// <summary>
        /// The target decoration.
        /// </summary>
        Auriga.Diagram.Diagram.EdgeArrows TargetArrow { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
