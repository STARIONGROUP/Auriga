// ------------------------------------------------------------------------------------------------
// <copyright file="TSequenceDiagram.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>TSequenceDiagram</c> class.
    /// </summary>
    public partial class TSequenceDiagram : Auriga.AurigaElement, Auriga.Sirius.Sequence.Template.ITSequenceDiagram
    {
        /// <summary>
        /// The domain class of the mapping.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// Gets or sets the ends ordering.
        /// </summary>
        public string EndsOrdering { get; set; }

        /// <summary>
        /// Gets the lifeline mappings.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Sequence.Template.ITLifelineMapping> LifelineMappings => this.backingLifelineMappings ??= new Auriga.ContainerList<Auriga.Sirius.Sequence.Template.ITLifelineMapping>(this);

        /// <summary>
        /// Backing field for <see cref="LifelineMappings"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Sequence.Template.ITLifelineMapping> backingLifelineMappings;

        /// <summary>
        /// Gets the message mappings.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Sequence.Template.ITMessageMapping> MessageMappings => this.backingMessageMappings ??= new Auriga.ContainerList<Auriga.Sirius.Sequence.Template.ITMessageMapping>(this);

        /// <summary>
        /// Backing field for <see cref="MessageMappings"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Sequence.Template.ITMessageMapping> backingMessageMappings;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the outputs.
        /// </summary>
        public List<object> Outputs { get; } = new List<object>();

        /// <summary>
        /// Gets the owned representations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IRepresentationDescription> OwnedRepresentations => this.backingOwnedRepresentations ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.IRepresentationDescription>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRepresentations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IRepresentationDescription> backingOwnedRepresentations;

        /// <summary>
        /// Gets the elements directly contained by this <c>TSequenceDiagram</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.LifelineMappings)
            {
                yield return element;
            }

            foreach (var element in this.MessageMappings)
            {
                yield return element;
            }

            foreach (var element in this.OwnedRepresentations)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
