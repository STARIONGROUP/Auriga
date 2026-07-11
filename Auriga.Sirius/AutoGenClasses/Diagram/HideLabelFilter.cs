// ------------------------------------------------------------------------------------------------
// <copyright file="HideLabelFilter.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>HideLabelFilter</c> class.
    /// </summary>
    public partial class HideLabelFilter : Auriga.Core.AurigaElement, Auriga.Sirius.Diagram.IHideLabelFilter
    {
        /// <summary>
        /// List of VisualIDs of the labels that should be filtered. This feature is only used for the labels of a DEdge
        /// </summary>
        public List<int> HiddenLabels { get; } = new List<int>();

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
