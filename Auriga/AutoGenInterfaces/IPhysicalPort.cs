// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalPort.cs" company="Starion Group S.A.">
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
    public partial interface IPhysicalPort : global::Auriga.Information.IPort, global::Auriga.Cs.IAbstractPhysicalArtifact, global::Auriga.Modellingcore.IInformationsExchanger, global::Auriga.Cs.IAbstractPhysicalLinkEnd, global::Auriga.Information.IProperty
    {
        global::Auriga.IContainerList<global::Auriga.Fa.IComponentPortAllocation> OwnedComponentPortAllocations { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalPortRealization> OwnedPhysicalPortRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentPort> AllocatedComponentPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalPort> RealizedPhysicalPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalPort> RealizingPhysicalPorts { get; }

    }
}
