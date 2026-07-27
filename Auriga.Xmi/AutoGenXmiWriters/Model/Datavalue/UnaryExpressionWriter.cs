// ------------------------------------------------------------------------------------------------
// <copyright file="UnaryExpressionWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Model.AutoGenXmiWriters.Information.Datavalue
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>UnaryExpression</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class UnaryExpressionWriter : XmiElementWriter<Auriga.Model.Information.Datavalue.IUnaryExpression>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnaryExpressionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public UnaryExpressionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>org.polarsys.capella.core.data.information.datavalue</c>) of the package that
        /// declares <c>UnaryExpression</c>.
        /// </summary>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.information.datavalue";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>UnaryExpression</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "UnaryExpression";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/core/information/datavalue/7.0.0</c>) of the package that declares
        /// <c>UnaryExpression</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/information/datavalue/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>UnaryExpression</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Model.Information.Datavalue.IUnaryExpression poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteBooleanAttribute(xmlWriter, "abstract", poco.Abstract);
            WriteReferenceAttribute(xmlWriter, "abstractType", poco.AbstractType, poco, "AbstractType", context);
            WriteReferenceListAttribute(xmlWriter, "appliedPropertyValueGroups", poco.AppliedPropertyValueGroups, poco, "AppliedPropertyValueGroups", context);
            WriteReferenceListAttribute(xmlWriter, "appliedPropertyValues", poco.AppliedPropertyValues, poco, "AppliedPropertyValues", context);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            WriteReferenceListAttribute(xmlWriter, "features", poco.Features, poco, "Features", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteEnumAttribute<Auriga.Model.Information.Datavalue.UnaryOperator>(xmlWriter, "operator", poco.Operator, Auriga.Extensions.UnaryOperatorProvider.ToLiteralString);
            WriteStringAttribute(xmlWriter, "review", poco.Review);
            WriteStringAttribute(xmlWriter, "sid", poco.Sid);
            WriteReferenceAttribute(xmlWriter, "status", poco.Status, poco, "Status", context);
            WriteStringAttribute(xmlWriter, "summary", poco.Summary);
            WriteReferenceAttribute(xmlWriter, "unit", poco.Unit, poco, "Unit", context);
            WriteStringAttribute(xmlWriter, "unparsedExpression", poco.UnparsedExpression);
            WriteBooleanAttribute(xmlWriter, "visibleInDoc", poco.VisibleInDoc, true);
            WriteBooleanAttribute(xmlWriter, "visibleInLM", poco.VisibleInLM, true);

            // Attributes must all be written before any child element, so the uninterpreted ones the
            // reader retained are emitted here rather than alongside the uninterpreted children.
            WriteUninterpretedAttributes(xmlWriter, poco);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElement(xmlWriter, "ownedOperand", poco.OwnedOperand, poco, "OwnedOperand", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            WriteUninterpretedContent(xmlWriter, poco);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
