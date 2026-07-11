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

namespace Auriga.Sirius.Diagram.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// An abstract mapping.
    /// </summary>
    public partial interface IAbstractNodeMapping : Auriga.Sirius.Diagram.Description.IDiagramElementMapping, Auriga.Sirius.Viewpoint.Description.IDocumentedElement
    {
        /// <summary>
        /// The mapping for nodes that are on the border of nodes created by this mapping.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.INodeMapping> BorderedNodeMappings { get; }

        /// <summary>
        /// The domain class of the mapping.
        /// </summary>
        string DomainClass { get; set; }

        /// <summary>
        /// Gets the reused bordered node mappings.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.INodeMapping> ReusedBorderedNodeMappings { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
