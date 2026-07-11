// ------------------------------------------------------------------------------------------------
// <copyright file="CompositeFilterDescriptionWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Diagram.Description.Filter
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>CompositeFilterDescription</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CompositeFilterDescriptionWriter : XmiElementWriter<Auriga.Sirius.Diagram.Description.Filter.ICompositeFilterDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeFilterDescriptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CompositeFilterDescriptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>filter</c>) of the package that
        /// declares <c>CompositeFilterDescription</c>.
        /// </summary>
        public override string NamespacePrefix => "filter";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>CompositeFilterDescription</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "CompositeFilterDescription";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/filter/1.1.0</c>) of the package that declares
        /// <c>CompositeFilterDescription</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/filter/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CompositeFilterDescription</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Diagram.Description.Filter.ICompositeFilterDescription poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteContainedElements(xmlWriter, "filters", poco.Filters, poco, "Filters", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
