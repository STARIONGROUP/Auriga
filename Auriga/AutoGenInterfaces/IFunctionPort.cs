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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IFunctionPort : Auriga.Information.IPort, Auriga.Capellacore.ITypedElement, Auriga.Behavior.IAbstractEvent
    {
        /// <summary>
        /// @deprecated : 'representedComponentPort' shall not be used anymore
        /// </summary>
        Auriga.Fa.IComponentPort RepresentedComponentPort { get; set; }

        IEnumerable<Auriga.Fa.IComponentPort> AllocatorComponentPorts { get; }

        IEnumerable<Auriga.Fa.IFunctionPort> RealizedFunctionPorts { get; }

        IEnumerable<Auriga.Fa.IFunctionPort> RealizingFunctionPorts { get; }

    }
}
