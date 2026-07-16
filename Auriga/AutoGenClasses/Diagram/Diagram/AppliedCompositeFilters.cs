// ------------------------------------------------------------------------------------------------
// <copyright file="AppliedCompositeFilters.cs" company="Starion Group S.A.">
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
    public partial class AppliedCompositeFilters : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.IAppliedCompositeFilters
    {
        /// <summary>
        /// Gets the composite filter descriptions.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.Filter.ICompositeFilterDescription> CompositeFilterDescriptions { get; } = new List<Auriga.Diagram.Diagram.Description.Filter.ICompositeFilterDescription>();

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
