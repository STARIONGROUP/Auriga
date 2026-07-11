// ------------------------------------------------------------------------------------------------
// <copyright file="TCreationMessageMapping.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>TCreationMessageMapping</c> class.
    /// </summary>
    public partial class TCreationMessageMapping : Auriga.AurigaElement, Auriga.Sirius.Sequence.Template.ITCreationMessageMapping
    {
        /// <summary>
        /// Gets the conditional style.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Sequence.Template.ITConditionalMessageStyle> ConditionalStyle => this.backingConditionalStyle ??= new Auriga.ContainerList<Auriga.Sirius.Sequence.Template.ITConditionalMessageStyle>(this);

        /// <summary>
        /// Backing field for <see cref="ConditionalStyle"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Sequence.Template.ITConditionalMessageStyle> backingConditionalStyle;

        /// <summary>
        /// The domain class of the mapping.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the outputs.
        /// </summary>
        public List<object> Outputs { get; } = new List<object>();

        /// <summary>
        /// Gets or sets the receiving end finder expression.
        /// </summary>
        public string ReceivingEndFinderExpression { get; set; }

        /// <summary>
        /// In the default case, candidates of a mapping are all EObjet owned by the semantic element of the
        /// view container. The semanticCandidatesExpression is an expression that returns the list of EObject
        /// that are candidates of the mapping instead of the candidates of the default case. The context of the
        /// expression is the semantic element of the view container.
        /// </summary>
        public string SemanticCandidatesExpression { get; set; }

        /// <summary>
        /// Gets or sets the sending end finder expression.
        /// </summary>
        public string SendingEndFinderExpression { get; set; }

        /// <summary>
        /// Gets the source.
        /// </summary>
        public List<Auriga.Sirius.Sequence.Template.ITMessageExtremity> Source { get; } = new List<Auriga.Sirius.Sequence.Template.ITMessageExtremity>();

        /// <summary>
        /// The elements that are represented by this connection.
        /// </summary>
        public string SourceFinderExpression { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        public Auriga.Sirius.Sequence.Template.ITMessageStyle Style
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
        private Auriga.Sirius.Sequence.Template.ITMessageStyle backingStyle;

        /// <summary>
        /// Gets the target.
        /// </summary>
        public List<Auriga.Sirius.Sequence.Template.ITLifelineMapping> Target { get; } = new List<Auriga.Sirius.Sequence.Template.ITLifelineMapping>();

        /// <summary>
        /// The elements that are represented by this connection.
        /// </summary>
        public string TargetFinderExpression { get; set; }

        /// <summary>
        /// Gets or sets the use domain element.
        /// </summary>
        public bool? UseDomainElement { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>TCreationMessageMapping</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.ConditionalStyle)
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
