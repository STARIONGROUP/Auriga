// ------------------------------------------------------------------------------------------------
// <copyright file="IValidationFix.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description.Validation
{
    /// <summary>
    /// Definition of the <c>ValidationFix</c> interface.
    /// </summary>
    public partial interface IValidationFix : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// The first operation.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IInitialOperation InitialOperation { get; set; }

        /// <summary>
        /// Name of the quick fix displayed to the user.
        /// </summary>
        string Name { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
