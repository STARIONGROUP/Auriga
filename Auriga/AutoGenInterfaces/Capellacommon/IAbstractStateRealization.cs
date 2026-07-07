// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractStateRealization.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>AbstractStateRealization</c> interface.
    /// </summary>
    public partial interface IAbstractStateRealization : Auriga.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the realized abstract state.
        /// </summary>
        Auriga.Capellacommon.IAbstractState RealizedAbstractState { get; }

        /// <summary>
        /// Gets the realizing abstract state.
        /// </summary>
        Auriga.Capellacommon.IAbstractState RealizingAbstractState { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
