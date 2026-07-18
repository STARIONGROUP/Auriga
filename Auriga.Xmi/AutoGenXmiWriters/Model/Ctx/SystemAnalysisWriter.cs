// ------------------------------------------------------------------------------------------------
// <copyright file="SystemAnalysisWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Model.AutoGenXmiWriters.Ctx
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>SystemAnalysis</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class SystemAnalysisWriter : XmiElementWriter<Auriga.Model.Ctx.ISystemAnalysis>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemAnalysisWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public SystemAnalysisWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>org.polarsys.capella.core.data.ctx</c>) of the package that
        /// declares <c>SystemAnalysis</c>.
        /// </summary>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.ctx";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>SystemAnalysis</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "SystemAnalysis";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/core/ctx/7.0.0</c>) of the package that declares
        /// <c>SystemAnalysis</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/ctx/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>SystemAnalysis</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Model.Ctx.ISystemAnalysis poco, IXmiWriteContext context)
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
            WriteBooleanAttribute(xmlWriter, "visibleInDoc", poco.VisibleInDoc, true);
            WriteBooleanAttribute(xmlWriter, "visibleInLM", poco.VisibleInLM, true);
            this.WriteContainedElements(xmlWriter, "namingRules", poco.NamingRules, poco, "NamingRules", context);
            this.WriteContainedElement(xmlWriter, "ownedAbstractCapabilityPkg", poco.OwnedAbstractCapabilityPkg, poco, "OwnedAbstractCapabilityPkg", context);
            this.WriteContainedElements(xmlWriter, "ownedComponentExchangeCategories", poco.OwnedComponentExchangeCategories, poco, "OwnedComponentExchangeCategories", context);
            this.WriteContainedElements(xmlWriter, "ownedComponentExchangeRealizations", poco.OwnedComponentExchangeRealizations, poco, "OwnedComponentExchangeRealizations", context);
            this.WriteContainedElements(xmlWriter, "ownedComponentExchanges", poco.OwnedComponentExchanges, poco, "OwnedComponentExchanges", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElement(xmlWriter, "ownedDataPkg", poco.OwnedDataPkg, poco, "OwnedDataPkg", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElement(xmlWriter, "ownedFunctionPkg", poco.OwnedFunctionPkg, poco, "OwnedFunctionPkg", context);
            this.WriteContainedElements(xmlWriter, "ownedFunctionalAllocations", poco.OwnedFunctionalAllocations, poco, "OwnedFunctionalAllocations", context);
            this.WriteContainedElements(xmlWriter, "ownedFunctionalLinks", poco.OwnedFunctionalLinks, poco, "OwnedFunctionalLinks", context);
            this.WriteContainedElement(xmlWriter, "ownedInterfacePkg", poco.OwnedInterfacePkg, poco, "OwnedInterfacePkg", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElement(xmlWriter, "ownedMissionPkg", poco.OwnedMissionPkg, poco, "OwnedMissionPkg", context);
            this.WriteContainedElements(xmlWriter, "ownedOperationalAnalysisRealizations", poco.OwnedOperationalAnalysisRealizations, poco, "OwnedOperationalAnalysisRealizations", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValuePkgs", poco.OwnedPropertyValuePkgs, poco, "OwnedPropertyValuePkgs", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElement(xmlWriter, "ownedSystemComponentPkg", poco.OwnedSystemComponentPkg, poco, "OwnedSystemComponentPkg", context);
            this.WriteContainedElements(xmlWriter, "ownedTraces", poco.OwnedTraces, poco, "OwnedTraces", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
