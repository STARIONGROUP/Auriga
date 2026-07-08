// ------------------------------------------------------------------------------------------------
// <copyright file="CompliancyDefinitionPkgWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>CompliancyDefinitionPkg</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CompliancyDefinitionPkgWriter : XmiElementWriter<Auriga.Re.ICompliancyDefinitionPkg>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompliancyDefinitionPkgWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CompliancyDefinitionPkgWriter(IXmiElementWriterFacade facade, ILoggerFactory loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <inheritdoc/>
        public override string NamespacePrefix => "re";

        /// <inheritdoc/>
        public override string TypeName => "CompliancyDefinitionPkg";

        /// <inheritdoc/>
        public override string NamespaceUri => "http://www.polarsys.org/capella/common/re/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CompliancyDefinitionPkg</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Re.ICompliancyDefinitionPkg poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteContainedElements(xmlWriter, "ownedDefinitions", poco.OwnedDefinitions, poco, "OwnedDefinitions", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
