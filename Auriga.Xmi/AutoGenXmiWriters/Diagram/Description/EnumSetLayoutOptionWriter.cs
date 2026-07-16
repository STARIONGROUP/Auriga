// ------------------------------------------------------------------------------------------------
// <copyright file="EnumSetLayoutOptionWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Diagram.Description
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>EnumSetLayoutOption</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class EnumSetLayoutOptionWriter : XmiElementWriter<Auriga.Diagram.Diagram.Description.IEnumSetLayoutOption>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumSetLayoutOptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public EnumSetLayoutOptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>EnumSetLayoutOption</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>EnumSetLayoutOption</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "EnumSetLayoutOption";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/1.1.0</c>) of the package that declares
        /// <c>EnumSetLayoutOption</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>EnumSetLayoutOption</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Diagram.Description.IEnumSetLayoutOption poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteEnumListAttribute<Auriga.Diagram.Diagram.Description.LayoutOptionTarget>(xmlWriter, "targets", poco.Targets);
            this.WriteContainedElements(xmlWriter, "choices", poco.Choices, poco, "Choices", context);
            this.WriteContainedElements(xmlWriter, "values", poco.Values, poco, "Values", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
