// ------------------------------------------------------------------------------------------------
// <copyright file="SecurityNeedsWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Model.AutoGenXmiWriters.Cybersecurity
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>SecurityNeeds</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class SecurityNeedsWriter : XmiElementWriter<Auriga.Model.Cybersecurity.ISecurityNeeds>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityNeedsWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public SecurityNeedsWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>cybersecurity</c>) of the package that
        /// declares <c>SecurityNeeds</c>.
        /// </summary>
        public override string NamespacePrefix => "cybersecurity";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>SecurityNeeds</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "SecurityNeeds";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/cybersecurity/1.0</c>) of the package that declares
        /// <c>SecurityNeeds</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/cybersecurity/1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>SecurityNeeds</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Model.Cybersecurity.ISecurityNeeds poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteReferenceListAttribute(xmlWriter, "appliedPropertyValueGroups", poco.AppliedPropertyValueGroups, poco, "AppliedPropertyValueGroups", context);
            WriteReferenceListAttribute(xmlWriter, "appliedPropertyValues", poco.AppliedPropertyValues, poco, "AppliedPropertyValues", context);
            WriteReferenceAttribute(xmlWriter, "availabilityValue", poco.AvailabilityValue, poco, "AvailabilityValue", context);
            WriteReferenceAttribute(xmlWriter, "confidentialityValue", poco.ConfidentialityValue, poco, "ConfidentialityValue", context);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            WriteReferenceListAttribute(xmlWriter, "features", poco.Features, poco, "Features", context);
            WriteReferenceAttribute(xmlWriter, "integrityValue", poco.IntegrityValue, poco, "IntegrityValue", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteStringAttribute(xmlWriter, "review", poco.Review);
            WriteStringAttribute(xmlWriter, "sid", poco.Sid);
            WriteReferenceAttribute(xmlWriter, "status", poco.Status, poco, "Status", context);
            WriteStringAttribute(xmlWriter, "summary", poco.Summary);
            WriteReferenceAttribute(xmlWriter, "traceabilityValue", poco.TraceabilityValue, poco, "TraceabilityValue", context);
            WriteBooleanAttribute(xmlWriter, "visibleInDoc", poco.VisibleInDoc, true);
            WriteBooleanAttribute(xmlWriter, "visibleInLM", poco.VisibleInLM, true);

            // Attributes must all be written before any child element, so the uninterpreted ones the
            // reader retained are emitted here rather than alongside the uninterpreted children.
            WriteUninterpretedAttributes(xmlWriter, poco);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            WriteUninterpretedContent(xmlWriter, poco);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
