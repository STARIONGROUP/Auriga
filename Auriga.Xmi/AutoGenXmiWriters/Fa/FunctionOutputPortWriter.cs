// ------------------------------------------------------------------------------------------------
// <copyright file="FunctionOutputPortWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.AutoGenXmiWriters.Fa
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>FunctionOutputPort</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class FunctionOutputPortWriter : XmiElementWriter<Auriga.Fa.IFunctionOutputPort>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionOutputPortWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public FunctionOutputPortWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>org.polarsys.capella.core.data.fa</c>) of the package that
        /// declares <c>FunctionOutputPort</c>.
        /// </summary>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.fa";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>FunctionOutputPort</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "FunctionOutputPort";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/core/fa/7.0.0</c>) of the package that declares
        /// <c>FunctionOutputPort</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/fa/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>FunctionOutputPort</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Fa.IFunctionOutputPort poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "abstractType", poco.AbstractType, poco, "AbstractType", context);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValueGroups", poco.AppliedPropertyValueGroups, poco, "AppliedPropertyValueGroups", context);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValues", poco.AppliedPropertyValues, poco, "AppliedPropertyValues", context);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            this.WriteReferenceListAttribute(xmlWriter, "features", poco.Features, poco, "Features", context);
            this.WriteReferenceListAttribute(xmlWriter, "inState", poco.InState, poco, "InState", context);
            WriteBooleanAttribute(xmlWriter, "isControl", poco.IsControl);
            WriteBooleanAttribute(xmlWriter, "isControlType", poco.IsControlType);
            WriteEnumAttribute<Auriga.Activity.ObjectNodeKind>(xmlWriter, "kindOfNode", poco.KindOfNode);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteEnumAttribute<Auriga.Activity.ObjectNodeOrderingKind>(xmlWriter, "ordering", poco.Ordering);
            this.WriteReferenceListAttribute(xmlWriter, "outgoingExchangeItems", poco.OutgoingExchangeItems, poco, "OutgoingExchangeItems", context);
            this.WriteReferenceListAttribute(xmlWriter, "providedInterfaces", poco.ProvidedInterfaces, poco, "ProvidedInterfaces", context);
            this.WriteReferenceAttribute(xmlWriter, "representedComponentPort", poco.RepresentedComponentPort, poco, "RepresentedComponentPort", context);
            this.WriteReferenceListAttribute(xmlWriter, "requiredInterfaces", poco.RequiredInterfaces, poco, "RequiredInterfaces", context);
            WriteStringAttribute(xmlWriter, "review", poco.Review);
            this.WriteReferenceAttribute(xmlWriter, "selection", poco.Selection, poco, "Selection", context);
            WriteStringAttribute(xmlWriter, "sid", poco.Sid);
            this.WriteReferenceAttribute(xmlWriter, "status", poco.Status, poco, "Status", context);
            WriteStringAttribute(xmlWriter, "summary", poco.Summary);
            WriteBooleanAttribute(xmlWriter, "visibleInDoc", poco.VisibleInDoc);
            WriteBooleanAttribute(xmlWriter, "visibleInLM", poco.VisibleInLM);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedPortAllocations", poco.OwnedPortAllocations, poco, "OwnedPortAllocations", context);
            this.WriteContainedElements(xmlWriter, "ownedPortRealizations", poco.OwnedPortRealizations, poco, "OwnedPortRealizations", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElements(xmlWriter, "ownedProtocols", poco.OwnedProtocols, poco, "OwnedProtocols", context);
            this.WriteContainedElement(xmlWriter, "upperBound", poco.UpperBound, poco, "UpperBound", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
