// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractPhysicalLinkEnd.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>AbstractPhysicalLinkEnd</c> interface.
    /// </summary>
    public partial interface IAbstractPhysicalLinkEnd : Auriga.Model.Capellacore.ICapellaElement
    {
        /// <summary>
        /// Gets the involved links.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IPhysicalLink> InvolvedLinks { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
