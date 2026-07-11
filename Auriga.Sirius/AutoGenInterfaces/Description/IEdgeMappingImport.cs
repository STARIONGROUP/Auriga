// ------------------------------------------------------------------------------------------------
// <copyright file="IEdgeMappingImport.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description
{
    /// <summary>
    /// Definition of the <c>EdgeMappingImport</c> interface.
    /// </summary>
    public partial interface IEdgeMappingImport : Auriga.Sirius.Viewpoint.Description.IDocumentedElement, Auriga.Sirius.Diagram.Description.IIEdgeMapping, Auriga.Sirius.Viewpoint.Description.IIdentifiedElement
    {
        /// <summary>
        /// All conditional styles.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IConditionalEdgeStyleDescription> ConditionnalStyles { get; }

        /// <summary>
        /// The imported mapping used to define default values for the current mapping.
        /// </summary>
        Auriga.Sirius.Diagram.Description.IIEdgeMapping ImportedMapping { get; set; }

        /// <summary>
        /// Set to true if you want the filters applying on the imported mappings apply on this one.
        /// </summary>
        bool? InheritsAncestorFilters { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
