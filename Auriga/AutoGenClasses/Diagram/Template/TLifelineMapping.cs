// ------------------------------------------------------------------------------------------------
// <copyright file="TLifelineMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Sequence.Template
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>TLifelineMapping</c> class.
    /// </summary>
    public partial class TLifelineMapping : Auriga.Core.AurigaElement, Auriga.Diagram.Sequence.Template.ITLifelineMapping
    {
        /// <summary>
        /// All conditional styles.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Sequence.Template.ITConditionalLifelineStyle> ConditionalLifeLineStyles => this.backingConditionalLifeLineStyles ??= new Auriga.Core.ContainerList<Auriga.Diagram.Sequence.Template.ITConditionalLifelineStyle>(this);

        /// <summary>
        /// Backing field for <see cref="ConditionalLifeLineStyles"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Sequence.Template.ITConditionalLifelineStyle> backingConditionalLifeLineStyles;

        /// <summary>
        /// The domain class of the mapping.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// Gets or sets the end of life style.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Style.INodeStyleDescription EndOfLifeStyle
        {
            get => this.backingEndOfLifeStyle;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingEndOfLifeStyle = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="EndOfLifeStyle"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.Style.INodeStyleDescription backingEndOfLifeStyle;

        /// <summary>
        /// Gets or sets the eol visible expression.
        /// </summary>
        public string EolVisibleExpression { get; set; }

        /// <summary>
        /// Gets the execution mappings.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Sequence.Template.ITExecutionMapping> ExecutionMappings => this.backingExecutionMappings ??= new Auriga.Core.ContainerList<Auriga.Diagram.Sequence.Template.ITExecutionMapping>(this);

        /// <summary>
        /// Backing field for <see cref="ExecutionMappings"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Sequence.Template.ITExecutionMapping> backingExecutionMappings;

        /// <summary>
        /// Gets or sets the instance role style.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Style.INodeStyleDescription InstanceRoleStyle
        {
            get => this.backingInstanceRoleStyle;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingInstanceRoleStyle = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="InstanceRoleStyle"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.Style.INodeStyleDescription backingInstanceRoleStyle;

        /// <summary>
        /// Gets or sets the lifeline style.
        /// </summary>
        public Auriga.Diagram.Sequence.Template.ITLifelineStyle LifelineStyle
        {
            get => this.backingLifelineStyle;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingLifelineStyle = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="LifelineStyle"/>.
        /// </summary>
        private Auriga.Diagram.Sequence.Template.ITLifelineStyle backingLifelineStyle;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the outputs.
        /// </summary>
        public List<object> Outputs { get; } = new List<object>();

        /// <summary>
        /// In the default case, candidates of a mapping are all EObjet owned by the semantic element of the view container. The semanticCandidatesExpression is an expression that returns the list of EObject that are candidates of the mapping instead of the candidates of the default case. The context of the expression is the semantic element of the view container.
        /// </summary>
        public string SemanticCandidatesExpression { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>TLifelineMapping</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.ConditionalLifeLineStyles)
            {
                yield return element;
            }

            if (this.EndOfLifeStyle != null)
            {
                yield return this.EndOfLifeStyle;
            }

            foreach (var element in this.ExecutionMappings)
            {
                yield return element;
            }

            if (this.InstanceRoleStyle != null)
            {
                yield return this.InstanceRoleStyle;
            }

            if (this.LifelineStyle != null)
            {
                yield return this.LifelineStyle;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
