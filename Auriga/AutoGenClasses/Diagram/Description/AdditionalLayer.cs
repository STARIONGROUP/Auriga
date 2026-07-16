// ------------------------------------------------------------------------------------------------
// <copyright file="AdditionalLayer.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>AdditionalLayer</c> class.
    /// </summary>
    public partial class AdditionalLayer : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.IAdditionalLayer
    {
        /// <summary>
        /// Gets or sets the active by default.
        /// </summary>
        public bool? ActiveByDefault { get; set; }

        /// <summary>
        /// All tools of the viewpoint.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription> AllTools => Enumerable.Empty<Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription>();

        /// <summary>
        /// container mappings that are owned by this simple mapping.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IContainerMapping> ContainerMappings => this.backingContainerMappings ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.IContainerMapping>(this);

        /// <summary>
        /// Backing field for <see cref="ContainerMappings"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IContainerMapping> backingContainerMappings;

        /// <summary>
        /// Gets or sets the customization.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.ICustomization Customization
        {
            get => this.backingCustomization;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingCustomization = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Customization"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.ICustomization backingCustomization;

        /// <summary>
        /// Gets or sets the decoration descriptions set.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IDecorationDescriptionsSet DecorationDescriptionsSet
        {
            get => this.backingDecorationDescriptionsSet;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingDecorationDescriptionsSet = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="DecorationDescriptionsSet"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.IDecorationDescriptionsSet backingDecorationDescriptionsSet;

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

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
        /// Gets or sets the end user documentation.
        /// </summary>
        public string EndUserDocumentation { get; set; }

        /// <summary>
        /// image path to use as an icon for the layer
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

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
        /// Gets or sets the optional.
        /// </summary>
        public bool? Optional { get; set; }

        /// <summary>
        /// Add here any mapping you want to reuse from another layer or diagram.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping> ReusedMappings { get; } = new List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping>();

        /// <summary>
        /// Tools that are reused by this viewpoint.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription> ReusedTools { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription>();

        /// <summary>
        /// A tool section encloses many tools
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.Tool.IToolSection> ToolSections => this.backingToolSections ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.Tool.IToolSection>(this);

        /// <summary>
        /// Backing field for <see cref="ToolSections"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.Tool.IToolSection> backingToolSections;

        /// <summary>
        /// Gets the elements directly contained by this <c>AdditionalLayer</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.ContainerMappings)
            {
                yield return element;
            }

            if (this.Customization != null)
            {
                yield return this.Customization;
            }

            if (this.DecorationDescriptionsSet != null)
            {
                yield return this.DecorationDescriptionsSet;
            }

            foreach (var element in this.EdgeMappingImports)
            {
                yield return element;
            }

            foreach (var element in this.EdgeMappings)
            {
                yield return element;
            }

            foreach (var element in this.NodeMappings)
            {
                yield return element;
            }

            foreach (var element in this.ToolSections)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
