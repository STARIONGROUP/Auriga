// ------------------------------------------------------------------------------------------------
// <copyright file="ICatalogElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Re
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>CatalogElement</c> interface.
    /// </summary>
    public partial interface ICatalogElement : Auriga.Re.IReDescriptionElement, Auriga.Re.IReElementContainer
    {
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// Gets or sets the current compliancy.
        /// </summary>
        Auriga.Re.ICompliancyDefinition CurrentCompliancy { get; set; }

        /// <summary>
        /// Gets or sets the default replica compliancy.
        /// </summary>
        Auriga.Re.ICompliancyDefinition DefaultReplicaCompliancy { get; set; }

        /// <summary>
        /// Gets or sets the environment.
        /// </summary>
        string Environment { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Re.CatalogElementKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        Auriga.Re.ICatalogElement Origin { get; set; }

        /// <summary>
        /// Gets the owned links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Re.ICatalogElementLink> OwnedLinks { get; }

        /// <summary>
        /// Gets or sets the purpose.
        /// </summary>
        string Purpose { get; set; }

        /// <summary>
        /// Gets or sets the read only.
        /// </summary>
        bool? ReadOnly { get; set; }

        /// <summary>
        /// Gets the referenced elements.
        /// </summary>
        IEnumerable<object> ReferencedElements { get; }

        /// <summary>
        /// Gets the replicated elements.
        /// </summary>
        IEnumerable<Auriga.Re.ICatalogElement> ReplicatedElements { get; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        string Suffix { get; set; }

        /// <summary>
        /// Gets the tags.
        /// </summary>
        List<string> Tags { get; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        string Version { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
