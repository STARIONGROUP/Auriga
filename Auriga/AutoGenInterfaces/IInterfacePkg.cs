// ------------------------------------------------------------------------------------------------
// <copyright file="IInterfacePkg.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>InterfacePkg</c> interface.
    /// </summary>
    public partial interface IInterfacePkg : Auriga.Information.Communication.IMessageReferencePkg, Auriga.Capellacore.IAbstractDependenciesPkg, Auriga.Capellacore.IAbstractExchangeItemPkg
    {
        /// <summary>
        /// Gets the owned interface pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IInterfacePkg> OwnedInterfacePkgs { get; }

        /// <summary>
        /// Gets the owned interfaces.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IInterface> OwnedInterfaces { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
