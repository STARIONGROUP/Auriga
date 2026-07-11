// ------------------------------------------------------------------------------------------------
// <copyright file="ValidationFixWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Viewpoint.Description.Validation
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>ValidationFix</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class ValidationFixWriter : XmiElementWriter<Auriga.Sirius.Viewpoint.Description.Validation.IValidationFix>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationFixWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ValidationFixWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>validation</c>) of the package that
        /// declares <c>ValidationFix</c>.
        /// </summary>
        public override string NamespacePrefix => "validation";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>ValidationFix</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "ValidationFix";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/description/validation/1.1.0</c>) of the package that declares
        /// <c>ValidationFix</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/description/validation/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>ValidationFix</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Viewpoint.Description.Validation.IValidationFix poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteContainedElement(xmlWriter, "initialOperation", poco.InitialOperation, poco, "InitialOperation", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
