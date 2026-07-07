// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractPropertyValue.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacore
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>AbstractPropertyValue</c> interface.
    /// </summary>
    public partial interface IAbstractPropertyValue : Auriga.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the involved elements.
        /// </summary>
        List<Auriga.Capellacore.ICapellaElement> InvolvedElements { get; }

        /// <summary>
        /// Gets the valued elements.
        /// </summary>
        IEnumerable<Auriga.Capellacore.ICapellaElement> ValuedElements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
