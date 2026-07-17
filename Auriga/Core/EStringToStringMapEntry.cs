// ------------------------------------------------------------------------------------------------
// <copyright file="EStringToStringMapEntry.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Core
{
    /// <summary>
    /// The default <see cref="IEStringToStringMapEntry"/>: a key/value pair read from an inline
    /// <c>ecore:EStringToStringMapEntry</c> element, retained on the owning element's
    /// <c>EMap</c>-typed containment feature.
    /// </summary>
    public sealed class EStringToStringMapEntry : AurigaElement, IEStringToStringMapEntry
    {
        /// <summary>
        /// Gets or sets the entry's key.
        /// </summary>
        public string? Key { get; set; }

        /// <summary>
        /// Gets or sets the entry's value.
        /// </summary>
        public string? Value { get; set; }
    }
}
