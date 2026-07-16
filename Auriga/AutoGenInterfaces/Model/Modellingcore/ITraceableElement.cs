// ------------------------------------------------------------------------------------------------
// <copyright file="ITraceableElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Modellingcore
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>TraceableElement</c> interface.
    /// </summary>
    public partial interface ITraceableElement : Auriga.Model.Modellingcore.IModelElement
    {
        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> IncomingTraces { get; }

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> OutgoingTraces { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
