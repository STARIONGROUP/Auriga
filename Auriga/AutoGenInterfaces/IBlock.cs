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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Cs
{
    public partial interface IBlock : Auriga.Capellacore.IModellingBlock, Auriga.Fa.IAbstractFunctionalBlock
    {
        Auriga.Capellacommon.IAbstractCapabilityPkg OwnedAbstractCapabilityPkg { get; set; }

        Auriga.Cs.IInterfacePkg OwnedInterfacePkg { get; set; }

        Auriga.Information.IDataPkg OwnedDataPkg { get; set; }

        Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> OwnedStateMachines { get; }

    }
}
