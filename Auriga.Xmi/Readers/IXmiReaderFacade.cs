// ------------------------------------------------------------------------------------------------
// <copyright file="IXmiReaderFacade.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Readers
{
    using System.Xml;

    /// <summary>
    /// Resolves the concrete <see cref="IXmiElementReader{T}"/> for the element at the cursor of an
    /// <see cref="XmlReader"/> and reads it. The type is taken from the element's <c>xsi:type</c>
    /// attribute (namespace-prefixed) unless an explicit package-qualified type key is supplied — as it
    /// is for the document root, whose type is its own element name. This is the code-generated
    /// registry that maps <c>package:TypeName</c> to a reader, the analogue of uml4net's
    /// <c>XmiElementReaderFacade</c>.
    /// </summary>
    public interface IXmiReaderFacade
    {
        /// <summary>
        /// Registers a document-level <c>xmlns</c> prefix-to-URI binding so an <c>xsi:type</c> prefix can
        /// be resolved even deep in the tree, where <see cref="XmlReader.LookupNamespace"/> no longer sees
        /// the root's declarations because of the nested <see cref="XmlReader.ReadSubtree"/> calls.
        /// </summary>
        /// <param name="prefix">the namespace prefix</param>
        /// <param name="namespaceUri">the namespace URI it is bound to</param>
        void RegisterNamespace(string prefix, string namespaceUri);

        /// <summary>
        /// Reads the element at the cursor of <paramref name="xmlReader"/> into a typed
        /// <see cref="IAurigaElement"/>, recursing into contained elements.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element to read</param>
        /// <param name="explicitTypeKey">
        /// the package-qualified type key (<c>package:TypeName</c>) to use instead of the element's
        /// <c>xsi:type</c>, or <c>null</c> to resolve the type from <c>xsi:type</c>
        /// </param>
        /// <returns>the instantiated, populated element</returns>
        IAurigaElement QueryElement(XmlReader xmlReader, string? explicitTypeKey = null);
    }
}
