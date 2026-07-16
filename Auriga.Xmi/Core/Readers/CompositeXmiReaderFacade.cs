// ------------------------------------------------------------------------------------------------
// <copyright file="CompositeXmiReaderFacade.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Readers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    using Auriga.Core;

    /// <summary>
    /// An <see cref="IXmiReaderFacade"/> that unions the dispatch tables of several metamodel facades
    /// (e.g. the generated Capella and Sirius facades), so one reader reads every document type. Each
    /// element's type key is routed to the first facade that has a reader registered for it — the
    /// per-metamodel key spaces are disjoint by construction, because the <c>package:TypeName</c> keys
    /// use each metamodel's own Ecore package names. The constituent facades must share one
    /// namespace resolver seeded with the union of the metamodels' namespace registries, so any of
    /// them can resolve any document's type keys.
    /// </summary>
    public sealed class CompositeXmiReaderFacade : IXmiReaderFacade
    {
        /// <summary>
        /// The per-metamodel facades the composite routes between, in registration order.
        /// </summary>
        private readonly IReadOnlyList<IXmiReaderFacade> facades;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeXmiReaderFacade"/> class.
        /// </summary>
        /// <param name="facades">the per-metamodel facades to union, in routing order</param>
        public CompositeXmiReaderFacade(params IXmiReaderFacade[] facades)
        {
            if (facades == null)
            {
                throw new ArgumentNullException(nameof(facades));
            }

            if (facades.Length == 0)
            {
                throw new ArgumentException("At least one facade is required.", nameof(facades));
            }

            this.facades = facades;
        }

        /// <summary>
        /// Registers a document-level <c>xmlns</c> prefix-to-URI binding with every constituent facade,
        /// so an <c>xsi:type</c> prefix can be resolved even deep in the tree regardless of which facade
        /// ends up reading the element.
        /// </summary>
        /// <param name="prefix">the namespace prefix</param>
        /// <param name="namespaceUri">the namespace URI it is bound to</param>
        public void RegisterNamespace(string prefix, string namespaceUri)
        {
            foreach (var facade in this.facades)
            {
                facade.RegisterNamespace(prefix, namespaceUri);
            }
        }

        /// <summary>
        /// Whether any constituent facade has a reader registered for the supplied package-qualified
        /// type key (<c>package:TypeName</c>).
        /// </summary>
        /// <param name="typeKey">the package-qualified type key (<c>package:TypeName</c>)</param>
        /// <returns>true when one of the constituent facades can read the type</returns>
        public bool CanRead(string typeKey)
        {
            return this.facades.Any(facade => facade.CanRead(typeKey));
        }

        /// <summary>
        /// Resolves the package-qualified type key (<c>package:TypeName</c>) of the element at the
        /// cursor. Delegated to the first constituent facade: all constituents share the same namespace
        /// resolver and receive the same <see cref="RegisterNamespace"/> calls, so any of them resolves
        /// the same key.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the package-qualified type key</returns>
        public string ResolveTypeKey(XmlReader xmlReader)
        {
            return this.facades[0].ResolveTypeKey(xmlReader);
        }

        /// <summary>
        /// Reads the element at the cursor of <paramref name="xmlReader"/> into a typed
        /// <see cref="IAurigaElement"/> by routing its type key to the constituent facade that has a
        /// reader registered for it.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element to read</param>
        /// <param name="documentName">the document being read, relative to the model's main file; recorded
        /// as the element's source and used to build its document-scoped cache key</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <param name="explicitTypeKey">
        /// the package-qualified type key (<c>package:TypeName</c>) to use instead of the element's
        /// <c>xsi:type</c>, or <c>null</c> to resolve the type from <c>xsi:type</c>
        /// </param>
        /// <returns>the instantiated, populated element</returns>
        /// <exception cref="InvalidOperationException">
        /// no constituent facade has a reader registered for the element's type
        /// </exception>
        public IAurigaElement QueryElement(XmlReader xmlReader, string documentName, string namespaceUri, string? explicitTypeKey = null)
        {
            var typeKey = explicitTypeKey ?? this.ResolveTypeKey(xmlReader);

            foreach (var facade in this.facades)
            {
                if (facade.CanRead(typeKey))
                {
                    return facade.QueryElement(xmlReader, documentName, namespaceUri, typeKey);
                }
            }

            throw new InvalidOperationException(
                $"No XMI reader is registered for the type '{typeKey}' in any of the configured metamodel facades: {string.Join(", ", this.facades.Select(facade => facade.GetType().FullName))}.");
        }
    }
}
