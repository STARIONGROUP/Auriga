// ------------------------------------------------------------------------------------------------
// <copyright file="ICreateView.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Tool
{
    /// <summary>
    /// This operation allows to create a view.
    /// </summary>
    public partial interface ICreateView : Auriga.Sirius.Viewpoint.Description.Tool.IContainerModelOperation
    {
        /// <summary>
        /// Gets or sets the container view expression.
        /// </summary>
        string ContainerViewExpression { get; set; }

        /// <summary>
        /// Mapping to create a view from.
        /// </summary>
        Auriga.Sirius.Diagram.Description.IDiagramElementMapping Mapping { get; set; }

        /// <summary>
        /// Once the view is created, a new variable will be bound with the name given here and will be available to any contained operation.
        /// </summary>
        string VariableName { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
