// ------------------------------------------------------------------------------------------------
// <copyright file="ITExecutionStyle.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>TExecutionStyle</c> interface.
    /// </summary>
    public partial interface ITExecutionStyle : Auriga.Sirius.Sequence.Template.ITTransformer
    {
        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.IColorDescription BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.IColorDescription BorderColor { get; set; }

        /// <summary>
        /// An expression computing the size of the border.
        /// </summary>
        string BorderSizeComputationExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
