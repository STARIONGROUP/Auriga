// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractNodeMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// An abstract mapping.
    /// </summary>
    public partial interface IAbstractNodeMapping : Auriga.Diagram.Diagram.Description.IDiagramElementMapping, Auriga.Diagram.Viewpoint.Description.IDocumentedElement
    {
        /// <summary>
        /// The mapping for nodes that are on the border of nodes created by this mapping.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.INodeMapping> BorderedNodeMappings { get; }

        /// <summary>
        /// The domain class of the mapping.
        /// </summary>
        string DomainClass { get; set; }

        /// <summary>
        /// Gets the reused bordered node mappings.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.INodeMapping> ReusedBorderedNodeMappings { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
