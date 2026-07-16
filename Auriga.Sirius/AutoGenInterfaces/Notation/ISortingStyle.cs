// ------------------------------------------------------------------------------------------------
// <copyright file="ISortingStyle.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>SortingStyle</c> interface.
    /// </summary>
    public partial interface ISortingStyle : Auriga.Sirius.Notation.IStyle
    {
        /// <summary>
        /// Gets the sorted objects.
        /// </summary>
        List<object> SortedObjects { get; }

        /// <summary>
        /// Gets or sets the sorting.
        /// </summary>
        Auriga.Sirius.Notation.Sorting? Sorting { get; set; }

        /// <summary>
        /// Gets or sets the sorting keys.
        /// </summary>
        string SortingKeys { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
