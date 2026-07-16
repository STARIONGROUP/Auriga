// ------------------------------------------------------------------------------------------------
// <copyright file="InteractionContainerMappingWriter.cs" company="Starion Group S.A.">
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

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>InteractionContainerMapping</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class InteractionContainerMappingWriter : XmiElementWriter<Auriga.Sirius.Sequence.Description.IInteractionContainerMapping>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionContainerMappingWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public InteractionContainerMappingWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>InteractionContainerMapping</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>InteractionContainerMapping</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "InteractionContainerMapping";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/sequence/description/2.0.0</c>) of the package that declares
        /// <c>InteractionContainerMapping</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/sequence/description/2.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>InteractionContainerMapping</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Sequence.Description.IInteractionContainerMapping poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteEnumAttribute<Auriga.Sirius.Diagram.ContainerLayout>(xmlWriter, "childrenPresentation", poco.ChildrenPresentation);
            WriteBooleanAttribute(xmlWriter, "createElements", poco.CreateElements);
            this.WriteReferenceAttribute(xmlWriter, "deletionDescription", poco.DeletionDescription, poco, "DeletionDescription", context);
            this.WriteReferenceListAttribute(xmlWriter, "detailDescriptions", poco.DetailDescriptions, poco, "DetailDescriptions", context);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation);
            WriteStringAttribute(xmlWriter, "domainClass", poco.DomainClass);
            this.WriteReferenceAttribute(xmlWriter, "doubleClickDescription", poco.DoubleClickDescription, poco, "DoubleClickDescription", context);
            this.WriteReferenceListAttribute(xmlWriter, "dropDescriptions", poco.DropDescriptions, poco, "DropDescriptions", context);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            this.WriteReferenceAttribute(xmlWriter, "labelDirectEdit", poco.LabelDirectEdit, poco, "LabelDirectEdit", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceListAttribute(xmlWriter, "navigationDescriptions", poco.NavigationDescriptions, poco, "NavigationDescriptions", context);
            this.WriteReferenceListAttribute(xmlWriter, "pasteDescriptions", poco.PasteDescriptions, poco, "PasteDescriptions", context);
            WriteStringAttribute(xmlWriter, "preconditionExpression", poco.PreconditionExpression);
            this.WriteReferenceListAttribute(xmlWriter, "reusedBorderedNodeMappings", poco.ReusedBorderedNodeMappings, poco, "ReusedBorderedNodeMappings", context);
            this.WriteReferenceListAttribute(xmlWriter, "reusedContainerMappings", poco.ReusedContainerMappings, poco, "ReusedContainerMappings", context);
            this.WriteReferenceListAttribute(xmlWriter, "reusedNodeMappings", poco.ReusedNodeMappings, poco, "ReusedNodeMappings", context);
            WriteStringAttribute(xmlWriter, "semanticCandidatesExpression", poco.SemanticCandidatesExpression);
            WriteStringAttribute(xmlWriter, "semanticElements", poco.SemanticElements);
            WriteBooleanAttribute(xmlWriter, "synchronizationLock", poco.SynchronizationLock);
            this.WriteContainedElements(xmlWriter, "borderedNodeMappings", poco.BorderedNodeMappings, poco, "BorderedNodeMappings", context);
            this.WriteContainedElements(xmlWriter, "conditionnalStyles", poco.ConditionnalStyles, poco, "ConditionnalStyles", context);
            this.WriteContainedElement(xmlWriter, "style", poco.Style, poco, "Style", context);
            this.WriteContainedElements(xmlWriter, "subContainerMappings", poco.SubContainerMappings, poco, "SubContainerMappings", context);
            this.WriteContainedElements(xmlWriter, "subNodeMappings", poco.SubNodeMappings, poco, "SubNodeMappings", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
