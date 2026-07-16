// ------------------------------------------------------------------------------------------------
// <copyright file="ILet.cs" company="Starion Group S.A.">
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
    /// This operation allows the creation of a new variable.
    /// </summary>
    public partial interface ILet : Auriga.Diagram.Viewpoint.Description.Tool.IContainerModelOperation
    {
        /// <summary>
        /// Expression used to initialize the value of the new variable.
        /// </summary>
        string ValueExpression { get; set; }

        /// <summary>
        /// Once the variable is created, it will be bound with the name given here and will be available to any contained operation.
        /// </summary>
        string VariableName { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
