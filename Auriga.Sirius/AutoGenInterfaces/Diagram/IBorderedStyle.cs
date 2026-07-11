// ------------------------------------------------------------------------------------------------
// <copyright file="IBorderedStyle.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>BorderedStyle</c> interface.
    /// </summary>
    public partial interface IBorderedStyle : Auriga.Sirius.Viewpoint.IStyle
    {
        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        string BorderColor { get; set; }

        /// <summary>
        /// The style of the border line.
        /// </summary>
        Auriga.Sirius.Diagram.LineStyle? BorderLineStyle { get; set; }

        /// <summary>
        /// Gets or sets the border size.
        /// </summary>
        int BorderSize { get; set; }

        /// <summary>
        /// Gets or sets the border size computation expression.
        /// </summary>
        string BorderSizeComputationExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
