// ------------------------------------------------------------------------------------------------
// <copyright file="SelectModelElementVariableWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Viewpoint.Description.Tool
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>SelectModelElementVariable</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class SelectModelElementVariableWriter : XmiElementWriter<Auriga.Diagram.Viewpoint.Description.Tool.ISelectModelElementVariable>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectModelElementVariableWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public SelectModelElementVariableWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>tool</c>) of the package that
        /// declares <c>SelectModelElementVariable</c>.
        /// </summary>
        public override string NamespacePrefix => "tool";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>SelectModelElementVariable</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "SelectModelElementVariable";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/description/tool/1.1.0</c>) of the package that declares
        /// <c>SelectModelElementVariable</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/description/tool/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>SelectModelElementVariable</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Viewpoint.Description.Tool.ISelectModelElementVariable poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "candidatesExpression", poco.CandidatesExpression);
            WriteStringAttribute(xmlWriter, "childrenExpression", poco.ChildrenExpression);
            WriteStringAttribute(xmlWriter, "message", poco.Message);
            WriteBooleanAttribute(xmlWriter, "multiple", poco.Multiple);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteStringAttribute(xmlWriter, "rootExpression", poco.RootExpression);
            WriteBooleanAttribute(xmlWriter, "tree", poco.Tree);
            WriteStringAttribute(xmlWriter, "userDocumentation", poco.UserDocumentation);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
