// ------------------------------------------------------------------------------------------------
// <copyright file="CollectionWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>Collection</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CollectionWriter : XmiElementWriter<Auriga.Model.Information.ICollection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CollectionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>org.polarsys.capella.core.data.information</c>) of the package that
        /// declares <c>Collection</c>.
        /// </summary>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.information";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>Collection</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "Collection";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/core/information/7.0.0</c>) of the package that declares
        /// <c>Collection</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/information/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>Collection</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Model.Information.ICollection poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteBooleanAttribute(xmlWriter, "abstract", poco.Abstract);
            WriteEnumAttribute<Auriga.Model.Information.AggregationKind>(xmlWriter, "aggregationKind", poco.AggregationKind);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValueGroups", poco.AppliedPropertyValueGroups, poco, "AppliedPropertyValueGroups", context);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValues", poco.AppliedPropertyValues, poco, "AppliedPropertyValues", context);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            this.WriteReferenceListAttribute(xmlWriter, "features", poco.Features, poco, "Features", context);
            WriteBooleanAttribute(xmlWriter, "final", poco.Final);
            this.WriteReferenceListAttribute(xmlWriter, "index", poco.Index, poco, "Index", context);
            WriteBooleanAttribute(xmlWriter, "isPrimitive", poco.IsPrimitive);
            WriteEnumAttribute<Auriga.Model.Information.CollectionKind>(xmlWriter, "kind", poco.Kind);
            WriteBooleanAttribute(xmlWriter, "maxInclusive", poco.MaxInclusive);
            WriteBooleanAttribute(xmlWriter, "minInclusive", poco.MinInclusive);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteBooleanAttribute(xmlWriter, "ordered", poco.Ordered);
            WriteStringAttribute(xmlWriter, "review", poco.Review);
            WriteStringAttribute(xmlWriter, "sid", poco.Sid);
            this.WriteReferenceAttribute(xmlWriter, "status", poco.Status, poco, "Status", context);
            WriteStringAttribute(xmlWriter, "summary", poco.Summary);
            this.WriteReferenceAttribute(xmlWriter, "type", poco.Type, poco, "Type", context);
            WriteBooleanAttribute(xmlWriter, "unique", poco.Unique);
            WriteEnumAttribute<Auriga.Model.Capellacore.VisibilityKind>(xmlWriter, "visibility", poco.Visibility);
            WriteBooleanAttribute(xmlWriter, "visibleInDoc", poco.VisibleInDoc);
            WriteBooleanAttribute(xmlWriter, "visibleInLM", poco.VisibleInLM);
            this.WriteContainedElements(xmlWriter, "namingRules", poco.NamingRules, poco, "NamingRules", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedDataValues", poco.OwnedDataValues, poco, "OwnedDataValues", context);
            this.WriteContainedElement(xmlWriter, "ownedDefaultValue", poco.OwnedDefaultValue, poco, "OwnedDefaultValue", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedFeatures", poco.OwnedFeatures, poco, "OwnedFeatures", context);
            this.WriteContainedElements(xmlWriter, "ownedGeneralizations", poco.OwnedGeneralizations, poco, "OwnedGeneralizations", context);
            this.WriteContainedElement(xmlWriter, "ownedMaxCard", poco.OwnedMaxCard, poco, "OwnedMaxCard", context);
            this.WriteContainedElement(xmlWriter, "ownedMaxLength", poco.OwnedMaxLength, poco, "OwnedMaxLength", context);
            this.WriteContainedElement(xmlWriter, "ownedMaxValue", poco.OwnedMaxValue, poco, "OwnedMaxValue", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElement(xmlWriter, "ownedMinCard", poco.OwnedMinCard, poco, "OwnedMinCard", context);
            this.WriteContainedElement(xmlWriter, "ownedMinLength", poco.OwnedMinLength, poco, "OwnedMinLength", context);
            this.WriteContainedElement(xmlWriter, "ownedMinValue", poco.OwnedMinValue, poco, "OwnedMinValue", context);
            this.WriteContainedElement(xmlWriter, "ownedNullValue", poco.OwnedNullValue, poco, "OwnedNullValue", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValuePkgs", poco.OwnedPropertyValuePkgs, poco, "OwnedPropertyValuePkgs", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElements(xmlWriter, "ownedTraces", poco.OwnedTraces, poco, "OwnedTraces", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
