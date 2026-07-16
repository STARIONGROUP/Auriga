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

namespace Auriga.Model.Pa
{
    /// <summary>
    /// Definition of the <c>PhysicalComponentPkg</c> interface.
    /// </summary>
    public partial interface IPhysicalComponentPkg : Auriga.Model.Cs.IComponentPkg, Auriga.Model.Information.IAssociationPkg
    {
        /// <summary>
        /// Gets the owned deployments.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IAbstractDeploymentLink> OwnedDeployments { get; }

        /// <summary>
        /// Gets the owned key parts.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.IKeyPart> OwnedKeyParts { get; }

        /// <summary>
        /// Gets the owned physical component pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Pa.IPhysicalComponentPkg> OwnedPhysicalComponentPkgs { get; }

        /// <summary>
        /// Gets the owned physical components.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Pa.IPhysicalComponent> OwnedPhysicalComponents { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
