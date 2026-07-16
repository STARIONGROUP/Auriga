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

namespace Auriga.Model.Information
{
    /// <summary>
    /// Definition of the <c>DataPkg</c> interface.
    /// </summary>
    public partial interface IDataPkg : Auriga.Model.Capellacore.IAbstractDependenciesPkg, Auriga.Model.Capellacore.IAbstractExchangeItemPkg, Auriga.Model.Information.IAssociationPkg, Auriga.Model.Information.Datavalue.IDataValueContainer, Auriga.Model.Information.Communication.IMessageReferencePkg
    {
        /// <summary>
        /// Gets the owned classes.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.IClass> OwnedClasses { get; }

        /// <summary>
        /// Gets the owned collections.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.ICollection> OwnedCollections { get; }

        /// <summary>
        /// Gets the owned data pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.IDataPkg> OwnedDataPkgs { get; }

        /// <summary>
        /// Gets the owned data types.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.Datatype.IDataType> OwnedDataTypes { get; }

        /// <summary>
        /// Gets the owned exceptions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.Communication.IException> OwnedExceptions { get; }

        /// <summary>
        /// Gets the owned key parts.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.IKeyPart> OwnedKeyParts { get; }

        /// <summary>
        /// Gets the owned messages.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.Communication.IMessage> OwnedMessages { get; }

        /// <summary>
        /// Gets the owned signals.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.Communication.ISignal> OwnedSignals { get; }

        /// <summary>
        /// Gets the owned state events.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IStateEvent> OwnedStateEvents { get; }

        /// <summary>
        /// Gets the owned units.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.IUnit> OwnedUnits { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
