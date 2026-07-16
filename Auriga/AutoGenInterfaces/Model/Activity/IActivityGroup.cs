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

namespace Auriga.Model.Activity
{
    /// <summary>
    /// Definition of the <c>ActivityGroup</c> interface.
    /// </summary>
    public partial interface IActivityGroup : Auriga.Model.Modellingcore.IModelElement
    {
        /// <summary>
        /// Gets the owned edges.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Activity.IActivityEdge> OwnedEdges { get; }

        /// <summary>
        /// Gets the owned nodes.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Activity.IActivityNode> OwnedNodes { get; }

        /// <summary>
        /// Gets the sub groups.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Activity.IActivityGroup> SubGroups { get; }

        /// <summary>
        /// Gets or sets the super group.
        /// </summary>
        Auriga.Model.Activity.IActivityGroup SuperGroup { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
