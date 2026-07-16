// ------------------------------------------------------------------------------------------------
// <copyright file="IInvolverElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Capellacore
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>InvolverElement</c> interface.
    /// </summary>
    public partial interface IInvolverElement : Auriga.Model.Capellacore.ICapellaElement
    {
        /// <summary>
        /// Gets the involved involvements.
        /// </summary>
        IEnumerable<Auriga.Model.Capellacore.IInvolvement> InvolvedInvolvements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
