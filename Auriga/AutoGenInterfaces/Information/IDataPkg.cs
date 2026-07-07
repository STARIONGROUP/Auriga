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

namespace Auriga.Information
{
    /// <summary>
    /// Definition of the <c>DataPkg</c> interface.
    /// </summary>
    public partial interface IDataPkg : Auriga.Capellacore.IAbstractDependenciesPkg, Auriga.Capellacore.IAbstractExchangeItemPkg, Auriga.Information.IAssociationPkg, Auriga.Information.Datavalue.IDataValueContainer, Auriga.Information.Communication.IMessageReferencePkg
    {
        /// <summary>
        /// Gets the owned classes.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.IClass> OwnedClasses { get; }

        /// <summary>
        /// Gets the owned collections.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.ICollection> OwnedCollections { get; }

        /// <summary>
        /// Gets the owned data pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.IDataPkg> OwnedDataPkgs { get; }

        /// <summary>
        /// Gets the owned data types.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.Datatype.IDataType> OwnedDataTypes { get; }

        /// <summary>
        /// Gets the owned exceptions.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.Communication.IException> OwnedExceptions { get; }

        /// <summary>
        /// Gets the owned key parts.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.IKeyPart> OwnedKeyParts { get; }

        /// <summary>
        /// Gets the owned messages.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.Communication.IMessage> OwnedMessages { get; }

        /// <summary>
        /// Gets the owned signals.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.Communication.ISignal> OwnedSignals { get; }

        /// <summary>
        /// Gets the owned state events.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacommon.IStateEvent> OwnedStateEvents { get; }

        /// <summary>
        /// Gets the owned units.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.IUnit> OwnedUnits { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
