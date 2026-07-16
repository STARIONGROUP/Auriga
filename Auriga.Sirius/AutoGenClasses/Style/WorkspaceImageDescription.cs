// ------------------------------------------------------------------------------------------------
// <copyright file="WorkspaceImageDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Style
{
    using System.Collections.Generic;

    /// <summary>
    /// A custom image that is present in the user workspace.
    /// </summary>
    public partial class WorkspaceImageDescription : Auriga.Core.AurigaElement, Auriga.Sirius.Diagram.Description.Style.IWorkspaceImageDescription
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
        /// Gets or sets the border color.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.IColorDescription BorderColor { get; set; }

        /// <summary>
        /// The style of the border line.
        /// </summary>
        public Auriga.Sirius.Diagram.LineStyle? BorderLineStyle { get; set; }

        /// <summary>
        /// An expression computing the size of the border.
        /// </summary>
        public string BorderSizeComputationExpression { get; set; }

        /// <summary>
        /// Select which side of the container is authorized or not.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.Style.Side> ForbiddenSides { get; } = new List<Auriga.Sirius.Diagram.Description.Style.Side>();

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
        public Auriga.Sirius.Viewpoint.LabelAlignment? LabelAlignment { get; set; }

        /// <summary>
        /// Gets or sets the label color.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.IColorDescription LabelColor { get; set; }

        /// <summary>
        /// Expression that computes the name of a node.
        /// </summary>
        public string LabelExpression { get; set; }

        /// <summary>
        /// The font format.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.FontFormat> LabelFormat { get; } = new List<Auriga.Sirius.Viewpoint.FontFormat>();

        /// <summary>
        /// The relative position of the label to the node.
        /// </summary>
        public Auriga.Sirius.Diagram.LabelPosition? LabelPosition { get; set; }

        /// <summary>
        /// The font size.
        /// </summary>
        public int? LabelSize { get; set; }

        /// <summary>
        /// Define the directions the user is able to resize.
        /// </summary>
        public Auriga.Sirius.Diagram.ResizeKind ResizeKind { get; set; }

        /// <summary>
        /// Gets or sets the rounded corner.
        /// </summary>
        public bool? RoundedCorner { get; set; }

        /// <summary>
        /// True, if the icon shoud be dispayed on the element.
        /// </summary>
        public bool? ShowIcon { get; set; }

        /// <summary>
        /// Expression that computes the size of the node.
        /// </summary>
        public string SizeComputationExpression { get; set; }

        /// <summary>
        /// This expression is used to compute the text of the optional tooltip shown when the user leaves the mouse on an element.
        /// </summary>
        public string TooltipExpression { get; set; }

        /// <summary>
        /// The path of the image to use in the form of /myProjectID/path/to/image.png,  if the image is not found in the workspace it will be looked for in the plugins.
        /// </summary>
        public string WorkspacePath { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
