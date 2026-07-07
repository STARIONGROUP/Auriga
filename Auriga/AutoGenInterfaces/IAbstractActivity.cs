// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractActivity.cs" company="Starion Group S.A.">
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

    public partial interface IAbstractActivity : Auriga.Behavior.IAbstractBehavior, Auriga.Modellingcore.ITraceableElement
    {
        bool? IsReadOnly { get; set; }

        bool? IsSingleExecution { get; set; }

        Auriga.IContainerList<Auriga.Activity.IActivityNode> OwnedNodes { get; }

        Auriga.IContainerList<Auriga.Activity.IActivityEdge> OwnedEdges { get; }

        Auriga.IContainerList<Auriga.Activity.IActivityGroup> OwnedGroups { get; }

        IEnumerable<Auriga.Activity.IStructuredActivityNode> OwnedStructuredNodes { get; }

    }
}
