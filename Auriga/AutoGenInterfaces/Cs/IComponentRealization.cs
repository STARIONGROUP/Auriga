// ------------------------------------------------------------------------------------------------
// <copyright file="IComponentRealization.cs" company="Starion Group S.A.">
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

namespace Auriga.Cs
{
    /// <summary>
    /// Definition of the <c>ComponentRealization</c> interface.
    /// </summary>
    public partial interface IComponentRealization : Auriga.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the realized component.
        /// </summary>
        Auriga.Cs.IComponent RealizedComponent { get; }

        /// <summary>
        /// Gets the realizing component.
        /// </summary>
        Auriga.Cs.IComponent RealizingComponent { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
