// ------------------------------------------------------------------------------------------------
// <copyright file="IPaneBasedSelectionWizardDescription.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>PaneBasedSelectionWizardDescription</c> interface.
    /// </summary>
    public partial interface IPaneBasedSelectionWizardDescription : Auriga.Sirius.Viewpoint.Description.Tool.IAbstractToolDescription
    {
        /// <summary>
        /// Gets or sets the candidates expression.
        /// </summary>
        string CandidatesExpression { get; set; }

        /// <summary>
        /// Gets or sets the children expression.
        /// </summary>
        string ChildrenExpression { get; set; }

        /// <summary>
        /// Gets or sets the choice of values message.
        /// </summary>
        string ChoiceOfValuesMessage { get; set; }

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
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets the pre selected candidates expression.
        /// </summary>
        string PreSelectedCandidatesExpression { get; set; }

        /// <summary>
        /// Gets or sets the root expression.
        /// </summary>
        string RootExpression { get; set; }

        /// <summary>
        /// Gets or sets the selected values message.
        /// </summary>
        string SelectedValuesMessage { get; set; }

        /// <summary>
        /// Set to true if you want a tree representation of the selection candidates.
        /// </summary>
        bool Tree { get; set; }

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
