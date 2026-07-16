// ------------------------------------------------------------------------------------------------
// <copyright file="IRepresentationCreationDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint.Description.Tool
{
    /// <summary>
    /// Definition of the <c>RepresentationCreationDescription</c> interface.
    /// </summary>
    public partial interface IRepresentationCreationDescription : Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription
    {
        /// <summary>
        /// You might put here an expression to browse the semantic model to get to a new place before creating the representation.
        /// </summary>
        string BrowseExpression { get; set; }

        /// <summary>
        /// The variable containerView that represents the clickedView (instance of ViewPoint or ViewPointElement).
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IContainerViewVariable ContainerViewVariable { get; set; }

        /// <summary>
        /// Gets or sets the initial operation.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation InitialOperation { get; set; }

        /// <summary>
        /// Gets the representation description.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.IRepresentationDescription RepresentationDescription { get; }

        /// <summary>
        /// The variable representationName that represents the name of the created representation.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.INameVariable RepresentationNameVariable { get; set; }

        /// <summary>
        /// The default title of the representation to create. (new + name if empty)
        /// </summary>
        string TitleExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
