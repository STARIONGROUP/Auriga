// ------------------------------------------------------------------------------------------------
// <copyright file="ISelectionWizardDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description.Tool
{
    /// <summary>
    /// Definition of the <c>SelectionWizardDescription</c> interface.
    /// </summary>
    public partial interface ISelectionWizardDescription : Auriga.Sirius.Viewpoint.Description.Tool.IAbstractToolDescription, Auriga.Sirius.Viewpoint.Description.ISelectionDescription
    {
        /// <summary>
        /// Gets or sets the container view.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IContainerViewVariable ContainerView { get; set; }

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IElementSelectVariable Element { get; set; }

        /// <summary>
        /// Gets or sets the icon path.
        /// </summary>
        string IconPath { get; set; }

        /// <summary>
        /// Gets or sets the initial operation.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IInitialOperation InitialOperation { get; set; }

        /// <summary>
        /// Gets or sets the window image path.
        /// </summary>
        string WindowImagePath { get; set; }

        /// <summary>
        /// Title of the dialog.
        /// </summary>
        string WindowTitle { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
