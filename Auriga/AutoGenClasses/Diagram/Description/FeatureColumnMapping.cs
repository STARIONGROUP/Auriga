// ------------------------------------------------------------------------------------------------
// <copyright file="FeatureColumnMapping.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>FeatureColumnMapping</c> class.
    /// </summary>
    public partial class FeatureColumnMapping : Auriga.Core.AurigaElement, Auriga.Diagram.Table.Description.IFeatureColumnMapping
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
        /// Gets or sets the can edit.
        /// </summary>
        public string CanEdit { get; set; }

        /// <summary>
        /// Gets or sets the cell editor.
        /// </summary>
        public Auriga.Diagram.Table.Description.ICellEditorTool CellEditor
        {
            get => this.backingCellEditor;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingCellEditor = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="CellEditor"/>.
        /// </summary>
        private Auriga.Diagram.Table.Description.ICellEditorTool backingCellEditor;

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
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription> DetailDescriptions { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription>();

        /// <summary>
        /// Gets or sets the direct edit.
        /// </summary>
        public Auriga.Diagram.Table.Description.ILabelEditTool DirectEdit
        {
            get => this.backingDirectEdit;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingDirectEdit = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="DirectEdit"/>.
        /// </summary>
        private Auriga.Diagram.Table.Description.ILabelEditTool backingDirectEdit;

        /// <summary>
        /// Gets or sets the feature name.
        /// </summary>
        public string FeatureName { get; set; }

        /// <summary>
        /// An expression to get the parent of the feature. By default, the parent of the feature is the semantic element of the line.
        /// </summary>
        public string FeatureParentExpression { get; set; }

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
        /// Gets or sets the label expression.
        /// </summary>
        public string LabelExpression { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription> NavigationDescriptions { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription>();

        /// <summary>
        /// The elements that are represented by this mapping.
        /// </summary>
        public string SemanticElements { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>FeatureColumnMapping</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.BackgroundConditionalStyle)
            {
                yield return element;
            }

            if (this.CellEditor != null)
            {
                yield return this.CellEditor;
            }

            if (this.DefaultBackground != null)
            {
                yield return this.DefaultBackground;
            }

            if (this.DefaultForeground != null)
            {
                yield return this.DefaultForeground;
            }

            if (this.DirectEdit != null)
            {
                yield return this.DirectEdit;
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
