// ------------------------------------------------------------------------------------------------
// <copyright file="NodeDiagramBuilder.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Builders
{
    using System.Collections.Generic;

    using Auriga.Reporting.Model;
    using Auriga.Reporting.Styles;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Builds the intermediate model of a node-and-edge representation — Capella's architecture
    /// and data-flow blank diagrams (LAB, PAB, OAB, SAB, xDFB, …) and any other kind without
    /// layout rules of its own. The persisted GMF geometry consumed by the generic walk fully
    /// describes these diagrams, so this builder contributes no additional rules.
    /// </summary>
    public sealed class NodeDiagramBuilder : DiagramBuilderBase, INodeDiagramBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeDiagramBuilder"/> class with the
        /// supplied style resolver.
        /// </summary>
        /// <param name="styleResolver">the resolver producing each built item's resolved style</param>
        /// <param name="tooltipResolver">the resolver producing each built item's hover text</param>
        /// <param name="loggerFactory">the factory the builder creates its logger from</param>
        /// <exception cref="System.ArgumentNullException">a resolver or the logger factory is null</exception>
        public NodeDiagramBuilder(IStyleResolver styleResolver, ITooltipResolver tooltipResolver, ILoggerFactory loggerFactory)
            : base(styleResolver, tooltipResolver, loggerFactory)
        {
        }

        /// <summary>
        /// Applies the layout rules of the node-diagram kind — none: the persisted GMF geometry
        /// consumed by the generic walk is the complete layout of a node-and-edge representation.
        /// </summary>
        /// <param name="rootBoxes">the top-level boxes, in notation order</param>
        /// <param name="edges">the built edges</param>
        protected override void ApplyRepresentationRules(List<Box> rootBoxes, List<Edge> edges)
        {
            // A node diagram is fully described by its persisted geometry.
        }
    }
}
