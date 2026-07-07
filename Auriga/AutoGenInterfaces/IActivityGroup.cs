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

namespace Auriga.Activity
{
    /// <summary>
    /// Definition of the <c>ActivityGroup</c> interface.
    /// </summary>
    public partial interface IActivityGroup : Auriga.Modellingcore.IModelElement
    {
        /// <summary>
        /// Gets the owned edges.
        /// </summary>
        Auriga.IContainerList<Auriga.Activity.IActivityEdge> OwnedEdges { get; }

        /// <summary>
        /// Gets the owned nodes.
        /// </summary>
        Auriga.IContainerList<Auriga.Activity.IActivityNode> OwnedNodes { get; }

        /// <summary>
        /// Gets the sub groups.
        /// </summary>
        Auriga.IContainerList<Auriga.Activity.IActivityGroup> SubGroups { get; }

        /// <summary>
        /// Gets or sets the super group.
        /// </summary>
        Auriga.Activity.IActivityGroup SuperGroup { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
