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

namespace Auriga.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PhysicalLink</c> interface.
    /// </summary>
    public partial interface IPhysicalLink : Auriga.Cs.IAbstractPhysicalPathLink, Auriga.Cs.IAbstractPhysicalArtifact, Auriga.Cs.IAbstractPathInvolvedElement
    {
        /// <summary>
        /// Gets the categories.
        /// </summary>
        IEnumerable<Auriga.Cs.IPhysicalLinkCategory> Categories { get; }

        /// <summary>
        /// Gets the link ends.
        /// </summary>
        List<Auriga.Cs.IAbstractPhysicalLinkEnd> LinkEnds { get; }

        /// <summary>
        /// Gets the owned component exchange functional exchange allocations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> OwnedComponentExchangeFunctionalExchangeAllocations { get; }

        /// <summary>
        /// Gets the owned physical link ends.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Cs.IPhysicalLinkEnd> OwnedPhysicalLinkEnds { get; }

        /// <summary>
        /// Gets the owned physical link realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Cs.IPhysicalLinkRealization> OwnedPhysicalLinkRealizations { get; }

        /// <summary>
        /// Gets the realized physical links.
        /// </summary>
        IEnumerable<Auriga.Cs.IPhysicalLink> RealizedPhysicalLinks { get; }

        /// <summary>
        /// Gets the realizing physical links.
        /// </summary>
        IEnumerable<Auriga.Cs.IPhysicalLink> RealizingPhysicalLinks { get; }

        /// <summary>
        /// Gets the source physical port.
        /// </summary>
        Auriga.Cs.IPhysicalPort SourcePhysicalPort { get; }

        /// <summary>
        /// Gets the target physical port.
        /// </summary>
        Auriga.Cs.IPhysicalPort TargetPhysicalPort { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
