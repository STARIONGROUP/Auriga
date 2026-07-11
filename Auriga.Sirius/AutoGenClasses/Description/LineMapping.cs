// ------------------------------------------------------------------------------------------------
// <copyright file="LineMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Table.Description
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>LineMapping</c> class.
    /// </summary>
    public partial class LineMapping : Auriga.Core.AurigaElement, Auriga.Sirius.Table.Description.ILineMapping
    {
        /// <summary>
        /// Gets the all sub lines.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Table.Description.ILineMapping> AllSubLines => Enumerable.Empty<Auriga.Sirius.Table.Description.ILineMapping>();

        /// <summary>
        /// Gets the background conditional style.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.IBackgroundConditionalStyle> BackgroundConditionalStyle => this.backingBackgroundConditionalStyle ??= new Auriga.Core.ContainerList<Auriga.Sirius.Table.Description.IBackgroundConditionalStyle>(this);

        /// <summary>
        /// Backing field for <see cref="BackgroundConditionalStyle"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.IBackgroundConditionalStyle> backingBackgroundConditionalStyle;

        /// <summary>
        /// Gets the create.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.ICreateLineTool> Create => this.backingCreate ??= new Auriga.Core.ContainerList<Auriga.Sirius.Table.Description.ICreateLineTool>(this);

        /// <summary>
        /// Backing field for <see cref="Create"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.ICreateLineTool> backingCreate;

        /// <summary>
        /// Gets or sets the default background.
        /// </summary>
        public Auriga.Sirius.Table.Description.IBackgroundStyleDescription DefaultBackground
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
        private Auriga.Sirius.Table.Description.IBackgroundStyleDescription backingDefaultBackground;

        /// <summary>
        /// Gets or sets the default foreground.
        /// </summary>
        public Auriga.Sirius.Table.Description.IForegroundStyleDescription DefaultForeground
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
        private Auriga.Sirius.Table.Description.IForegroundStyleDescription backingDefaultForeground;

        /// <summary>
        /// Gets or sets the delete.
        /// </summary>
        public Auriga.Sirius.Table.Description.IDeleteLineTool Delete
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
        private Auriga.Sirius.Table.Description.IDeleteLineTool backingDelete;

        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationCreationDescription> DetailDescriptions { get; } = new List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationCreationDescription>();

        /// <summary>
        /// Gets or sets the domain class.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// Gets the foreground conditional style.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.IForegroundConditionalStyle> ForegroundConditionalStyle => this.backingForegroundConditionalStyle ??= new Auriga.Core.ContainerList<Auriga.Sirius.Table.Description.IForegroundConditionalStyle>(this);

        /// <summary>
        /// Backing field for <see cref="ForegroundConditionalStyle"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.IForegroundConditionalStyle> backingForegroundConditionalStyle;

        /// <summary>
        /// Gets or sets the header label expression.
        /// </summary>
        public string HeaderLabelExpression { get; set; }

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
        public List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationNavigationDescription> NavigationDescriptions { get; } = new List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationNavigationDescription>();

        /// <summary>
        /// Gets the owned sub lines.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.ILineMapping> OwnedSubLines => this.backingOwnedSubLines ??= new Auriga.Core.ContainerList<Auriga.Sirius.Table.Description.ILineMapping>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedSubLines"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.ILineMapping> backingOwnedSubLines;

        /// <summary>
        /// Gets the reused in mappings.
        /// </summary>
        public List<Auriga.Sirius.Table.Description.ILineMapping> ReusedInMappings { get; } = new List<Auriga.Sirius.Table.Description.ILineMapping>();

        /// <summary>
        /// Gets the reused sub lines.
        /// </summary>
        public List<Auriga.Sirius.Table.Description.ILineMapping> ReusedSubLines { get; } = new List<Auriga.Sirius.Table.Description.ILineMapping>();

        /// <summary>
        /// Gets or sets the semantic candidates expression.
        /// </summary>
        public string SemanticCandidatesExpression { get; set; }

        /// <summary>
        /// The elements that are represented by this mapping.
        /// </summary>
        public string SemanticElements { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>LineMapping</c>.
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

            foreach (var element in this.OwnedSubLines)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
