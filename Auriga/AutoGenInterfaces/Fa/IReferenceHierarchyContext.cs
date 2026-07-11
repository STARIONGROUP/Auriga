// ------------------------------------------------------------------------------------------------
// <copyright file="IReferenceHierarchyContext.cs" company="Starion Group S.A.">
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

namespace Auriga.Fa
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>ReferenceHierarchyContext</c> interface.
    /// </summary>
    public partial interface IReferenceHierarchyContext : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets the source reference hierarchy.
        /// </summary>
        List<Auriga.Fa.IFunctionalChainReference> SourceReferenceHierarchy { get; }

        /// <summary>
        /// Gets the target reference hierarchy.
        /// </summary>
        List<Auriga.Fa.IFunctionalChainReference> TargetReferenceHierarchy { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
