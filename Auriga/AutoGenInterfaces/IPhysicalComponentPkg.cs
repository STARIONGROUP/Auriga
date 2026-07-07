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

namespace Auriga.Pa
{
    /// <summary>
    /// Definition of the <c>PhysicalComponentPkg</c> interface.
    /// </summary>
    public partial interface IPhysicalComponentPkg : Auriga.Cs.IComponentPkg, Auriga.Information.IAssociationPkg
    {
        /// <summary>
        /// Gets the owned deployments.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeployments { get; }

        /// <summary>
        /// Gets the owned key parts.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.IKeyPart> OwnedKeyParts { get; }

        /// <summary>
        /// Gets the owned physical component pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.Pa.IPhysicalComponentPkg> OwnedPhysicalComponentPkgs { get; }

        /// <summary>
        /// Gets the owned physical components.
        /// </summary>
        Auriga.IContainerList<Auriga.Pa.IPhysicalComponent> OwnedPhysicalComponents { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
