// ------------------------------------------------------------------------------------------------
// <copyright file="IActivityExchange.cs" company="Starion Group S.A.">
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

namespace Auriga.Activity
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ActivityExchange</c> interface.
    /// </summary>
    public partial interface IActivityExchange : Auriga.Modellingcore.IAbstractInformationFlow
    {
        /// <summary>
        /// Gets the realizing activity flows.
        /// </summary>
        IEnumerable<Auriga.Activity.IActivityEdge> RealizingActivityFlows { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
