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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Modellingcore
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface ITraceableElement : Auriga.Modellingcore.IModelElement
    {
        IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces { get; }

        IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces { get; }

    }
}
