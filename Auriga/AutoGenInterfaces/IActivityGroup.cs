// ------------------------------------------------------------------------------------------------
// <copyright file="IActivityGroup.cs" company="Starion Group S.A.">
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
    public partial interface IActivityGroup : global::Auriga.Modellingcore.IModelElement
    {
        global::Auriga.Activity.IActivityGroup SuperGroup { get; set; }

        global::Auriga.IContainerList<global::Auriga.Activity.IActivityGroup> SubGroups { get; }

        global::Auriga.IContainerList<global::Auriga.Activity.IActivityNode> OwnedNodes { get; }

        global::Auriga.IContainerList<global::Auriga.Activity.IActivityEdge> OwnedEdges { get; }

    }
}
