// ------------------------------------------------------------------------------------------------
// <copyright file="EAnnotationWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Writers
{
    using System.Xml;

    using Auriga.Core;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The hand-written XMI writer for the inline <c>ecore:EAnnotation</c> elements EMF emits for an
    /// annotated model element — a <c>source</c>-keyed bag of <c>details</c> entries (e.g. the
    /// Requirements viewpoint's queries under a Sirius <c>DAnalysisCustomData</c>). The annotation type is
    /// an Ecore built-in that belongs to no vendored metamodel package, so a composed runtime facade
    /// routes it here instead of to a generated per-type writer — the inverse of
    /// <see cref="Auriga.Xmi.Core.Readers.EAnnotationReader"/>.
    /// </summary>
    public sealed class EAnnotationWriter : XmiElementWriter<IEAnnotation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EAnnotationWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public EAnnotationWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory = null)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the <c>xmlns</c> prefix (<c>ecore</c>) of the Ecore package the annotation type belongs to.
        /// </summary>
        public override string NamespacePrefix => "ecore";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>EAnnotation</c>).
        /// </summary>
        public override string TypeName => "EAnnotation";

        /// <summary>
        /// Gets the Ecore namespace URI (<c>http://www.eclipse.org/emf/2002/Ecore</c>).
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/emf/2002/Ecore";

        /// <summary>
        /// Writes the annotation's identity, its <c>source</c> attribute and its contained <c>details</c>
        /// entries.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the annotation whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, IEAnnotation poco, IXmiWriteContext context)
        {
            this.WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "source", poco.Source);
            this.WriteContainedElements(xmlWriter, "details", poco.Details, poco, "Details", context);
        }
    }
}
