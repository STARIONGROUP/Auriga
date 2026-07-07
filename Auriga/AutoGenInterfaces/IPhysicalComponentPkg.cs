// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalComponentPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa
{
    public partial interface IPhysicalComponentPkg : global::Auriga.Cs.IComponentPkg, global::Auriga.Information.IAssociationPkg
    {
        global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalComponent> OwnedPhysicalComponents { get; }

        global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalComponentPkg> OwnedPhysicalComponentPkgs { get; }

        global::Auriga.IContainerList<global::Auriga.Information.IKeyPart> OwnedKeyParts { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IAbstractDeploymentLink> OwnedDeployments { get; }

    }
}
