// ------------------------------------------------------------------------------------------------
// <copyright file="CommunicationMeanWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable disable

namespace Auriga.Xmi.AutoGenXmiWriters.Oa
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>CommunicationMean</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CommunicationMeanWriter : XmiElementWriter<Auriga.Oa.ICommunicationMean>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationMeanWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CommunicationMeanWriter(IXmiElementWriterFacade facade, ILoggerFactory loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <inheritdoc/>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.oa";

        /// <inheritdoc/>
        public override string TypeName => "CommunicationMean";

        /// <inheritdoc/>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/oa/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CommunicationMean</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Oa.ICommunicationMean poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "realizedFlow", poco.RealizedFlow, poco, "RealizedFlow", context);
            WriteStringAttribute(xmlWriter, "sid", poco.Sid);
            WriteStringAttribute(xmlWriter, "summary", poco.Summary);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            WriteStringAttribute(xmlWriter, "review", poco.Review);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValues", poco.AppliedPropertyValues, poco, "AppliedPropertyValues", context);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValueGroups", poco.AppliedPropertyValueGroups, poco, "AppliedPropertyValueGroups", context);
            this.WriteReferenceAttribute(xmlWriter, "status", poco.Status, poco, "Status", context);
            this.WriteReferenceListAttribute(xmlWriter, "features", poco.Features, poco, "Features", context);
            WriteBooleanAttribute(xmlWriter, "visibleInDoc", poco.VisibleInDoc);
            WriteBooleanAttribute(xmlWriter, "visibleInLM", poco.VisibleInLM);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteEnumAttribute<Auriga.Fa.ComponentExchangeKind>(xmlWriter, "kind", poco.Kind);
            WriteBooleanAttribute(xmlWriter, "oriented", poco.Oriented);
            this.WriteReferenceAttribute(xmlWriter, "link", poco.Link, poco, "Link", context);
            this.WriteReferenceListAttribute(xmlWriter, "realizations", poco.Realizations, poco, "Realizations", context);
            this.WriteReferenceListAttribute(xmlWriter, "convoyedInformations", poco.ConvoyedInformations, poco, "ConvoyedInformations", context);
            this.WriteReferenceAttribute(xmlWriter, "source", poco.Source, poco, "Source", context);
            this.WriteReferenceAttribute(xmlWriter, "target", poco.Target, poco, "Target", context);
            this.WriteContainedElements(xmlWriter, "namingRules", poco.NamingRules, poco, "NamingRules", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedComponentExchangeFunctionalExchangeAllocations", poco.OwnedComponentExchangeFunctionalExchangeAllocations, poco, "OwnedComponentExchangeFunctionalExchangeAllocations", context);
            this.WriteContainedElements(xmlWriter, "ownedComponentExchangeRealizations", poco.OwnedComponentExchangeRealizations, poco, "OwnedComponentExchangeRealizations", context);
            this.WriteContainedElements(xmlWriter, "ownedComponentExchangeEnds", poco.OwnedComponentExchangeEnds, poco, "OwnedComponentExchangeEnds", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
