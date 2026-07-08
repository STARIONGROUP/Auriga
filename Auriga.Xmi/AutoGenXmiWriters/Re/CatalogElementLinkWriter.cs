// ------------------------------------------------------------------------------------------------
// <copyright file="CatalogElementLinkWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable disable

namespace Auriga.Xmi.AutoGenXmiWriters.Re
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>CatalogElementLink</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CatalogElementLinkWriter : XmiElementWriter<Auriga.Re.ICatalogElementLink>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogElementLinkWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CatalogElementLinkWriter(IXmiElementWriterFacade facade, ILoggerFactory loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <inheritdoc/>
        public override string NamespacePrefix => "re";

        /// <inheritdoc/>
        public override string TypeName => "CatalogElementLink";

        /// <inheritdoc/>
        public override string NamespaceUri => "http://www.polarsys.org/capella/common/re/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CatalogElementLink</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Re.ICatalogElementLink poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "source", poco.Source, poco, "Source", context);
            this.WriteReferenceAttribute(xmlWriter, "target", poco.Target as Auriga.IAurigaElement, poco, "Target", context);
            this.WriteReferenceAttribute(xmlWriter, "origin", poco.Origin, poco, "Origin", context);
            WriteStringListAttribute(xmlWriter, "unsynchronizedFeatures", poco.UnsynchronizedFeatures);
            WriteBooleanAttribute(xmlWriter, "suffixed", poco.Suffixed);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
