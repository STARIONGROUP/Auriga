// ------------------------------------------------------------------------------------------------
// <copyright file="SingleEventEndWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Sequence.Ordering
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>SingleEventEnd</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class SingleEventEndWriter : XmiElementWriter<Auriga.Sirius.Sequence.Ordering.ISingleEventEnd>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleEventEndWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public SingleEventEndWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>ordering</c>) of the package that
        /// declares <c>SingleEventEnd</c>.
        /// </summary>
        public override string NamespacePrefix => "ordering";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>SingleEventEnd</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "SingleEventEnd";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/sequence/ordering/2.0.0</c>) of the package that declares
        /// <c>SingleEventEnd</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/sequence/ordering/2.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>SingleEventEnd</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Sequence.Ordering.ISingleEventEnd poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "semanticEnd", poco.SemanticEnd as Auriga.IAurigaElement, poco, "SemanticEnd", context);
            this.WriteReferenceAttribute(xmlWriter, "semanticEvent", poco.SemanticEvent as Auriga.IAurigaElement, poco, "SemanticEvent", context);
            WriteBooleanAttribute(xmlWriter, "start", poco.Start);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
