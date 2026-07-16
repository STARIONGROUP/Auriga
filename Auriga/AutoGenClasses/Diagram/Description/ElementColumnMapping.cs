// ------------------------------------------------------------------------------------------------
// <copyright file="ElementColumnMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Table.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>ElementColumnMapping</c> class.
    /// </summary>
    public partial class ElementColumnMapping : Auriga.Core.AurigaElement, Auriga.Diagram.Table.Description.IElementColumnMapping
    {
        /// <summary>
        /// Gets the background conditional style.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.IBackgroundConditionalStyle> BackgroundConditionalStyle => this.backingBackgroundConditionalStyle ??= new Auriga.Core.ContainerList<Auriga.Diagram.Table.Description.IBackgroundConditionalStyle>(this);

        /// <summary>
        /// Backing field for <see cref="BackgroundConditionalStyle"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.IBackgroundConditionalStyle> backingBackgroundConditionalStyle;

        /// <summary>
        /// Gets the create.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.ICreateColumnTool> Create => this.backingCreate ??= new Auriga.Core.ContainerList<Auriga.Diagram.Table.Description.ICreateColumnTool>(this);

        /// <summary>
        /// Backing field for <see cref="Create"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.ICreateColumnTool> backingCreate;

        /// <summary>
        /// Gets or sets the default background.
        /// </summary>
        public Auriga.Diagram.Table.Description.IBackgroundStyleDescription DefaultBackground
        {
            get => this.backingDefaultBackground;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingDefaultBackground = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="DefaultBackground"/>.
        /// </summary>
        private Auriga.Diagram.Table.Description.IBackgroundStyleDescription backingDefaultBackground;

        /// <summary>
        /// Gets or sets the default foreground.
        /// </summary>
        public Auriga.Diagram.Table.Description.IForegroundStyleDescription DefaultForeground
        {
            get => this.backingDefaultForeground;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingDefaultForeground = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="DefaultForeground"/>.
        /// </summary>
        private Auriga.Diagram.Table.Description.IForegroundStyleDescription backingDefaultForeground;

        /// <summary>
        /// Gets or sets the delete.
        /// </summary>
        public Auriga.Diagram.Table.Description.IDeleteColumnTool Delete
        {
            get => this.backingDelete;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingDelete = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Delete"/>.
        /// </summary>
        private Auriga.Diagram.Table.Description.IDeleteColumnTool backingDelete;

        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription> DetailDescriptions { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription>();

        /// <summary>
        /// Gets or sets the domain class.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// Gets the foreground conditional style.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.IForegroundConditionalStyle> ForegroundConditionalStyle => this.backingForegroundConditionalStyle ??= new Auriga.Core.ContainerList<Auriga.Diagram.Table.Description.IForegroundConditionalStyle>(this);

        /// <summary>
        /// Backing field for <see cref="ForegroundConditionalStyle"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.IForegroundConditionalStyle> backingForegroundConditionalStyle;

        /// <summary>
        /// Gets or sets the header label expression.
        /// </summary>
        public string HeaderLabelExpression { get; set; }

        /// <summary>
        /// The initial width of the column (calculated if not available).
        /// </summary>
        public int? InitialWidth { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription> NavigationDescriptions { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription>();

        /// <summary>
        /// Gets or sets the semantic candidates expression.
        /// </summary>
        public string SemanticCandidatesExpression { get; set; }

        /// <summary>
        /// The elements that are represented by this mapping.
        /// </summary>
        public string SemanticElements { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>ElementColumnMapping</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.BackgroundConditionalStyle)
            {
                yield return element;
            }

            foreach (var element in this.Create)
            {
                yield return element;
            }

            if (this.DefaultBackground != null)
            {
                yield return this.DefaultBackground;
            }

            if (this.DefaultForeground != null)
            {
                yield return this.DefaultForeground;
            }

            if (this.Delete != null)
            {
                yield return this.Delete;
            }

            foreach (var element in this.ForegroundConditionalStyle)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
