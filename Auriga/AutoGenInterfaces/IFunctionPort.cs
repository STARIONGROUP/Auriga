// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionPort.cs" company="Starion Group S.A.">
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
    public partial interface IFunctionPort : global::Auriga.Information.IPort, global::Auriga.Capellacore.ITypedElement, global::Auriga.Behavior.IAbstractEvent
    {
        /// <summary>
        /// @deprecated : 'representedComponentPort' shall not be used anymore
        /// </summary>
        global::Auriga.Fa.IComponentPort RepresentedComponentPort { get; set; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentPort> AllocatorComponentPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionPort> RealizedFunctionPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionPort> RealizingFunctionPorts { get; }

    }
}
