// ------------------------------------------------------------------------------------------------
// <copyright file="IEdgeStyleDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description.Style
{
    using System.Collections.Generic;

    /// <summary>
    /// The style of an edge.
    /// </summary>
    public partial interface IEdgeStyleDescription : Auriga.Diagram.Viewpoint.Description.Style.IStyleDescription
    {
        /// <summary>
        /// Gets or sets the begin label style description.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Style.IBeginLabelStyleDescription BeginLabelStyleDescription { get; set; }

        /// <summary>
        /// Gets or sets the center label style description.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Style.ICenterLabelStyleDescription CenterLabelStyleDescription { get; set; }

        /// <summary>
        /// The mappings for which the edge source will be centered.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping> CenteredSourceMappings { get; }

        /// <summary>
        /// The mappings for which the edge target will be centered.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping> CenteredTargetMappings { get; }

        /// <summary>
        /// Gets or sets the end label style description.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Style.IEndLabelStyleDescription EndLabelStyleDescription { get; set; }

        /// <summary>
        /// Use this feature to generalize the ends centering behavior to all source mappings, all target mappings or both. If "None", you have to select the source and target mappings manually.
        /// </summary>
        Auriga.Diagram.Diagram.Description.CenteringStyle? EndsCentering { get; set; }

        /// <summary>
        /// A folding style allow to collapse the elements targeted by the edge.
        /// </summary>
        Auriga.Diagram.Diagram.Description.FoldingStyle? FoldingStyle { get; set; }

        /// <summary>
        /// The style of the line.
        /// </summary>
        Auriga.Diagram.Diagram.LineStyle? LineStyle { get; set; }

        /// <summary>
        /// The routing style for your edge.
        /// </summary>
        Auriga.Diagram.Diagram.EdgeRouting RoutingStyle { get; set; }

        /// <summary>
        /// An expression to compute the thickness of the link.
        /// </summary>
        string SizeComputationExpression { get; set; }

        /// <summary>
        /// The source decoration.
        /// </summary>
        Auriga.Diagram.Diagram.EdgeArrows SourceArrow { get; set; }

        /// <summary>
        /// The color of the edge.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.IColorDescription StrokeColor { get; set; }

        /// <summary>
        /// The target decoration.
        /// </summary>
        Auriga.Diagram.Diagram.EdgeArrows TargetArrow { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
