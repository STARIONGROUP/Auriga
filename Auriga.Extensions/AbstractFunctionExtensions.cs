// ------------------------------------------------------------------------------------------------
// <copyright file="AbstractFunctionExtensions.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Query extensions for <see cref="Auriga.Fa.IAbstractFunction"/> — the base of the Arcadia
    /// functions (operational activity, system / logical / physical function) — covering their ports,
    /// component allocation, and cross-layer realization.
    /// </summary>
    public static class AbstractFunctionExtensions
    {
        /// <summary>
        /// Queries the function ports of this function — its input and output function ports, gathered from
        /// the underlying action's <c>Inputs</c> and <c>Outputs</c> pins.
        /// </summary>
        /// <param name="function">the function whose ports are queried</param>
        /// <returns>the function's input and output ports</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="function"/> is <c>null</c></exception>
        public static IEnumerable<Auriga.Fa.IFunctionPort> QueryFunctionPorts(this Auriga.Fa.IAbstractFunction function)
        {
            if (function is null)
            {
                throw new ArgumentNullException(nameof(function));
            }

            // Every function is an activity action (IAbstractFunction inherits Activity.IAbstractAction),
            // so its ports are its input and output pins.
            var action = (Auriga.Activity.IAbstractAction)function;

            return action.Inputs.OfType<Auriga.Fa.IFunctionPort>()
                .Concat(action.Outputs.OfType<Auriga.Fa.IFunctionPort>());
        }

        /// <summary>
        /// Queries the blocks (typically components) this function is allocated to, by scanning the model
        /// for the component-functional allocations that reference this function.
        /// </summary>
        /// <param name="function">the allocated function</param>
        /// <returns>the distinct blocks the function is allocated to</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="function"/> is <c>null</c></exception>
        public static IEnumerable<Auriga.Fa.IAbstractFunctionalBlock> QueryAllocatingBlocks(this Auriga.Fa.IAbstractFunction function)
        {
            if (function is null)
            {
                throw new ArgumentNullException(nameof(function));
            }

            return function.QueryRoot().QueryAllContainedElements()
                .OfType<Auriga.Fa.IComponentFunctionalAllocation>()
                .Where(allocation => allocation.QueryEndpoints().Contains(function))
                .SelectMany(allocation => allocation.QueryEndpoints().OfType<Auriga.Fa.IAbstractFunctionalBlock>())
                .Distinct();
        }

        /// <summary>
        /// Determines whether this function is allocated to <paramref name="block"/> (for example, whether a
        /// system function is allocated to a given system component).
        /// </summary>
        /// <param name="function">the function to test</param>
        /// <param name="block">the candidate allocating block</param>
        /// <returns><c>true</c> when the function is among <paramref name="block"/>'s allocated functions</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="function"/> or <paramref name="block"/> is <c>null</c></exception>
        public static bool IsAllocatedTo(this Auriga.Fa.IAbstractFunction function, Auriga.Fa.IAbstractFunctionalBlock block)
        {
            if (function is null)
            {
                throw new ArgumentNullException(nameof(function));
            }

            if (block is null)
            {
                throw new ArgumentNullException(nameof(block));
            }

            return block.QueryAllocatedFunctions().Contains(function);
        }

        /// <summary>
        /// Queries the functions this function realizes — the counterpart functions of its owned function
        /// realizations. For a lower-layer function this yields the higher-layer functions it fulfils (for
        /// example a physical function realizing logical functions).
        /// </summary>
        /// <param name="function">the realizing function</param>
        /// <returns>the distinct functions realized by this function</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="function"/> is <c>null</c></exception>
        public static IEnumerable<Auriga.Fa.IAbstractFunction> QueryRealizedFunctions(this Auriga.Fa.IAbstractFunction function)
        {
            if (function is null)
            {
                throw new ArgumentNullException(nameof(function));
            }

            return function.OwnedFunctionRealizations
                .SelectMany(realization => realization.QueryEndpoints())
                .OfType<Auriga.Fa.IAbstractFunction>()
                .Where(other => !ReferenceEquals(other, function))
                .Distinct();
        }

        /// <summary>
        /// Queries the functions that realize this function — the model's functions whose owned function
        /// realizations point at this function. The inverse of <see cref="QueryRealizedFunctions"/>.
        /// </summary>
        /// <param name="function">the realized function</param>
        /// <returns>the distinct functions that realize this function</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="function"/> is <c>null</c></exception>
        public static IEnumerable<Auriga.Fa.IAbstractFunction> QueryRealizingFunctions(this Auriga.Fa.IAbstractFunction function)
        {
            if (function is null)
            {
                throw new ArgumentNullException(nameof(function));
            }

            return function.QueryRoot().QueryAllContainedElements()
                .OfType<Auriga.Fa.IAbstractFunction>()
                .Where(candidate => candidate.QueryRealizedFunctions().Contains(function));
        }
    }
}
