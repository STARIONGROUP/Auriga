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

namespace Auriga.Model.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PhysicalPort</c> interface.
    /// </summary>
    public partial interface IPhysicalPort : Auriga.Model.Information.IPort, Auriga.Model.Cs.IAbstractPhysicalArtifact, Auriga.Model.Modellingcore.IInformationsExchanger, Auriga.Model.Cs.IAbstractPhysicalLinkEnd, Auriga.Model.Information.IProperty
    {
        /// <summary>
        /// Gets the allocated component ports.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentPort> AllocatedComponentPorts { get; }

        /// <summary>
        /// Gets the owned component port allocations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentPortAllocation> OwnedComponentPortAllocations { get; }

        /// <summary>
        /// Gets the owned physical port realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IPhysicalPortRealization> OwnedPhysicalPortRealizations { get; }

        /// <summary>
        /// Gets the realized physical ports.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IPhysicalPort> RealizedPhysicalPorts { get; }

        /// <summary>
        /// Gets the realizing physical ports.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IPhysicalPort> RealizingPhysicalPorts { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
