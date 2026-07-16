// ------------------------------------------------------------------------------------------------
// <copyright file="ILayer.cs" company="Starion Group S.A.">
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
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Layer</c> interface.
    /// </summary>
    public partial interface ILayer : Auriga.Diagram.Viewpoint.Description.IDocumentedElement, Auriga.Diagram.Viewpoint.Description.IEndUserDocumentedElement, Auriga.Diagram.Viewpoint.Description.IIdentifiedElement
    {
        /// <summary>
        /// All tools of the viewpoint.
        /// </summary>
        IEnumerable<Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription> AllTools { get; }

        /// <summary>
        /// container mappings that are owned by this simple mapping.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IContainerMapping> ContainerMappings { get; }

        /// <summary>
        /// Gets or sets the customization.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.ICustomization Customization { get; set; }

        /// <summary>
        /// Gets or sets the decoration descriptions set.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.IDecorationDescriptionsSet DecorationDescriptionsSet { get; set; }

        /// <summary>
        /// Edge mapping imports that are owned by this simple mapping.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IEdgeMappingImport> EdgeMappingImports { get; }

        /// <summary>
        /// Edge mappings that are owned by this simple mapping.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IEdgeMapping> EdgeMappings { get; }

        /// <summary>
        /// image path to use as an icon for the layer
        /// </summary>
        string Icon { get; set; }

        /// <summary>
        /// Node mappings that are owned by this simple mapping.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.INodeMapping> NodeMappings { get; }

        /// <summary>
        /// Add here any mapping you want to reuse from another layer or diagram.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping> ReusedMappings { get; }

        /// <summary>
        /// Tools that are reused by this viewpoint.
        /// </summary>
        List<Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription> ReusedTools { get; }

        /// <summary>
        /// A tool section encloses many tools
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.Tool.IToolSection> ToolSections { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
