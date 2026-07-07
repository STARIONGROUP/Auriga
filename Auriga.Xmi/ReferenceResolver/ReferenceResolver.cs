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
        private const BindingFlags PropertyBindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase;

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
        /// Resolves every deferred single- and multi-valued reference of every element in the cache.
        /// </summary>
        /// <param name="cache">the cache holding all instantiated elements</param>
        public void Resolve(IXmiElementCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            foreach (var element in cache.Values)
            {
                this.ResolveSingleValued(cache, element);
                this.ResolveMultiValued(cache, element);
            }
        }

        /// <summary>
        /// Assigns each single-valued reference collected on the supplied element to its property,
        /// resolving the <c>#id</c> against the cache. A reference whose id is unknown, whose property is
        /// missing or read-only, or whose target is not assignable to the property, is logged and skipped.
        /// </summary>
        /// <param name="cache">the cache holding all instantiated elements</param>
        /// <param name="element">the element whose single-valued references are resolved</param>
        private void ResolveSingleValued(IXmiElementCache cache, IAurigaElement element)
        {
            foreach (var pair in element.SingleValueReferencePropertyIdentifiers)
            {
                if (!cache.TryGetValue(pair.Value, out var target) || target == null)
                {
                    this.logger.LogWarning("Unresolved reference {Property}={Id} on {Type}", pair.Key, pair.Value, element.GetType().Name);
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
        private void ResolveMultiValued(IXmiElementCache cache, IAurigaElement element)
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
                    if (!cache.TryGetValue(identifier, out var target) || target == null)
                    {
                        this.logger.LogWarning("Unresolved reference {Property}={Id} on {Type}", pair.Key, identifier, element.GetType().Name);
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
    }
}
