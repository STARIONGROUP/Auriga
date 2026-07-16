// ------------------------------------------------------------------------------------------------
// <copyright file="ITMessageStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Sequence.Template
{
    /// <summary>
    /// Definition of the <c>TMessageStyle</c> interface.
    /// </summary>
    public partial interface ITMessageStyle : Auriga.Diagram.Sequence.Template.ITTransformer
    {
        /// <summary>
        /// Expression that computes the name of a node.
        /// </summary>
        string LabelExpression { get; set; }

        /// <summary>
        /// The style of the line.
        /// </summary>
        Auriga.Diagram.Diagram.LineStyle? LineStyle { get; set; }

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
