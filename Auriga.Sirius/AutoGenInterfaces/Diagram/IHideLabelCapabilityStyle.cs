// ------------------------------------------------------------------------------------------------
// <copyright file="IHideLabelCapabilityStyle.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>HideLabelCapabilityStyle</c> interface.
    /// </summary>
    public partial interface IHideLabelCapabilityStyle : Auriga.IAurigaElement
    {
        /// <summary>
        /// The default visibility of the label (available only if labelPosition equals BORDER).
        /// A change of
        /// this option does not affect already existing elements.
        /// </summary>
        bool? HideLabelByDefault { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
