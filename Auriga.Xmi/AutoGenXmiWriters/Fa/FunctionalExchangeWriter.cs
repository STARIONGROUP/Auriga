// ------------------------------------------------------------------------------------------------
// <copyright file="FunctionalExchangeWriter.cs" company="Starion Group S.A.">
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

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>FunctionalExchange</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class FunctionalExchangeWriter : XmiElementWriter<Auriga.Fa.IFunctionalExchange>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalExchangeWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public FunctionalExchangeWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>org.polarsys.capella.core.data.fa</c>) of the package that
        /// declares <c>FunctionalExchange</c>.
        /// </summary>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.fa";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>FunctionalExchange</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "FunctionalExchange";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/core/fa/7.0.0</c>) of the package that declares
        /// <c>FunctionalExchange</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/fa/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>FunctionalExchange</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Fa.IFunctionalExchange poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValueGroups", poco.AppliedPropertyValueGroups, poco, "AppliedPropertyValueGroups", context);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValues", poco.AppliedPropertyValues, poco, "AppliedPropertyValues", context);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            this.WriteReferenceListAttribute(xmlWriter, "exchangeSpecifications", poco.ExchangeSpecifications, poco, "ExchangeSpecifications", context);
            this.WriteReferenceListAttribute(xmlWriter, "exchangedItems", poco.ExchangedItems, poco, "ExchangedItems", context);
            this.WriteReferenceListAttribute(xmlWriter, "features", poco.Features, poco, "Features", context);
            this.WriteReferenceAttribute(xmlWriter, "interrupts", poco.Interrupts, poco, "Interrupts", context);
            WriteBooleanAttribute(xmlWriter, "isMulticast", poco.IsMulticast);
            WriteBooleanAttribute(xmlWriter, "isMultireceive", poco.IsMultireceive);
            WriteEnumAttribute<Auriga.Modellingcore.RateKind>(xmlWriter, "kindOfRate", poco.KindOfRate);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceAttribute(xmlWriter, "realizedFlow", poco.RealizedFlow, poco, "RealizedFlow", context);
            WriteStringAttribute(xmlWriter, "review", poco.Review);
            this.WriteReferenceAttribute(xmlWriter, "selection", poco.Selection, poco, "Selection", context);
            WriteStringAttribute(xmlWriter, "sid", poco.Sid);
            this.WriteReferenceAttribute(xmlWriter, "source", poco.Source, poco, "Source", context);
            this.WriteReferenceAttribute(xmlWriter, "status", poco.Status, poco, "Status", context);
            WriteStringAttribute(xmlWriter, "summary", poco.Summary);
            this.WriteReferenceAttribute(xmlWriter, "target", poco.Target, poco, "Target", context);
            this.WriteReferenceAttribute(xmlWriter, "transformation", poco.Transformation, poco, "Transformation", context);
            WriteBooleanAttribute(xmlWriter, "visibleInDoc", poco.VisibleInDoc);
            WriteBooleanAttribute(xmlWriter, "visibleInLM", poco.VisibleInLM);
            this.WriteContainedElement(xmlWriter, "guard", poco.Guard, poco, "Guard", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedFunctionalExchangeRealizations", poco.OwnedFunctionalExchangeRealizations, poco, "OwnedFunctionalExchangeRealizations", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElement(xmlWriter, "probability", poco.Probability, poco, "Probability", context);
            this.WriteContainedElement(xmlWriter, "rate", poco.Rate, poco, "Rate", context);
            this.WriteContainedElement(xmlWriter, "weight", poco.Weight, poco, "Weight", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
