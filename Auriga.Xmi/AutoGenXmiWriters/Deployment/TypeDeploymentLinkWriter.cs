// ------------------------------------------------------------------------------------------------
// <copyright file="TypeDeploymentLinkWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable enable

namespace Auriga.Xmi.AutoGenXmiWriters.Pa.Deployment
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>TypeDeploymentLink</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class TypeDeploymentLinkWriter : XmiElementWriter<Auriga.Pa.Deployment.ITypeDeploymentLink>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeDeploymentLinkWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public TypeDeploymentLinkWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>org.polarsys.capella.core.data.pa.deployment</c>) of the package that
        /// declares <c>TypeDeploymentLink</c>.
        /// </summary>
        public override string NamespacePrefix => "org.polarsys.capella.core.data.pa.deployment";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>TypeDeploymentLink</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "TypeDeploymentLink";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/core/pa/deployment/7.0.0</c>) of the package that declares
        /// <c>TypeDeploymentLink</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/core/pa/deployment/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>TypeDeploymentLink</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Pa.Deployment.ITypeDeploymentLink poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValueGroups", poco.AppliedPropertyValueGroups, poco, "AppliedPropertyValueGroups", context);
            this.WriteReferenceListAttribute(xmlWriter, "appliedPropertyValues", poco.AppliedPropertyValues, poco, "AppliedPropertyValues", context);
            this.WriteReferenceAttribute(xmlWriter, "deployedElement", poco.DeployedElement, poco, "DeployedElement", context);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            this.WriteReferenceListAttribute(xmlWriter, "features", poco.Features, poco, "Features", context);
            this.WriteReferenceAttribute(xmlWriter, "location", poco.Location, poco, "Location", context);
            this.WriteReferenceAttribute(xmlWriter, "realizedFlow", poco.RealizedFlow, poco, "RealizedFlow", context);
            WriteStringAttribute(xmlWriter, "review", poco.Review);
            WriteStringAttribute(xmlWriter, "sid", poco.Sid);
            this.WriteReferenceAttribute(xmlWriter, "status", poco.Status, poco, "Status", context);
            WriteStringAttribute(xmlWriter, "summary", poco.Summary);
            WriteBooleanAttribute(xmlWriter, "visibleInDoc", poco.VisibleInDoc);
            WriteBooleanAttribute(xmlWriter, "visibleInLM", poco.VisibleInLM);
            this.WriteContainedElements(xmlWriter, "ownedConstraints", poco.OwnedConstraints, poco, "OwnedConstraints", context);
            this.WriteContainedElements(xmlWriter, "ownedEnumerationPropertyTypes", poco.OwnedEnumerationPropertyTypes, poco, "OwnedEnumerationPropertyTypes", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedMigratedElements", poco.OwnedMigratedElements, poco, "OwnedMigratedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValueGroups", poco.OwnedPropertyValueGroups, poco, "OwnedPropertyValueGroups", context);
            this.WriteContainedElements(xmlWriter, "ownedPropertyValues", poco.OwnedPropertyValues, poco, "OwnedPropertyValues", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
