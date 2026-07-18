// ------------------------------------------------------------------------------------------------
// <copyright file="OperandMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Sequence.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>OperandMapping</c> class.
    /// </summary>
    public partial class OperandMapping : Auriga.Core.AurigaElement, Auriga.Diagram.Sequence.Description.IOperandMapping
    {
        /// <summary>
        /// The mapping for nodes that are on the border of nodes created by this mapping.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.INodeMapping> BorderedNodeMappings => this.backingBorderedNodeMappings ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.INodeMapping>(this);

        /// <summary>
        /// Backing field for <see cref="BorderedNodeMappings"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.INodeMapping> backingBorderedNodeMappings;

        /// <summary>
        /// Set to List if you want a container acting like a list.
        /// </summary>
        public Auriga.Diagram.Diagram.ContainerLayout ChildrenPresentation { get; set; } = Auriga.Diagram.Diagram.ContainerLayout.FreeForm;

        /// <summary>
        /// Gets the conditionnal styles.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IConditionalContainerStyleDescription> ConditionnalStyles => this.backingConditionnalStyles ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.IConditionalContainerStyleDescription>(this);

        /// <summary>
        /// Backing field for <see cref="ConditionnalStyles"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IConditionalContainerStyleDescription> backingConditionnalStyles;

        /// <summary>
        /// true if the init/refresh operations should create elements for this mapping.
        /// </summary>
        public bool CreateElements { get; set; } = true;

        /// <summary>
        /// The tool that describes how to delete this element.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Tool.IDeleteElementDescription DeletionDescription { get; set; }

        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription> DetailDescriptions { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription>();

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; } = "";

        /// <summary>
        /// The domain class of the mapping.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// Gets or sets the double click description.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Tool.IDoubleClickDescription DoubleClickDescription { get; set; }

        /// <summary>
        /// Gets the drop descriptions.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.Tool.IContainerDropDescription> DropDescriptions { get; } = new List<Auriga.Diagram.Diagram.Description.Tool.IContainerDropDescription>();

        /// <summary>
        /// Gets or sets the finishing end finder expression.
        /// </summary>
        public string FinishingEndFinderExpression { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The tool that describes what to do when the user edits the label of the elements.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Tool.IDirectEditLabel LabelDirectEdit { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription> NavigationDescriptions { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription>();

        /// <summary>
        /// Gets the paste descriptions.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IPasteDescription> PasteDescriptions { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IPasteDescription>();

        /// <summary>
        /// An expression guarding the effect if evaluated to false.
        /// </summary>
        public string PreconditionExpression { get; set; } = "";

        /// <summary>
        /// Gets the reused bordered node mappings.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.INodeMapping> ReusedBorderedNodeMappings { get; } = new List<Auriga.Diagram.Diagram.Description.INodeMapping>();

        /// <summary>
        /// Gets the reused container mappings.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.IContainerMapping> ReusedContainerMappings { get; } = new List<Auriga.Diagram.Diagram.Description.IContainerMapping>();

        /// <summary>
        /// Gets the reused node mappings.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.INodeMapping> ReusedNodeMappings { get; } = new List<Auriga.Diagram.Diagram.Description.INodeMapping>();

        /// <summary>
        /// In the default case, candidates of a mapping are all EObjet owned by the semantic element of the view container. The semanticCandidatesExpression is an expression that returns the list of EObject that are candidates of the mapping instead of the candidates of the default case. The context of the expression is the semantic element of the view container.
        /// </summary>
        public string SemanticCandidatesExpression { get; set; }

        /// <summary>
        /// The elements that are represented by this connection.
        /// </summary>
        public string SemanticElements { get; set; }

        /// <summary>
        /// Gets or sets the starting end finder expression.
        /// </summary>
        public string StartingEndFinderExpression { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Style.IContainerStyleDescription Style
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
        private Auriga.Diagram.Diagram.Description.Style.IContainerStyleDescription backingStyle;

        /// <summary>
        /// Gets the sub container mappings.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IContainerMapping> SubContainerMappings => this.backingSubContainerMappings ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.IContainerMapping>(this);

        /// <summary>
        /// Backing field for <see cref="SubContainerMappings"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IContainerMapping> backingSubContainerMappings;

        /// <summary>
        /// Gets the sub node mappings.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.INodeMapping> SubNodeMappings => this.backingSubNodeMappings ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.INodeMapping>(this);

        /// <summary>
        /// Backing field for <see cref="SubNodeMappings"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.INodeMapping> backingSubNodeMappings;

        /// <summary>
        /// Set to true to force the synchronization of the elements of this mapping when the current diagram is in an unsynchronized mode.
        /// This option is used only if createElements is true and the diagram which contain the elements of this mapping is unsynchronized.
        /// </summary>
        public bool? SynchronizationLock { get; set; } = false;

        /// <summary>
        /// Gets the elements directly contained by this <c>OperandMapping</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.BorderedNodeMappings)
            {
                yield return element;
            }

            foreach (var element in this.ConditionnalStyles)
            {
                yield return element;
            }

            if (this.Style != null)
            {
                yield return this.Style;
            }

            foreach (var element in this.SubContainerMappings)
            {
                yield return element;
            }

            foreach (var element in this.SubNodeMappings)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
