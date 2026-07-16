// ------------------------------------------------------------------------------------------------
// <copyright file="DSemanticDiagram.cs" company="Starion Group S.A.">
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
    /// A semantic viewpoint is a viewpoint that is rattached to a semantic element.
    /// </summary>
    public partial class DSemanticDiagram : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.IDSemanticDiagram
    {
        /// <summary>
        /// Behaviors that are currently activated for this viewpoint.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.Tool.IBehaviorTool> ActivateBehaviors { get; } = new List<Auriga.Diagram.Diagram.Description.Tool.IBehaviorTool>();

        /// <summary>
        /// Filters that are currently activated for this viewpoint.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.Filter.IFilterDescription> ActivatedFilters { get; } = new List<Auriga.Diagram.Diagram.Description.Filter.IFilterDescription>();

        /// <summary>
        /// Gets the activated layers.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.ILayer> ActivatedLayers { get; } = new List<Auriga.Diagram.Diagram.Description.ILayer>();

        /// <summary>
        /// Validation rules that are currently activated for this viewpoint.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Validation.IValidationRule> ActivatedRules { get; } = new List<Auriga.Diagram.Viewpoint.Description.Validation.IValidationRule>();

        /// <summary>
        /// Gets the activated transient layers.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Diagram.Description.IAdditionalLayer> ActivatedTransientLayers => Enumerable.Empty<Auriga.Diagram.Diagram.Description.IAdditionalLayer>();

        /// <summary>
        /// Filters that can be activated for this viewpoint.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Diagram.Description.Filter.IFilterDescription> AllFilters => Enumerable.Empty<Auriga.Diagram.Diagram.Description.Filter.IFilterDescription>();

        /// <summary>
        /// All containers of the diagram. It is a subset of diagramElements
        /// </summary>
        public IEnumerable<Auriga.Diagram.Diagram.IDDiagramElementContainer> Containers => Enumerable.Empty<Auriga.Diagram.Diagram.IDDiagramElementContainer>();

        /// <summary>
        /// The current selected concer. It may be null
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Concern.IConcernDescription CurrentConcern { get; set; }

        /// <summary>
        /// The description of the diagram. It may be null.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.IDiagramDescription Description { get; set; }

        /// <summary>
        /// The diagram elements directly and indirectly owned by this diagram.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Diagram.IDDiagramElement> DiagramElements => Enumerable.Empty<Auriga.Diagram.Diagram.IDDiagramElement>();

        /// <summary>
        /// Gets the documentation.
        /// </summary>
        public string Documentation => default;

        /// <summary>
        /// Gets the e annotations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IDAnnotation> EAnnotations => this.backingEAnnotations ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IDAnnotation>(this);

        /// <summary>
        /// Backing field for <see cref="EAnnotations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IDAnnotation> backingEAnnotations;

        /// <summary>
        /// All edges of the diagram. It is a subset of diagramElements
        /// </summary>
        public IEnumerable<Auriga.Diagram.Diagram.IDEdge> Edges => Enumerable.Empty<Auriga.Diagram.Diagram.IDEdge>();

        /// <summary>
        /// Gets or sets the filter variable history.
        /// </summary>
        public Auriga.Diagram.Diagram.IFilterVariableHistory FilterVariableHistory
        {
            get => this.backingFilterVariableHistory;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingFilterVariableHistory = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="FilterVariableHistory"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.IFilterVariableHistory backingFilterVariableHistory;

        /// <summary>
        /// The number of lines to display the header labels (1 by default). This field is used only if the IDiagramDescriptionProvider.supportHeader() return true for this DDiagram.
        /// </summary>
        public int? HeaderHeight { get; set; }

        /// <summary>
        /// List of DDiagramElement : Either the DDiagramElement is hidden or its label is hidden.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Diagram.IDDiagramElement> HiddenElements => Enumerable.Empty<Auriga.Diagram.Diagram.IDDiagramElement>();

        /// <summary>
        /// Gets the is in layouting mode.
        /// </summary>
        public bool? IsInLayoutingMode => default;

        /// <summary>
        /// Gets the is in showing mode.
        /// </summary>
        public bool? IsInShowingMode => default;

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name => default;

        /// <summary>
        /// All node list elements of the diagram. It is a subset of diagramElements
        /// </summary>
        public IEnumerable<Auriga.Diagram.Diagram.IDNodeListElement> NodeListElements => Enumerable.Empty<Auriga.Diagram.Diagram.IDNodeListElement>();

        /// <summary>
        /// All nodes of the diagram. It is a subset of diagramElements
        /// </summary>
        public IEnumerable<Auriga.Diagram.Diagram.IDNode> Nodes => Enumerable.Empty<Auriga.Diagram.Diagram.IDNode>();

        /// <summary>
        /// Gets the owned annotation entries.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IAnnotationEntry> OwnedAnnotationEntries => this.backingOwnedAnnotationEntries ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IAnnotationEntry>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedAnnotationEntries"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IAnnotationEntry> backingOwnedAnnotationEntries;

        /// <summary>
        /// The DDiagramElements directly owned by this diagram.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IDDiagramElement> OwnedDiagramElements => this.backingOwnedDiagramElements ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.IDDiagramElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedDiagramElements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IDDiagramElement> backingOwnedDiagramElements;

        /// <summary>
        /// The directly contained representation elements
        /// </summary>
        public IEnumerable<Auriga.Diagram.Viewpoint.IDRepresentationElement> OwnedRepresentationElements => Enumerable.Empty<Auriga.Diagram.Viewpoint.IDRepresentationElement>();

        /// <summary>
        /// The directly and indirectly contained representation elements
        /// </summary>
        public IEnumerable<Auriga.Diagram.Viewpoint.IDRepresentationElement> RepresentationElements => Enumerable.Empty<Auriga.Diagram.Viewpoint.IDRepresentationElement>();

        /// <summary>
        /// Gets or sets the synchronized.
        /// </summary>
        public bool? Synchronized { get; set; }

        /// <summary>
        /// The referenced EObject.
        /// </summary>
        public object Target { get; set; }

        /// <summary>
        /// Gets the ui state.
        /// </summary>
        public Auriga.Diagram.Viewpoint.IUIState UiState => default;

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>DSemanticDiagram</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.EAnnotations)
            {
                yield return element;
            }

            if (this.FilterVariableHistory != null)
            {
                yield return this.FilterVariableHistory;
            }

            foreach (var element in this.OwnedAnnotationEntries)
            {
                yield return element;
            }

            foreach (var element in this.OwnedDiagramElements)
            {
                yield return element;
            }

            if (this.UiState != null)
            {
                yield return this.UiState;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
