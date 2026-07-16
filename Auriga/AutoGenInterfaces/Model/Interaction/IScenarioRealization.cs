// ------------------------------------------------------------------------------------------------
// <copyright file="IScenarioRealization.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Interaction
{
    /// <summary>
    /// Definition of the <c>ScenarioRealization</c> interface.
    /// </summary>
    public partial interface IScenarioRealization : Auriga.Model.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the realized scenario.
        /// </summary>
        Auriga.Model.Interaction.IScenario RealizedScenario { get; }

        /// <summary>
        /// Gets the realizing scenario.
        /// </summary>
        Auriga.Model.Interaction.IScenario RealizingScenario { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
