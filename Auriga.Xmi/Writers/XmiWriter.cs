// ------------------------------------------------------------------------------------------------
// <copyright file="XmiWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Writers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// Serializes a Capella object graph back to XMI, preserving the fragment layout it was read from. It
    /// writes the document root with the package prefix and the <c>xmlns</c> declarations of every package
    /// the document uses, then delegates each element to its generated per-type writer through the facade.
    /// The inverse of <see cref="Auriga.Xmi.Readers.XmiReader"/>.
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
        /// <paramref name="mainFilePath"/> and every <c>.capellafragment</c> to a sibling path relative to
        /// it, with cross-document references serialized as relative <c>href</c>s.
        /// </summary>
        /// <param name="root">the root of the object graph (the <c>capellamodeller:Project</c>)</param>
        /// <param name="mainFilePath">the path of the main semantic file to write</param>
        /// <exception cref="ArgumentNullException"><paramref name="root"/> is <c>null</c></exception>
        /// <exception cref="ArgumentException"><paramref name="mainFilePath"/> is <c>null</c> or empty</exception>
        public void Write(IAurigaElement root, string mainFilePath)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            if (string.IsNullOrEmpty(mainFilePath))
            {
                throw new ArgumentException("The main file path is required.", nameof(mainFilePath));
            }

            var fullMainPath = Path.GetFullPath(mainFilePath);
            var mainDirectory = Path.GetDirectoryName(fullMainPath) ?? string.Empty;
            var mainDocument = string.IsNullOrEmpty(root.SourceDocument) ? Path.GetFileName(fullMainPath) : root.SourceDocument!;

            var groups = new Dictionary<string, List<IAurigaElement>>(StringComparer.Ordinal);
            foreach (var element in Flatten(root))
            {
                var document = string.IsNullOrEmpty(element.SourceDocument) ? mainDocument : element.SourceDocument!;
                if (!groups.TryGetValue(document, out var list))
                {
                    list = new List<IAurigaElement>();
                    groups[document] = list;
                }

                list.Add(element);
            }

            foreach (var group in groups)
            {
                var documentName = group.Key;
                var documentRoot = FindDocumentRoot(group.Value, documentName, mainDocument);
                var path = string.Equals(documentName, mainDocument, StringComparison.Ordinal)
                    ? fullMainPath
                    : Path.Combine(mainDirectory, documentName.Replace('/', Path.DirectorySeparatorChar));

                var directory = Path.GetDirectoryName(Path.GetFullPath(path));
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using var stream = File.Create(path);
                this.WriteDocument(documentRoot, stream, documentName);
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

        private static IEnumerable<IAurigaElement> Flatten(IAurigaElement root)
        {
            yield return root;

            foreach (var element in root.QueryAllContainedElements())
            {
                yield return element;
            }
        }

        private static IAurigaElement FindDocumentRoot(List<IAurigaElement> elements, string documentName, string mainDocument)
        {
            foreach (var element in elements)
            {
                var container = element.Container;
                if (container == null)
                {
                    return element;
                }

                var containerDocument = string.IsNullOrEmpty(container.SourceDocument) ? mainDocument : container.SourceDocument!;
                if (!string.Equals(containerDocument, documentName, StringComparison.Ordinal))
                {
                    return element;
                }
            }

            return elements[0];
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
