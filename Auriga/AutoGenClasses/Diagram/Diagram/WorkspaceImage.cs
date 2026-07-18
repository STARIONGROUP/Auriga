// ------------------------------------------------------------------------------------------------
// <copyright file="WorkspaceImage.cs" company="Starion Group S.A.">
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
    /// A custom image that is present in the user workspace.
    /// </summary>
    public partial class WorkspaceImage : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.IWorkspaceImage
    {
        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        public string BorderColor { get; set; } = "0,0,0";

        /// <summary>
        /// The style of the border line.
        /// </summary>
        public Auriga.Diagram.Diagram.LineStyle? BorderLineStyle { get; set; }

        /// <summary>
        /// Gets or sets the border size.
        /// </summary>
        public int BorderSize { get; set; } = 0;

        /// <summary>
        /// Gets or sets the border size computation expression.
        /// </summary>
        public string BorderSizeComputationExpression { get; set; } = "0";

        /// <summary>
        /// Gets the custom features.
        /// </summary>
        public List<string> CustomFeatures { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Style.IStyleDescription Description { get; set; }

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
        public string LabelColor { get; set; } = "0,0,0";

        /// <summary>
        /// The font format.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.FontFormat> LabelFormat { get; } = new List<Auriga.Diagram.Viewpoint.FontFormat>();

        /// <summary>
        /// The position of the label :
        /// BORDER : The label is around the node, on the border.
        /// NODE : the label is in the node.
        /// </summary>
        public Auriga.Diagram.Diagram.LabelPosition? LabelPosition { get; set; }

        /// <summary>
        /// The font size.
        /// </summary>
        public int? LabelSize { get; set; } = 8;

        /// <summary>
        /// True, if the icon shoud be dispayed on the element.
        /// </summary>
        public bool? ShowIcon { get; set; } = true;

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// The path of the image to use.
        /// </summary>
        public string WorkspacePath { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
