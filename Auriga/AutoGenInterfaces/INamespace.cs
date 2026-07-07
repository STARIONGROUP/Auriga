// ------------------------------------------------------------------------------------------------
// <copyright file="INamespace.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Namespace</c> interface.
    /// </summary>
    public partial interface INamespace : Auriga.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the contained generic traces.
        /// </summary>
        IEnumerable<Auriga.Capellacommon.IGenericTrace> ContainedGenericTraces { get; }

        /// <summary>
        /// Gets the naming rules.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacore.INamingRule> NamingRules { get; }

        /// <summary>
        /// Gets the owned traces.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacore.ITrace> OwnedTraces { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
