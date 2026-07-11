// ------------------------------------------------------------------------------------------------
// <copyright file="ValidationSetWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>ValidationSet</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class ValidationSetWriter : XmiElementWriter<Auriga.Sirius.Viewpoint.Description.Validation.IValidationSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationSetWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ValidationSetWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>validation</c>) of the package that
        /// declares <c>ValidationSet</c>.
        /// </summary>
        public override string NamespacePrefix => "validation";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>ValidationSet</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "ValidationSet";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/description/validation/1.1.0</c>) of the package that declares
        /// <c>ValidationSet</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/description/validation/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>ValidationSet</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Viewpoint.Description.Validation.IValidationSet poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceListAttribute(xmlWriter, "reusedRules", poco.ReusedRules, poco, "ReusedRules", context);
            this.WriteContainedElements(xmlWriter, "ownedRules", poco.OwnedRules, poco, "OwnedRules", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
