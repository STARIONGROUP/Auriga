// ------------------------------------------------------------------------------------------------
// <copyright file="IEObjectVariableValue.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>EObjectVariableValue</c> interface.
    /// </summary>
    public partial interface IEObjectVariableValue : Auriga.Sirius.Diagram.IVariableValue
    {
        /// <summary>
        /// Gets or sets the model element.
        /// </summary>
        object ModelElement { get; set; }

        /// <summary>
        /// Gets or sets the variable definition.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.ISelectModelElementVariable VariableDefinition { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
