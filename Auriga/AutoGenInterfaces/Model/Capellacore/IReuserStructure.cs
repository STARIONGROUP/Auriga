// ------------------------------------------------------------------------------------------------
// <copyright file="IReuserStructure.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Capellacore
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>ReuserStructure</c> interface.
    /// </summary>
    public partial interface IReuserStructure : Auriga.Model.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned reuse links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacore.IReuseLink> OwnedReuseLinks { get; }

        /// <summary>
        /// Gets the reuse links.
        /// </summary>
        List<Auriga.Model.Capellacore.IReuseLink> ReuseLinks { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
