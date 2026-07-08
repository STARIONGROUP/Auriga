// ------------------------------------------------------------------------------------------------
// <copyright file="AttributeDefinitionWriter.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiWriters.Requirements
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>AttributeDefinition</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class AttributeDefinitionWriter : XmiElementWriter<Auriga.Requirements.IAttributeDefinition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeDefinitionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public AttributeDefinitionWriter(IXmiElementWriterFacade facade, ILoggerFactory loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <inheritdoc/>
        public override string NamespacePrefix => "Requirements";

        /// <inheritdoc/>
        public override string TypeName => "AttributeDefinition";

        /// <inheritdoc/>
        public override string NamespaceUri => "http://www.polarsys.org/kitalpha/requirements";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>AttributeDefinition</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Requirements.IAttributeDefinition poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "definitionType", poco.DefinitionType, poco, "DefinitionType", context);
            WriteStringAttribute(xmlWriter, "ReqIFIdentifier", poco.ReqIFIdentifier);
            WriteStringAttribute(xmlWriter, "ReqIFDescription", poco.ReqIFDescription);
            WriteStringAttribute(xmlWriter, "ReqIFLongName", poco.ReqIFLongName);
            this.WriteContainedElement(xmlWriter, "defaultValue", poco.DefaultValue, poco, "DefaultValue", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
