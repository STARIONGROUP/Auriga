// ------------------------------------------------------------------------------------------------
// <copyright file="IToolDescription.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ToolDescription</c> interface.
    /// </summary>
    public partial interface IToolDescription : Auriga.Sirius.Viewpoint.Description.Tool.IMappingBasedToolDescription
    {
        /// <summary>
        /// The variable container that represents the semantic element of the clicked view.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IElementVariable Element { get; set; }

        /// <summary>
        /// The variable that represents the clicked view.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IElementViewVariable ElementView { get; set; }

        /// <summary>
        /// The path of the icon to display in the palette. If unset, the icon corresponding to the semantic
        /// element associated with the mapping will be displayed.
        /// </summary>
        string IconPath { get; set; }

        /// <summary>
        /// The first operation to execute.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IInitialOperation InitialOperation { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
