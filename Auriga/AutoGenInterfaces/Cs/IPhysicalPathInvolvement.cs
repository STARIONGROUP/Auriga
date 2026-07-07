// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalPathInvolvement.cs" company="Starion Group S.A.">
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

namespace Auriga.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PhysicalPathInvolvement</c> interface.
    /// </summary>
    public partial interface IPhysicalPathInvolvement : Auriga.Capellacore.IInvolvement
    {
        /// <summary>
        /// Gets the involved component.
        /// </summary>
        Auriga.Cs.IComponent InvolvedComponent { get; }

        /// <summary>
        /// Gets the involved element.
        /// </summary>
        Auriga.Cs.IAbstractPathInvolvedElement InvolvedElement { get; }

        /// <summary>
        /// Gets the next involvements.
        /// </summary>
        List<Auriga.Cs.IPhysicalPathInvolvement> NextInvolvements { get; }

        /// <summary>
        /// Gets the previous involvements.
        /// </summary>
        IEnumerable<Auriga.Cs.IPhysicalPathInvolvement> PreviousInvolvements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
