// ------------------------------------------------------------------------------------------------
// <copyright file="ITSequenceDiagram.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>TSequenceDiagram</c> interface.
    /// </summary>
    public partial interface ITSequenceDiagram : Auriga.Diagram.Viewpoint.Description.IRepresentationTemplate, Auriga.Diagram.Sequence.Template.ITTransformer
    {
        /// <summary>
        /// The domain class of the mapping.
        /// </summary>
        string DomainClass { get; set; }

        /// <summary>
        /// Gets or sets the ends ordering.
        /// </summary>
        string EndsOrdering { get; set; }

        /// <summary>
        /// Gets the lifeline mappings.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Sequence.Template.ITLifelineMapping> LifelineMappings { get; }

        /// <summary>
        /// Gets the message mappings.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Sequence.Template.ITMessageMapping> MessageMappings { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
