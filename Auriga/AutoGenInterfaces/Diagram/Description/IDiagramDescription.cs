// ------------------------------------------------------------------------------------------------
// <copyright file="IDiagramDescription.cs" company="Starion Group S.A.">
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
    /// The description of a diagram.
    /// </summary>
    public partial interface IDiagramDescription : Auriga.Diagram.Diagram.Description.IDragAndDropTargetDescription, Auriga.Diagram.Viewpoint.Description.IRepresentationDescription, Auriga.Diagram.Viewpoint.Description.IPasteTargetDescription
    {
        /// <summary>
        /// Gets the additional layers.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IAdditionalLayer> AdditionalLayers { get; }

        /// <summary>
        /// Color of the diagram background, white if unset.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.IColorDescription BackgroundColor { get; set; }

        /// <summary>
        /// All concerns of the viewpoint. A concern is a set of filters, validations and behaviors.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Concern.IConcernSet Concerns { get; set; }

        /// <summary>
        /// container mappings that are owned by this simple mapping.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IContainerMapping> ContainerMappings { get; }

        /// <summary>
        /// The default concern to use.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Concern.IConcernDescription DefaultConcern { get; set; }

        /// <summary>
        /// Gets or sets the default layer.
        /// </summary>
        Auriga.Diagram.Diagram.Description.ILayer DefaultLayer { get; set; }

        /// <summary>
        /// Gets or sets the diagram initialisation.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation DiagramInitialisation { get; set; }

        /// <summary>
        /// The domain class of the viewpoint.
        /// </summary>
        string DomainClass { get; set; }

        /// <summary>
        /// Edge mapping imports that are owned by this simple mapping.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IEdgeMappingImport> EdgeMappingImports { get; }

        /// <summary>
        /// Edge mappings that are owned by this simple mapping.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IEdgeMapping> EdgeMappings { get; }

        /// <summary>
        /// Boolean indicating whether or not to show dynamic popup bars with creation tools.
        /// </summary>
        bool? EnablePopupBars { get; set; }

        /// <summary>
        /// Filters that are owned by this simple mapping.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.Filter.IFilterDescription> Filters { get; }

        /// <summary>
        /// Gets or sets the init.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription Init { get; set; }

        /// <summary>
        /// Gets or sets the layout.
        /// </summary>
        Auriga.Diagram.Diagram.Description.ILayout Layout { get; set; }

        /// <summary>
        /// Node mappings that are owned by this simple mapping.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.INodeMapping> NodeMappings { get; }

        /// <summary>
        /// The predicate that allows (or not) to create a viewpoint from a Meta Class.
        /// </summary>
        string PreconditionExpression { get; set; }

        /// <summary>
        /// The reused mappings.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping> ReusedMappings { get; }

        /// <summary>
        /// Tools that are reused by this viewpoint.
        /// </summary>
        List<Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription> ReusedTools { get; }

        /// <summary>
        /// Gets or sets the root expression.
        /// </summary>
        string RootExpression { get; set; }

        /// <summary>
        /// A tool section encloses many tools
        /// </summary>
        Auriga.Diagram.Diagram.Description.Tool.IToolSection ToolSection { get; set; }

        /// <summary>
        /// The validations rules
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Validation.IValidationSet ValidationSet { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
