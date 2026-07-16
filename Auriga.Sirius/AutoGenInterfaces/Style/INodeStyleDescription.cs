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

namespace Auriga.Sirius.Diagram.Description.Style
{
    using System.Collections.Generic;

    /// <summary>
    /// Style of a node.
    /// </summary>
    public partial interface INodeStyleDescription : Auriga.Sirius.Viewpoint.Description.Style.IStyleDescription, Auriga.Sirius.Diagram.Description.Style.IBorderedStyleDescription, Auriga.Sirius.Viewpoint.Description.Style.ILabelStyleDescription, Auriga.Sirius.Viewpoint.Description.Style.ITooltipStyleDescription, Auriga.Sirius.Diagram.Description.Style.IHideLabelCapabilityStyleDescription
    {
        /// <summary>
        /// Select which side of the container is authorized or not.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.Style.Side> ForbiddenSides { get; }

        /// <summary>
        /// The relative position of the label to the node.
        /// </summary>
        Auriga.Sirius.Diagram.LabelPosition? LabelPosition { get; set; }

        /// <summary>
        /// Define the directions the user is able to resize.
        /// </summary>
        Auriga.Sirius.Diagram.ResizeKind ResizeKind { get; set; }

        /// <summary>
        /// Expression that computes the size of the node.
        /// </summary>
        string SizeComputationExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
