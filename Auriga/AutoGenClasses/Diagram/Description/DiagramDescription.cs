// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramDescription.cs" company="Starion Group S.A.">
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
    public partial class DiagramDescription : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.IDiagramDescription
    {
        /// <summary>
        /// Gets the additional layers.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IAdditionalLayer> AdditionalLayers => this.backingAdditionalLayers ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.IAdditionalLayer>(this);

        /// <summary>
        /// Backing field for <see cref="AdditionalLayers"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IAdditionalLayer> backingAdditionalLayers;

        /// <summary>
        /// Color of the diagram background, white if unset.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IColorDescription BackgroundColor { get; set; }

        /// <summary>
        /// All concerns of the viewpoint. A concern is a set of filters, validations and behaviors.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Concern.IConcernSet Concerns
        {
            get => this.backingConcerns;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingConcerns = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Concerns"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.Concern.IConcernSet backingConcerns;

        /// <summary>
        /// container mappings that are owned by this simple mapping.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IContainerMapping> ContainerMappings => this.backingContainerMappings ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.IContainerMapping>(this);

        /// <summary>
        /// Backing field for <see cref="ContainerMappings"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IContainerMapping> backingContainerMappings;

        /// <summary>
        /// The default concern to use.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Concern.IConcernDescription DefaultConcern { get; set; }

        /// <summary>
        /// Gets or sets the default layer.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.ILayer DefaultLayer
        {
            get => this.backingDefaultLayer;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingDefaultLayer = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="DefaultLayer"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.ILayer backingDefaultLayer;

        /// <summary>
        /// Gets or sets the diagram initialisation.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation DiagramInitialisation
        {
            get => this.backingDiagramInitialisation;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingDiagramInitialisation = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="DiagramInitialisation"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation backingDiagramInitialisation;

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// The domain class of the viewpoint.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// Gets the drop descriptions.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.Tool.IContainerDropDescription> DropDescriptions { get; } = new List<Auriga.Diagram.Diagram.Description.Tool.IContainerDropDescription>();

        /// <summary>
        /// Edge mapping imports that are owned by this simple mapping.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IEdgeMappingImport> EdgeMappingImports => this.backingEdgeMappingImports ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.IEdgeMappingImport>(this);

        /// <summary>
        /// Backing field for <see cref="EdgeMappingImports"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IEdgeMappingImport> backingEdgeMappingImports;

        /// <summary>
        /// Edge mappings that are owned by this simple mapping.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IEdgeMapping> EdgeMappings => this.backingEdgeMappings ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.IEdgeMapping>(this);

        /// <summary>
        /// Backing field for <see cref="EdgeMappings"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IEdgeMapping> backingEdgeMappings;

        /// <summary>
        /// Boolean indicating whether or not to show dynamic popup bars with creation tools.
        /// </summary>
        public bool? EnablePopupBars { get; set; }

        /// <summary>
        /// Gets or sets the end user documentation.
        /// </summary>
        public string EndUserDocumentation { get; set; }

        /// <summary>
        /// Filters that are owned by this simple mapping.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.Filter.IFilterDescription> Filters => this.backingFilters ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.Filter.IFilterDescription>(this);

        /// <summary>
        /// Backing field for <see cref="Filters"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.Filter.IFilterDescription> backingFilters;

        /// <summary>
        /// Gets or sets the init.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription Init { get; set; }

        /// <summary>
        /// Set to true if your want your representation to be automatically created when initializing a new session.
        /// </summary>
        public bool Initialisation { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the layout.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.ILayout Layout
        {
            get => this.backingLayout;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingLayout = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Layout"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.ILayout backingLayout;

        /// <summary>
        /// You might use this reference to statically bind your representation with a set of Ecore packages. Keep in mind that this is not mandatory.
        /// </summary>
        public List<object> Metamodel { get; } = new List<object>();

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Node mappings that are owned by this simple mapping.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.INodeMapping> NodeMappings => this.backingNodeMappings ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.INodeMapping>(this);

        /// <summary>
        /// Backing field for <see cref="NodeMappings"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.INodeMapping> backingNodeMappings;

        /// <summary>
        /// Gets the paste descriptions.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IPasteDescription> PasteDescriptions { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IPasteDescription>();

        /// <summary>
        /// The predicate that allows (or not) to create a viewpoint from a Meta Class.
        /// </summary>
        public string PreconditionExpression { get; set; }

        /// <summary>
        /// The reused mappings.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping> ReusedMappings { get; } = new List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping>();

        /// <summary>
        /// Tools that are reused by this viewpoint.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription> ReusedTools { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription>();

        /// <summary>
        /// Gets or sets the root expression.
        /// </summary>
        public string RootExpression { get; set; }

        /// <summary>
        /// Gets or sets the show on startup.
        /// </summary>
        public bool? ShowOnStartup { get; set; }

        /// <summary>
        /// The default title of the representation. (new + name if empty)
        /// </summary>
        public string TitleExpression { get; set; }

        /// <summary>
        /// A tool section encloses many tools
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Tool.IToolSection ToolSection
        {
            get => this.backingToolSection;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingToolSection = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="ToolSection"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.Tool.IToolSection backingToolSection;

        /// <summary>
        /// The validations rules
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Validation.IValidationSet ValidationSet
        {
            get => this.backingValidationSet;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingValidationSet = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="ValidationSet"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Validation.IValidationSet backingValidationSet;

        /// <summary>
        /// Gets the elements directly contained by this <c>DiagramDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.AdditionalLayers)
            {
                yield return element;
            }

            if (this.Concerns != null)
            {
                yield return this.Concerns;
            }

            foreach (var element in this.ContainerMappings)
            {
                yield return element;
            }

            if (this.DefaultLayer != null)
            {
                yield return this.DefaultLayer;
            }

            if (this.DiagramInitialisation != null)
            {
                yield return this.DiagramInitialisation;
            }

            foreach (var element in this.EdgeMappingImports)
            {
                yield return element;
            }

            foreach (var element in this.EdgeMappings)
            {
                yield return element;
            }

            foreach (var element in this.Filters)
            {
                yield return element;
            }

            if (this.Layout != null)
            {
                yield return this.Layout;
            }

            foreach (var element in this.NodeMappings)
            {
                yield return element;
            }

            if (this.ToolSection != null)
            {
                yield return this.ToolSection;
            }

            if (this.ValidationSet != null)
            {
                yield return this.ValidationSet;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
