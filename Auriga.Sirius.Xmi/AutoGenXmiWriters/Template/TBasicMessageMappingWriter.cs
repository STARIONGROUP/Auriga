// ------------------------------------------------------------------------------------------------
// <copyright file="TBasicMessageMappingWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Sequence.Template
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>TBasicMessageMapping</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class TBasicMessageMappingWriter : XmiElementWriter<Auriga.Sirius.Sequence.Template.ITBasicMessageMapping>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TBasicMessageMappingWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public TBasicMessageMappingWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>template</c>) of the package that
        /// declares <c>TBasicMessageMapping</c>.
        /// </summary>
        public override string NamespacePrefix => "template";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>TBasicMessageMapping</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "TBasicMessageMapping";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/sequence/template/2.0.0</c>) of the package that declares
        /// <c>TBasicMessageMapping</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/sequence/template/2.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>TBasicMessageMapping</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Sequence.Template.ITBasicMessageMapping poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "domainClass", poco.DomainClass);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteBooleanAttribute(xmlWriter, "oblique", poco.Oblique);
            this.WriteReferenceListAttribute(xmlWriter, "outputs", poco.Outputs, poco, "Outputs", context);
            WriteStringAttribute(xmlWriter, "receivingEndFinderExpression", poco.ReceivingEndFinderExpression);
            WriteStringAttribute(xmlWriter, "semanticCandidatesExpression", poco.SemanticCandidatesExpression);
            WriteStringAttribute(xmlWriter, "sendingEndFinderExpression", poco.SendingEndFinderExpression);
            this.WriteReferenceListAttribute(xmlWriter, "source", poco.Source, poco, "Source", context);
            WriteStringAttribute(xmlWriter, "sourceFinderExpression", poco.SourceFinderExpression);
            this.WriteReferenceListAttribute(xmlWriter, "target", poco.Target, poco, "Target", context);
            WriteStringAttribute(xmlWriter, "targetFinderExpression", poco.TargetFinderExpression);
            WriteBooleanAttribute(xmlWriter, "useDomainElement", poco.UseDomainElement);
            this.WriteContainedElements(xmlWriter, "conditionalStyle", poco.ConditionalStyle, poco, "ConditionalStyle", context);
            this.WriteContainedElement(xmlWriter, "style", poco.Style, poco, "Style", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
