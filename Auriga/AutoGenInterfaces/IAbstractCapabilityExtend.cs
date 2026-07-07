// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractCapabilityExtend.cs" company="Starion Group S.A.">
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Interaction
{
    public partial interface IAbstractCapabilityExtend : global::Auriga.Capellacore.IRelationship
    {
        global::Auriga.Interaction.IAbstractCapability Extended { get; set; }

        global::Auriga.Interaction.IAbstractCapability Extension { get; }

        global::Auriga.Interaction.IAbstractCapabilityExtensionPoint ExtensionLocation { get; set; }

    }
}
