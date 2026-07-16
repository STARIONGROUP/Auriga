// ------------------------------------------------------------------------------------------------
// <copyright file="INodeStyleDescription.cs" company="Starion Group S.A.">
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
    /// Style of a node.
    /// </summary>
    public partial interface INodeStyleDescription : Auriga.Diagram.Viewpoint.Description.Style.IStyleDescription, Auriga.Diagram.Diagram.Description.Style.IBorderedStyleDescription, Auriga.Diagram.Viewpoint.Description.Style.ILabelStyleDescription, Auriga.Diagram.Viewpoint.Description.Style.ITooltipStyleDescription, Auriga.Diagram.Diagram.Description.Style.IHideLabelCapabilityStyleDescription
    {
        /// <summary>
        /// Select which side of the container is authorized or not.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.Style.Side> ForbiddenSides { get; }

        /// <summary>
        /// The relative position of the label to the node.
        /// </summary>
        Auriga.Diagram.Diagram.LabelPosition? LabelPosition { get; set; }

        /// <summary>
        /// Define the directions the user is able to resize.
        /// </summary>
        Auriga.Diagram.Diagram.ResizeKind ResizeKind { get; set; }

        /// <summary>
        /// Expression that computes the size of the node.
        /// </summary>
        string SizeComputationExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
