// ------------------------------------------------------------------------------------------------
// <copyright file="SequenceDDiagramWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Sequence
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>SequenceDDiagram</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class SequenceDDiagramWriter : XmiElementWriter<Auriga.Diagram.Sequence.ISequenceDDiagram>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceDDiagramWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public SequenceDDiagramWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>sequence</c>) of the package that
        /// declares <c>SequenceDDiagram</c>.
        /// </summary>
        public override string NamespacePrefix => "sequence";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>SequenceDDiagram</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "SequenceDDiagram";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/sequence/2.0.0</c>) of the package that declares
        /// <c>SequenceDDiagram</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/sequence/2.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>SequenceDDiagram</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Sequence.ISequenceDDiagram poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceListAttribute(xmlWriter, "activateBehaviors", poco.ActivateBehaviors, poco, "ActivateBehaviors", context);
            this.WriteReferenceListAttribute(xmlWriter, "activatedFilters", poco.ActivatedFilters, poco, "ActivatedFilters", context);
            this.WriteReferenceListAttribute(xmlWriter, "activatedLayers", poco.ActivatedLayers, poco, "ActivatedLayers", context);
            this.WriteReferenceListAttribute(xmlWriter, "activatedRules", poco.ActivatedRules, poco, "ActivatedRules", context);
            this.WriteReferenceAttribute(xmlWriter, "currentConcern", poco.CurrentConcern, poco, "CurrentConcern", context);
            this.WriteReferenceAttribute(xmlWriter, "description", poco.Description, poco, "Description", context);
            WriteIntegerAttribute(xmlWriter, "headerHeight", poco.HeaderHeight);
            WriteBooleanAttribute(xmlWriter, "synchronized", poco.Synchronized);
            this.WriteReferenceAttribute(xmlWriter, "target", poco.Target as Auriga.Core.IAurigaElement, poco, "Target", context);
            WriteStringAttribute(xmlWriter, "uid", poco.Uid);
            this.WriteContainedElements(xmlWriter, "eAnnotations", poco.EAnnotations, poco, "EAnnotations", context);
            this.WriteContainedElement(xmlWriter, "filterVariableHistory", poco.FilterVariableHistory, poco, "FilterVariableHistory", context);
            this.WriteContainedElements(xmlWriter, "ownedAnnotationEntries", poco.OwnedAnnotationEntries, poco, "OwnedAnnotationEntries", context);
            this.WriteContainedElements(xmlWriter, "ownedDiagramElements", poco.OwnedDiagramElements, poco, "OwnedDiagramElements", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
