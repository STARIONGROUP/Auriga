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
    public partial interface IActivityPartition : global::Auriga.Activity.IActivityGroup, global::Auriga.Modellingcore.IAbstractNamedElement
    {
        bool? IsDimension { get; set; }

        bool? IsExternal { get; set; }

        global::Auriga.Modellingcore.IAbstractType RepresentedElement { get; set; }

        global::Auriga.Activity.IActivityPartition SuperPartition { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Activity.IActivityPartition> SubPartitions { get; }

    }
}
