// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionalPrimaryAsset.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Cybersecurity
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>FunctionalPrimaryAsset</c> interface.
    /// </summary>
    public partial interface IFunctionalPrimaryAsset : Auriga.Model.Cybersecurity.IPrimaryAsset
    {
        /// <summary>
        /// Gets the functional chains.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalChain> FunctionalChains { get; }

        /// <summary>
        /// Gets the functions.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IAbstractFunction> Functions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
