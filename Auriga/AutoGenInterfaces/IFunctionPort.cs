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

namespace Auriga.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>FunctionPort</c> interface.
    /// </summary>
    public partial interface IFunctionPort : Auriga.Information.IPort, Auriga.Capellacore.ITypedElement, Auriga.Behavior.IAbstractEvent
    {
        /// <summary>
        /// Gets the allocator component ports.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentPort> AllocatorComponentPorts { get; }

        /// <summary>
        /// Gets the realized function ports.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionPort> RealizedFunctionPorts { get; }

        /// <summary>
        /// Gets the realizing function ports.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionPort> RealizingFunctionPorts { get; }

        /// <summary>
        /// @deprecated : 'representedComponentPort' shall not be used anymore
        /// </summary>
        Auriga.Fa.IComponentPort RepresentedComponentPort { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
