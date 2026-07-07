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
    public partial interface IPhysicalPathInvolvement : global::Auriga.Capellacore.IInvolvement
    {
        global::System.Collections.Generic.List<global::Auriga.Cs.IPhysicalPathInvolvement> NextInvolvements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalPathInvolvement> PreviousInvolvements { get; }

        global::Auriga.Cs.IAbstractPathInvolvedElement InvolvedElement { get; }

        global::Auriga.Cs.IComponent InvolvedComponent { get; }

    }
}
