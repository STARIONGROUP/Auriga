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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IPhysicalLink : Auriga.Cs.IAbstractPhysicalPathLink, Auriga.Cs.IAbstractPhysicalArtifact, Auriga.Cs.IAbstractPathInvolvedElement
    {
        List<Auriga.Cs.IAbstractPhysicalLinkEnd> LinkEnds { get; }

        Auriga.IContainerList<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> OwnedComponentExchangeFunctionalExchangeAllocations { get; }

        Auriga.IContainerList<Auriga.Cs.IPhysicalLinkEnd> OwnedPhysicalLinkEnds { get; }

        Auriga.IContainerList<Auriga.Cs.IPhysicalLinkRealization> OwnedPhysicalLinkRealizations { get; }

        IEnumerable<Auriga.Cs.IPhysicalLinkCategory> Categories { get; }

        Auriga.Cs.IPhysicalPort SourcePhysicalPort { get; }

        Auriga.Cs.IPhysicalPort TargetPhysicalPort { get; }

        IEnumerable<Auriga.Cs.IPhysicalLink> RealizedPhysicalLinks { get; }

        IEnumerable<Auriga.Cs.IPhysicalLink> RealizingPhysicalLinks { get; }

    }
}
