// ------------------------------------------------------------------------------------------------
// <copyright file="ViewValidationRuleWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Viewpoint.Description.Validation
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>ViewValidationRule</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class ViewValidationRuleWriter : XmiElementWriter<Auriga.Diagram.Viewpoint.Description.Validation.IViewValidationRule>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewValidationRuleWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ViewValidationRuleWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>validation</c>) of the package that
        /// declares <c>ViewValidationRule</c>.
        /// </summary>
        public override string NamespacePrefix => "validation";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>ViewValidationRule</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "ViewValidationRule";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/description/validation/1.1.0</c>) of the package that declares
        /// <c>ViewValidationRule</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/description/validation/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>ViewValidationRule</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Viewpoint.Description.Validation.IViewValidationRule poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteEnumAttribute<Auriga.Diagram.Viewpoint.Description.Validation.ERROR_LEVEL>(xmlWriter, "level", poco.Level);
            WriteStringAttribute(xmlWriter, "message", poco.Message);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceListAttribute(xmlWriter, "targets", poco.Targets, poco, "Targets", context);
            this.WriteContainedElements(xmlWriter, "audits", poco.Audits, poco, "Audits", context);
            this.WriteContainedElements(xmlWriter, "fixes", poco.Fixes, poco, "Fixes", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
