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

namespace Auriga.Activity
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>AbstractActivity</c> interface.
    /// </summary>
    public partial interface IAbstractActivity : Auriga.Behavior.IAbstractBehavior, Auriga.Modellingcore.ITraceableElement
    {
        /// <summary>
        /// Gets or sets the is read only.
        /// </summary>
        bool? IsReadOnly { get; set; }

        /// <summary>
        /// Gets or sets the is single execution.
        /// </summary>
        bool? IsSingleExecution { get; set; }

        /// <summary>
        /// Gets the owned edges.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Activity.IActivityEdge> OwnedEdges { get; }

        /// <summary>
        /// Gets the owned groups.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Activity.IActivityGroup> OwnedGroups { get; }

        /// <summary>
        /// Gets the owned nodes.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Activity.IActivityNode> OwnedNodes { get; }

        /// <summary>
        /// Gets the owned structured nodes.
        /// </summary>
        IEnumerable<Auriga.Activity.IStructuredActivityNode> OwnedStructuredNodes { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
