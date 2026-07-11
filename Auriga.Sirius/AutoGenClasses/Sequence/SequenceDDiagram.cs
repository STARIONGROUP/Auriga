// ------------------------------------------------------------------------------------------------
// <copyright file="SequenceDDiagram.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>SequenceDDiagram</c> class.
    /// </summary>
    public partial class SequenceDDiagram : Auriga.AurigaElement, Auriga.Sirius.Sequence.ISequenceDDiagram
    {
        /// <summary>
        /// Behaviors that are currently activated for this viewpoint.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.Tool.IBehaviorTool> ActivateBehaviors { get; } = new List<Auriga.Sirius.Diagram.Description.Tool.IBehaviorTool>();

        /// <summary>
        /// Filters that are currently activated for this viewpoint.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.Filter.IFilterDescription> ActivatedFilters { get; } = new List<Auriga.Sirius.Diagram.Description.Filter.IFilterDescription>();

        /// <summary>
        /// Gets the activated layers.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.ILayer> ActivatedLayers { get; } = new List<Auriga.Sirius.Diagram.Description.ILayer>();

        /// <summary>
        /// Validation rules that are currently activated for this viewpoint.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.Description.Validation.IValidationRule> ActivatedRules { get; } = new List<Auriga.Sirius.Viewpoint.Description.Validation.IValidationRule>();

        /// <summary>
        /// Gets the activated transient layers.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Diagram.Description.IAdditionalLayer> ActivatedTransientLayers => Enumerable.Empty<Auriga.Sirius.Diagram.Description.IAdditionalLayer>();

        /// <summary>
        /// Filters that can be activated for this viewpoint.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Diagram.Description.Filter.IFilterDescription> AllFilters => Enumerable.Empty<Auriga.Sirius.Diagram.Description.Filter.IFilterDescription>();

        /// <summary>
        /// All containers of the diagram. It is a subset of diagramElements
        /// </summary>
        public IEnumerable<Auriga.Sirius.Diagram.IDDiagramElementContainer> Containers => Enumerable.Empty<Auriga.Sirius.Diagram.IDDiagramElementContainer>();

        /// <summary>
        /// The current selected concer. It may be null
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Concern.IConcernDescription CurrentConcern { get; set; }

        /// <summary>
        /// The description of the diagram. It may be null.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.IDiagramDescription Description { get; set; }

        /// <summary>
        /// The diagram elements directly and indirectly owned by this diagram.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Diagram.IDDiagramElement> DiagramElements => Enumerable.Empty<Auriga.Sirius.Diagram.IDDiagramElement>();

        /// <summary>
        /// Gets the documentation.
        /// </summary>
        public string Documentation => default;

        /// <summary>
        /// Gets the e annotations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IDAnnotation> EAnnotations => this.backingEAnnotations ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.IDAnnotation>(this);

        /// <summary>
        /// Backing field for <see cref="EAnnotations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IDAnnotation> backingEAnnotations;

        /// <summary>
        /// All edges of the diagram. It is a subset of diagramElements
        /// </summary>
        public IEnumerable<Auriga.Sirius.Diagram.IDEdge> Edges => Enumerable.Empty<Auriga.Sirius.Diagram.IDEdge>();

        /// <summary>
        /// Gets or sets the filter variable history.
        /// </summary>
        public Auriga.Sirius.Diagram.IFilterVariableHistory FilterVariableHistory
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
        private Auriga.Sirius.Diagram.IFilterVariableHistory backingFilterVariableHistory;

        /// <summary>
        /// Gets the graphical ordering.
        /// </summary>
        public Auriga.Sirius.Sequence.Ordering.IEventEndsOrdering GraphicalOrdering => default;

        /// <summary>
        /// The number of lines to display the header labels (1 by default). This field is used only if the IDiagramDescriptionProvider.supportHeader() return true for this DDiagram.
        /// </summary>
        public int? HeaderHeight { get; set; }

        /// <summary>
        /// List of DDiagramElement : Either the DDiagramElement is hidden or its label is hidden.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Diagram.IDDiagramElement> HiddenElements => Enumerable.Empty<Auriga.Sirius.Diagram.IDDiagramElement>();

        /// <summary>
        /// Gets the instance role semantic ordering.
        /// </summary>
        public Auriga.Sirius.Sequence.Ordering.IInstanceRolesOrdering InstanceRoleSemanticOrdering => default;

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
        public IEnumerable<Auriga.Sirius.Diagram.IDNodeListElement> NodeListElements => Enumerable.Empty<Auriga.Sirius.Diagram.IDNodeListElement>();

        /// <summary>
        /// All nodes of the diagram. It is a subset of diagramElements
        /// </summary>
        public IEnumerable<Auriga.Sirius.Diagram.IDNode> Nodes => Enumerable.Empty<Auriga.Sirius.Diagram.IDNode>();

        /// <summary>
        /// Gets the owned annotation entries.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IAnnotationEntry> OwnedAnnotationEntries => this.backingOwnedAnnotationEntries ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.IAnnotationEntry>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedAnnotationEntries"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IAnnotationEntry> backingOwnedAnnotationEntries;

        /// <summary>
        /// The DDiagramElements directly owned by this diagram.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Diagram.IDDiagramElement> OwnedDiagramElements => this.backingOwnedDiagramElements ??= new Auriga.ContainerList<Auriga.Sirius.Diagram.IDDiagramElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedDiagramElements"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Diagram.IDDiagramElement> backingOwnedDiagramElements;

        /// <summary>
        /// The directly contained representation elements
        /// </summary>
        public IEnumerable<Auriga.Sirius.Viewpoint.IDRepresentationElement> OwnedRepresentationElements => Enumerable.Empty<Auriga.Sirius.Viewpoint.IDRepresentationElement>();

        /// <summary>
        /// The directly and indirectly contained representation elements
        /// </summary>
        public IEnumerable<Auriga.Sirius.Viewpoint.IDRepresentationElement> RepresentationElements => Enumerable.Empty<Auriga.Sirius.Viewpoint.IDRepresentationElement>();

        /// <summary>
        /// Gets the semantic ordering.
        /// </summary>
        public Auriga.Sirius.Sequence.Ordering.IEventEndsOrdering SemanticOrdering => default;

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
        public Auriga.Sirius.Viewpoint.IUIState UiState => default;

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>SequenceDDiagram</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.EAnnotations)
            {
                yield return element;
            }

            if (this.FilterVariableHistory != null)
            {
                yield return this.FilterVariableHistory;
            }

            if (this.GraphicalOrdering != null)
            {
                yield return this.GraphicalOrdering;
            }

            if (this.InstanceRoleSemanticOrdering != null)
            {
                yield return this.InstanceRoleSemanticOrdering;
            }

            foreach (var element in this.OwnedAnnotationEntries)
            {
                yield return element;
            }

            foreach (var element in this.OwnedDiagramElements)
            {
                yield return element;
            }

            if (this.SemanticOrdering != null)
            {
                yield return this.SemanticOrdering;
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
