// ------------------------------------------------------------------------------------------------
// <copyright file="CompoundEventEndWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Sequence.Ordering
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>CompoundEventEnd</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CompoundEventEndWriter : XmiElementWriter<Auriga.Diagram.Sequence.Ordering.ICompoundEventEnd>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompoundEventEndWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CompoundEventEndWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>ordering</c>) of the package that
        /// declares <c>CompoundEventEnd</c>.
        /// </summary>
        public override string NamespacePrefix => "ordering";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>CompoundEventEnd</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "CompoundEventEnd";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/sequence/ordering/2.0.0</c>) of the package that declares
        /// <c>CompoundEventEnd</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/sequence/ordering/2.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CompoundEventEnd</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Sequence.Ordering.ICompoundEventEnd poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "semanticEnd", poco.SemanticEnd as Auriga.Core.IAurigaElement, poco, "SemanticEnd", context);
            this.WriteContainedElements(xmlWriter, "eventEnds", poco.EventEnds, poco, "EventEnds", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
