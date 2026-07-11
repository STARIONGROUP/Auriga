// ------------------------------------------------------------------------------------------------
// <copyright file="IXmiElementReader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Readers
{
    using Auriga.Core;
    using System.Xml;

    /// <summary>
    /// The contract implemented by every generated per-type XMI reader.
    /// </summary>
    /// <typeparam name="T">the type of <see cref="IAurigaElement"/> the reader produces</typeparam>
    public interface IXmiElementReader<out T>
        where T : IAurigaElement
    {
        /// <summary>
        /// Reads the element at the cursor of <paramref name="xmlReader"/> into a new
        /// <typeparamref name="T"/>. Contained elements are read recursively; cross-references are
        /// collected for later resolution rather than resolved here.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on (or just before) the element to read</param>
        /// <param name="documentName">the document the element is read from, relative to the model's main
        /// file; recorded as the element's source and used to build its document-scoped cache key</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <returns>the instantiated, populated element</returns>
        T Read(XmlReader xmlReader, string documentName, string namespaceUri);
    }
}
