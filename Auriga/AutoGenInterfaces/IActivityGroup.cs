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
    public partial interface IActivityGroup : Auriga.Modellingcore.IModelElement
    {
        Auriga.Activity.IActivityGroup SuperGroup { get; set; }

        Auriga.IContainerList<Auriga.Activity.IActivityGroup> SubGroups { get; }

        Auriga.IContainerList<Auriga.Activity.IActivityNode> OwnedNodes { get; }

        Auriga.IContainerList<Auriga.Activity.IActivityEdge> OwnedEdges { get; }

    }
}
