// ------------------------------------------------------------------------------------------------
// <copyright file="IAppliedCompositeFilters.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram
{
    using System.Collections.Generic;

    /// <summary>
    /// Graphical filter listing the active filters applied on a diagram element.
    /// </summary>
    public partial interface IAppliedCompositeFilters : Auriga.Diagram.Diagram.IGraphicalFilter
    {
        /// <summary>
        /// Gets the composite filter descriptions.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.Filter.ICompositeFilterDescription> CompositeFilterDescriptions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
