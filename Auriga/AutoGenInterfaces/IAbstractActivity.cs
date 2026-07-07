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
    public partial interface IAbstractActivity : global::Auriga.Behavior.IAbstractBehavior, global::Auriga.Modellingcore.ITraceableElement
    {
        bool? IsReadOnly { get; set; }

        bool? IsSingleExecution { get; set; }

        global::Auriga.IContainerList<global::Auriga.Activity.IActivityNode> OwnedNodes { get; }

        global::Auriga.IContainerList<global::Auriga.Activity.IActivityEdge> OwnedEdges { get; }

        global::Auriga.IContainerList<global::Auriga.Activity.IActivityGroup> OwnedGroups { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Activity.IStructuredActivityNode> OwnedStructuredNodes { get; }

    }
}
