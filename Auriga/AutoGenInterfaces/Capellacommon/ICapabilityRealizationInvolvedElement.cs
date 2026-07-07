// ------------------------------------------------------------------------------------------------
// <copyright file="ICapabilityRealizationInvolvedElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacommon
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>CapabilityRealizationInvolvedElement</c> interface.
    /// </summary>
    public partial interface ICapabilityRealizationInvolvedElement : Auriga.Capellacore.IInvolvedElement
    {
        /// <summary>
        /// Gets the capability realization involvements.
        /// </summary>
        IEnumerable<Auriga.Capellacommon.ICapabilityRealizationInvolvement> CapabilityRealizationInvolvements { get; }

        /// <summary>
        /// Gets the involving capability realizations.
        /// </summary>
        IEnumerable<Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
