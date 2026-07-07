// ------------------------------------------------------------------------------------------------
// <copyright file="IGeneralizableElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacore
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>GeneralizableElement</c> interface.
    /// </summary>
    public partial interface IGeneralizableElement : Auriga.Capellacore.IType
    {
        /// <summary>
        /// Gets or sets the abstract.
        /// </summary>
        bool? Abstract { get; set; }

        /// <summary>
        /// Gets the owned generalizations.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacore.IGeneralization> OwnedGeneralizations { get; }

        /// <summary>
        /// Gets the sub.
        /// </summary>
        IEnumerable<Auriga.Capellacore.IGeneralizableElement> Sub { get; }

        /// <summary>
        /// Gets the sub generalizations.
        /// </summary>
        IEnumerable<Auriga.Capellacore.IGeneralization> SubGeneralizations { get; }

        /// <summary>
        /// Gets the super.
        /// </summary>
        IEnumerable<Auriga.Capellacore.IGeneralizableElement> Super { get; }

        /// <summary>
        /// Gets the super generalizations.
        /// </summary>
        IEnumerable<Auriga.Capellacore.IGeneralization> SuperGeneralizations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
