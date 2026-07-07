// ------------------------------------------------------------------------------------------------
// <copyright file="IInvolvement.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacore
{
    /// <summary>
    /// Definition of the <c>Involvement</c> interface.
    /// </summary>
    public partial interface IInvolvement : Auriga.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets or sets the involved.
        /// </summary>
        Auriga.Capellacore.IInvolvedElement Involved { get; set; }

        /// <summary>
        /// Gets the involver.
        /// </summary>
        Auriga.Capellacore.IInvolverElement Involver { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
