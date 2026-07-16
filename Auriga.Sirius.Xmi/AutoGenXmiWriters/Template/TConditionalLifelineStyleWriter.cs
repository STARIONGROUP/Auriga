// ------------------------------------------------------------------------------------------------
// <copyright file="TConditionalLifelineStyleWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>TConditionalLifelineStyle</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class TConditionalLifelineStyleWriter : XmiElementWriter<Auriga.Sirius.Sequence.Template.ITConditionalLifelineStyle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TConditionalLifelineStyleWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public TConditionalLifelineStyleWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>template</c>) of the package that
        /// declares <c>TConditionalLifelineStyle</c>.
        /// </summary>
        public override string NamespacePrefix => "template";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>TConditionalLifelineStyle</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "TConditionalLifelineStyle";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/sequence/template/2.0.0</c>) of the package that declares
        /// <c>TConditionalLifelineStyle</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/sequence/template/2.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>TConditionalLifelineStyle</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Sequence.Template.ITConditionalLifelineStyle poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceListAttribute(xmlWriter, "outputs", poco.Outputs, poco, "Outputs", context);
            WriteStringAttribute(xmlWriter, "predicateExpression", poco.PredicateExpression);
            this.WriteContainedElement(xmlWriter, "style", poco.Style, poco, "Style", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
