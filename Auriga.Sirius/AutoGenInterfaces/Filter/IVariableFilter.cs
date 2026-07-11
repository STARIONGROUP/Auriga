// ------------------------------------------------------------------------------------------------
// <copyright file="IVariableFilter.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Filter
{
    /// <summary>
    /// A filter that filters viewpoint elements considering an expression and some variables defined by the
    /// user.
    /// </summary>
    public partial interface IVariableFilter : Auriga.Sirius.Diagram.Description.Filter.IFilter
    {
        /// <summary>
        /// Gets the owned variables.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IInteractiveVariableDescription> OwnedVariables { get; }

        /// <summary>
        /// The condition to apply on the semantic element.
        /// </summary>
        string SemanticConditionExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
