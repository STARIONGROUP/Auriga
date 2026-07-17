// ------------------------------------------------------------------------------------------------
// <copyright file="IEStringToStringMapEntry.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Core
{
    /// <summary>
    /// A single entry of an <c>EMap&lt;String, String&gt;</c>-typed feature. EMF serializes such a
    /// feature inline as <c>ecore:EStringToStringMapEntry</c> child elements carrying <c>key</c> /
    /// <c>value</c> attributes (e.g. a Sirius <c>DAnnotation</c>'s <c>details</c>). The map-entry type is
    /// an Ecore built-in that belongs to no vendored metamodel package, so it is modeled here in the
    /// shared core rather than generated per metamodel.
    /// </summary>
    public interface IEStringToStringMapEntry : IAurigaElement
    {
        /// <summary>
        /// Gets or sets the entry's key.
        /// </summary>
        string? Key { get; set; }

        /// <summary>
        /// Gets or sets the entry's value.
        /// </summary>
        string? Value { get; set; }
    }
}
