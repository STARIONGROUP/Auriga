// ------------------------------------------------------------------------------------------------
// <copyright file="IDataPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Information
{
    public partial interface IDataPkg : global::Auriga.Capellacore.IAbstractDependenciesPkg, global::Auriga.Capellacore.IAbstractExchangeItemPkg, global::Auriga.Information.IAssociationPkg, global::Auriga.Information.Datavalue.IDataValueContainer, global::Auriga.Information.Communication.IMessageReferencePkg
    {
        global::Auriga.IContainerList<global::Auriga.Information.IDataPkg> OwnedDataPkgs { get; }

        global::Auriga.IContainerList<global::Auriga.Information.IClass> OwnedClasses { get; }

        global::Auriga.IContainerList<global::Auriga.Information.IKeyPart> OwnedKeyParts { get; }

        global::Auriga.IContainerList<global::Auriga.Information.ICollection> OwnedCollections { get; }

        global::Auriga.IContainerList<global::Auriga.Information.IUnit> OwnedUnits { get; }

        global::Auriga.IContainerList<global::Auriga.Information.Datatype.IDataType> OwnedDataTypes { get; }

        global::Auriga.IContainerList<global::Auriga.Information.Communication.ISignal> OwnedSignals { get; }

        global::Auriga.IContainerList<global::Auriga.Information.Communication.IMessage> OwnedMessages { get; }

        global::Auriga.IContainerList<global::Auriga.Information.Communication.IException> OwnedExceptions { get; }

        global::Auriga.IContainerList<global::Auriga.Capellacommon.IStateEvent> OwnedStateEvents { get; }

    }
}
