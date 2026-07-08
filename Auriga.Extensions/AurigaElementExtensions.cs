// ------------------------------------------------------------------------------------------------
// <copyright file="AurigaElementExtensions.cs" company="Starion Group S.A.">
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
    /// LINQ-style navigation extensions for <see cref="IAurigaElement"/>, the base of every element in
    /// the Auriga Capella object model. These build on the containment graph — the <c>Container</c>
    /// back-pointer and <c>QueryContainedElements()</c>/<c>QueryAllContainedElements()</c> — so they
    /// work against any loaded model regardless of layer.
    /// </summary>
    public static class AurigaElementExtensions
    {
        /// <summary>
        /// Walks the containment chain from this element to the model root, yielding each ancestor in turn
        /// (the immediate <c>Container</c> first, the root last). The element itself is not included.
        /// </summary>
        /// <param name="element">the element whose ancestors are queried</param>
        /// <returns>the containing elements, nearest first</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="element"/> is <c>null</c></exception>
        public static IEnumerable<IAurigaElement> QueryAncestors(this IAurigaElement element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var ancestors = new List<IAurigaElement>();

            for (var container = element.Container; container is not null; container = container.Container)
            {
                ancestors.Add(container);
            }

            return ancestors;
        }

        /// <summary>
        /// Returns the containment root reachable from this element — the topmost <c>Container</c>, which for
        /// a fully loaded Capella model is the <c>capellamodeller::Project</c>. Returns the element itself
        /// when it has no container.
        /// </summary>
        /// <param name="element">the element to walk up from</param>
        /// <returns>the root of this element's containment chain</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="element"/> is <c>null</c></exception>
        public static IAurigaElement QueryRoot(this IAurigaElement element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var current = element;

            while (current.Container is not null)
            {
                current = current.Container;
            }

            return current;
        }

        /// <summary>
        /// Determines whether this element is contained — directly or transitively — by
        /// <paramref name="ancestor"/>.
        /// </summary>
        /// <param name="element">the element to test</param>
        /// <param name="ancestor">the candidate containing element</param>
        /// <returns><c>true</c> when <paramref name="ancestor"/> is one of this element's ancestors</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="element"/> or <paramref name="ancestor"/> is <c>null</c></exception>
        public static bool IsContainedIn(this IAurigaElement element, IAurigaElement ancestor)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (ancestor is null)
            {
                throw new ArgumentNullException(nameof(ancestor));
            }

            return element.QueryAncestors().Contains(ancestor);
        }

        /// <summary>
        /// Queries every function in this element's containment subtree, across all layers — the
        /// <see cref="Auriga.Fa.IAbstractFunction"/> descendants. Applied to an architecture layer it yields
        /// that layer's functions; applied to the project root it yields the whole model's functions.
        /// </summary>
        /// <param name="element">the element whose subtree is searched</param>
        /// <returns>the contained functions</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="element"/> is <c>null</c></exception>
        public static IEnumerable<Auriga.Fa.IAbstractFunction> QueryAllFunctions(this IAurigaElement element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.QueryAllContainedElements().OfType<Auriga.Fa.IAbstractFunction>();
        }

        /// <summary>
        /// Queries every component in this element's containment subtree, across all layers — the
        /// <see cref="Auriga.Cs.IComponent"/> descendants.
        /// </summary>
        /// <param name="element">the element whose subtree is searched</param>
        /// <returns>the contained components</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="element"/> is <c>null</c></exception>
        public static IEnumerable<Auriga.Cs.IComponent> QueryAllComponents(this IAurigaElement element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.QueryAllContainedElements().OfType<Auriga.Cs.IComponent>();
        }
    }
}
