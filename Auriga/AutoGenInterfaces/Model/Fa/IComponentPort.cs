// ------------------------------------------------------------------------------------------------
// <copyright file="IComponentPort.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ComponentPort</c> interface.
    /// </summary>
    public partial interface IComponentPort : Auriga.Model.Information.IPort, Auriga.Model.Modellingcore.IInformationsExchanger, Auriga.Model.Information.IProperty
    {
        /// <summary>
        /// Gets the allocated function ports.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionPort> AllocatedFunctionPorts { get; }

        /// <summary>
        /// Gets the allocating physical ports.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IPhysicalPort> AllocatingPhysicalPorts { get; }

        /// <summary>
        /// Gets the component exchanges.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentExchange> ComponentExchanges { get; }

        /// <summary>
        /// Gets the delegated component ports.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentPort> DelegatedComponentPorts { get; }

        /// <summary>
        /// Gets the delegating component ports.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentPort> DelegatingComponentPorts { get; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Model.Fa.ComponentPortKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        Auriga.Model.Fa.OrientationPortKind? Orientation { get; set; }

        /// <summary>
        /// Gets the realized component ports.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentPort> RealizedComponentPorts { get; }

        /// <summary>
        /// Gets the realizing component ports.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentPort> RealizingComponentPorts { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
