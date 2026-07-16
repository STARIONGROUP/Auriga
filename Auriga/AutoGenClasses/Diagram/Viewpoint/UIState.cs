// ------------------------------------------------------------------------------------------------
// <copyright file="UIState.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This abstraction is used to store transient UI informations.
    /// </summary>
    public partial class UIState : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.IUIState
    {
        /// <summary>
        /// This map associates a Decoration to its computed image (Object as value) which can be either an Image or an IFigure.
        /// </summary>
        public object DecorationImage => default;

        /// <summary>
        /// Gets the elements to select.
        /// </summary>
        public IEnumerable<object> ElementsToSelect => Enumerable.Empty<object>();

        /// <summary>
        /// Gets the inverse selection order.
        /// </summary>
        public bool? InverseSelectionOrder => default;

        /// <summary>
        /// This map associates a Decoration to its computed image (Object as value) which can be either an Image or an IFigure.
        /// </summary>
        public object SubDiagramDecorationDescriptors => default;

        /// <summary>
        /// Gets the tool sections.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Viewpoint.IToolSectionInstance> ToolSections => Enumerable.Empty<Auriga.Diagram.Viewpoint.IToolSectionInstance>();

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
