// ------------------------------------------------------------------------------------------------
// <copyright file="ITLifelineStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence.Template
{
    /// <summary>
    /// Definition of the <c>TLifelineStyle</c> interface.
    /// </summary>
    public partial interface ITLifelineStyle : Auriga.Sirius.Sequence.Template.ITTransformer
    {
        /// <summary>
        /// Gets or sets the lifeline color.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.IColorDescription LifelineColor { get; set; }

        /// <summary>
        /// An expression computing the size of the border.
        /// </summary>
        string LifelineWidthComputationExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
