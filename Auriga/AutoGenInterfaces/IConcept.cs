// ------------------------------------------------------------------------------------------------
// <copyright file="IConcept.cs" company="Starion Group S.A.">
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

namespace Auriga.Oa
{
    using System.Collections.Generic;

    public partial interface IConcept : Auriga.Capellacore.INamedElement
    {
        List<Auriga.Oa.IConceptCompliance> Compliances { get; }

        Auriga.IContainerList<Auriga.Oa.IItemInConcept> CompositeLinks { get; }

    }
}
