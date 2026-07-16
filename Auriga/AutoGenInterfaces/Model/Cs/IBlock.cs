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

namespace Auriga.Model.Cs
{
    /// <summary>
    /// Definition of the <c>Block</c> interface.
    /// </summary>
    public partial interface IBlock : Auriga.Model.Capellacore.IModellingBlock, Auriga.Model.Fa.IAbstractFunctionalBlock
    {
        /// <summary>
        /// Gets or sets the owned abstract capability pkg.
        /// </summary>
        Auriga.Model.Capellacommon.IAbstractCapabilityPkg OwnedAbstractCapabilityPkg { get; set; }

        /// <summary>
        /// Gets or sets the owned data pkg.
        /// </summary>
        Auriga.Model.Information.IDataPkg OwnedDataPkg { get; set; }

        /// <summary>
        /// Gets or sets the owned interface pkg.
        /// </summary>
        Auriga.Model.Cs.IInterfacePkg OwnedInterfacePkg { get; set; }

        /// <summary>
        /// Gets the owned state machines.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IStateMachine> OwnedStateMachines { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
