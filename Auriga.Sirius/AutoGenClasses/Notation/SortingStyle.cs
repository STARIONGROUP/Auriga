// ------------------------------------------------------------------------------------------------
// <copyright file="SortingStyle.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>SortingStyle</c> class.
    /// </summary>
    public partial class SortingStyle : Auriga.AurigaElement, Auriga.Sirius.Notation.ISortingStyle
    {
        /// <summary>
        /// Gets the sorted objects.
        /// </summary>
        public List<object> SortedObjects { get; } = new List<object>();

        /// <summary>
        /// Gets or sets the sorting.
        /// </summary>
        public Auriga.Sirius.Notation.Sorting? Sorting { get; set; }

        /// <summary>
        /// Gets or sets the sorting keys.
        /// </summary>
        public string SortingKeys { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
