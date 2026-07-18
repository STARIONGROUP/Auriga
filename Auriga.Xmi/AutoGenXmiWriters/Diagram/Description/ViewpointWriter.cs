// ------------------------------------------------------------------------------------------------
// <copyright file="ViewpointWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Viewpoint.Description
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>Viewpoint</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class ViewpointWriter : XmiElementWriter<Auriga.Diagram.Viewpoint.Description.IViewpoint>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewpointWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ViewpointWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>Viewpoint</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>Viewpoint</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "Viewpoint";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/description/1.1.0</c>) of the package that declares
        /// <c>Viewpoint</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/description/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>Viewpoint</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Viewpoint.Description.IViewpoint poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringListAttribute(xmlWriter, "conflicts", poco.Conflicts);
            WriteStringListAttribute(xmlWriter, "customizes", poco.Customizes);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation, "");
            WriteStringAttribute(xmlWriter, "endUserDocumentation", poco.EndUserDocumentation, "");
            WriteStringAttribute(xmlWriter, "icon", poco.Icon);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteStringAttribute(xmlWriter, "modelFileExtension", poco.ModelFileExtension, "*");
            WriteStringAttribute(xmlWriter, "name", poco.Name, "");
            WriteStringListAttribute(xmlWriter, "reuses", poco.Reuses);
            this.WriteContainedElements(xmlWriter, "ownedFeatureExtensions", poco.OwnedFeatureExtensions, poco, "OwnedFeatureExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedJavaExtensions", poco.OwnedJavaExtensions, poco, "OwnedJavaExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedMMExtensions", poco.OwnedMMExtensions, poco, "OwnedMMExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedRepresentationExtensions", poco.OwnedRepresentationExtensions, poco, "OwnedRepresentationExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedRepresentations", poco.OwnedRepresentations, poco, "OwnedRepresentations", context);
            this.WriteContainedElements(xmlWriter, "ownedTemplates", poco.OwnedTemplates, poco, "OwnedTemplates", context);
            this.WriteContainedElement(xmlWriter, "validationSet", poco.ValidationSet, poco, "ValidationSet", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
