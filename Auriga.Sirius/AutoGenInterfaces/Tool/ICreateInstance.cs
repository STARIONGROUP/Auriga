// ------------------------------------------------------------------------------------------------
// <copyright file="ICreateInstance.cs" company="Starion Group S.A.">
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
    /// This operation allows to create a new instance. The context must be the container of the new instance.
    /// </summary>
    public partial interface ICreateInstance : Auriga.Sirius.Viewpoint.Description.Tool.IContainerModelOperation
    {
        /// <summary>
        /// The name of the reference that contained the new instance.
        /// </summary>
        string ReferenceName { get; set; }

        /// <summary>
        /// The type of the new instance.
        /// </summary>
        string TypeName { get; set; }

        /// <summary>
        /// Once the instance is created, a new variable will be bound with the name given here and will be available to any contained operation.
        /// </summary>
        string VariableName { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
