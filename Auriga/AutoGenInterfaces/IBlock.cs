// ------------------------------------------------------------------------------------------------
// <copyright file="IBlock.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Block</c> interface.
    /// </summary>
    public partial interface IBlock : Auriga.Capellacore.IModellingBlock, Auriga.Fa.IAbstractFunctionalBlock
    {
        /// <summary>
        /// Gets or sets the owned abstract capability pkg.
        /// </summary>
        Auriga.Capellacommon.IAbstractCapabilityPkg OwnedAbstractCapabilityPkg { get; set; }

        /// <summary>
        /// Gets or sets the owned data pkg.
        /// </summary>
        Auriga.Information.IDataPkg OwnedDataPkg { get; set; }

        /// <summary>
        /// Gets or sets the owned interface pkg.
        /// </summary>
        Auriga.Cs.IInterfacePkg OwnedInterfacePkg { get; set; }

        /// <summary>
        /// Gets the owned state machines.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> OwnedStateMachines { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
