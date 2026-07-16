// ------------------------------------------------------------------------------------------------
// <copyright file="IOperationAction.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>OperationAction</c> interface.
    /// </summary>
    public partial interface IOperationAction : Auriga.Diagram.Viewpoint.Description.Tool.IMenuItemDescriptionWithIcon, Auriga.Diagram.Viewpoint.Description.Tool.IGroupMenuItem
    {
        /// <summary>
        /// Gets or sets the initial operation.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation InitialOperation { get; set; }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IContainerViewVariable View { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
