// ------------------------------------------------------------------------------------------------
// <copyright file="FunctionSpecificationWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>FunctionSpecification</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class FunctionSpecificationWriter : XmiElementWriter<Auriga.Fa.IFunctionSpecification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionSpecificationWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public FunctionSpecificationWriter(IXmiElementWriterFacade facade, ILoggerFactory loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <inheritdoc/>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.fa";

        /// <inheritdoc/>
        public override string TypeName => "FunctionSpecification";

        /// <inheritdoc/>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/fa/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>FunctionSpecification</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Fa.IFunctionSpecification poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceListAttribute(xmlWriter, "inExchangeLinks", poco.InExchangeLinks, poco, "InExchangeLinks", context);
            this.WriteReferenceListAttribute(xmlWriter, "outExchangeLinks", poco.OutExchangeLinks, poco, "OutExchangeLinks", context);
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
            WriteBooleanAttribute(xmlWriter, "isReadOnly", poco.IsReadOnly);
            WriteBooleanAttribute(xmlWriter, "isSingleExecution", poco.IsSingleExecution);
            WriteBooleanAttribute(xmlWriter, "isControlOperator", poco.IsControlOperator);
            this.WriteReferenceListAttribute(xmlWriter, "ownedParameterSet", poco.OwnedParameterSet, poco, "OwnedParameterSet", context);
            this.WriteReferenceListAttribute(xmlWriter, "ownedParameter", poco.OwnedParameter, poco, "OwnedParameter", context);
            this.WriteContainedElements(xmlWriter, "ownedFunctionPorts", poco.OwnedFunctionPorts, poco, "OwnedFunctionPorts", context);
            this.WriteContainedElements(xmlWriter, "ownedTraces", poco.OwnedTraces, poco, "OwnedTraces", context);
            this.WriteContainedElements(xmlWriter, "namingRules", poco.NamingRules, poco, "NamingRules", context);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedNodes", poco.OwnedNodes, poco, "OwnedNodes", context);
            this.WriteContainedElements(xmlWriter, "ownedEdges", poco.OwnedEdges, poco, "OwnedEdges", context);
            this.WriteContainedElements(xmlWriter, "ownedGroups", poco.OwnedGroups, poco, "OwnedGroups", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
