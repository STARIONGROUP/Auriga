// ------------------------------------------------------------------------------------------------
// <copyright file="DataPkgWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Model.AutoGenXmiWriters.Information
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>DataPkg</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class DataPkgWriter : XmiElementWriter<Auriga.Model.Information.IDataPkg>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataPkgWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DataPkgWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>org.polarsys.capella.core.data.information</c>) of the package that
        /// declares <c>DataPkg</c>.
        /// </summary>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.information";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>DataPkg</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "DataPkg";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/core/information/7.0.0</c>) of the package that declares
        /// <c>DataPkg</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/information/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>DataPkg</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Model.Information.IDataPkg poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValueGroups", poco.AppliedPropertyValueGroups, poco, "AppliedPropertyValueGroups", context);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValues", poco.AppliedPropertyValues, poco, "AppliedPropertyValues", context);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            this.WriteReferenceListAttribute(xmlWriter, "features", poco.Features, poco, "Features", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteStringAttribute(xmlWriter, "review", poco.Review);
            WriteStringAttribute(xmlWriter, "sid", poco.Sid);
            this.WriteReferenceAttribute(xmlWriter, "status", poco.Status, poco, "Status", context);
            WriteStringAttribute(xmlWriter, "summary", poco.Summary);
            WriteEnumAttribute<Auriga.Model.Capellacore.VisibilityKind>(xmlWriter, "visibility", poco.Visibility);
            WriteBooleanAttribute(xmlWriter, "visibleInDoc", poco.VisibleInDoc, true);
            WriteBooleanAttribute(xmlWriter, "visibleInLM", poco.VisibleInLM, true);
            this.WriteContainedElements(xmlWriter, "namingRules", poco.NamingRules, poco, "NamingRules", context);
            this.WriteContainedElements(xmlWriter, "ownedAssociations", poco.OwnedAssociations, poco, "OwnedAssociations", context);
            this.WriteContainedElements(xmlWriter, "ownedClasses", poco.OwnedClasses, poco, "OwnedClasses", context);
            this.WriteContainedElements(xmlWriter, "ownedCollections", poco.OwnedCollections, poco, "OwnedCollections", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedDataPkgs", poco.OwnedDataPkgs, poco, "OwnedDataPkgs", context);
            this.WriteContainedElements(xmlWriter, "ownedDataTypes", poco.OwnedDataTypes, poco, "OwnedDataTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedDataValues", poco.OwnedDataValues, poco, "OwnedDataValues", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedExceptions", poco.OwnedExceptions, poco, "OwnedExceptions", context);
            this.WriteContainedElements(xmlWriter, "ownedExchangeItems", poco.OwnedExchangeItems, poco, "OwnedExchangeItems", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedKeyParts", poco.OwnedKeyParts, poco, "OwnedKeyParts", context);
            this.WriteContainedElements(xmlWriter, "ownedMessageReferences", poco.OwnedMessageReferences, poco, "OwnedMessageReferences", context);
            this.WriteContainedElements(xmlWriter, "ownedMessages", poco.OwnedMessages, poco, "OwnedMessages", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValuePkgs", poco.OwnedPropertyValuePkgs, poco, "OwnedPropertyValuePkgs", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElements(xmlWriter, "ownedSignals", poco.OwnedSignals, poco, "OwnedSignals", context);
            this.WriteContainedElements(xmlWriter, "ownedStateEvents", poco.OwnedStateEvents, poco, "OwnedStateEvents", context);
            this.WriteContainedElements(xmlWriter, "ownedTraces", poco.OwnedTraces, poco, "OwnedTraces", context);
            this.WriteContainedElements(xmlWriter, "ownedUnits", poco.OwnedUnits, poco, "OwnedUnits", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
