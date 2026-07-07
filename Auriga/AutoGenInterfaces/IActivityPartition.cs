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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Activity
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IActivityPartition : Auriga.Activity.IActivityGroup, Auriga.Modellingcore.IAbstractNamedElement
    {
        bool? IsDimension { get; set; }

        bool? IsExternal { get; set; }

        Auriga.Modellingcore.IAbstractType RepresentedElement { get; set; }

        Auriga.Activity.IActivityPartition SuperPartition { get; }

        IEnumerable<Auriga.Activity.IActivityPartition> SubPartitions { get; }

    }
}
