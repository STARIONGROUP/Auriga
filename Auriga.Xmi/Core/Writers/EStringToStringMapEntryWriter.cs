// ------------------------------------------------------------------------------------------------
// <copyright file="EStringToStringMapEntryWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Writers
{
    using System.Xml;

    using Auriga.Core;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The hand-written XMI writer for the inline <c>ecore:EStringToStringMapEntry</c> elements EMF
    /// emits for an <c>EMap&lt;String, String&gt;</c>-typed feature (e.g. a Sirius
    /// <c>DAnnotation</c>'s <c>details</c>). The map-entry type is an Ecore built-in that belongs to
    /// no vendored metamodel package, so a composed runtime facade routes it here instead of to a
    /// generated per-type writer — the inverse of
    /// <see cref="Auriga.Xmi.Core.Readers.EStringToStringMapEntryReader"/>.
    /// </summary>
    public sealed class EStringToStringMapEntryWriter : XmiElementWriter<IEStringToStringMapEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EStringToStringMapEntryWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public EStringToStringMapEntryWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory = null)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the <c>xmlns</c> prefix (<c>ecore</c>) of the Ecore package the map-entry type belongs to.
        /// </summary>
        public override string NamespacePrefix => "ecore";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>EStringToStringMapEntry</c>).
        /// </summary>
        public override string TypeName => "EStringToStringMapEntry";

        /// <summary>
        /// Gets the Ecore namespace URI (<c>http://www.eclipse.org/emf/2002/Ecore</c>).
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/emf/2002/Ecore";

        /// <summary>
        /// Writes the entry's identity and its <c>key</c> / <c>value</c> attributes. A map entry carries
        /// no children of its own.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the map entry whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, IEStringToStringMapEntry poco, IXmiWriteContext context)
        {
            this.WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "key", poco.Key);
            WriteStringAttribute(xmlWriter, "value", poco.Value);
        }
    }
}
