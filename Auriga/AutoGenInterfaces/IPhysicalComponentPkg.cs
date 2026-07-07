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
    public partial interface IPhysicalComponentPkg : Auriga.Cs.IComponentPkg, Auriga.Information.IAssociationPkg
    {
        Auriga.IContainerList<Auriga.Pa.IPhysicalComponent> OwnedPhysicalComponents { get; }

        Auriga.IContainerList<Auriga.Pa.IPhysicalComponentPkg> OwnedPhysicalComponentPkgs { get; }

        Auriga.IContainerList<Auriga.Information.IKeyPart> OwnedKeyParts { get; }

        Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeployments { get; }

    }
}
