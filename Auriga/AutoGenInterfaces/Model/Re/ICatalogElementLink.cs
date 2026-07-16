// ------------------------------------------------------------------------------------------------
// <copyright file="ICatalogElementLink.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Re
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>CatalogElementLink</c> interface.
    /// </summary>
    public partial interface ICatalogElementLink : Auriga.Model.Re.IReAbstractElement
    {
        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        Auriga.Model.Re.ICatalogElementLink Origin { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        Auriga.Model.Re.ICatalogElement Source { get; set; }

        /// <summary>
        /// Gets or sets the suffixed.
        /// </summary>
        bool? Suffixed { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        object Target { get; set; }

        /// <summary>
        /// Gets the unsynchronized features.
        /// </summary>
        List<string> UnsynchronizedFeatures { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
