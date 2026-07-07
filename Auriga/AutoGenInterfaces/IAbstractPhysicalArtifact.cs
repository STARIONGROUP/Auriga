// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractPhysicalArtifact.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>AbstractPhysicalArtifact</c> interface.
    /// </summary>
    public partial interface IAbstractPhysicalArtifact : Auriga.Capellacore.ICapellaElement
    {
        /// <summary>
        /// Gets the allocator configuration items.
        /// </summary>
        IEnumerable<Auriga.Epbs.IConfigurationItem> AllocatorConfigurationItems { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
