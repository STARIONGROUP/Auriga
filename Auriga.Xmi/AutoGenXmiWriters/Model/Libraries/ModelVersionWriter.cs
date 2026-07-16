// ------------------------------------------------------------------------------------------------
// <copyright file="ModelVersionWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>ModelVersion</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class ModelVersionWriter : XmiElementWriter<Auriga.Model.Libraries.IModelVersion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelVersionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ModelVersionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>libraries</c>) of the package that
        /// declares <c>ModelVersion</c>.
        /// </summary>
        public override string NamespacePrefix => "libraries";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>ModelVersion</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "ModelVersion";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/common/libraries/7.0.0</c>) of the package that declares
        /// <c>ModelVersion</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/common/libraries/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>ModelVersion</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Model.Libraries.IModelVersion poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteLongAttribute(xmlWriter, "lastModifiedFileStamp", poco.LastModifiedFileStamp);
            WriteIntegerAttribute(xmlWriter, "majorVersionNumber", poco.MajorVersionNumber);
            WriteIntegerAttribute(xmlWriter, "minorVersionNumber", poco.MinorVersionNumber);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
