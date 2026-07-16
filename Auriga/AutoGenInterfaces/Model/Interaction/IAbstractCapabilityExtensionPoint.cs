// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractCapabilityExtensionPoint.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Interaction
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>AbstractCapabilityExtensionPoint</c> interface.
    /// </summary>
    public partial interface IAbstractCapabilityExtensionPoint : Auriga.Model.Capellacore.INamedRelationship
    {
        /// <summary>
        /// Gets the abstract capability.
        /// </summary>
        Auriga.Model.Interaction.IAbstractCapability AbstractCapability { get; }

        /// <summary>
        /// Gets the extend links.
        /// </summary>
        List<Auriga.Model.Interaction.IAbstractCapabilityExtend> ExtendLinks { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
