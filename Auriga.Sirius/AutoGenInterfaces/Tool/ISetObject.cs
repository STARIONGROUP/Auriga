// ------------------------------------------------------------------------------------------------
// <copyright file="ISetObject.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>SetObject</c> interface.
    /// </summary>
    public partial interface ISetObject : Auriga.Sirius.Viewpoint.Description.Tool.IContainerModelOperation
    {
        /// <summary>
        /// The name of the feature to set.
        /// </summary>
        string FeatureName { get; set; }

        /// <summary>
        /// An instance to set, you might need to use "load resource" in the editor in order to be able to pick
        /// it.
        /// </summary>
        object Object { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
