// ------------------------------------------------------------------------------------------------
// <copyright file="TMessageStyle.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>TMessageStyle</c> class.
    /// </summary>
    public partial class TMessageStyle : Auriga.Core.AurigaElement, Auriga.Diagram.Sequence.Template.ITMessageStyle
    {
        /// <summary>
        /// Expression that computes the name of a node.
        /// </summary>
        public string LabelExpression { get; set; } = "feature:name";

        /// <summary>
        /// The style of the line.
        /// </summary>
        public Auriga.Diagram.Diagram.LineStyle? LineStyle { get; set; }

        /// <summary>
        /// Gets the outputs.
        /// </summary>
        public List<object> Outputs { get; } = new List<object>();

        /// <summary>
        /// The source decoration.
        /// </summary>
        public Auriga.Diagram.Diagram.EdgeArrows SourceArrow { get; set; } = Auriga.Diagram.Diagram.EdgeArrows.NoDecoration;

        /// <summary>
        /// The color of the edge.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IColorDescription StrokeColor { get; set; }

        /// <summary>
        /// The target decoration.
        /// </summary>
        public Auriga.Diagram.Diagram.EdgeArrows TargetArrow { get; set; } = Auriga.Diagram.Diagram.EdgeArrows.InputArrow;

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
