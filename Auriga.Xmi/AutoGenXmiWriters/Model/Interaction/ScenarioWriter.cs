// ------------------------------------------------------------------------------------------------
// <copyright file="ScenarioWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Model.AutoGenXmiWriters.Interaction
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>Scenario</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class ScenarioWriter : XmiElementWriter<Auriga.Model.Interaction.IScenario>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ScenarioWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>org.polarsys.capella.core.data.interaction</c>) of the package that
        /// declares <c>Scenario</c>.
        /// </summary>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.interaction";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>Scenario</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "Scenario";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/core/interaction/7.0.0</c>) of the package that declares
        /// <c>Scenario</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/interaction/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>Scenario</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Model.Interaction.IScenario poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValueGroups", poco.AppliedPropertyValueGroups, poco, "AppliedPropertyValueGroups", context);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValues", poco.AppliedPropertyValues, poco, "AppliedPropertyValues", context);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            this.WriteReferenceListAttribute(xmlWriter, "features", poco.Features, poco, "Features", context);
            WriteBooleanAttribute(xmlWriter, "isControlOperator", poco.IsControlOperator);
            WriteEnumAttribute<Auriga.Model.Interaction.ScenarioKind>(xmlWriter, "kind", poco.Kind, Auriga.Model.Interaction.ScenarioKind.UNSET);
            WriteBooleanAttribute(xmlWriter, "merged", poco.Merged);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceListAttribute(xmlWriter, "ownedParameter", poco.OwnedParameter, poco, "OwnedParameter", context);
            this.WriteReferenceListAttribute(xmlWriter, "ownedParameterSet", poco.OwnedParameterSet, poco, "OwnedParameterSet", context);
            this.WriteReferenceAttribute(xmlWriter, "postCondition", poco.PostCondition, poco, "PostCondition", context);
            this.WriteReferenceAttribute(xmlWriter, "preCondition", poco.PreCondition, poco, "PreCondition", context);
            WriteStringAttribute(xmlWriter, "review", poco.Review);
            WriteStringAttribute(xmlWriter, "sid", poco.Sid);
            this.WriteReferenceAttribute(xmlWriter, "status", poco.Status, poco, "Status", context);
            WriteStringAttribute(xmlWriter, "summary", poco.Summary);
            WriteBooleanAttribute(xmlWriter, "visibleInDoc", poco.VisibleInDoc, true);
            WriteBooleanAttribute(xmlWriter, "visibleInLM", poco.VisibleInLM, true);
            this.WriteContainedElements(xmlWriter, "namingRules", poco.NamingRules, poco, "NamingRules", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraintDurations", poco.OwnedConstraintDurations, poco, "OwnedConstraintDurations", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedEvents", poco.OwnedEvents, poco, "OwnedEvents", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedFormalGates", poco.OwnedFormalGates, poco, "OwnedFormalGates", context);
            this.WriteContainedElements(xmlWriter, "ownedInstanceRoles", poco.OwnedInstanceRoles, poco, "OwnedInstanceRoles", context);
            this.WriteContainedElements(xmlWriter, "ownedInteractionFragments", poco.OwnedInteractionFragments, poco, "OwnedInteractionFragments", context);
            this.WriteContainedElements(xmlWriter, "ownedMessages", poco.OwnedMessages, poco, "OwnedMessages", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElements(xmlWriter, "ownedScenarioRealization", poco.OwnedScenarioRealization, poco, "OwnedScenarioRealization", context);
            this.WriteContainedElements(xmlWriter, "ownedTimeLapses", poco.OwnedTimeLapses, poco, "OwnedTimeLapses", context);
            this.WriteContainedElements(xmlWriter, "ownedTraces", poco.OwnedTraces, poco, "OwnedTraces", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
