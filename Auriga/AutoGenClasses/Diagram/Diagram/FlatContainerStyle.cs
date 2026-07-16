// ------------------------------------------------------------------------------------------------
// <copyright file="FlatContainerStyle.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>FlatContainerStyle</c> class.
    /// </summary>
    public partial class FlatContainerStyle : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.IFlatContainerStyle
    {
        /// <summary>
        /// The background color.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// The background style.
        /// </summary>
        public Auriga.Diagram.Diagram.BackgroundStyle BackgroundStyle { get; set; }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        public string BorderColor { get; set; }

        /// <summary>
        /// The style of the border line.
        /// </summary>
        public Auriga.Diagram.Diagram.LineStyle? BorderLineStyle { get; set; }

        /// <summary>
        /// Gets or sets the border size.
        /// </summary>
        public int BorderSize { get; set; }

        /// <summary>
        /// Gets or sets the border size computation expression.
        /// </summary>
        public string BorderSizeComputationExpression { get; set; }

        /// <summary>
        /// Gets the custom features.
        /// </summary>
        public List<string> CustomFeatures { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Style.IStyleDescription Description { get; set; }

        /// <summary>
        /// The foreground color.
        /// </summary>
        public string ForegroundColor { get; set; }

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
        public string LabelColor { get; set; }

        /// <summary>
        /// The font format.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.FontFormat> LabelFormat { get; } = new List<Auriga.Diagram.Viewpoint.FontFormat>();

        /// <summary>
        /// The font size.
        /// </summary>
        public int? LabelSize { get; set; }

        /// <summary>
        /// True, if the icon shoud be dispayed on the element.
        /// </summary>
        public bool? ShowIcon { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
