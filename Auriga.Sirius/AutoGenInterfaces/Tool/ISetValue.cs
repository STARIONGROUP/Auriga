// ------------------------------------------------------------------------------------------------
// <copyright file="ISetValue.cs" company="Starion Group S.A.">
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
    /// This operation allows to set a value of a feature of the current context.
    /// </summary>
    public partial interface ISetValue : Auriga.Sirius.Viewpoint.Description.Tool.IContainerModelOperation
    {
        /// <summary>
        /// The name of the feature to set.
        /// </summary>
        string FeatureName { get; set; }

        /// <summary>
        /// An expression computing the value to set.
        /// </summary>
        string ValueExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
