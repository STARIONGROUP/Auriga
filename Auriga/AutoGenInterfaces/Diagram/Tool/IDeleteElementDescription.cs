// ------------------------------------------------------------------------------------------------
// <copyright file="IDeleteElementDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description.Tool
{
    /// <summary>
    /// Tool that describes how to delete a ViewPointElement.
    /// </summary>
    public partial interface IDeleteElementDescription : Auriga.Diagram.Viewpoint.Description.Tool.IMappingBasedToolDescription
    {
        /// <summary>
        /// The view that contains the ViewPointElement to delete.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IContainerViewVariable ContainerView { get; set; }

        /// <summary>
        /// The semantic element of the ViewPointElement to delete.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IElementDeleteVariable Element { get; set; }

        /// <summary>
        /// Gets or sets the element view.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IElementDeleteVariable ElementView { get; set; }

        /// <summary>
        /// Gets or sets the hook.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Tool.IDeleteHook Hook { get; set; }

        /// <summary>
        /// The first operation.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation InitialOperation { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
