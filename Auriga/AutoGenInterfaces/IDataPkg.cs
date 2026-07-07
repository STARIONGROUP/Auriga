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
    public partial interface IDataPkg : Auriga.Capellacore.IAbstractDependenciesPkg, Auriga.Capellacore.IAbstractExchangeItemPkg, Auriga.Information.IAssociationPkg, Auriga.Information.Datavalue.IDataValueContainer, Auriga.Information.Communication.IMessageReferencePkg
    {
        Auriga.IContainerList<Auriga.Information.IDataPkg> OwnedDataPkgs { get; }

        Auriga.IContainerList<Auriga.Information.IClass> OwnedClasses { get; }

        Auriga.IContainerList<Auriga.Information.IKeyPart> OwnedKeyParts { get; }

        Auriga.IContainerList<Auriga.Information.ICollection> OwnedCollections { get; }

        Auriga.IContainerList<Auriga.Information.IUnit> OwnedUnits { get; }

        Auriga.IContainerList<Auriga.Information.Datatype.IDataType> OwnedDataTypes { get; }

        Auriga.IContainerList<Auriga.Information.Communication.ISignal> OwnedSignals { get; }

        Auriga.IContainerList<Auriga.Information.Communication.IMessage> OwnedMessages { get; }

        Auriga.IContainerList<Auriga.Information.Communication.IException> OwnedExceptions { get; }

        Auriga.IContainerList<Auriga.Capellacommon.IStateEvent> OwnedStateEvents { get; }

    }
}
