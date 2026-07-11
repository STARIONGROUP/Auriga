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

namespace Auriga.Sirius.Diagram.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// A container mapping allows to create containers (ViewNodeContainer or ViewNodeList).
    /// </summary>
    public partial interface IContainerMapping : Auriga.Sirius.Diagram.Description.IAbstractNodeMapping, Auriga.Sirius.Diagram.Description.IDragAndDropTargetDescription
    {
        /// <summary>
        /// Set to List if you want a container acting like a list.
        /// </summary>
        Auriga.Sirius.Diagram.ContainerLayout ChildrenPresentation { get; set; }

        /// <summary>
        /// Gets the conditionnal styles.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IConditionalContainerStyleDescription> ConditionnalStyles { get; }

        /// <summary>
        /// Gets the reused container mappings.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IContainerMapping> ReusedContainerMappings { get; }

        /// <summary>
        /// Gets the reused node mappings.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.INodeMapping> ReusedNodeMappings { get; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Style.IContainerStyleDescription Style { get; set; }

        /// <summary>
        /// Gets the sub container mappings.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IContainerMapping> SubContainerMappings { get; }

        /// <summary>
        /// Gets the sub node mappings.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.INodeMapping> SubNodeMappings { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
