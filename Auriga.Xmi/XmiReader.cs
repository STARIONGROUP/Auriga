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
    /// the <see cref="IReferenceResolver"/> — the two-pass strategy of uml4net. When a model is split
    /// across a main document and <c>.capellafragment</c> files, <see cref="Read(string)"/> discovers and
    /// loads the referenced fragments into the same object graph so cross-fragment references resolve.
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
        /// Reads the Capella model whose main document is at the supplied path. Any
        /// <c>.capellafragment</c> documents the model references — transitively, resolved relative to the
        /// main document — are loaded into the same object graph so cross-fragment references resolve.
        /// </summary>
        /// <param name="path">the path of the main <c>.melodymodeller</c> / <c>.capella</c> file</param>
        /// <returns>the read result</returns>
        public XmiReaderResult Read(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The path must be provided.", nameof(path));
            }

            var mainPath = Path.GetFullPath(path);
            var baseDirectory = Path.GetDirectoryName(mainPath) ?? string.Empty;

            this.cache.Clear();

            var loaded = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var root = this.LoadDocument(mainPath, baseDirectory, loaded, isMain: true)!;

            // Transitively load every referenced fragment document into the same cache before resolving,
            // so an href whose target lives in another fragment resolves against the merged object graph.
            var pending = new Queue<string>(this.DiscoverReferencedDocuments(baseDirectory, loaded));
            while (pending.Count > 0)
            {
                var documentPath = pending.Dequeue();
                if (loaded.Contains(documentPath))
                {
                    continue;
                }

                this.LoadDocument(documentPath, baseDirectory, loaded, isMain: false);

                foreach (var referenced in this.DiscoverReferencedDocuments(baseDirectory, loaded))
                {
                    pending.Enqueue(referenced);
                }
            }

            return this.ResolveAndBuild(root, Path.GetFileName(mainPath), loaded.Count);
        }

        /// <summary>
        /// Reads a single XMI document from the supplied stream. A stream has no location, so referenced
        /// fragment documents cannot be discovered; use <see cref="Read(string)"/> to load a model that is
        /// split across fragment files.
        /// </summary>
        /// <param name="stream">the stream to read</param>
        /// <param name="documentName">the name of the document (used for diagnostics and source tracking)</param>
        /// <returns>the read result</returns>
        public XmiReaderResult Read(Stream stream, string documentName)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            this.cache.Clear();

            var root = this.ReadDocument(stream, documentName);

            return this.ResolveAndBuild(root, documentName, 1);
        }

        /// <summary>
        /// Parses a single XMI document from the stream into the cache (without clearing it or resolving
        /// references) and tags every element it contributes with <paramref name="documentName"/>.
        /// </summary>
        /// <param name="stream">the stream to read</param>
        /// <param name="documentName">the name recorded as the source document of the read elements</param>
        /// <returns>the root element of the document</returns>
        private IAurigaElement ReadDocument(Stream stream, string documentName)
        {
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

            var namespaceUri = xmlReader.NamespaceURI;
            var rootTypeKey = this.ResolveRootTypeKey(xmlReader, documentName);

            // Each generated reader records documentName as the read element's source and caches it under
            // its document-scoped key, so no post-hoc tagging pass is needed.
            return this.facade.QueryElement(xmlReader, documentName, namespaceUri, rootTypeKey);
        }

        /// <summary>
        /// Loads the document at the supplied path into the cache. The main document's failures propagate;
        /// a fragment that is missing or fails to parse is logged and skipped so one bad fragment does not
        /// abort the load.
        /// </summary>
        /// <param name="fullPath">the absolute path of the document</param>
        /// <param name="baseDirectory">the directory of the main document, used to name the source</param>
        /// <param name="loaded">the set of already-loaded document paths, to which this path is added</param>
        /// <param name="isMain">whether this is the model's main document</param>
        /// <returns>the root element of the document, or <c>null</c> when a fragment could not be loaded</returns>
        private IAurigaElement? LoadDocument(string fullPath, string baseDirectory, HashSet<string> loaded, bool isMain)
        {
            loaded.Add(fullPath);

            if (!File.Exists(fullPath))
            {
                this.logger.LogWarning("Referenced fragment document {Document} was not found", fullPath);
                return null;
            }

            var documentName = RelativeDocumentName(baseDirectory, fullPath);

            try
            {
                using var stream = File.OpenRead(fullPath);
                return this.ReadDocument(stream, documentName);
            }
            catch (Exception exception) when (!isMain)
            {
                this.logger.LogWarning(exception, "Failed to load fragment document {Document}", documentName);
                return null;
            }
        }

        /// <summary>
        /// Runs the second-pass reference resolution over the merged cache and builds the read result.
        /// </summary>
        /// <param name="root">the root element of the main document</param>
        /// <param name="modelName">the model name used in diagnostics</param>
        /// <param name="documentCount">the number of documents loaded into the graph</param>
        /// <returns>the read result</returns>
        private XmiReaderResult ResolveAndBuild(IAurigaElement root, string modelName, int documentCount)
        {
            var unresolvedReferences = this.referenceResolver.Resolve(this.cache);

            if (unresolvedReferences.Count > 0)
            {
                this.logger.LogWarning("{Count} references in {Model} could not be resolved", unresolvedReferences.Count, modelName);
            }

            this.logger.LogInformation("Read {Count} elements from {DocumentCount} document(s) of {Model}", this.cache.Count, documentCount, modelName);

            return new XmiReaderResult(root, this.BuildIndex(), unresolvedReferences);
        }

        /// <summary>
        /// Scans every collected reference for cross-document <c>href</c> tokens (<c>path#id</c>) and
        /// returns the absolute paths of the referenced documents that have not yet been loaded.
        /// </summary>
        /// <param name="baseDirectory">the directory the relative href paths are resolved against</param>
        /// <param name="loaded">the set of already-loaded document paths</param>
        /// <returns>the absolute paths of the not-yet-loaded referenced documents</returns>
        private IEnumerable<string> DiscoverReferencedDocuments(string baseDirectory, HashSet<string> loaded)
        {
            var documents = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var element in this.cache.Values)
            {
                foreach (var token in element.SingleValueReferencePropertyIdentifiers.Values)
                {
                    AddReferencedDocument(token, baseDirectory, loaded, documents);
                }

                foreach (var tokens in element.MultiValueReferencePropertyIdentifiers.Values)
                {
                    foreach (var token in tokens)
                    {
                        AddReferencedDocument(token, baseDirectory, loaded, documents);
                    }
                }
            }

            return documents;
        }

        /// <summary>
        /// Adds the document referenced by a single <c>href</c> token to <paramref name="documents"/> when
        /// the token is a not-yet-loaded reference into a <c>.capellafragment</c>. Intra-document
        /// references (a bare id) and references to anything other than a fragment — <c>hlink://</c> in
        /// rich text, <c>platform:/resource</c> library links, <c>.aird</c> diagrams — are ignored.
        /// </summary>
        /// <param name="token">the collected reference token</param>
        /// <param name="baseDirectory">the directory the relative path is resolved against</param>
        /// <param name="loaded">the set of already-loaded document paths</param>
        /// <param name="documents">the set the referenced document path is added to</param>
        private static void AddReferencedDocument(string token, string baseDirectory, HashSet<string> loaded, HashSet<string> documents)
        {
            var separator = token.IndexOf('#');
            if (separator <= 0)
            {
                return;
            }

            var relative = token.Substring(0, separator);

            if (!relative.EndsWith(".capellafragment", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var documentPath = Path.GetFullPath(Path.Combine(baseDirectory, Uri.UnescapeDataString(relative)));

            if (!loaded.Contains(documentPath))
            {
                documents.Add(documentPath);
            }
        }

        /// <summary>
        /// Names a loaded document relative to the model's base directory, with forward slashes, for use
        /// as the elements' <see cref="IAurigaElement.SourceDocument"/>.
        /// </summary>
        /// <param name="baseDirectory">the directory of the main document</param>
        /// <param name="fullPath">the absolute path of the loaded document</param>
        /// <returns>the document name relative to the base directory</returns>
        private static string RelativeDocumentName(string baseDirectory, string fullPath)
        {
            var relative = Path.GetRelativePath(baseDirectory, fullPath);
            return relative.Replace(Path.DirectorySeparatorChar, '/');
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
