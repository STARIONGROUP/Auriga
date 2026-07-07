// ------------------------------------------------------------------------------------------------
// <copyright file="IInvolvedElement.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>InvolvedElement</c> interface.
    /// </summary>
    public partial interface IInvolvedElement : Auriga.Capellacore.ICapellaElement
    {
        /// <summary>
        /// Gets the involving involvements.
        /// </summary>
        IEnumerable<Auriga.Capellacore.IInvolvement> InvolvingInvolvements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
