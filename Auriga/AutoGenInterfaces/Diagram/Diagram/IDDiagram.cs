// ------------------------------------------------------------------------------------------------
// <copyright file="IDDiagram.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ViewPoint is the type of all diagrams in AIR.
    /// A viewpoint is composed of nodes, containers and connections. It is owned by an anlysis or by a parent viewpoint. In this last case the viewpoint should be called detailed viewpoint.
    /// </summary>
    public partial interface IDDiagram : Auriga.Diagram.Viewpoint.IDRepresentation, Auriga.Diagram.Diagram.IDragAndDropTarget
    {
        /// <summary>
        /// Behaviors that are currently activated for this viewpoint.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.Tool.IBehaviorTool> ActivateBehaviors { get; }

        /// <summary>
        /// Filters that are currently activated for this viewpoint.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.Filter.IFilterDescription> ActivatedFilters { get; }

        /// <summary>
        /// Gets the activated layers.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.ILayer> ActivatedLayers { get; }

        /// <summary>
        /// Validation rules that are currently activated for this viewpoint.
        /// </summary>
        List<Auriga.Diagram.Viewpoint.Description.Validation.IValidationRule> ActivatedRules { get; }

        /// <summary>
        /// Gets the activated transient layers.
        /// </summary>
        IEnumerable<Auriga.Diagram.Diagram.Description.IAdditionalLayer> ActivatedTransientLayers { get; }

        /// <summary>
        /// Filters that can be activated for this viewpoint.
        /// </summary>
        IEnumerable<Auriga.Diagram.Diagram.Description.Filter.IFilterDescription> AllFilters { get; }

        /// <summary>
        /// All containers of the diagram. It is a subset of diagramElements
        /// </summary>
        IEnumerable<Auriga.Diagram.Diagram.IDDiagramElementContainer> Containers { get; }

        /// <summary>
        /// The current selected concer. It may be null
        /// </summary>
        Auriga.Diagram.Diagram.Description.Concern.IConcernDescription CurrentConcern { get; set; }

        /// <summary>
        /// The description of the diagram. It may be null.
        /// </summary>
        Auriga.Diagram.Diagram.Description.IDiagramDescription Description { get; set; }

        /// <summary>
        /// The diagram elements directly and indirectly owned by this diagram.
        /// </summary>
        IEnumerable<Auriga.Diagram.Diagram.IDDiagramElement> DiagramElements { get; }

        /// <summary>
        /// All edges of the diagram. It is a subset of diagramElements
        /// </summary>
        IEnumerable<Auriga.Diagram.Diagram.IDEdge> Edges { get; }

        /// <summary>
        /// Gets or sets the filter variable history.
        /// </summary>
        Auriga.Diagram.Diagram.IFilterVariableHistory FilterVariableHistory { get; set; }

        /// <summary>
        /// The number of lines to display the header labels (1 by default). This field is used only if the IDiagramDescriptionProvider.supportHeader() return true for this DDiagram.
        /// </summary>
        int? HeaderHeight { get; set; }

        /// <summary>
        /// List of DDiagramElement : Either the DDiagramElement is hidden or its label is hidden.
        /// </summary>
        IEnumerable<Auriga.Diagram.Diagram.IDDiagramElement> HiddenElements { get; }

        /// <summary>
        /// Gets the is in layouting mode.
        /// </summary>
        bool? IsInLayoutingMode { get; }

        /// <summary>
        /// Gets the is in showing mode.
        /// </summary>
        bool? IsInShowingMode { get; }

        /// <summary>
        /// All node list elements of the diagram. It is a subset of diagramElements
        /// </summary>
        IEnumerable<Auriga.Diagram.Diagram.IDNodeListElement> NodeListElements { get; }

        /// <summary>
        /// All nodes of the diagram. It is a subset of diagramElements
        /// </summary>
        IEnumerable<Auriga.Diagram.Diagram.IDNode> Nodes { get; }

        /// <summary>
        /// The DDiagramElements directly owned by this diagram.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IDDiagramElement> OwnedDiagramElements { get; }

        /// <summary>
        /// Gets or sets the synchronized.
        /// </summary>
        bool? Synchronized { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
