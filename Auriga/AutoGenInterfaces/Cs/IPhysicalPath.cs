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

namespace Auriga.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PhysicalPath</c> interface.
    /// </summary>
    public partial interface IPhysicalPath : Auriga.Capellacore.INamedElement, Auriga.Fa.IComponentExchangeAllocator, Auriga.Cs.IAbstractPathInvolvedElement, Auriga.Capellacore.IInvolverElement
    {
        /// <summary>
        /// Gets the first physical path involvements.
        /// </summary>
        IEnumerable<Auriga.Cs.IPhysicalPathInvolvement> FirstPhysicalPathInvolvements { get; }

        /// <summary>
        /// @deprecated : 'involvedLinks' shall not be used anymore
        /// </summary>
        List<Auriga.Cs.IAbstractPhysicalPathLink> InvolvedLinks { get; }

        /// <summary>
        /// Gets the owned physical path involvements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Cs.IPhysicalPathInvolvement> OwnedPhysicalPathInvolvements { get; }

        /// <summary>
        /// Gets the owned physical path realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Cs.IPhysicalPathRealization> OwnedPhysicalPathRealizations { get; }

        /// <summary>
        /// Gets the realized physical paths.
        /// </summary>
        IEnumerable<Auriga.Cs.IPhysicalPath> RealizedPhysicalPaths { get; }

        /// <summary>
        /// Gets the realizing physical paths.
        /// </summary>
        IEnumerable<Auriga.Cs.IPhysicalPath> RealizingPhysicalPaths { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
