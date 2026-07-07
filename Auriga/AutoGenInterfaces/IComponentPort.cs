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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IComponentPort : Auriga.Information.IPort, Auriga.Modellingcore.IInformationsExchanger, Auriga.Information.IProperty
    {
        Auriga.Fa.OrientationPortKind? Orientation { get; set; }

        Auriga.Fa.ComponentPortKind? Kind { get; set; }

        IEnumerable<Auriga.Fa.IComponentExchange> ComponentExchanges { get; }

        IEnumerable<Auriga.Fa.IFunctionPort> AllocatedFunctionPorts { get; }

        IEnumerable<Auriga.Fa.IComponentPort> DelegatedComponentPorts { get; }

        IEnumerable<Auriga.Fa.IComponentPort> DelegatingComponentPorts { get; }

        IEnumerable<Auriga.Cs.IPhysicalPort> AllocatingPhysicalPorts { get; }

        IEnumerable<Auriga.Fa.IComponentPort> RealizedComponentPorts { get; }

        IEnumerable<Auriga.Fa.IComponentPort> RealizingComponentPorts { get; }

    }
}
