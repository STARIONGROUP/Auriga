// ------------------------------------------------------------------------------------------------
// <copyright file="IIState.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Modellingcore
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>IState</c> interface.
    /// </summary>
    public partial interface IIState : Auriga.Model.Modellingcore.IAbstractNamedElement
    {
        /// <summary>
        /// Gets the exploited states.
        /// </summary>
        List<Auriga.Model.Modellingcore.IIState> ExploitedStates { get; }

        /// <summary>
        /// Gets the referenced states.
        /// </summary>
        List<Auriga.Model.Modellingcore.IIState> ReferencedStates { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
