// ------------------------------------------------------------------------------------------------
// <copyright file="IUIState.cs" company="Starion Group S.A.">
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
    public partial interface IUIState : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// This map associates a Decoration to its computed image (Object as value) which can be either an Image or an IFigure.
        /// </summary>
        object DecorationImage { get; }

        /// <summary>
        /// Gets the elements to select.
        /// </summary>
        IEnumerable<object> ElementsToSelect { get; }

        /// <summary>
        /// Gets the inverse selection order.
        /// </summary>
        bool? InverseSelectionOrder { get; }

        /// <summary>
        /// This map associates a Decoration to its computed image (Object as value) which can be either an Image or an IFigure.
        /// </summary>
        object SubDiagramDecorationDescriptors { get; }

        /// <summary>
        /// Gets the tool sections.
        /// </summary>
        IEnumerable<Auriga.Diagram.Viewpoint.IToolSectionInstance> ToolSections { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
