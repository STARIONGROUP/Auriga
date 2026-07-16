// ------------------------------------------------------------------------------------------------
// <copyright file="FilteringStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Notation
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>FilteringStyle</c> class.
    /// </summary>
    public partial class FilteringStyle : Auriga.Core.AurigaElement, Auriga.Sirius.Notation.IFilteringStyle
    {
        /// <summary>
        /// Gets the filtered objects.
        /// </summary>
        public List<object> FilteredObjects { get; } = new List<object>();

        /// <summary>
        /// Gets or sets the filtering.
        /// </summary>
        public Auriga.Sirius.Notation.Filtering? Filtering { get; set; }

        /// <summary>
        /// Gets or sets the filtering keys.
        /// </summary>
        public string FilteringKeys { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
