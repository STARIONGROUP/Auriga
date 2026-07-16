// ------------------------------------------------------------------------------------------------
// <copyright file="TExecutionMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence.Template
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>TExecutionMapping</c> class.
    /// </summary>
    public partial class TExecutionMapping : Auriga.Core.AurigaElement, Auriga.Sirius.Sequence.Template.ITExecutionMapping
    {
        /// <summary>
        /// Gets the conditional styles.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Sequence.Template.ITConditionalExecutionStyle> ConditionalStyles => this.backingConditionalStyles ??= new Auriga.Core.ContainerList<Auriga.Sirius.Sequence.Template.ITConditionalExecutionStyle>(this);

        /// <summary>
        /// Backing field for <see cref="ConditionalStyles"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Sequence.Template.ITConditionalExecutionStyle> backingConditionalStyles;

        /// <summary>
        /// The domain class of the mapping.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// Gets the execution mappings.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Sequence.Template.ITExecutionMapping> ExecutionMappings => this.backingExecutionMappings ??= new Auriga.Core.ContainerList<Auriga.Sirius.Sequence.Template.ITExecutionMapping>(this);

        /// <summary>
        /// Backing field for <see cref="ExecutionMappings"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Sequence.Template.ITExecutionMapping> backingExecutionMappings;

        /// <summary>
        /// Gets or sets the finishing end finder expression.
        /// </summary>
        public string FinishingEndFinderExpression { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the outputs.
        /// </summary>
        public List<object> Outputs { get; } = new List<object>();

        /// <summary>
        /// Gets or sets the recursive.
        /// </summary>
        public bool Recursive { get; set; }

        /// <summary>
        /// In the default case, candidates of a mapping are all EObjet owned by the semantic element of the view container. The semanticCandidatesExpression is an expression that returns the list of EObject that are candidates of the mapping instead of the candidates of the default case. The context of the expression is the semantic element of the view container.
        /// </summary>
        public string SemanticCandidatesExpression { get; set; }

        /// <summary>
        /// Gets or sets the starting end finder expression.
        /// </summary>
        public string StartingEndFinderExpression { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        public Auriga.Sirius.Sequence.Template.ITExecutionStyle Style
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
        private Auriga.Sirius.Sequence.Template.ITExecutionStyle backingStyle;

        /// <summary>
        /// Gets the elements directly contained by this <c>TExecutionMapping</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.ConditionalStyles)
            {
                yield return element;
            }

            foreach (var element in this.ExecutionMappings)
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
