// ------------------------------------------------------------------------------------------------
// <copyright file="XmiElementReader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Readers
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using Auriga.Xmi.Cache;

    /// <summary>
    /// The abstract base class from which every generated per-type XMI reader derives. It holds the
    /// shared <see cref="IXmiElementCache"/> and <see cref="IXmiReaderFacade"/> and provides the helpers
    /// that collect unresolved <c>#id</c> references into the element's deferred-reference dictionaries
    /// (resolved on the reader's second pass). This is the analogue of uml4net's
    /// <c>XmiElementReader&lt;T&gt;</c>.
    /// </summary>
    /// <typeparam name="T">the type of <see cref="IAurigaElement"/> the reader produces</typeparam>
    public abstract class XmiElementReader<T>
        where T : IAurigaElement
    {
        /// <summary>
        /// The characters used to split a whitespace-delimited attribute value — a reference list such as
        /// <c>linkEnds</c>, or a multi-valued primitive attribute.
        /// </summary>
        protected static readonly char[] WhitespaceSeparator = { ' ', '\t', '\r', '\n' };

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementReader{T}"/> class.
        /// </summary>
        /// <param name="cache">the cache in which every read element is registered by <c>xmi:id</c></param>
        /// <param name="facade">the facade used to read contained elements</param>
        protected XmiElementReader(IXmiElementCache cache, IXmiReaderFacade facade)
        {
            this.Cache = cache ?? throw new ArgumentNullException(nameof(cache));
            this.Facade = facade ?? throw new ArgumentNullException(nameof(facade));
        }

        /// <summary>
        /// Gets the cache in which every read element is registered by <c>xmi:id</c>.
        /// </summary>
        protected IXmiElementCache Cache { get; }

        /// <summary>
        /// Gets the facade used to read contained elements.
        /// </summary>
        protected IXmiReaderFacade Facade { get; }

        /// <summary>
        /// Records a single-valued cross-reference, parsed from an attribute value of the form
        /// <c>#id</c>, in the element's <see cref="IAurigaElement.SingleValueReferencePropertyIdentifiers"/>.
        /// </summary>
        /// <param name="element">the element that owns the reference</param>
        /// <param name="propertyName">the (PascalCase) name of the reference property</param>
        /// <param name="attributeValue">the raw attribute value (a single <c>#id</c>)</param>
        protected static void CollectSingleValueReference(IAurigaElement element, string propertyName, string? attributeValue)
        {
            if (string.IsNullOrWhiteSpace(attributeValue))
            {
                return;
            }

            element.SingleValueReferencePropertyIdentifiers[propertyName] = NormalizeIdentifier(attributeValue!);
        }

        /// <summary>
        /// Records a multi-valued cross-reference, parsed from a whitespace-delimited attribute value of
        /// <c>#id</c> tokens, in the element's
        /// <see cref="IAurigaElement.MultiValueReferencePropertyIdentifiers"/>.
        /// </summary>
        /// <param name="element">the element that owns the reference</param>
        /// <param name="propertyName">the (PascalCase) name of the reference property</param>
        /// <param name="attributeValue">the raw attribute value (whitespace-delimited <c>#id</c>s)</param>
        protected static void CollectMultiValueReferences(IAurigaElement element, string propertyName, string? attributeValue)
        {
            if (string.IsNullOrWhiteSpace(attributeValue))
            {
                return;
            }

            var tokens = attributeValue!.Split(WhitespaceSeparator, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0)
            {
                return;
            }

            var identifiers = new List<string>(tokens.Length);
            foreach (var token in tokens)
            {
                identifiers.Add(NormalizeIdentifier(token));
            }

            element.MultiValueReferencePropertyIdentifiers[propertyName] = identifiers;
        }

        /// <summary>
        /// Parses an enumeration attribute value case-insensitively by literal name, returning false for a
        /// null, empty or unrecognized value so the property is simply left at its default.
        /// </summary>
        /// <typeparam name="TEnum">the enumeration type</typeparam>
        /// <param name="value">the raw attribute value</param>
        /// <param name="result">the parsed value, or the default when parsing fails</param>
        /// <returns>true when the value parsed to a defined literal</returns>
        protected static bool TryParseEnum<TEnum>(string? value, out TEnum result)
            where TEnum : struct
        {
            if (!string.IsNullOrEmpty(value) && Enum.TryParse(value, ignoreCase: true, out result))
            {
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// Fully consumes the element (and its subtree) at the cursor, leaving the reader on its end tag,
        /// so an unrecognized child element does not derail the parent's child-element loop.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element to skip</param>
        protected static void SkipElement(XmlReader xmlReader)
        {
            using var subReader = xmlReader.ReadSubtree();
            while (subReader.Read())
            {
            }
        }

        /// <summary>
        /// Strips the leading <c>#</c> of an intra-document reference so it matches the cache key
        /// (the bare <c>xmi:id</c>). A cross-document reference (<c>document#id</c>) is left intact.
        /// </summary>
        /// <param name="reference">the raw reference token</param>
        /// <returns>the normalized identifier</returns>
        private static string NormalizeIdentifier(string reference)
        {
            return reference.StartsWith("#", StringComparison.Ordinal) ? reference.Substring(1) : reference;
        }
    }
}
