// ------------------------------------------------------------------------------------------------
// <copyright file="AbstractFunctionalBlockExtensions.cs" company="Starion Group S.A.">
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
    /// Query extensions for <see cref="Auriga.Fa.IAbstractFunctionalBlock"/> — the base of the Arcadia
    /// components — covering the functions allocated to a block.
    /// </summary>
    public static class AbstractFunctionalBlockExtensions
    {
        /// <summary>
        /// Queries the functions allocated to this block through its owned component-functional
        /// allocations. For a component this is the set of behaviours the component is responsible for.
        /// </summary>
        /// <param name="block">the functional block (typically a component)</param>
        /// <returns>the distinct functions allocated to the block</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="block"/> is <c>null</c></exception>
        public static IEnumerable<Auriga.Fa.IAbstractFunction> QueryAllocatedFunctions(this Auriga.Fa.IAbstractFunctionalBlock block)
        {
            if (block is null)
            {
                throw new ArgumentNullException(nameof(block));
            }

            return block.OwnedFunctionalAllocation
                .SelectMany(allocation => allocation.QueryEndpoints())
                .OfType<Auriga.Fa.IAbstractFunction>()
                .Distinct();
        }
    }
}
