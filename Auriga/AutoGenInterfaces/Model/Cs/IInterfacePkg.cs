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

namespace Auriga.Model.Cs
{
    /// <summary>
    /// Definition of the <c>InterfacePkg</c> interface.
    /// </summary>
    public partial interface IInterfacePkg : Auriga.Model.Information.Communication.IMessageReferencePkg, Auriga.Model.Capellacore.IAbstractDependenciesPkg, Auriga.Model.Capellacore.IAbstractExchangeItemPkg
    {
        /// <summary>
        /// Gets the owned interface pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IInterfacePkg> OwnedInterfacePkgs { get; }

        /// <summary>
        /// Gets the owned interfaces.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IInterface> OwnedInterfaces { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
