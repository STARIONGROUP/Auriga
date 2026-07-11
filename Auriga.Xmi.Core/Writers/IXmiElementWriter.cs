// ------------------------------------------------------------------------------------------------
// <copyright file="IXmiElementWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Writers
{
    using Auriga.Core;
    using System.Xml;

    /// <summary>
    /// The contract every generated per-type XMI writer implements. It knows the element's Capella
    /// namespace (so the document root can declare it and a contained element can carry the matching
    /// <c>xsi:type</c>) and can write the element either as a contained child (with an <c>xsi:type</c>) or
    /// as a document root (its body only, the root tag being written by the <see cref="IXmiWriter"/>).
    /// The inverse of <c>IXmiElementReader&lt;T&gt;</c>.
    /// </summary>
    public interface IXmiElementWriter
    {
        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix of the element's package (e.g.
        /// <c>org.polarsys.capella.core.data.pa</c>).
        /// </summary>
        string NamespacePrefix { get; }

        /// <summary>
        /// Gets the element's XMI type name, unqualified (e.g. <c>PhysicalFunction</c>).
        /// </summary>
        string TypeName { get; }

        /// <summary>
        /// Gets the namespace URI of the element's package (e.g.
        /// <c>http://www.polarsys.org/capella/core/pa/7.0.0</c>).
        /// </summary>
        string NamespaceUri { get; }

        /// <summary>
        /// Writes the element as a contained child under <paramref name="roleName"/>: the role-named start
        /// tag, the <c>xsi:type</c>, then the body (id, attributes and children).
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="element">the element to write</param>
        /// <param name="roleName">the containment feature's XML name (e.g. <c>ownedFunctions</c>)</param>
        /// <param name="context">the write context</param>
        void Write(XmlWriter xmlWriter, IAurigaElement element, string roleName, IXmiWriteContext context);

        /// <summary>
        /// Writes the element's body only — its <c>id</c>, attributes and contained children — without the
        /// enclosing start/end tag. Used for a document root, whose tag the <see cref="IXmiWriter"/> writes
        /// with the package prefix and namespace declarations.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="element">the element whose body to write</param>
        /// <param name="context">the write context</param>
        void WriteBody(XmlWriter xmlWriter, IAurigaElement element, IXmiWriteContext context);
    }
}
