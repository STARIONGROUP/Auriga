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
    public partial interface IPhysicalPath : global::Auriga.Capellacore.INamedElement, global::Auriga.Fa.IComponentExchangeAllocator, global::Auriga.Cs.IAbstractPathInvolvedElement, global::Auriga.Capellacore.IInvolverElement
    {
        /// <summary>
        /// @deprecated : 'involvedLinks' shall not be used anymore
        /// </summary>
        global::System.Collections.Generic.List<global::Auriga.Cs.IAbstractPhysicalPathLink> InvolvedLinks { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalPathInvolvement> OwnedPhysicalPathInvolvements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalPathInvolvement> FirstPhysicalPathInvolvements { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalPathRealization> OwnedPhysicalPathRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalPath> RealizedPhysicalPaths { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalPath> RealizingPhysicalPaths { get; }

    }
}
