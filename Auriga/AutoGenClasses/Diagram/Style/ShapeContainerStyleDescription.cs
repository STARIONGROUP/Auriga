// ------------------------------------------------------------------------------------------------
// <copyright file="ShapeContainerStyleDescription.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ShapeContainerStyleDescription</c> class.
    /// </summary>
    public partial class ShapeContainerStyleDescription : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.Style.IShapeContainerStyleDescription
    {
        /// <summary>
        /// The height of the ellipse used to draw the corners.
        /// </summary>
        public int? ArcHeight { get; set; }

        /// <summary>
        /// The width of the ellipse used to draw the corners.
        /// </summary>
        public int? ArcWidth { get; set; }

        /// <summary>
        /// The color to use.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IColorDescription BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IColorDescription BorderColor { get; set; }

        /// <summary>
        /// The style of the border line.
        /// </summary>
        public Auriga.Diagram.Diagram.LineStyle? BorderLineStyle { get; set; }

        /// <summary>
        /// An expression computing the size of the border.
        /// </summary>
        public string BorderSizeComputationExpression { get; set; }

        /// <summary>
        /// Expression that computes the size of the node.
        /// </summary>
        public string HeightComputationExpression { get; set; }

        /// <summary>
        /// The default visibility of the label (available only if labelPosition equals BORDER).
        /// A change of this option does not affect already existing elements.
        /// </summary>
        public bool? HideLabelByDefault { get; set; }

        /// <summary>
        /// The path of the icon to display on the element. If unset, the icon corresponding to the semantic element will be displayed.
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// Gets or sets the label alignment.
        /// </summary>
        public Auriga.Diagram.Viewpoint.LabelAlignment? LabelAlignment { get; set; }

        /// <summary>
        /// Gets or sets the label color.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IColorDescription LabelColor { get; set; }

        /// <summary>
        /// Expression that computes the name of a node.
        /// </summary>
        public string LabelExpression { get; set; }

        /// <summary>
        /// The font format.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.FontFormat> LabelFormat { get; } = new List<Auriga.Diagram.Viewpoint.FontFormat>();

        /// <summary>
        /// The font size.
        /// </summary>
        public int? LabelSize { get; set; }

        /// <summary>
        /// Gets or sets the rounded corner.
        /// </summary>
        public bool? RoundedCorner { get; set; }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        public Auriga.Diagram.Diagram.ContainerShape Shape { get; set; }

        /// <summary>
        /// True, if the icon shoud be dispayed on the element.
        /// </summary>
        public bool? ShowIcon { get; set; }

        /// <summary>
        /// This expression is used to compute the text of the optional tooltip shown when the user leaves the mouse on an element.
        /// </summary>
        public string TooltipExpression { get; set; }

        /// <summary>
        /// Expression that computes the size of the node.
        /// </summary>
        public string WidthComputationExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
