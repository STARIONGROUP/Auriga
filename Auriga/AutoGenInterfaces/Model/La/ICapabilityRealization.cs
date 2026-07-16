// ------------------------------------------------------------------------------------------------
// <copyright file="ICapabilityRealization.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.La
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>CapabilityRealization</c> interface.
    /// </summary>
    public partial interface ICapabilityRealization : Auriga.Model.Interaction.IAbstractCapability
    {
        /// <summary>
        /// Gets the involved components.
        /// </summary>
        IEnumerable<Auriga.Model.Capellacommon.ICapabilityRealizationInvolvedElement> InvolvedComponents { get; }

        /// <summary>
        /// Gets the owned capability realization involvements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacommon.ICapabilityRealizationInvolvement> OwnedCapabilityRealizationInvolvements { get; }

        /// <summary>
        /// Gets the realized capabilities.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ICapability> RealizedCapabilities { get; }

        /// <summary>
        /// Gets the realized capability realizations.
        /// </summary>
        IEnumerable<Auriga.Model.La.ICapabilityRealization> RealizedCapabilityRealizations { get; }

        /// <summary>
        /// Gets the realizing capability realizations.
        /// </summary>
        IEnumerable<Auriga.Model.La.ICapabilityRealization> RealizingCapabilityRealizations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
