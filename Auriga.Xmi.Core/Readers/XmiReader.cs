// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReader.cs" company="Starion Group S.A.">
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
    using System.IO;
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Namespaces;
    using Auriga.Xmi.ReferenceResolver;

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
        /// The namespace URI of the <c>xmi:XMI</c> wrapper element. A document whose root is this element
        /// (as every Sirius <c>.aird</c> is) carries no type of its own; its typed top-level elements are its
        /// children, so each is read as a root into the shared graph.
        /// </summary>
        private const string XmiWrapperNamespace = "http://www.omg.org/XMI";

        /// <summary>
        /// The local name of the <c>xmi:XMI</c> wrapper element.
        /// </summary>
        private const string XmiWrapperLocalName = "XMI";

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

            // An .aird wraps its typed top-level elements in an xmi:XMI element that has no type of its own;
            // read each child as a root into the shared graph and return the first as the document root.
            if (xmlReader.NamespaceURI == XmiWrapperNamespace && xmlReader.LocalName == XmiWrapperLocalName)
            {
                return this.ReadXmiWrapper(xmlReader, documentName);
            }

            var namespaceUri = xmlReader.NamespaceURI;
            var rootTypeKey = this.ResolveRootTypeKey(xmlReader, documentName);

            // Each generated reader records documentName as the read element's source and caches it under
            // its document-scoped key, so no post-hoc tagging pass is needed.
            return this.facade.QueryElement(xmlReader, documentName, namespaceUri, rootTypeKey);
        }

        /// <summary>
        /// Reads a multi-root <c>xmi:XMI</c> document: every top-level child is a typed element (keyed by
        /// its element name, like a single-root document's root), so each is dispatched to its generated
        /// reader and registered in the shared cache. The first child is returned as the document root; the
        /// rest are reachable through the cache and the read result's element index, and cross-references
        /// between them resolve on the second pass.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the <c>xmi:XMI</c> wrapper element</param>
        /// <param name="documentName">the name recorded as the source document of the read elements</param>
        /// <returns>the first top-level child element</returns>
        /// <exception cref="InvalidDataException">the wrapper contains no top-level elements</exception>
        private IAurigaElement ReadXmiWrapper(XmlReader xmlReader, string documentName)
        {
            IAurigaElement? firstRoot = null;

            if (!xmlReader.IsEmptyElement)
            {
                var wrapperDepth = xmlReader.Depth;

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Depth == wrapperDepth)
                    {
                        break;
                    }

                    if (xmlReader.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }

                    var namespaceUri = xmlReader.NamespaceURI;
                    var typeKey = this.ResolveRootTypeKey(xmlReader, documentName);

                    // QueryElement reads the child's subtree; the reader is left on the child's end element,
                    // so the next Read() advances to the following sibling (or the wrapper's end element).
                    var element = this.facade.QueryElement(xmlReader, documentName, namespaceUri, typeKey);
                    firstRoot ??= element;
                }
            }

            if (firstRoot == null)
            {
                throw new InvalidDataException($"The XMI document '{documentName}' contains no top-level elements.");
            }

            return firstRoot;
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
        /// Scans every collected reference for cross-document <c>href</c> tokens and returns the absolute
        /// paths of the referenced fragment documents that have not yet been loaded. Each href is resolved
        /// relative to the directory of the document that owns it, so a fragment referencing another
        /// fragment (or referencing back to the main file) resolves correctly.
        /// </summary>
        /// <param name="baseDirectory">the directory of the model's main document</param>
        /// <param name="loaded">the set of already-loaded document paths</param>
        /// <returns>the absolute paths of the not-yet-loaded referenced documents</returns>
        private IEnumerable<string> DiscoverReferencedDocuments(string baseDirectory, HashSet<string> loaded)
        {
            var documents = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var element in this.cache.Values)
            {
                foreach (var token in element.SingleValueReferencePropertyIdentifiers.Values)
                {
                    AddReferencedDocument(element.SourceDocument, token, baseDirectory, loaded, documents);
                }

                foreach (var tokens in element.MultiValueReferencePropertyIdentifiers.Values)
                {
                    foreach (var token in tokens)
                    {
                        AddReferencedDocument(element.SourceDocument, token, baseDirectory, loaded, documents);
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
        /// <param name="referringDocument">the document that owns the reference, whose directory the href
        /// path is resolved relative to</param>
        /// <param name="token">the collected reference token</param>
        /// <param name="baseDirectory">the directory of the model's main document</param>
        /// <param name="loaded">the set of already-loaded document paths</param>
        /// <param name="documents">the set the referenced document path is added to</param>
        private static void AddReferencedDocument(string? referringDocument, string token, string baseDirectory, HashSet<string> loaded, HashSet<string> documents)
        {
            var (documentPath, _) = HrefReference.Parse(token);
            if (documentPath.Length == 0)
            {
                return;
            }

            var canonical = HrefReference.Canonicalize(referringDocument, documentPath);

            if (!canonical.EndsWith(".capellafragment", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var fullPath = Path.GetFullPath(Path.Combine(baseDirectory, canonical));

            if (!loaded.Contains(fullPath))
            {
                documents.Add(fullPath);
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
        /// <exception cref="InvalidDataException">the root namespace is not a known package</exception>
        private string ResolveRootTypeKey(XmlReader xmlReader, string documentName)
        {
            if (!this.namespaceResolver.TryResolvePackage(xmlReader.NamespaceURI, out var package) || package == null)
            {
                throw new InvalidDataException($"The root namespace '{xmlReader.NamespaceURI}' of '{documentName}' is not a known package.");
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
