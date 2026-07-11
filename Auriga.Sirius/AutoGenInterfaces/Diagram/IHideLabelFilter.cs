// ------------------------------------------------------------------------------------------------
// <copyright file="IHideLabelFilter.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>HideLabelFilter</c> interface.
    /// </summary>
    public partial interface IHideLabelFilter : Auriga.Sirius.Diagram.IGraphicalFilter
    {
        /// <summary>
        /// List of VisualIDs of the labels that should be filtered. This feature is only used for the labels of
        /// a DEdge
        /// </summary>
        List<int> HiddenLabels { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
