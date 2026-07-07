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
    public partial interface IConcept : global::Auriga.Capellacore.INamedElement
    {
        global::System.Collections.Generic.List<global::Auriga.Oa.IConceptCompliance> Compliances { get; }

        global::Auriga.IContainerList<global::Auriga.Oa.IItemInConcept> CompositeLinks { get; }

    }
}
