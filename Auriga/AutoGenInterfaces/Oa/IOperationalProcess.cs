// ------------------------------------------------------------------------------------------------
// <copyright file="IOperationalProcess.cs" company="Starion Group S.A.">
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

namespace Auriga.Oa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>OperationalProcess</c> interface.
    /// </summary>
    public partial interface IOperationalProcess : Auriga.Fa.IFunctionalChain
    {
        /// <summary>
        /// Gets the involving operational capabilities.
        /// </summary>
        IEnumerable<Auriga.Oa.IOperationalCapability> InvolvingOperationalCapabilities { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
