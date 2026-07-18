// ------------------------------------------------------------------------------------------------
// <copyright file="DotDescription.cs" company="Starion Group S.A.">
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
    /// The dot style.
    /// </summary>
    public partial class DotDescription : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.Style.IDotDescription
    {
        /// <summary>
        /// The background color.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IColorDescription BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IColorDescription BorderColor { get; set; }

        /// <summary>
        /// The style of the border line.
        /// </summary>
        public Auriga.Diagram.Diagram.LineStyle? BorderLineStyle { get; set; } = Auriga.Diagram.Diagram.LineStyle.Solid;

        /// <summary>
        /// An expression computing the size of the border.
        /// </summary>
        public string BorderSizeComputationExpression { get; set; } = "0";

        /// <summary>
        /// Select which side of the container is authorized or not.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.Style.Side> ForbiddenSides { get; } = new List<Auriga.Diagram.Diagram.Description.Style.Side>();

        /// <summary>
        /// The default visibility of the label (available only if labelPosition equals BORDER).
        /// A change of this option does not affect already existing elements.
        /// </summary>
        public bool? HideLabelByDefault { get; set; } = false;

        /// <summary>
        /// The path of the icon to display on the element. If unset, the icon corresponding to the semantic element will be displayed.
        /// </summary>
        public string IconPath { get; set; } = "";

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
        public string LabelExpression { get; set; } = "feature:name";

        /// <summary>
        /// The font format.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.FontFormat> LabelFormat { get; } = new List<Auriga.Diagram.Viewpoint.FontFormat>();

        /// <summary>
        /// The relative position of the label to the node.
        /// </summary>
        public Auriga.Diagram.Diagram.LabelPosition? LabelPosition { get; set; } = Auriga.Diagram.Diagram.LabelPosition.Border;

        /// <summary>
        /// The font size.
        /// </summary>
        public int? LabelSize { get; set; } = 8;

        /// <summary>
        /// Define the directions the user is able to resize.
        /// </summary>
        public Auriga.Diagram.Diagram.ResizeKind ResizeKind { get; set; } = Auriga.Diagram.Diagram.ResizeKind.NONE;

        /// <summary>
        /// True, if the icon shoud be dispayed on the element.
        /// </summary>
        public bool? ShowIcon { get; set; } = true;

        /// <summary>
        /// Expression that computes the size of the node.
        /// </summary>
        public string SizeComputationExpression { get; set; } = "3";

        /// <summary>
        /// An expression to compute the size of the stroke.
        /// </summary>
        public string StrokeSizeComputationExpression { get; set; } = "2";

        /// <summary>
        /// This expression is used to compute the text of the optional tooltip shown when the user leaves the mouse on an element.
        /// </summary>
        public string TooltipExpression { get; set; } = "";

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
