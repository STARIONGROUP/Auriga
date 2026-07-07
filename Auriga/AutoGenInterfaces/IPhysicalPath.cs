// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalPath.cs" company="Starion Group S.A.">
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

    public partial interface IPhysicalPath : Auriga.Capellacore.INamedElement, Auriga.Fa.IComponentExchangeAllocator, Auriga.Cs.IAbstractPathInvolvedElement, Auriga.Capellacore.IInvolverElement
    {
        /// <summary>
        /// @deprecated : 'involvedLinks' shall not be used anymore
        /// </summary>
        List<Auriga.Cs.IAbstractPhysicalPathLink> InvolvedLinks { get; }

        Auriga.IContainerList<Auriga.Cs.IPhysicalPathInvolvement> OwnedPhysicalPathInvolvements { get; }

        IEnumerable<Auriga.Cs.IPhysicalPathInvolvement> FirstPhysicalPathInvolvements { get; }

        Auriga.IContainerList<Auriga.Cs.IPhysicalPathRealization> OwnedPhysicalPathRealizations { get; }

        IEnumerable<Auriga.Cs.IPhysicalPath> RealizedPhysicalPaths { get; }

        IEnumerable<Auriga.Cs.IPhysicalPath> RealizingPhysicalPaths { get; }

    }
}
