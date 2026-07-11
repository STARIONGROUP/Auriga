// ------------------------------------------------------------------------------------------------
// <copyright file="IIf.cs" company="Starion Group S.A.">
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
    /// If the evaluation of the condition returns true then all operations contains by this If statement will be executed, otherwise all operations will be ignored.
    /// </summary>
    public partial interface IIf : Auriga.Sirius.Viewpoint.Description.Tool.IContainerModelOperation
    {
        /// <summary>
        /// Expression representing the condition, if it returns true, every operation contained by this statement will be executed.
        /// </summary>
        string ConditionExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
