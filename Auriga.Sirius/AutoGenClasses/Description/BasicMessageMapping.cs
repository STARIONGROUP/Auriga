// ------------------------------------------------------------------------------------------------
// <copyright file="BasicMessageMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>BasicMessageMapping</c> class.
    /// </summary>
    public partial class BasicMessageMapping : Auriga.AurigaElement, Auriga.Sirius.Sequence.Description.IBasicMessageMapping
    {
        /// <summary>
        /// All conditional styles.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IConditionalEdgeStyleDescription> ConditionnalStyles => this.backingConditionnalStyles ??= new Auriga.ContainerList<Auriga.Sirius.Diagram.Description.IConditionalEdgeStyleDescription>(this);

        /// <summary>
        /// Backing field for <see cref="ConditionnalStyles"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IConditionalEdgeStyleDescription> backingConditionnalStyles;

        /// <summary>
        /// true if the init/refresh operations should create elements for this mapping.
        /// </summary>
        public bool CreateElements { get; set; }

        /// <summary>
        /// The tool that describes how to delete this element.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Tool.IDeleteElementDescription DeletionDescription { get; set; }

        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationCreationDescription> DetailDescriptions { get; } = new List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationCreationDescription>();

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// The type of the target elements that are represented by this edge. Useful only if useDomainElement is true.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// Gets or sets the double click description.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Tool.IDoubleClickDescription DoubleClickDescription { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The tool that describes what to do when the user edits the label of the elements.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Tool.IDirectEditLabel LabelDirectEdit { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationNavigationDescription> NavigationDescriptions { get; } = new List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationNavigationDescription>();

        /// <summary>
        /// Gets or sets the oblique.
        /// </summary>
        public bool Oblique { get; set; }

        /// <summary>
        /// Gets the paste descriptions.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.Description.Tool.IPasteDescription> PasteDescriptions { get; } = new List<Auriga.Sirius.Viewpoint.Description.Tool.IPasteDescription>();

        /// <summary>
        /// Gets or sets the path expression.
        /// </summary>
        public string PathExpression { get; set; }

        /// <summary>
        /// Gets the path node mapping.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.IAbstractNodeMapping> PathNodeMapping { get; } = new List<Auriga.Sirius.Diagram.Description.IAbstractNodeMapping>();

        /// <summary>
        /// An expression guarding the effect if evaluated to false.
        /// </summary>
        public string PreconditionExpression { get; set; }

        /// <summary>
        /// Gets or sets the receiving end finder expression.
        /// </summary>
        public string ReceivingEndFinderExpression { get; set; }

        /// <summary>
        /// Gets the reconnections.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.Tool.IReconnectEdgeDescription> Reconnections { get; } = new List<Auriga.Sirius.Diagram.Description.Tool.IReconnectEdgeDescription>();

        /// <summary>
        /// In the default case, candidates of a mapping are all EObjet owned by the semantic element of the view container. The semanticCandidatesExpression is an expression that returns the list of EObject that are candidates of the mapping instead of the candidates of the default case. The context of the expression is the semantic element of the view container.
        /// </summary>
        public string SemanticCandidatesExpression { get; set; }

        /// <summary>
        /// The elements that are represented by this connection.
        /// </summary>
        public string SemanticElements { get; set; }

        /// <summary>
        /// Gets or sets the sending end finder expression.
        /// </summary>
        public string SendingEndFinderExpression { get; set; }

        /// <summary>
        /// An expression to retrieve the sources of an edge.
        /// All this objects will depends on the semanticCandidatesExpression. By default all objects are the objects that are in the enclosing viewpoint's rootContent subtree. If the semanticCandidatesExpression is filled in then all the objects will be the objects of the returned list.
        /// This attribute is taking in account only if the useDomainElement is true.
        /// </summary>
        public string SourceFinderExpression { get; set; }

        /// <summary>
        /// The mapping that creates EdgeTargets that are the sources of the ViewEdges that are created by this EdgeMapping.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> SourceMapping { get; } = new List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping>();

        /// <summary>
        /// The style of the edge.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Style.IEdgeStyleDescription Style
        {
            get => this.backingStyle;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingStyle = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Style"/>.
        /// </summary>
        private Auriga.Sirius.Diagram.Description.Style.IEdgeStyleDescription backingStyle;

        /// <summary>
        /// Set to true to force the synchronization of the elements of this mapping when the current diagram is in an unsynchronized mode.
        /// This option is used only if createElements is true and the diagram which contain the elements of this mapping is unsynchronized.
        /// </summary>
        public bool? SynchronizationLock { get; set; }

        /// <summary>
        /// An expression computing the targeted semantic element of this edge.
        /// If this attribut is not filled in. Then the target element will be :
        /// - The target element of the source node if useDomainElement is false.
        /// - The object that is an instance of domainClass value if useDomainElement is true.
        /// </summary>
        public string TargetExpression { get; set; }

        /// <summary>
        /// An expression  to retrieve the targets of an edge.
        /// The context of the expression depends on the useDomainElement value. If useDomainElement is true, the expression will be evaluated with all objects that are instances of the type represented by the domainClass value.
        /// All this objects will depends on the semanticCandidatesExpression. By default all objects are the objects that are in the enclosing viewpoint's rootContent subtree. If the semanticCandidatesExpression is filled in then all the objects will be the objects of the returned list.
        /// </summary>
        public string TargetFinderExpression { get; set; }

        /// <summary>
        /// The mapping that creates EdgeTargets that are the targets of the ViewEdges that are created by this EdgeMapping.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> TargetMapping { get; } = new List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping>();

        /// <summary>
        /// Gets or sets the use domain element.
        /// </summary>
        public bool? UseDomainElement { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>BasicMessageMapping</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.ConditionnalStyles)
            {
                yield return element;
            }

            if (this.Style != null)
            {
                yield return this.Style;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
