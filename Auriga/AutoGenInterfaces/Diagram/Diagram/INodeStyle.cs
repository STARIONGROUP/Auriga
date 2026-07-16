// ------------------------------------------------------------------------------------------------
// <copyright file="INodeStyle.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Style of a node.
    /// </summary>
    public partial interface INodeStyle : Auriga.Diagram.Viewpoint.ILabelStyle, Auriga.Diagram.Viewpoint.IStyle, Auriga.Diagram.Diagram.IBorderedStyle, Auriga.Diagram.Diagram.IHideLabelCapabilityStyle
    {
        /// <summary>
        /// The position of the label :
        /// BORDER : The label is around the node, on the border.
        /// NODE : the label is in the node.
        /// </summary>
        Auriga.Diagram.Diagram.LabelPosition? LabelPosition { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
