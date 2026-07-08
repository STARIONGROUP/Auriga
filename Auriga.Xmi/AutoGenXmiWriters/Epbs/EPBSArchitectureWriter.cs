// ------------------------------------------------------------------------------------------------
// <copyright file="EPBSArchitectureWriter.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiWriters.Epbs
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>EPBSArchitecture</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class EPBSArchitectureWriter : XmiElementWriter<Auriga.Epbs.IEPBSArchitecture>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EPBSArchitectureWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public EPBSArchitectureWriter(IXmiElementWriterFacade facade, ILoggerFactory loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <inheritdoc/>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.epbs";

        /// <inheritdoc/>
        public override string TypeName => "EPBSArchitecture";

        /// <inheritdoc/>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/epbs/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>EPBSArchitecture</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Epbs.IEPBSArchitecture poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
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
            this.WriteContainedElement(xmlWriter, "ownedConfigurationItemPkg", poco.OwnedConfigurationItemPkg, poco, "OwnedConfigurationItemPkg", context);
            this.WriteContainedElements(xmlWriter, "ownedPhysicalArchitectureRealizations", poco.OwnedPhysicalArchitectureRealizations, poco, "OwnedPhysicalArchitectureRealizations", context);
            this.WriteContainedElement(xmlWriter, "ownedAbstractCapabilityPkg", poco.OwnedAbstractCapabilityPkg, poco, "OwnedAbstractCapabilityPkg", context);
            this.WriteContainedElement(xmlWriter, "ownedInterfacePkg", poco.OwnedInterfacePkg, poco, "OwnedInterfacePkg", context);
            this.WriteContainedElement(xmlWriter, "ownedDataPkg", poco.OwnedDataPkg, poco, "OwnedDataPkg", context);
            this.WriteContainedElement(xmlWriter, "ownedFunctionPkg", poco.OwnedFunctionPkg, poco, "OwnedFunctionPkg", context);
            this.WriteContainedElements(xmlWriter, "ownedComponentExchanges", poco.OwnedComponentExchanges, poco, "OwnedComponentExchanges", context);
            this.WriteContainedElements(xmlWriter, "ownedComponentExchangeCategories", poco.OwnedComponentExchangeCategories, poco, "OwnedComponentExchangeCategories", context);
            this.WriteContainedElements(xmlWriter, "ownedFunctionalLinks", poco.OwnedFunctionalLinks, poco, "OwnedFunctionalLinks", context);
            this.WriteContainedElements(xmlWriter, "ownedFunctionalAllocations", poco.OwnedFunctionalAllocations, poco, "OwnedFunctionalAllocations", context);
            this.WriteContainedElements(xmlWriter, "ownedComponentExchangeRealizations", poco.OwnedComponentExchangeRealizations, poco, "OwnedComponentExchangeRealizations", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValuePkgs", poco.OwnedPropertyValuePkgs, poco, "OwnedPropertyValuePkgs", context);
            this.WriteContainedElements(xmlWriter, "ownedTraces", poco.OwnedTraces, poco, "OwnedTraces", context);
            this.WriteContainedElements(xmlWriter, "namingRules", poco.NamingRules, poco, "NamingRules", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
