// ------------------------------------------------------------------------------------------------
// <copyright file="ITypedVariable.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description
{
    /// <summary>
    /// Definition of the <c>TypedVariable</c> interface.
    /// </summary>
    public partial interface ITypedVariable : Auriga.Sirius.Viewpoint.Description.IInteractiveVariableDescription, Auriga.Sirius.Viewpoint.Description.ISubVariable
    {
        /// <summary>
        /// An expression used to define the default variable value.
        /// </summary>
        string DefaultValueExpression { get; set; }

        /// <summary>
        /// The type of the variable value.
        /// </summary>
        object ValueType { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
