// ------------------------------------------------------------------------------------------------
// <copyright file="ComponentExtensions.cs" company="Starion Group S.A.">
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
    /// Query extensions for <see cref="Auriga.Model.Cs.IComponent"/> — the Arcadia components (system,
    /// logical, physical) — covering their ports and cross-layer realization. The functions a component
    /// is responsible for are queried with
    /// <see cref="AbstractFunctionalBlockExtensions.QueryAllocatedFunctions"/>, since a component is an
    /// <see cref="Auriga.Model.Fa.IAbstractFunctionalBlock"/>.
    /// </summary>
    public static class ComponentExtensions
    {
        /// <summary>
        /// Queries the component ports directly owned by this component.
        /// </summary>
        /// <param name="component">the component whose ports are queried</param>
        /// <returns>the component's ports</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="component"/> is <c>null</c></exception>
        public static IEnumerable<Auriga.Model.Fa.IComponentPort> QueryComponentPorts(this Auriga.Model.Cs.IComponent component)
        {
            if (component is null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            return component.QueryContainedElements().OfType<Auriga.Model.Fa.IComponentPort>();
        }

        /// <summary>
        /// Queries the components this component realizes — the counterpart components of its owned
        /// component realizations. For a lower-layer component this yields the higher-layer components it
        /// fulfils (for example a physical component realizing logical components).
        /// </summary>
        /// <param name="component">the realizing component</param>
        /// <returns>the distinct components realized by this component</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="component"/> is <c>null</c></exception>
        public static IEnumerable<Auriga.Model.Cs.IComponent> QueryRealizedComponents(this Auriga.Model.Cs.IComponent component)
        {
            if (component is null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            return component.OwnedComponentRealizations
                .SelectMany(realization => realization.QueryEndpoints())
                .OfType<Auriga.Model.Cs.IComponent>()
                .Where(other => !ReferenceEquals(other, component))
                .Distinct();
        }

        /// <summary>
        /// Queries the components that realize this component — the model's components whose owned component
        /// realizations point at this component. The inverse of <see cref="QueryRealizedComponents"/>.
        /// </summary>
        /// <param name="component">the realized component</param>
        /// <returns>the distinct components that realize this component</returns>
        /// <exception cref="ArgumentNullException">thrown when <paramref name="component"/> is <c>null</c></exception>
        public static IEnumerable<Auriga.Model.Cs.IComponent> QueryRealizingComponents(this Auriga.Model.Cs.IComponent component)
        {
            if (component is null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            return component.QueryRoot().QueryAllContainedElements()
                .OfType<Auriga.Model.Cs.IComponent>()
                .Where(candidate => candidate.QueryRealizedComponents().Contains(component));
        }
    }
}
