// ------------------------------------------------------------------------------------------------
// <copyright file="IActivityPartition.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Activity
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ActivityPartition</c> interface.
    /// </summary>
    public partial interface IActivityPartition : Auriga.Model.Activity.IActivityGroup, Auriga.Model.Modellingcore.IAbstractNamedElement
    {
        /// <summary>
        /// Gets or sets the is dimension.
        /// </summary>
        bool? IsDimension { get; set; }

        /// <summary>
        /// Gets or sets the is external.
        /// </summary>
        bool? IsExternal { get; set; }

        /// <summary>
        /// Gets or sets the represented element.
        /// </summary>
        Auriga.Model.Modellingcore.IAbstractType RepresentedElement { get; set; }

        /// <summary>
        /// Gets the sub partitions.
        /// </summary>
        IEnumerable<Auriga.Model.Activity.IActivityPartition> SubPartitions { get; }

        /// <summary>
        /// Gets the super partition.
        /// </summary>
        Auriga.Model.Activity.IActivityPartition SuperPartition { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
