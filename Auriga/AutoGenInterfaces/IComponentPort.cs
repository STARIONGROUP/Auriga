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
    public partial interface IComponentPort : global::Auriga.Information.IPort, global::Auriga.Modellingcore.IInformationsExchanger, global::Auriga.Information.IProperty
    {
        global::Auriga.Fa.OrientationPortKind? Orientation { get; set; }

        global::Auriga.Fa.ComponentPortKind? Kind { get; set; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentExchange> ComponentExchanges { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionPort> AllocatedFunctionPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentPort> DelegatedComponentPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentPort> DelegatingComponentPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalPort> AllocatingPhysicalPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentPort> RealizedComponentPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentPort> RealizingComponentPorts { get; }

    }
}
