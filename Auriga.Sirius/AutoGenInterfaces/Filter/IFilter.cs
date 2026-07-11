// ------------------------------------------------------------------------------------------------
// <copyright file="IFilter.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Filter
{
    /// <summary>
    /// A filter.
    /// </summary>
    public partial interface IFilter : Auriga.IAurigaElement
    {
        /// <summary>
        /// A filter might hide elements or just shrink them. In the case of the shrink, the edges going to this element will be kept.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Filter.FilterKind? FilterKind { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
