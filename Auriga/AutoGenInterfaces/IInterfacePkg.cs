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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Cs
{
    public partial interface IInterfacePkg : Auriga.Information.Communication.IMessageReferencePkg, Auriga.Capellacore.IAbstractDependenciesPkg, Auriga.Capellacore.IAbstractExchangeItemPkg
    {
        Auriga.IContainerList<Auriga.Cs.IInterface> OwnedInterfaces { get; }

        Auriga.IContainerList<Auriga.Cs.IInterfacePkg> OwnedInterfacePkgs { get; }

    }
}
