// ------------------------------------------------------------------------------------------------
// <copyright file="IContainerDropDescription.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Tool that describes a Drag & Drop operation.
    /// </summary>
    public partial interface IContainerDropDescription : Auriga.Diagram.Viewpoint.Description.Tool.IMappingBasedToolDescription
    {
        /// <summary>
        /// Authorized sources of the drag.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.DragSource DragSource { get; set; }

        /// <summary>
        /// The semantic element that is dragged and dropped.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IElementDropVariable Element { get; set; }

        /// <summary>
        /// The first operation.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IInitialContainerDropOperation InitialOperation { get; set; }

        /// <summary>
        /// All mapping that can create the target view.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping> Mappings { get; }

        /// <summary>
        /// Set to true if you want to automatically move the edges associated with a node.
        /// </summary>
        bool MoveEdges { get; set; }

        /// <summary>
        /// The semantic element of the new container view.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IDropContainerVariable NewContainer { get; set; }

        /// <summary>
        /// The new view container (instance of ViewPoint or ViewPointElement).
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IContainerViewVariable NewViewContainer { get; set; }

        /// <summary>
        /// The semantic element of the old container view.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IDropContainerVariable OldContainer { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
