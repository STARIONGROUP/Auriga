// ------------------------------------------------------------------------------------------------
// <copyright file="CapabilityConfigurationWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>CapabilityConfiguration</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CapabilityConfigurationWriter : XmiElementWriter<Auriga.Oa.ICapabilityConfiguration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapabilityConfigurationWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CapabilityConfigurationWriter(IXmiElementWriterFacade facade, ILoggerFactory loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <inheritdoc/>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.oa";

        /// <inheritdoc/>
        public override string TypeName => "CapabilityConfiguration";

        /// <inheritdoc/>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/oa/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CapabilityConfiguration</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Oa.ICapabilityConfiguration poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "configuredCapability", poco.ConfiguredCapability, poco, "ConfiguredCapability", context);
            this.WriteReferenceListAttribute(xmlWriter, "composingLinks", poco.ComposingLinks, poco, "ComposingLinks", context);
            WriteBooleanAttribute(xmlWriter, "actor", poco.Actor);
            WriteBooleanAttribute(xmlWriter, "human", poco.Human);
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
            this.WriteReferenceListAttribute(xmlWriter, "inExchangeLinks", poco.InExchangeLinks, poco, "InExchangeLinks", context);
            this.WriteReferenceListAttribute(xmlWriter, "outExchangeLinks", poco.OutExchangeLinks, poco, "OutExchangeLinks", context);
            WriteBooleanAttribute(xmlWriter, "abstract", poco.Abstract);
            this.WriteContainedElements(xmlWriter, "ownedInterfaceUses", poco.OwnedInterfaceUses, poco, "OwnedInterfaceUses", context);
            this.WriteContainedElements(xmlWriter, "ownedInterfaceImplementations", poco.OwnedInterfaceImplementations, poco, "OwnedInterfaceImplementations", context);
            this.WriteContainedElements(xmlWriter, "ownedComponentRealizations", poco.OwnedComponentRealizations, poco, "OwnedComponentRealizations", context);
            this.WriteContainedElements(xmlWriter, "ownedPhysicalPath", poco.OwnedPhysicalPath, poco, "OwnedPhysicalPath", context);
            this.WriteContainedElements(xmlWriter, "ownedPhysicalLinks", poco.OwnedPhysicalLinks, poco, "OwnedPhysicalLinks", context);
            this.WriteContainedElements(xmlWriter, "ownedPhysicalLinkCategories", poco.OwnedPhysicalLinkCategories, poco, "OwnedPhysicalLinkCategories", context);
            this.WriteContainedElement(xmlWriter, "ownedAbstractCapabilityPkg", poco.OwnedAbstractCapabilityPkg, poco, "OwnedAbstractCapabilityPkg", context);
            this.WriteContainedElement(xmlWriter, "ownedInterfacePkg", poco.OwnedInterfacePkg, poco, "OwnedInterfacePkg", context);
            this.WriteContainedElement(xmlWriter, "ownedDataPkg", poco.OwnedDataPkg, poco, "OwnedDataPkg", context);
            this.WriteContainedElements(xmlWriter, "ownedStateMachines", poco.OwnedStateMachines, poco, "OwnedStateMachines", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedTraces", poco.OwnedTraces, poco, "OwnedTraces", context);
            this.WriteContainedElements(xmlWriter, "namingRules", poco.NamingRules, poco, "NamingRules", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedFunctionalAllocation", poco.OwnedFunctionalAllocation, poco, "OwnedFunctionalAllocation", context);
            this.WriteContainedElements(xmlWriter, "ownedComponentExchanges", poco.OwnedComponentExchanges, poco, "OwnedComponentExchanges", context);
            this.WriteContainedElements(xmlWriter, "ownedComponentExchangeCategories", poco.OwnedComponentExchangeCategories, poco, "OwnedComponentExchangeCategories", context);
            this.WriteContainedElements(xmlWriter, "ownedFeatures", poco.OwnedFeatures, poco, "OwnedFeatures", context);
            this.WriteContainedElements(xmlWriter, "ownedGeneralizations", poco.OwnedGeneralizations, poco, "OwnedGeneralizations", context);
            this.WriteContainedElements(xmlWriter, "ownedInterfaceAllocations", poco.OwnedInterfaceAllocations, poco, "OwnedInterfaceAllocations", context);
            this.WriteContainedElements(xmlWriter, "ownedCommunicationLinks", poco.OwnedCommunicationLinks, poco, "OwnedCommunicationLinks", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
