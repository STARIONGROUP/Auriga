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

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Sequence.Description
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>InteractionContainerMapping</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class InteractionContainerMappingWriter : XmiElementWriter<Auriga.Diagram.Sequence.Description.IInteractionContainerMapping>
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
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Sequence.Description.IInteractionContainerMapping poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteEnumAttribute<Auriga.Diagram.Diagram.ContainerLayout>(xmlWriter, "childrenPresentation", poco.ChildrenPresentation, Auriga.Extensions.ContainerLayoutProvider.ToLiteralString, Auriga.Diagram.Diagram.ContainerLayout.FreeForm);
            WriteBooleanAttribute(xmlWriter, "createElements", poco.CreateElements, true);
            WriteReferenceAttribute(xmlWriter, "deletionDescription", poco.DeletionDescription, poco, "DeletionDescription", context);
            WriteReferenceListAttribute(xmlWriter, "detailDescriptions", poco.DetailDescriptions, poco, "DetailDescriptions", context);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation, "");
            WriteStringAttribute(xmlWriter, "domainClass", poco.DomainClass);
            WriteReferenceAttribute(xmlWriter, "doubleClickDescription", poco.DoubleClickDescription, poco, "DoubleClickDescription", context);
            WriteReferenceListAttribute(xmlWriter, "dropDescriptions", poco.DropDescriptions, poco, "DropDescriptions", context);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteReferenceAttribute(xmlWriter, "labelDirectEdit", poco.LabelDirectEdit, poco, "LabelDirectEdit", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name, "");
            WriteReferenceListAttribute(xmlWriter, "navigationDescriptions", poco.NavigationDescriptions, poco, "NavigationDescriptions", context);
            WriteReferenceListAttribute(xmlWriter, "pasteDescriptions", poco.PasteDescriptions, poco, "PasteDescriptions", context);
            WriteStringAttribute(xmlWriter, "preconditionExpression", poco.PreconditionExpression, "");
            WriteReferenceListAttribute(xmlWriter, "reusedBorderedNodeMappings", poco.ReusedBorderedNodeMappings, poco, "ReusedBorderedNodeMappings", context);
            WriteReferenceListAttribute(xmlWriter, "reusedContainerMappings", poco.ReusedContainerMappings, poco, "ReusedContainerMappings", context);
            WriteReferenceListAttribute(xmlWriter, "reusedNodeMappings", poco.ReusedNodeMappings, poco, "ReusedNodeMappings", context);
            WriteStringAttribute(xmlWriter, "semanticCandidatesExpression", poco.SemanticCandidatesExpression);
            WriteStringAttribute(xmlWriter, "semanticElements", poco.SemanticElements);
            WriteBooleanAttribute(xmlWriter, "synchronizationLock", poco.SynchronizationLock, false);

            // Attributes must all be written before any child element, so the uninterpreted ones the
            // reader retained are emitted here rather than alongside the uninterpreted children.
            WriteUninterpretedAttributes(xmlWriter, poco);
            this.WriteContainedElements(xmlWriter, "borderedNodeMappings", poco.BorderedNodeMappings, poco, "BorderedNodeMappings", context);
            this.WriteContainedElements(xmlWriter, "conditionnalStyles", poco.ConditionnalStyles, poco, "ConditionnalStyles", context);
            this.WriteContainedElement(xmlWriter, "style", poco.Style, poco, "Style", context);
            this.WriteContainedElements(xmlWriter, "subContainerMappings", poco.SubContainerMappings, poco, "SubContainerMappings", context);
            this.WriteContainedElements(xmlWriter, "subNodeMappings", poco.SubNodeMappings, poco, "SubNodeMappings", context);
            WriteUninterpretedContent(xmlWriter, poco);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
