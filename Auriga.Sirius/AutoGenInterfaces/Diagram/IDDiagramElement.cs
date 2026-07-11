// ------------------------------------------------------------------------------------------------
// <copyright file="IDDiagramElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>DDiagramElement</c> interface.
    /// </summary>
    public partial interface IDDiagramElement : Auriga.Sirius.Viewpoint.IDRepresentationElement
    {
        /// <summary>
        /// Gets the decorations.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Viewpoint.IDecoration> Decorations { get; }

        /// <summary>
        /// The mapping of the element.
        /// </summary>
        Auriga.Sirius.Diagram.Description.IDiagramElementMapping DiagramElementMapping { get; }

        /// <summary>
        /// Graphical filters allowing to handle this element.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.IGraphicalFilter> GraphicalFilters { get; }

        /// <summary>
        /// Gets the parent layers.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.ILayer> ParentLayers { get; }

        /// <summary>
        /// The text to show in the element's tooltip.
        /// </summary>
        string TooltipText { get; set; }

        /// <summary>
        /// Gets the transient decorations.
        /// </summary>
        IEnumerable<Auriga.Sirius.Viewpoint.IDecoration> TransientDecorations { get; }

        /// <summary>
        /// True if the element is visible, false otherwise.
        /// </summary>
        bool? Visible { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
