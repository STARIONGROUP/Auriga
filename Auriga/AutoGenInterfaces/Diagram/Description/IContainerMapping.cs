// ------------------------------------------------------------------------------------------------
// <copyright file="IContainerMapping.cs" company="Starion Group S.A.">
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
    /// A container mapping allows to create containers (ViewNodeContainer or ViewNodeList).
    /// </summary>
    public partial interface IContainerMapping : Auriga.Diagram.Diagram.Description.IAbstractNodeMapping, Auriga.Diagram.Diagram.Description.IDragAndDropTargetDescription
    {
        /// <summary>
        /// Set to List if you want a container acting like a list.
        /// </summary>
        Auriga.Diagram.Diagram.ContainerLayout ChildrenPresentation { get; set; }

        /// <summary>
        /// Gets the conditionnal styles.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IConditionalContainerStyleDescription> ConditionnalStyles { get; }

        /// <summary>
        /// Gets the reused container mappings.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.IContainerMapping> ReusedContainerMappings { get; }

        /// <summary>
        /// Gets the reused node mappings.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.INodeMapping> ReusedNodeMappings { get; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Style.IContainerStyleDescription Style { get; set; }

        /// <summary>
        /// Gets the sub container mappings.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IContainerMapping> SubContainerMappings { get; }

        /// <summary>
        /// Gets the sub node mappings.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.INodeMapping> SubNodeMappings { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
