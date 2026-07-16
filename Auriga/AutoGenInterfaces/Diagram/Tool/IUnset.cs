// ------------------------------------------------------------------------------------------------
// <copyright file="IUnset.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Unset</c> interface.
    /// </summary>
    public partial interface IUnset : Auriga.Diagram.Viewpoint.Description.Tool.IContainerModelOperation
    {
        /// <summary>
        /// Expression returning the elements to unset from the feature.
        /// </summary>
        string ElementExpression { get; set; }

        /// <summary>
        /// Name of the feature to unset.
        /// </summary>
        string FeatureName { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
