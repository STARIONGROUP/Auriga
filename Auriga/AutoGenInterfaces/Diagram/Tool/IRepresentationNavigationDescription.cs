// ------------------------------------------------------------------------------------------------
// <copyright file="IRepresentationNavigationDescription.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>RepresentationNavigationDescription</c> interface.
    /// </summary>
    public partial interface IRepresentationNavigationDescription : Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription
    {
        /// <summary>
        /// Expression returning the navigation target.
        /// </summary>
        string BrowseExpression { get; set; }

        /// <summary>
        /// The variable container that represents the semantic element of the clicked view.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IElementSelectVariable ContainerVariable { get; set; }

        /// <summary>
        /// The variable containerView that represents the clickedView (instance of ViewPoint or ViewPointElement).
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IContainerViewVariable ContainerViewVariable { get; set; }

        /// <summary>
        /// Gets or sets the navigation name expression.
        /// </summary>
        string NavigationNameExpression { get; set; }

        /// <summary>
        /// Gets the representation description.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.IRepresentationDescription RepresentationDescription { get; }

        /// <summary>
        /// The variable representationName that represents the name of the representation to open.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.INameVariable RepresentationNameVariable { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
