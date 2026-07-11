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

namespace Auriga.Sirius.Diagram
{
    /// <summary>
    /// Style of a node.
    /// </summary>
    public partial interface INodeStyle : Auriga.Sirius.Viewpoint.ILabelStyle, Auriga.Sirius.Viewpoint.IStyle, Auriga.Sirius.Diagram.IBorderedStyle, Auriga.Sirius.Diagram.IHideLabelCapabilityStyle
    {
        /// <summary>
        /// The position of the label :BORDER : The label is around the node, on the border.NODE : the label is
        /// in the node.
        /// </summary>
        Auriga.Sirius.Diagram.LabelPosition? LabelPosition { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
