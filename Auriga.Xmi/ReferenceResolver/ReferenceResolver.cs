// ------------------------------------------------------------------------------------------------
// <copyright file="ReferenceResolver.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.ReferenceResolver
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    using Auriga.Xmi.Cache;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// The default <see cref="IReferenceResolver"/>. It walks the cache and, for every element, assigns
    /// each collected single-valued reference to its property and appends each collected multi-valued
    /// reference to its collection property, resolving the <c>#id</c>s against the cache. References that
    /// cannot be resolved (unknown id, missing property, or an incompatible target type) are logged and
    /// skipped so a single dangling reference does not abort the load.
    /// </summary>
    public sealed class ReferenceResolver : IReferenceResolver
    {
        /// <summary>
        /// The binding flags used to look up a reference property by its (PascalCase) name — public
        /// instance properties, matched case-insensitively.
        /// </summary>
        private const BindingFlags PropertyBindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase;

        /// <summary>
        /// The logger used to report references that cannot be resolved.
        /// </summary>
        private readonly ILogger<ReferenceResolver> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceResolver"/> class.
        /// </summary>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ReferenceResolver(ILoggerFactory? loggerFactory = null)
        {
            this.logger = (loggerFactory ?? NullLoggerFactory.Instance).CreateLogger<ReferenceResolver>();
        }

        /// <summary>
        /// Resolves every deferred single- and multi-valued reference of every element in the cache,
        /// returning the references that could not be resolved (dangling references) so the caller can
        /// report them without the load being aborted by the first one.
        /// </summary>
        /// <param name="cache">the cache holding all instantiated elements</param>
        /// <returns>the dangling references; empty when every reference resolved</returns>
        public IReadOnlyList<UnresolvedReference> Resolve(IXmiElementCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            var unresolved = new List<UnresolvedReference>();

            foreach (var element in cache.Values)
            {
                this.ResolveSingleValued(cache, element, unresolved);
                this.ResolveMultiValued(cache, element, unresolved);
            }

            return unresolved;
        }

        /// <summary>
        /// Assigns each single-valued reference collected on the supplied element to its property,
        /// resolving the <c>#id</c> against the cache. A reference whose id is unknown, whose property is
        /// missing or read-only, or whose target is not assignable to the property, is logged and skipped.
        /// </summary>
        /// <param name="cache">the cache holding all instantiated elements</param>
        /// <param name="element">the element whose single-valued references are resolved</param>
        /// <param name="unresolved">the collection to which dangling references are appended</param>
        private void ResolveSingleValued(IXmiElementCache cache, IAurigaElement element, ICollection<UnresolvedReference> unresolved)
        {
            foreach (var pair in element.SingleValueReferencePropertyIdentifiers)
            {
                if (!cache.TryGetValue(ResolveKey(element, pair.Value), out var target) || target == null)
                {
                    this.logger.LogWarning("Unresolved reference {Property}={Id} on {Type}", pair.Key, pair.Value, element.GetType().Name);
                    unresolved.Add(new UnresolvedReference(element.Id ?? string.Empty, element.GetType().Name, pair.Key, pair.Value));
                    continue;
                }

                var property = element.GetType().GetProperty(pair.Key, PropertyBindingFlags);
                if (property == null || !property.CanWrite)
                {
                    this.logger.LogWarning("No writable property {Property} on {Type}", pair.Key, element.GetType().Name);
                    continue;
                }

                if (!property.PropertyType.IsInstanceOfType(target))
                {
                    this.logger.LogWarning("Reference {Property} target {TargetType} is not assignable to {PropertyType}", pair.Key, target.GetType().Name, property.PropertyType.Name);
                    continue;
                }

                property.SetValue(element, target);
            }
        }

        /// <summary>
        /// Appends each multi-valued reference collected on the supplied element to its collection
        /// property, resolving every <c>#id</c> against the cache. A reference whose property is missing
        /// or not an addable collection, whose id is unknown, or whose target is not assignable to the
        /// collection's element type, is logged and skipped.
        /// </summary>
        /// <param name="cache">the cache holding all instantiated elements</param>
        /// <param name="element">the element whose multi-valued references are resolved</param>
        /// <param name="unresolved">the collection to which dangling references are appended</param>
        private void ResolveMultiValued(IXmiElementCache cache, IAurigaElement element, ICollection<UnresolvedReference> unresolved)
        {
            foreach (var pair in element.MultiValueReferencePropertyIdentifiers)
            {
                var property = element.GetType().GetProperty(pair.Key, PropertyBindingFlags);
                if (property == null)
                {
                    this.logger.LogWarning("No property {Property} on {Type}", pair.Key, element.GetType().Name);
                    continue;
                }

                if (property.GetValue(element) is not IList collection)
                {
                    this.logger.LogWarning("Property {Property} on {Type} is not an addable collection", pair.Key, element.GetType().Name);
                    continue;
                }

                var elementType = property.PropertyType.IsGenericType
                    ? property.PropertyType.GetGenericArguments()[0]
                    : typeof(object);

                foreach (var identifier in pair.Value)
                {
                    if (!cache.TryGetValue(ResolveKey(element, identifier), out var target) || target == null)
                    {
                        this.logger.LogWarning("Unresolved reference {Property}={Id} on {Type}", pair.Key, identifier, element.GetType().Name);
                        unresolved.Add(new UnresolvedReference(element.Id ?? string.Empty, element.GetType().Name, pair.Key, identifier));
                        continue;
                    }

                    if (!elementType.IsInstanceOfType(target))
                    {
                        this.logger.LogWarning("Reference {Property} target {TargetType} is not assignable to {ElementType}", pair.Key, target.GetType().Name, elementType.Name);
                        continue;
                    }

                    collection.Add(target);
                }
            }
        }

        /// <summary>
        /// Builds the document-scoped cache key (<c>documentName#id</c>) for a collected reference token,
        /// following uml4net's rule: a token that names another document (contains <c>#</c>) is resolved
        /// against that document; a bare intra-document reference is qualified with the owner's own
        /// document. The document part of an <c>href</c> is resolved relative to the owner's document
        /// directory and normalized, so the same target yields the same key no matter which document — at
        /// whatever directory depth — referenced it (the fragment→fragment / back-to-main case).
        /// </summary>
        /// <param name="owner">the element that owns the reference</param>
        /// <param name="token">the collected reference token (<c>id</c> or <c>path#id</c>)</param>
        /// <returns>the document-scoped cache key to look up</returns>
        private static string ResolveKey(IAurigaElement owner, string token)
        {
            var separator = token.IndexOf('#');
            if (separator < 0)
            {
                return XmiElementCache.Key(owner.SourceDocument, token);
            }

            var id = token.Substring(separator + 1);
            var relativePath = token.Substring(0, separator);

            // EMF's cross-fragment link form is "xsi:type path#id"; strip the optional leading type prefix.
            // A literal space only ever separates the type from the path — real spaces in the path are
            // URL-encoded (%20) — so the path is the last whitespace-separated token before the '#'.
            var space = relativePath.LastIndexOf(' ');
            if (space >= 0)
            {
                relativePath = relativePath.Substring(space + 1);
            }

            if (relativePath.Length == 0)
            {
                return XmiElementCache.Key(owner.SourceDocument, id);
            }

            return XmiElementCache.Key(CanonicalDocument(owner.SourceDocument, relativePath), id);
        }

        /// <summary>
        /// Resolves an <c>href</c> document path (relative to the owner's document) to the canonical,
        /// forward-slashed, <c>..</c>-collapsed, URL-decoded document name used as the cache-key document
        /// component (matching <see cref="IAurigaElement.SourceDocument"/>).
        /// </summary>
        /// <param name="ownerDocument">the document the reference is written in</param>
        /// <param name="relativePath">the (possibly URL-encoded) document part of the href</param>
        /// <returns>the canonical target document name</returns>
        private static string CanonicalDocument(string? ownerDocument, string relativePath)
        {
            var segments = new List<string>();

            var ownerDirectory = ownerDocument ?? string.Empty;
            var lastSlash = ownerDirectory.LastIndexOf('/');
            if (lastSlash >= 0)
            {
                segments.AddRange(ownerDirectory.Substring(0, lastSlash).Split('/'));
            }

            foreach (var segment in Uri.UnescapeDataString(relativePath).Replace('\\', '/').Split('/'))
            {
                if (segment.Length == 0 || segment == ".")
                {
                    continue;
                }

                if (segment == ".." && segments.Count > 0)
                {
                    segments.RemoveAt(segments.Count - 1);
                }
                else if (segment != "..")
                {
                    segments.Add(segment);
                }
            }

            return string.Join("/", segments);
        }
    }
}
