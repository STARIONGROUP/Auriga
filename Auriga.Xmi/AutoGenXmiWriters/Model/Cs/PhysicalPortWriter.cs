// ------------------------------------------------------------------------------------------------
// <copyright file="PhysicalPortWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Model.AutoGenXmiWriters.Cs
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>PhysicalPort</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class PhysicalPortWriter : XmiElementWriter<Auriga.Model.Cs.IPhysicalPort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalPortWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public PhysicalPortWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>org.polarsys.capella.core.data.cs</c>) of the package that
        /// declares <c>PhysicalPort</c>.
        /// </summary>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.cs";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>PhysicalPort</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "PhysicalPort";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/core/cs/7.0.0</c>) of the package that declares
        /// <c>PhysicalPort</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/cs/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>PhysicalPort</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Model.Cs.IPhysicalPort poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "abstractType", poco.AbstractType, poco, "AbstractType", context);
            WriteEnumAttribute<Auriga.Model.Information.AggregationKind>(xmlWriter, "aggregationKind", poco.AggregationKind);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValueGroups", poco.AppliedPropertyValueGroups, poco, "AppliedPropertyValueGroups", context);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValues", poco.AppliedPropertyValues, poco, "AppliedPropertyValues", context);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            this.WriteReferenceListAttribute(xmlWriter, "features", poco.Features, poco, "Features", context);
            WriteBooleanAttribute(xmlWriter, "final", poco.Final);
            WriteBooleanAttribute(xmlWriter, "isAbstract", poco.IsAbstract);
            WriteBooleanAttribute(xmlWriter, "isDerived", poco.IsDerived);
            WriteBooleanAttribute(xmlWriter, "isPartOfKey", poco.IsPartOfKey);
            WriteBooleanAttribute(xmlWriter, "isReadOnly", poco.IsReadOnly);
            WriteBooleanAttribute(xmlWriter, "isStatic", poco.IsStatic);
            WriteBooleanAttribute(xmlWriter, "maxInclusive", poco.MaxInclusive);
            WriteBooleanAttribute(xmlWriter, "minInclusive", poco.MinInclusive);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteBooleanAttribute(xmlWriter, "ordered", poco.Ordered);
            this.WriteReferenceListAttribute(xmlWriter, "providedInterfaces", poco.ProvidedInterfaces, poco, "ProvidedInterfaces", context);
            this.WriteReferenceListAttribute(xmlWriter, "requiredInterfaces", poco.RequiredInterfaces, poco, "RequiredInterfaces", context);
            WriteStringAttribute(xmlWriter, "review", poco.Review);
            WriteStringAttribute(xmlWriter, "sid", poco.Sid);
            this.WriteReferenceAttribute(xmlWriter, "status", poco.Status, poco, "Status", context);
            WriteStringAttribute(xmlWriter, "summary", poco.Summary);
            WriteBooleanAttribute(xmlWriter, "unique", poco.Unique);
            WriteEnumAttribute<Auriga.Model.Capellacore.VisibilityKind>(xmlWriter, "visibility", poco.Visibility);
            WriteBooleanAttribute(xmlWriter, "visibleInDoc", poco.VisibleInDoc);
            WriteBooleanAttribute(xmlWriter, "visibleInLM", poco.VisibleInLM);
            this.WriteContainedElements(xmlWriter, "ownedComponentPortAllocations", poco.OwnedComponentPortAllocations, poco, "OwnedComponentPortAllocations", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElement(xmlWriter, "ownedDefaultValue", poco.OwnedDefaultValue, poco, "OwnedDefaultValue", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElement(xmlWriter, "ownedMaxCard", poco.OwnedMaxCard, poco, "OwnedMaxCard", context);
            this.WriteContainedElement(xmlWriter, "ownedMaxLength", poco.OwnedMaxLength, poco, "OwnedMaxLength", context);
            this.WriteContainedElement(xmlWriter, "ownedMaxValue", poco.OwnedMaxValue, poco, "OwnedMaxValue", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElement(xmlWriter, "ownedMinCard", poco.OwnedMinCard, poco, "OwnedMinCard", context);
            this.WriteContainedElement(xmlWriter, "ownedMinLength", poco.OwnedMinLength, poco, "OwnedMinLength", context);
            this.WriteContainedElement(xmlWriter, "ownedMinValue", poco.OwnedMinValue, poco, "OwnedMinValue", context);
            this.WriteContainedElement(xmlWriter, "ownedNullValue", poco.OwnedNullValue, poco, "OwnedNullValue", context);
            this.WriteContainedElements(xmlWriter, "ownedPhysicalPortRealizations", poco.OwnedPhysicalPortRealizations, poco, "OwnedPhysicalPortRealizations", context);
            this.WriteContainedElements(xmlWriter, "ownedPortAllocations", poco.OwnedPortAllocations, poco, "OwnedPortAllocations", context);
            this.WriteContainedElements(xmlWriter, "ownedPortRealizations", poco.OwnedPortRealizations, poco, "OwnedPortRealizations", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElements(xmlWriter, "ownedProtocols", poco.OwnedProtocols, poco, "OwnedProtocols", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
