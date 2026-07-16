// ------------------------------------------------------------------------------------------------
// <copyright file="TLifelineMappingWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>TLifelineMapping</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class TLifelineMappingWriter : XmiElementWriter<Auriga.Sirius.Sequence.Template.ITLifelineMapping>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TLifelineMappingWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public TLifelineMappingWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>template</c>) of the package that
        /// declares <c>TLifelineMapping</c>.
        /// </summary>
        public override string NamespacePrefix => "template";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>TLifelineMapping</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "TLifelineMapping";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/sequence/template/2.0.0</c>) of the package that declares
        /// <c>TLifelineMapping</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/sequence/template/2.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>TLifelineMapping</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Sequence.Template.ITLifelineMapping poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "domainClass", poco.DomainClass);
            WriteStringAttribute(xmlWriter, "eolVisibleExpression", poco.EolVisibleExpression);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceListAttribute(xmlWriter, "outputs", poco.Outputs, poco, "Outputs", context);
            WriteStringAttribute(xmlWriter, "semanticCandidatesExpression", poco.SemanticCandidatesExpression);
            this.WriteContainedElements(xmlWriter, "conditionalLifeLineStyles", poco.ConditionalLifeLineStyles, poco, "ConditionalLifeLineStyles", context);
            this.WriteContainedElement(xmlWriter, "endOfLifeStyle", poco.EndOfLifeStyle, poco, "EndOfLifeStyle", context);
            this.WriteContainedElements(xmlWriter, "executionMappings", poco.ExecutionMappings, poco, "ExecutionMappings", context);
            this.WriteContainedElement(xmlWriter, "instanceRoleStyle", poco.InstanceRoleStyle, poco, "InstanceRoleStyle", context);
            this.WriteContainedElement(xmlWriter, "lifelineStyle", poco.LifelineStyle, poco, "LifelineStyle", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
