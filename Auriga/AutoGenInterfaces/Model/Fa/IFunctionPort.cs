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

namespace Auriga.Model.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>FunctionPort</c> interface.
    /// </summary>
    public partial interface IFunctionPort : Auriga.Model.Information.IPort, Auriga.Model.Capellacore.ITypedElement, Auriga.Model.Behavior.IAbstractEvent
    {
        /// <summary>
        /// Gets the allocator component ports.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentPort> AllocatorComponentPorts { get; }

        /// <summary>
        /// Gets the realized function ports.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionPort> RealizedFunctionPorts { get; }

        /// <summary>
        /// Gets the realizing function ports.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionPort> RealizingFunctionPorts { get; }

        /// <summary>
        /// @deprecated : 'representedComponentPort' shall not be used anymore
        /// </summary>
        Auriga.Model.Fa.IComponentPort RepresentedComponentPort { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
