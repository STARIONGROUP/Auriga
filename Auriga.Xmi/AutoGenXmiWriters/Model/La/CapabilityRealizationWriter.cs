// ------------------------------------------------------------------------------------------------
// <copyright file="CapabilityRealizationWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Model.AutoGenXmiWriters.La
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>CapabilityRealization</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CapabilityRealizationWriter : XmiElementWriter<Auriga.Model.La.ICapabilityRealization>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapabilityRealizationWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CapabilityRealizationWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>org.polarsys.capella.core.data.la</c>) of the package that
        /// declares <c>CapabilityRealization</c>.
        /// </summary>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.la";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>CapabilityRealization</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "CapabilityRealization";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/core/la/7.0.0</c>) of the package that declares
        /// <c>CapabilityRealization</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/la/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CapabilityRealization</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Model.La.ICapabilityRealization poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValueGroups", poco.AppliedPropertyValueGroups, poco, "AppliedPropertyValueGroups", context);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValues", poco.AppliedPropertyValues, poco, "AppliedPropertyValues", context);
            this.WriteReferenceListAttribute(xmlWriter, "availableInStates", poco.AvailableInStates, poco, "AvailableInStates", context);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            this.WriteReferenceListAttribute(xmlWriter, "features", poco.Features, poco, "Features", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceAttribute(xmlWriter, "postCondition", poco.PostCondition, poco, "PostCondition", context);
            this.WriteReferenceAttribute(xmlWriter, "preCondition", poco.PreCondition, poco, "PreCondition", context);
            WriteStringAttribute(xmlWriter, "review", poco.Review);
            WriteStringAttribute(xmlWriter, "sid", poco.Sid);
            this.WriteReferenceAttribute(xmlWriter, "status", poco.Status, poco, "Status", context);
            WriteStringAttribute(xmlWriter, "summary", poco.Summary);
            WriteBooleanAttribute(xmlWriter, "visibleInDoc", poco.VisibleInDoc, true);
            WriteBooleanAttribute(xmlWriter, "visibleInLM", poco.VisibleInLM, true);
            this.WriteContainedElements(xmlWriter, "abstractCapabilityExtensionPoints", poco.AbstractCapabilityExtensionPoints, poco, "AbstractCapabilityExtensionPoints", context);
            this.WriteContainedElements(xmlWriter, "extends", poco.Extends, poco, "Extends", context);
            this.WriteContainedElements(xmlWriter, "includes", poco.Includes, poco, "Includes", context);
            this.WriteContainedElements(xmlWriter, "namingRules", poco.NamingRules, poco, "NamingRules", context);
            this.WriteContainedElements(xmlWriter, "ownedAbstractCapabilityRealizations", poco.OwnedAbstractCapabilityRealizations, poco, "OwnedAbstractCapabilityRealizations", context);
            this.WriteContainedElements(xmlWriter, "ownedAbstractFunctionAbstractCapabilityInvolvements", poco.OwnedAbstractFunctionAbstractCapabilityInvolvements, poco, "OwnedAbstractFunctionAbstractCapabilityInvolvements", context);
            this.WriteContainedElements(xmlWriter, "ownedCapabilityRealizationInvolvements", poco.OwnedCapabilityRealizationInvolvements, poco, "OwnedCapabilityRealizationInvolvements", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedFunctionalChainAbstractCapabilityInvolvements", poco.OwnedFunctionalChainAbstractCapabilityInvolvements, poco, "OwnedFunctionalChainAbstractCapabilityInvolvements", context);
            this.WriteContainedElements(xmlWriter, "ownedFunctionalChains", poco.OwnedFunctionalChains, poco, "OwnedFunctionalChains", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValuePkgs", poco.OwnedPropertyValuePkgs, poco, "OwnedPropertyValuePkgs", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElements(xmlWriter, "ownedScenarios", poco.OwnedScenarios, poco, "OwnedScenarios", context);
            this.WriteContainedElements(xmlWriter, "ownedTraces", poco.OwnedTraces, poco, "OwnedTraces", context);
            this.WriteContainedElements(xmlWriter, "superGeneralizations", poco.SuperGeneralizations, poco, "SuperGeneralizations", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
