// ------------------------------------------------------------------------------------------------
// <copyright file="ITypedVariableValue.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram
{
    /// <summary>
    /// Definition of the <c>TypedVariableValue</c> interface.
    /// </summary>
    public partial interface ITypedVariableValue : Auriga.Sirius.Diagram.IVariableValue
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// Gets or sets the variable definition.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.ITypedVariable VariableDefinition { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
