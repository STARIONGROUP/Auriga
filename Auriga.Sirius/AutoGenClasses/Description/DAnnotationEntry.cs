// ------------------------------------------------------------------------------------------------
// <copyright file="DAnnotationEntry.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>DAnnotationEntry</c> class.
    /// </summary>
    public partial class DAnnotationEntry : Auriga.Core.AurigaElement, Auriga.Sirius.Viewpoint.Description.IDAnnotationEntry
    {
        /// <summary>
        /// Gets the details.
        /// </summary>
        public List<string> Details { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
