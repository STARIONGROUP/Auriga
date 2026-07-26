// ------------------------------------------------------------------------------------------------
// <copyright file="UninterpretedAttribute.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Core
{
    /// <summary>
    /// An attribute the reader could not interpret, retained verbatim so a write can re-emit it — an
    /// attribute of a package Auriga does not vendor, or one the metamodel does not declare (issue #127).
    /// </summary>
    /// <remarks>
    /// The namespace is carried alongside the name because a prefixed attribute cannot be written back
    /// without it: the prefix may resolve to a namespace the document root does not declare, precisely
    /// because the package is not one Auriga models.
    /// </remarks>
    public sealed class UninterpretedAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UninterpretedAttribute"/> class.
        /// </summary>
        /// <param name="name">the attribute's qualified XML name, prefix included</param>
        /// <param name="namespaceUri">the namespace the prefix resolves to, or empty when unprefixed</param>
        /// <param name="value">the attribute's value</param>
        public UninterpretedAttribute(string name, string? namespaceUri, string? value)
        {
            this.Name = name;
            this.NamespaceUri = namespaceUri;
            this.Value = value;
        }

        /// <summary>
        /// Gets the attribute's qualified XML name, prefix included (e.g. <c>vp:customField</c>).
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the namespace the attribute's prefix resolves to, or <c>null</c>/empty when the attribute
        /// is unprefixed.
        /// </summary>
        public string? NamespaceUri { get; }

        /// <summary>
        /// Gets the attribute's value.
        /// </summary>
        public string? Value { get; }
    }
}
