// ------------------------------------------------------------------------------------------------
// <copyright file="CreationMessageMappingWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Sequence.Description
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>CreationMessageMapping</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CreationMessageMappingWriter : XmiElementWriter<Auriga.Sirius.Sequence.Description.ICreationMessageMapping>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreationMessageMappingWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CreationMessageMappingWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>CreationMessageMapping</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>CreationMessageMapping</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "CreationMessageMapping";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/sequence/description/2.0.0</c>) of the package that declares
        /// <c>CreationMessageMapping</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/sequence/description/2.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CreationMessageMapping</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Sequence.Description.ICreationMessageMapping poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteBooleanAttribute(xmlWriter, "createElements", poco.CreateElements);
            this.WriteReferenceAttribute(xmlWriter, "deletionDescription", poco.DeletionDescription, poco, "DeletionDescription", context);
            this.WriteReferenceListAttribute(xmlWriter, "detailDescriptions", poco.DetailDescriptions, poco, "DetailDescriptions", context);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation);
            WriteStringAttribute(xmlWriter, "domainClass", poco.DomainClass);
            this.WriteReferenceAttribute(xmlWriter, "doubleClickDescription", poco.DoubleClickDescription, poco, "DoubleClickDescription", context);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            this.WriteReferenceAttribute(xmlWriter, "labelDirectEdit", poco.LabelDirectEdit, poco, "LabelDirectEdit", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceListAttribute(xmlWriter, "navigationDescriptions", poco.NavigationDescriptions, poco, "NavigationDescriptions", context);
            this.WriteReferenceListAttribute(xmlWriter, "pasteDescriptions", poco.PasteDescriptions, poco, "PasteDescriptions", context);
            WriteStringAttribute(xmlWriter, "pathExpression", poco.PathExpression);
            this.WriteReferenceListAttribute(xmlWriter, "pathNodeMapping", poco.PathNodeMapping, poco, "PathNodeMapping", context);
            WriteStringAttribute(xmlWriter, "preconditionExpression", poco.PreconditionExpression);
            WriteStringAttribute(xmlWriter, "receivingEndFinderExpression", poco.ReceivingEndFinderExpression);
            this.WriteReferenceListAttribute(xmlWriter, "reconnections", poco.Reconnections, poco, "Reconnections", context);
            WriteStringAttribute(xmlWriter, "semanticCandidatesExpression", poco.SemanticCandidatesExpression);
            WriteStringAttribute(xmlWriter, "semanticElements", poco.SemanticElements);
            WriteStringAttribute(xmlWriter, "sendingEndFinderExpression", poco.SendingEndFinderExpression);
            WriteStringAttribute(xmlWriter, "sourceFinderExpression", poco.SourceFinderExpression);
            this.WriteReferenceListAttribute(xmlWriter, "sourceMapping", poco.SourceMapping, poco, "SourceMapping", context);
            WriteBooleanAttribute(xmlWriter, "synchronizationLock", poco.SynchronizationLock);
            WriteStringAttribute(xmlWriter, "targetExpression", poco.TargetExpression);
            WriteStringAttribute(xmlWriter, "targetFinderExpression", poco.TargetFinderExpression);
            this.WriteReferenceListAttribute(xmlWriter, "targetMapping", poco.TargetMapping, poco, "TargetMapping", context);
            WriteBooleanAttribute(xmlWriter, "useDomainElement", poco.UseDomainElement);
            this.WriteContainedElements(xmlWriter, "conditionnalStyles", poco.ConditionnalStyles, poco, "ConditionnalStyles", context);
            this.WriteContainedElement(xmlWriter, "style", poco.Style, poco, "Style", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
