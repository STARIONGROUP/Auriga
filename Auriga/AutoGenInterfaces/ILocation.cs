// ------------------------------------------------------------------------------------------------
// <copyright file="ILocation.cs" company="Starion Group S.A.">
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

namespace Auriga.Oa
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>Location</c> interface.
    /// </summary>
    public partial interface ILocation : Auriga.Oa.IAbstractConceptItem
    {
        /// <summary>
        /// Gets the located entities.
        /// </summary>
        List<Auriga.Oa.IEntity> LocatedEntities { get; }

        /// <summary>
        /// Gets or sets the location description.
        /// </summary>
        string LocationDescription { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
