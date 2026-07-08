// ------------------------------------------------------------------------------------------------
// <copyright file="FunctionalExchangeExtensions.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Extensions
{
    using System;

    /// <summary>
    /// Query extensions for <see cref="Auriga.Fa.IFunctionalExchange"/> — the directed flow between two
    /// function ports — resolving each end to its owning function.
    /// </summary>
    public static class FunctionalExchangeExtensions
    {
        /// <summary>
        /// Returns the function at the source end of this exchange — the function that owns the exchange's
        /// source port — or <c>null</c> when the source port or its owner is not resolved.
        /// </summary>
        /// <param name="exchange">the functional exchange</param>
        /// <returns>the source function, or <c>null</c></returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="exchange"/> is <c>null</c></exception>
        public static Auriga.Fa.IAbstractFunction? QuerySourceFunction(this Auriga.Fa.IFunctionalExchange exchange)
        {
            if (exchange is null)
            {
                throw new ArgumentNullException(nameof(exchange));
            }

            return (exchange.Source as IAurigaElement)?.Container as Auriga.Fa.IAbstractFunction;
        }

        /// <summary>
        /// Returns the function at the target end of this exchange — the function that owns the exchange's
        /// target port — or <c>null</c> when the target port or its owner is not resolved.
        /// </summary>
        /// <param name="exchange">the functional exchange</param>
        /// <returns>the target function, or <c>null</c></returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="exchange"/> is <c>null</c></exception>
        public static Auriga.Fa.IAbstractFunction? QueryTargetFunction(this Auriga.Fa.IFunctionalExchange exchange)
        {
            if (exchange is null)
            {
                throw new ArgumentNullException(nameof(exchange));
            }

            return (exchange.Target as IAurigaElement)?.Container as Auriga.Fa.IAbstractFunction;
        }
    }
}
