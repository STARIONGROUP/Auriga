// ------------------------------------------------------------------------------------------------
// <copyright file="ComponentPortWriter.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiWriters.Fa
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>ComponentPort</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class ComponentPortWriter : XmiElementWriter<Auriga.Fa.IComponentPort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentPortWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ComponentPortWriter(IXmiElementWriterFacade facade, ILoggerFactory loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <inheritdoc/>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.fa";

        /// <inheritdoc/>
        public override string TypeName => "ComponentPort";

        /// <inheritdoc/>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/fa/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>ComponentPort</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Fa.IComponentPort poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteEnumAttribute<Auriga.Fa.OrientationPortKind>(xmlWriter, "orientation", poco.Orientation);
            WriteEnumAttribute<Auriga.Fa.ComponentPortKind>(xmlWriter, "kind", poco.Kind);
            this.WriteReferenceListAttribute(xmlWriter, "providedInterfaces", poco.ProvidedInterfaces, poco, "ProvidedInterfaces", context);
            this.WriteReferenceListAttribute(xmlWriter, "requiredInterfaces", poco.RequiredInterfaces, poco, "RequiredInterfaces", context);
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
            WriteEnumAttribute<Auriga.Information.AggregationKind>(xmlWriter, "aggregationKind", poco.AggregationKind);
            WriteBooleanAttribute(xmlWriter, "isDerived", poco.IsDerived);
            WriteBooleanAttribute(xmlWriter, "isReadOnly", poco.IsReadOnly);
            WriteBooleanAttribute(xmlWriter, "isPartOfKey", poco.IsPartOfKey);
            WriteBooleanAttribute(xmlWriter, "isAbstract", poco.IsAbstract);
            WriteBooleanAttribute(xmlWriter, "isStatic", poco.IsStatic);
            WriteEnumAttribute<Auriga.Capellacore.VisibilityKind>(xmlWriter, "visibility", poco.Visibility);
            this.WriteReferenceAttribute(xmlWriter, "abstractType", poco.AbstractType, poco, "AbstractType", context);
            WriteBooleanAttribute(xmlWriter, "ordered", poco.Ordered);
            WriteBooleanAttribute(xmlWriter, "unique", poco.Unique);
            WriteBooleanAttribute(xmlWriter, "minInclusive", poco.MinInclusive);
            WriteBooleanAttribute(xmlWriter, "maxInclusive", poco.MaxInclusive);
            WriteBooleanAttribute(xmlWriter, "final", poco.Final);
            this.WriteContainedElements(xmlWriter, "ownedProtocols", poco.OwnedProtocols, poco, "OwnedProtocols", context);
            this.WriteContainedElements(xmlWriter, "ownedPortRealizations", poco.OwnedPortRealizations, poco, "OwnedPortRealizations", context);
            this.WriteContainedElements(xmlWriter, "ownedPortAllocations", poco.OwnedPortAllocations, poco, "OwnedPortAllocations", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElement(xmlWriter, "ownedDefaultValue", poco.OwnedDefaultValue, poco, "OwnedDefaultValue", context);
            this.WriteContainedElement(xmlWriter, "ownedMinValue", poco.OwnedMinValue, poco, "OwnedMinValue", context);
            this.WriteContainedElement(xmlWriter, "ownedMaxValue", poco.OwnedMaxValue, poco, "OwnedMaxValue", context);
            this.WriteContainedElement(xmlWriter, "ownedNullValue", poco.OwnedNullValue, poco, "OwnedNullValue", context);
            this.WriteContainedElement(xmlWriter, "ownedMinCard", poco.OwnedMinCard, poco, "OwnedMinCard", context);
            this.WriteContainedElement(xmlWriter, "ownedMinLength", poco.OwnedMinLength, poco, "OwnedMinLength", context);
            this.WriteContainedElement(xmlWriter, "ownedMaxCard", poco.OwnedMaxCard, poco, "OwnedMaxCard", context);
            this.WriteContainedElement(xmlWriter, "ownedMaxLength", poco.OwnedMaxLength, poco, "OwnedMaxLength", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
