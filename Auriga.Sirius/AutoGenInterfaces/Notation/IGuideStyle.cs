// ------------------------------------------------------------------------------------------------
// <copyright file="IGuideStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Notation
{
    /// <summary>
    /// Definition of the <c>GuideStyle</c> interface.
    /// </summary>
    public partial interface IGuideStyle : Auriga.Sirius.Notation.IStyle
    {
        /// <summary>
        /// Gets the horizontal guides.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Notation.IGuide> HorizontalGuides { get; }

        /// <summary>
        /// Gets the vertical guides.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Notation.IGuide> VerticalGuides { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
