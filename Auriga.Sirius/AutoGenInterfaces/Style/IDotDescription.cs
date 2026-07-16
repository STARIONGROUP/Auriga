// ------------------------------------------------------------------------------------------------
// <copyright file="IDotDescription.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// The dot style.
    /// </summary>
    public partial interface IDotDescription : Auriga.Sirius.Diagram.Description.Style.INodeStyleDescription
    {
        /// <summary>
        /// The background color.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.IColorDescription BackgroundColor { get; set; }

        /// <summary>
        /// An expression to compute the size of the stroke.
        /// </summary>
        string StrokeSizeComputationExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
