// ------------------------------------------------------------------------------------------------
// <copyright file="XmiWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Writers
{
    using Auriga.Core;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// Serializes a Capella or Sirius object graph back to XMI, preserving the fragment layout it was read
    /// from. It writes each document's roots with the package prefix and the <c>xmlns</c> declarations of
    /// every package the document uses, then delegates each element to its generated per-type writer
    /// through the facade. A single-root document (a Capella <c>.capella</c>) is written with its typed
    /// root element; a multi-root document (a Sirius <c>.aird</c>) is wrapped in an <c>xmi:XMI</c> element
    /// holding its parallel roots. The inverse of <see cref="Auriga.Xmi.Core.Readers.XmiReader"/>.
    /// </summary>
    public sealed class XmiWriter : IXmiWriter
    {
        private const string XmiNamespace = "http://www.omg.org/XMI";

        private const string XsiNamespace = "http://www.w3.org/2001/XMLSchema-instance";

        private const string XmlnsNamespace = "http://www.w3.org/2000/xmlns/";

        private readonly IXmiElementWriterFacade facade;

        private readonly IXmiWriterSettings settings;

        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWriter"/> class.
        /// </summary>
        /// <param name="facade">the generated writer facade</param>
        /// <param name="settings">the formatting settings</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public XmiWriter(IXmiElementWriterFacade facade, IXmiWriterSettings settings, ILoggerFactory? loggerFactory = null)
        {
            this.facade = facade ?? throw new ArgumentNullException(nameof(facade));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.logger = (loggerFactory ?? NullLoggerFactory.Instance).CreateLogger<XmiWriter>();
        }

        /// <summary>
        /// Writes the object graph rooted at <paramref name="root"/> to <paramref name="mainFilePath"/>,
        /// preserving the fragment layout: elements are partitioned by their
        /// <see cref="IAurigaElement.SourceDocument"/>, the main document is written to
        /// <paramref name="mainFilePath"/> and every fragment to a sibling path relative to it, with
        /// cross-document references serialized as relative <c>href</c>s.
        /// </summary>
        /// <param name="root">the root of the object graph (e.g. the <c>capellamodeller:Project</c>)</param>
        /// <param name="mainFilePath">the path of the main semantic file to write</param>
        /// <exception cref="ArgumentNullException"><paramref name="root"/> is <c>null</c></exception>
        /// <exception cref="ArgumentException"><paramref name="mainFilePath"/> is <c>null</c> or empty</exception>
        public void Write(IAurigaElement root, string mainFilePath)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            this.Write(new[] { root }, mainFilePath);
        }

        /// <summary>
        /// Writes a multi-root object graph to <paramref name="mainFilePath"/>. Every root is flattened and
        /// all elements are partitioned by their <see cref="IAurigaElement.SourceDocument"/>; each document
        /// is written to its file, wrapped in an <c>xmi:XMI</c> element when it holds more than one root or
        /// is a Sirius <c>.aird</c> / <c>.airdfragment</c>, otherwise written with its single typed root.
        /// </summary>
        /// <param name="roots">the roots of the object graph; the first is treated as the primary root</param>
        /// <param name="mainFilePath">the path of the main file to write</param>
        /// <exception cref="ArgumentNullException"><paramref name="roots"/> is <c>null</c> or contains a <c>null</c></exception>
        /// <exception cref="ArgumentException"><paramref name="roots"/> is empty, or <paramref name="mainFilePath"/> is <c>null</c> or empty</exception>
        public void Write(IReadOnlyCollection<IAurigaElement> roots, string mainFilePath)
        {
            if (roots == null)
            {
                throw new ArgumentNullException(nameof(roots));
            }

            if (string.IsNullOrEmpty(mainFilePath))
            {
                throw new ArgumentException("The main file path is required.", nameof(mainFilePath));
            }

            var rootList = new List<IAurigaElement>(roots);
            if (rootList.Count == 0)
            {
                throw new ArgumentException("At least one root is required.", nameof(roots));
            }

            if (rootList.Contains(null!))
            {
                throw new ArgumentNullException(nameof(roots), "A root element is null.");
            }

            var fullMainPath = Path.GetFullPath(mainFilePath);
            var mainDirectory = Path.GetDirectoryName(fullMainPath) ?? string.Empty;
            var mainDocument = string.IsNullOrEmpty(rootList[0].SourceDocument) ? Path.GetFileName(fullMainPath) : rootList[0].SourceDocument!;

            var groups = new Dictionary<string, List<IAurigaElement>>(StringComparer.Ordinal);
            foreach (var root in rootList)
            {
                foreach (var element in Flatten(root))
                {
                    var document = ResolveDocument(element, mainDocument);
                    if (!groups.TryGetValue(document, out var list))
                    {
                        list = new List<IAurigaElement>();
                        groups[document] = list;
                    }

                    list.Add(element);
                }
            }

            foreach (var group in groups)
            {
                var documentName = group.Key;
                var documentRoots = FindDocumentRoots(group.Value, documentName, mainDocument);
                var path = string.Equals(documentName, mainDocument, StringComparison.Ordinal)
                    ? fullMainPath
                    : Path.Combine(mainDirectory, documentName.Replace('/', Path.DirectorySeparatorChar));

                var directory = Path.GetDirectoryName(Path.GetFullPath(path));
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using var stream = File.Create(path);

                if (documentRoots.Count > 1 || IsAirdFamilyDocument(documentName))
                {
                    this.WriteWrapperDocument(documentRoots, stream, documentName);
                }
                else
                {
                    this.WriteDocument(documentRoots[0], stream, documentName);
                }
            }
        }

        /// <summary>
        /// Writes a single document — the subtree rooted at <paramref name="documentRoot"/> that belongs to
        /// <paramref name="documentName"/> — to a stream. References to elements in other documents are
        /// serialized relative to <paramref name="documentName"/>.
        /// </summary>
        /// <param name="documentRoot">the root element of the document</param>
        /// <param name="stream">the stream to write to</param>
        /// <param name="documentName">the document's canonical name, relative to the main file</param>
        /// <exception cref="ArgumentNullException"><paramref name="documentRoot"/> or <paramref name="stream"/> is <c>null</c></exception>
        /// <exception cref="ArgumentException"><paramref name="documentName"/> is <c>null</c> or empty</exception>
        public void WriteDocument(IAurigaElement documentRoot, Stream stream, string documentName)
        {
            if (documentRoot == null)
            {
                throw new ArgumentNullException(nameof(documentRoot));
            }

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException("The document name is required.", nameof(documentName));
            }

            var xmlSettings = new XmlWriterSettings
            {
                Indent = this.settings.Indent,
                IndentChars = this.settings.IndentChars,
                Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false),
                OmitXmlDeclaration = false,
                CloseOutput = false,

                // Entitize a carriage return in element text as &#xD; rather than writing it literally.
                // XML line-ending normalization collapses a literal CRLF to LF on the next read, so the
                // default (Replace) silently loses every CR in multi-line content — e.g. an
                // OpaqueExpression's bodies, which Capella stores with &#xD;&#xA; line breaks.
                NewLineHandling = NewLineHandling.Entitize,
            };

            using var xmlWriter = XmlWriter.Create(stream, xmlSettings);

            var rootWriter = this.facade.ResolveWriter(documentRoot);

            var namespaces = new SortedDictionary<string, string>(StringComparer.Ordinal);
            this.CollectNamespaces(documentRoot, documentName, namespaces);

            var context = new XmiWriteContext(documentName);

            if (!string.IsNullOrEmpty(this.settings.VersionComment))
            {
                xmlWriter.WriteComment(this.settings.VersionComment);
            }

            xmlWriter.WriteStartElement(rootWriter.NamespacePrefix, rootWriter.TypeName, rootWriter.NamespaceUri);
            xmlWriter.WriteAttributeString("xmi", "version", XmiNamespace, "2.0");
            xmlWriter.WriteAttributeString("xmlns", "xsi", XmlnsNamespace, XsiNamespace);

            foreach (var pair in namespaces)
            {
                if (!string.Equals(pair.Key, rootWriter.NamespacePrefix, StringComparison.Ordinal))
                {
                    xmlWriter.WriteAttributeString("xmlns", pair.Key, XmlnsNamespace, pair.Value);
                }
            }

            rootWriter.WriteBody(xmlWriter, documentRoot, context);

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();

            this.logger.LogTrace("wrote document {Document} rooted at {Type}", documentName, rootWriter.TypeName);
        }

        /// <summary>
        /// Writes a multi-root document as an <c>xmi:XMI</c> wrapper — the form a Sirius <c>.aird</c> takes,
        /// where one <c>viewpoint:DAnalysis</c> and N parallel representation roots share the same file. The
        /// wrapper declares every package the roots use; each root is written with its own package prefix
        /// and type-named element tag (a root carries no type attribute — its tag conveys the type, as the
        /// reader's <c>ResolveRootTypeKey</c> assumes).
        /// </summary>
        /// <param name="documentRoots">the top-level roots of the document, in write order</param>
        /// <param name="stream">the stream to write to</param>
        /// <param name="documentName">the document's canonical name, relative to the main file</param>
        private void WriteWrapperDocument(IReadOnlyList<IAurigaElement> documentRoots, Stream stream, string documentName)
        {
            var xmlSettings = new XmlWriterSettings
            {
                Indent = this.settings.Indent,
                IndentChars = this.settings.IndentChars,
                Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false),
                OmitXmlDeclaration = false,
                CloseOutput = false,

                // Entitize a carriage return in element text as &#xD; rather than writing it literally.
                // XML line-ending normalization collapses a literal CRLF to LF on the next read, so the
                // default (Replace) silently loses every CR in multi-line content — e.g. an
                // OpaqueExpression's bodies, which Capella stores with &#xD;&#xA; line breaks.
                NewLineHandling = NewLineHandling.Entitize,
            };

            using var xmlWriter = XmlWriter.Create(stream, xmlSettings);

            var namespaces = new SortedDictionary<string, string>(StringComparer.Ordinal);
            foreach (var root in documentRoots)
            {
                this.CollectNamespaces(root, documentName, namespaces);
            }

            var context = new XmiWriteContext(documentName);

            if (!string.IsNullOrEmpty(this.settings.VersionComment))
            {
                xmlWriter.WriteComment(this.settings.VersionComment);
            }

            xmlWriter.WriteStartElement("xmi", "XMI", XmiNamespace);
            xmlWriter.WriteAttributeString("xmi", "version", XmiNamespace, "2.0");
            xmlWriter.WriteAttributeString("xmlns", "xsi", XmlnsNamespace, XsiNamespace);

            foreach (var pair in namespaces)
            {
                xmlWriter.WriteAttributeString("xmlns", pair.Key, XmlnsNamespace, pair.Value);
            }

            foreach (var root in documentRoots)
            {
                var rootWriter = this.facade.ResolveWriter(root);
                xmlWriter.WriteStartElement(rootWriter.NamespacePrefix, rootWriter.TypeName, rootWriter.NamespaceUri);
                rootWriter.WriteBody(xmlWriter, root, context);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();

            this.logger.LogTrace("wrote xmi:XMI document {Document} with {RootCount} roots", documentName, documentRoots.Count);
        }

        private static IEnumerable<IAurigaElement> Flatten(IAurigaElement root)
        {
            yield return root;

            foreach (var element in root.QueryAllContainedElements())
            {
                yield return element;
            }
        }

        /// <summary>
        /// The document an element is written into: its own <see cref="IAurigaElement.SourceDocument"/>, or —
        /// for an in-memory element that has none — its container's document (walking up), matching the inline
        /// write policy that an untracked new element belongs to its container's document. Falls back to the
        /// main document for a root without a source.
        /// </summary>
        private static string ResolveDocument(IAurigaElement element, string mainDocument)
        {
            for (var current = element; current != null; current = current.Container)
            {
                if (!string.IsNullOrEmpty(current.SourceDocument))
                {
                    return current.SourceDocument;
                }
            }

            return mainDocument;
        }

        private static List<IAurigaElement> FindDocumentRoots(List<IAurigaElement> elements, string documentName, string mainDocument)
        {
            var roots = new List<IAurigaElement>();

            foreach (var element in elements)
            {
                var container = element.Container;
                if (container == null)
                {
                    roots.Add(element);
                    continue;
                }

                var containerDocument = ResolveDocument(container, mainDocument);
                if (!string.Equals(containerDocument, documentName, StringComparison.Ordinal))
                {
                    roots.Add(element);
                }
            }

            // A document always has at least one root; fall back to the first element read for it.
            if (roots.Count == 0 && elements.Count > 0)
            {
                roots.Add(elements[0]);
            }

            return roots;
        }

        private static bool IsAirdFamilyDocument(string documentName)
        {
            return documentName.EndsWith(".aird", StringComparison.OrdinalIgnoreCase)
                || documentName.EndsWith(".airdfragment", StringComparison.OrdinalIgnoreCase);
        }

        private void CollectNamespaces(IAurigaElement element, string documentName, IDictionary<string, string> namespaces)
        {
            var writer = this.facade.ResolveWriter(element);
            namespaces[writer.NamespacePrefix] = writer.NamespaceUri;

            foreach (var child in element.QueryContainedElements())
            {
                if (string.IsNullOrEmpty(child.SourceDocument) || string.Equals(child.SourceDocument, documentName, StringComparison.Ordinal))
                {
                    this.CollectNamespaces(child, documentName, namespaces);
                }
            }
        }
    }
}
