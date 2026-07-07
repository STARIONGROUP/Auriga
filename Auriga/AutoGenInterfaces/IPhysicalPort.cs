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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IPhysicalPort : Auriga.Information.IPort, Auriga.Cs.IAbstractPhysicalArtifact, Auriga.Modellingcore.IInformationsExchanger, Auriga.Cs.IAbstractPhysicalLinkEnd, Auriga.Information.IProperty
    {
        Auriga.IContainerList<Auriga.Fa.IComponentPortAllocation> OwnedComponentPortAllocations { get; }

        Auriga.IContainerList<Auriga.Cs.IPhysicalPortRealization> OwnedPhysicalPortRealizations { get; }

        IEnumerable<Auriga.Fa.IComponentPort> AllocatedComponentPorts { get; }

        IEnumerable<Auriga.Cs.IPhysicalPort> RealizedPhysicalPorts { get; }

        IEnumerable<Auriga.Cs.IPhysicalPort> RealizingPhysicalPorts { get; }

    }
}
