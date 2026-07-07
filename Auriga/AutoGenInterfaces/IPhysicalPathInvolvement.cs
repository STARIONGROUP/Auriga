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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IPhysicalPathInvolvement : Auriga.Capellacore.IInvolvement
    {
        List<Auriga.Cs.IPhysicalPathInvolvement> NextInvolvements { get; }

        IEnumerable<Auriga.Cs.IPhysicalPathInvolvement> PreviousInvolvements { get; }

        Auriga.Cs.IAbstractPathInvolvedElement InvolvedElement { get; }

        Auriga.Cs.IComponent InvolvedComponent { get; }

    }
}
