// ------------------------------------------------------------------------------------------------
// <copyright file="TraceExtensions.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// Internal helpers over <see cref="Auriga.Modellingcore.IAbstractTrace"/>, the base of the
    /// allocation and realization links, used to read their resolved endpoints uniformly.
    /// </summary>
    /// <remarks>
    /// The generated model exposes typed convenience accessors on the concrete allocation and
    /// realization types (for example <c>ComponentFunctionalAllocation.Function</c>), but those are
    /// derived features the code generator stubs out to <c>null</c>. The reader only ever populates
    /// the stored <see cref="Auriga.Modellingcore.IAbstractTrace.SourceElement"/> and
    /// <see cref="Auriga.Modellingcore.IAbstractTrace.TargetElement"/> references, so every allocation
    /// and realization query reads those two endpoints and selects the end of the type it wants.
    /// </remarks>
    internal static class TraceExtensions
    {
        /// <summary>
        /// Enumerates the resolved source and target endpoints of a trace-based link (an allocation or a
        /// realization), skipping an endpoint that did not resolve.
        /// </summary>
        /// <param name="trace">the allocation or realization link</param>
        /// <returns>the resolved endpoints, source first then target</returns>
        internal static IEnumerable<IAurigaElement> QueryEndpoints(this Auriga.Modellingcore.IAbstractTrace trace)
        {
            if (trace.SourceElement is IAurigaElement source)
            {
                yield return source;
            }

            if (trace.TargetElement is IAurigaElement target)
            {
                yield return target;
            }
        }
    }
}
