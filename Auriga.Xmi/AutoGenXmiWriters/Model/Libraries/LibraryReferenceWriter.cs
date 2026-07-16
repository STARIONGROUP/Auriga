// ------------------------------------------------------------------------------------------------
// <copyright file="LibraryReferenceWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Model.AutoGenXmiWriters.Libraries
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>LibraryReference</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class LibraryReferenceWriter : XmiElementWriter<Auriga.Model.Libraries.ILibraryReference>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryReferenceWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public LibraryReferenceWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>libraries</c>) of the package that
        /// declares <c>LibraryReference</c>.
        /// </summary>
        public override string NamespacePrefix => "libraries";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>LibraryReference</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "LibraryReference";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/common/libraries/7.0.0</c>) of the package that declares
        /// <c>LibraryReference</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/common/libraries/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>LibraryReference</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Model.Libraries.ILibraryReference poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteEnumAttribute<Auriga.Model.Libraries.AccessPolicy>(xmlWriter, "accessPolicy", poco.AccessPolicy);
            this.WriteReferenceAttribute(xmlWriter, "library", poco.Library, poco, "Library", context);
            this.WriteReferenceAttribute(xmlWriter, "version", poco.Version, poco, "Version", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
