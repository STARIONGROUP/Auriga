// ------------------------------------------------------------------------------------------------
// <copyright file="TSequenceDiagramWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Sequence.Template
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>TSequenceDiagram</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class TSequenceDiagramWriter : XmiElementWriter<Auriga.Diagram.Sequence.Template.ITSequenceDiagram>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TSequenceDiagramWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public TSequenceDiagramWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>template</c>) of the package that
        /// declares <c>TSequenceDiagram</c>.
        /// </summary>
        public override string NamespacePrefix => "template";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>TSequenceDiagram</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "TSequenceDiagram";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/sequence/template/2.0.0</c>) of the package that declares
        /// <c>TSequenceDiagram</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/sequence/template/2.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>TSequenceDiagram</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Sequence.Template.ITSequenceDiagram poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "domainClass", poco.DomainClass);
            WriteStringAttribute(xmlWriter, "endsOrdering", poco.EndsOrdering);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceListAttribute(xmlWriter, "outputs", poco.Outputs, poco, "Outputs", context);
            this.WriteContainedElements(xmlWriter, "lifelineMappings", poco.LifelineMappings, poco, "LifelineMappings", context);
            this.WriteContainedElements(xmlWriter, "messageMappings", poco.MessageMappings, poco, "MessageMappings", context);
            this.WriteContainedElements(xmlWriter, "ownedRepresentations", poco.OwnedRepresentations, poco, "OwnedRepresentations", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
