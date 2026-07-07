// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalLink.cs" company="Starion Group S.A.">
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
    public partial interface IPhysicalLink : global::Auriga.Cs.IAbstractPhysicalPathLink, global::Auriga.Cs.IAbstractPhysicalArtifact, global::Auriga.Cs.IAbstractPathInvolvedElement
    {
        global::System.Collections.Generic.List<global::Auriga.Cs.IAbstractPhysicalLinkEnd> LinkEnds { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> OwnedComponentExchangeFunctionalExchangeAllocations { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalLinkEnd> OwnedPhysicalLinkEnds { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalLinkRealization> OwnedPhysicalLinkRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalLinkCategory> Categories { get; }

        global::Auriga.Cs.IPhysicalPort SourcePhysicalPort { get; }

        global::Auriga.Cs.IPhysicalPort TargetPhysicalPort { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalLink> RealizedPhysicalLinks { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalLink> RealizingPhysicalLinks { get; }

    }
}
