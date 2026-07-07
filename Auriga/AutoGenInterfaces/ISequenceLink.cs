// ------------------------------------------------------------------------------------------------
// <copyright file="ISequenceLink.cs" company="Starion Group S.A.">
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

namespace Auriga.Fa
{
    using System.Collections.Generic;

    public partial interface ISequenceLink : Auriga.Capellacore.ICapellaElement, Auriga.Fa.IReferenceHierarchyContext
    {
        Auriga.Capellacore.IConstraint Condition { get; set; }

        List<Auriga.Fa.IFunctionalChainInvolvementLink> Links { get; }

        Auriga.Fa.ISequenceLinkEnd Source { get; set; }

        Auriga.Fa.ISequenceLinkEnd Target { get; set; }

    }
}
