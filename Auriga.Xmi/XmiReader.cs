// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Namespaces;
    using Auriga.Xmi.ReferenceResolver;
    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// The default <see cref="IXmiReader"/>. It instantiates the object graph in a first pass by
    /// dispatching the root and every contained element to its generated reader through the
    /// <see cref="IXmiReaderFacade"/>, then resolves the collected cross-references in a second pass via
    /// the <see cref="IReferenceResolver"/> — the two-pass strategy of uml4net. Cross-file fragments
    /// (<c>href</c>) are out of scope for this reader.
    /// </summary>
    public sealed class XmiReader : IXmiReader
    {
        /// <summary>
        /// The cache in which every element read on the first pass is registered by <c>xmi:id</c>.
        /// </summary>
        private readonly IXmiElementCache cache;

        /// <summary>
        /// The facade that maps an element's <c>xsi:type</c> to its generated reader and reads it.
        /// </summary>
        private readonly IXmiReaderFacade facade;

        /// <summary>
        /// The resolver that maps a namespace URI to its Ecore package, used to key the document root.
        /// </summary>
        private readonly INamespaceResolver namespaceResolver;

        /// <summary>
        /// The second-pass resolver that turns the collected <c>#id</c> references into object references.
        /// </summary>
        private readonly IReferenceResolver referenceResolver;

        /// <summary>
        /// The logger used to report unresolved roots and other read-level diagnostics.
        /// </summary>
        private readonly ILogger<XmiReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade (xsi:type to reader registry)</param>
        /// <param name="namespaceResolver">the namespace-URI-to-package resolver</param>
        /// <param name="referenceResolver">the second-pass reference resolver</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public XmiReader(IXmiElementCache cache, IXmiReaderFacade facade, INamespaceResolver namespaceResolver, IReferenceResolver referenceResolver, ILoggerFactory? loggerFactory = null)
        {
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
            this.facade = facade ?? throw new ArgumentNullException(nameof(facade));
            this.namespaceResolver = namespaceResolver ?? throw new ArgumentNullException(nameof(namespaceResolver));
            this.referenceResolver = referenceResolver ?? throw new ArgumentNullException(nameof(referenceResolver));
            this.logger = (loggerFactory ?? NullLoggerFactory.Instance).CreateLogger<XmiReader>();
        }

        /// <summary>
        /// Reads the XMI document at the supplied path.
        /// </summary>
        /// <param name="path">the path of the <c>.melodymodeller</c> / <c>.capella</c> file</param>
        /// <returns>the read result</returns>
        public XmiReaderResult Read(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The path must be provided.", nameof(path));
            }

            using var stream = File.OpenRead(path);
            return this.Read(stream, Path.GetFileName(path));
        }

        /// <summary>
        /// Reads the XMI document from the supplied stream.
        /// </summary>
        /// <param name="stream">the stream to read</param>
        /// <param name="documentName">the name of the document (used for diagnostics)</param>
        /// <returns>the read result</returns>
        public XmiReaderResult Read(Stream stream, string documentName)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            this.cache.Clear();

            var settings = new XmlReaderSettings
            {
                IgnoreComments = true,
                IgnoreWhitespace = true,
                IgnoreProcessingInstructions = true,
                DtdProcessing = DtdProcessing.Prohibit,
                CloseInput = false,
            };

            using var xmlReader = XmlReader.Create(stream, settings);

            if (xmlReader.MoveToContent() != XmlNodeType.Element)
            {
                throw new InvalidDataException($"The document '{documentName}' does not contain a root element.");
            }

            this.RegisterDocumentNamespaces(xmlReader);

            var rootTypeKey = this.ResolveRootTypeKey(xmlReader, documentName);
            var root = this.facade.QueryElement(xmlReader, rootTypeKey);

            var unresolvedReferences = this.referenceResolver.Resolve(this.cache);

            if (unresolvedReferences.Count > 0)
            {
                this.logger.LogWarning("{Count} references in {Document} could not be resolved", unresolvedReferences.Count, documentName);
            }

            this.logger.LogInformation("Read {Count} elements from {Document}", this.cache.Count, documentName);

            return new XmiReaderResult(root, this.BuildIndex(), unresolvedReferences);
        }

        /// <summary>
        /// Registers every <c>xmlns</c> prefix-to-URI binding declared on the document with the facade, so
        /// an <c>xsi:type</c> prefix still resolves deep in the tree where nested
        /// <see cref="XmlReader.ReadSubtree"/> readers no longer expose the root's declarations.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the document root</param>
        private void RegisterDocumentNamespaces(XmlReader xmlReader)
        {
            // Capella declares every package namespace on the root element. Capture them once here, while
            // the reader still has the full namespace scope, so xsi:type prefixes resolve deep in the tree
            // where nested ReadSubtree readers no longer expose the root declarations.
            if (xmlReader is IXmlNamespaceResolver resolver)
            {
                foreach (var binding in resolver.GetNamespacesInScope(XmlNamespaceScope.All))
                {
                    this.facade.RegisterNamespace(binding.Key, binding.Value);
                }
            }
        }

        /// <summary>
        /// Builds the package-qualified type key (<c>package:TypeName</c>) for the document root from its
        /// namespace URI and local name, since the root carries no <c>xsi:type</c> of its own.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the document root</param>
        /// <param name="documentName">the name of the document (used for diagnostics)</param>
        /// <returns>the package-qualified type key for the root element</returns>
        /// <exception cref="InvalidDataException">the root namespace is not a known Capella package</exception>
        private string ResolveRootTypeKey(XmlReader xmlReader, string documentName)
        {
            if (!this.namespaceResolver.TryResolvePackage(xmlReader.NamespaceURI, out var package) || package == null)
            {
                throw new InvalidDataException($"The root namespace '{xmlReader.NamespaceURI}' of '{documentName}' is not a known Capella package.");
            }

            return $"{package}:{xmlReader.LocalName}";
        }

        /// <summary>
        /// Builds the read result's <c>xmi:id</c>-to-element index from the populated cache, skipping any
        /// element that has no identifier.
        /// </summary>
        /// <returns>an index of every identified element keyed by its <c>xmi:id</c></returns>
        private IReadOnlyDictionary<string, IAurigaElement> BuildIndex()
        {
            var index = new Dictionary<string, IAurigaElement>(StringComparer.Ordinal);
            foreach (var element in this.cache.Values)
            {
                if (!string.IsNullOrEmpty(element.Id))
                {
                    index[element.Id!] = element;
                }
            }

            return index;
        }
    }
}
