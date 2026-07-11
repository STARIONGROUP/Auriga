// ------------------------------------------------------------------------------------------------
// <copyright file="IXmiElementWriterFacade.cs" company="Starion Group S.A.">
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
    /// The generated registry that resolves an element's runtime type to its per-type writer and writes
    /// contained children. The inverse of <c>IXmiReaderFacade</c>.
    /// </summary>
    public interface IXmiElementWriterFacade
    {
        /// <summary>
        /// Writes a contained element under <paramref name="roleName"/> by dispatching to the writer of the
        /// element's runtime type.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="element">the element to write</param>
        /// <param name="roleName">the containment feature's XML name</param>
        /// <param name="context">the write context</param>
        void WriteElement(XmlWriter xmlWriter, IAurigaElement element, string roleName, IXmiWriteContext context);

        /// <summary>
        /// Resolves the per-type writer for an element's runtime type — used to write a document root and to
        /// collect the namespaces a document declares.
        /// </summary>
        /// <param name="element">the element to resolve a writer for</param>
        /// <returns>the writer for the element's type</returns>
        IXmiElementWriter ResolveWriter(IAurigaElement element);
    }
}
