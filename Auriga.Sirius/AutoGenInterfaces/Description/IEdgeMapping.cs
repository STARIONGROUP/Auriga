// ------------------------------------------------------------------------------------------------
// <copyright file="IEdgeMapping.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// An edge mapping allows to create ViewEdge.
    /// </summary>
    public partial interface IEdgeMapping : Auriga.Sirius.Diagram.Description.IDiagramElementMapping, Auriga.Sirius.Viewpoint.Description.IDocumentedElement, Auriga.Sirius.Diagram.Description.IIEdgeMapping
    {
        /// <summary>
        /// All conditional styles.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IConditionalEdgeStyleDescription> ConditionnalStyles { get; }

        /// <summary>
        /// The type of the target elements that are represented by this edge. Useful only if useDomainElement
        /// is true.
        /// </summary>
        string DomainClass { get; set; }

        /// <summary>
        /// Gets or sets the path expression.
        /// </summary>
        string PathExpression { get; set; }

        /// <summary>
        /// Gets the path node mapping.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IAbstractNodeMapping> PathNodeMapping { get; }

        /// <summary>
        /// Gets the reconnections.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.Tool.IReconnectEdgeDescription> Reconnections { get; }

        /// <summary>
        /// An expression to retrieve the sources of an edge.All this objects will depends on the
        /// semanticCandidatesExpression. By default all objects are the objects that are in the enclosing
        /// viewpoint's rootContent subtree. If the semanticCandidatesExpression is filled in then all the
        /// objects will be the objects of the returned list.This attribute is taking in account only if the
        /// useDomainElement is true.
        /// </summary>
        string SourceFinderExpression { get; set; }

        /// <summary>
        /// The mapping that creates EdgeTargets that are the sources of the ViewEdges that are created by this
        /// EdgeMapping.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> SourceMapping { get; }

        /// <summary>
        /// The style of the edge.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Style.IEdgeStyleDescription Style { get; set; }

        /// <summary>
        /// An expression computing the targeted semantic element of this edge.If this attribut is not filled
        /// in. Then the target element will be : - The target element of the source node if useDomainElement is
        /// false. - The object that is an instance of domainClass value if useDomainElement is true.
        /// </summary>
        string TargetExpression { get; set; }

        /// <summary>
        /// An expression  to retrieve the targets of an edge.The context of the expression depends on the
        /// useDomainElement value. If useDomainElement is true, the expression will be evaluated with all
        /// objects that are instances of the type represented by the domainClass value.All this objects will
        /// depends on the semanticCandidatesExpression. By default all objects are the objects that are in the
        /// enclosing viewpoint's rootContent subtree. If the semanticCandidatesExpression is filled in then all
        /// the objects will be the objects of the returned list.
        /// </summary>
        string TargetFinderExpression { get; set; }

        /// <summary>
        /// The mapping that creates EdgeTargets that are the targets of the ViewEdges that are created by this
        /// EdgeMapping.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> TargetMapping { get; }

        /// <summary>
        /// Gets or sets the use domain element.
        /// </summary>
        bool? UseDomainElement { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
