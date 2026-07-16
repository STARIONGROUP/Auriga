// ------------------------------------------------------------------------------------------------
// <copyright file="IFilteringStyle.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>FilteringStyle</c> interface.
    /// </summary>
    public partial interface IFilteringStyle : Auriga.Sirius.Notation.IStyle
    {
        /// <summary>
        /// Gets the filtered objects.
        /// </summary>
        List<object> FilteredObjects { get; }

        /// <summary>
        /// Gets or sets the filtering.
        /// </summary>
        Auriga.Sirius.Notation.Filtering? Filtering { get; set; }

        /// <summary>
        /// Gets or sets the filtering keys.
        /// </summary>
        string FilteringKeys { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
