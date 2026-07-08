// ------------------------------------------------------------------------------------------------
// <copyright file="ServiceWriter.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiWriters.Information
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>Service</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class ServiceWriter : XmiElementWriter<Auriga.Information.IService>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ServiceWriter(IXmiElementWriterFacade facade, ILoggerFactory loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <inheritdoc/>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.information";

        /// <inheritdoc/>
        public override string TypeName => "Service";

        /// <inheritdoc/>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/information/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>Service</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Information.IService poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteEnumAttribute<Auriga.Information.SynchronismKind>(xmlWriter, "synchronismKind", poco.SynchronismKind);
            this.WriteReferenceListAttribute(xmlWriter, "thrownExceptions", poco.ThrownExceptions, poco, "ThrownExceptions", context);
            this.WriteReferenceListAttribute(xmlWriter, "messageReferences", poco.MessageReferences, poco, "MessageReferences", context);
            WriteBooleanAttribute(xmlWriter, "isAbstract", poco.IsAbstract);
            WriteBooleanAttribute(xmlWriter, "isStatic", poco.IsStatic);
            WriteEnumAttribute<Auriga.Capellacore.VisibilityKind>(xmlWriter, "visibility", poco.Visibility);
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
            this.WriteContainedElements(xmlWriter, "ownedParameters", poco.OwnedParameters, poco, "OwnedParameters", context);
            this.WriteContainedElements(xmlWriter, "ownedOperationAllocation", poco.OwnedOperationAllocation, poco, "OwnedOperationAllocation", context);
            this.WriteContainedElements(xmlWriter, "ownedExchangeItemRealizations", poco.OwnedExchangeItemRealizations, poco, "OwnedExchangeItemRealizations", context);
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
