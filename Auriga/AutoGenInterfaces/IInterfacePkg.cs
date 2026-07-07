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
    public partial interface IInterfacePkg : global::Auriga.Information.Communication.IMessageReferencePkg, global::Auriga.Capellacore.IAbstractDependenciesPkg, global::Auriga.Capellacore.IAbstractExchangeItemPkg
    {
        global::Auriga.IContainerList<global::Auriga.Cs.IInterface> OwnedInterfaces { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IInterfacePkg> OwnedInterfacePkgs { get; }

    }
}
