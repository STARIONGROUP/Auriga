// ------------------------------------------------------------------------------------------------
// <copyright file="CompositeXmiElementWriterFacade.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Writers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    using Auriga.Core;

    /// <summary>
    /// An <see cref="IXmiElementWriterFacade"/> that unions the dispatch tables of several metamodel
    /// facades (e.g. the generated Capella and Sirius facades), so one writer serializes every document
    /// type. Each element is routed to the first facade that has a writer registered for its runtime
    /// type — the per-metamodel type spaces are disjoint because each metamodel's generated classes live
    /// in their own namespaces.
    /// </summary>
    public sealed class CompositeXmiElementWriterFacade : IXmiElementWriterFacade
    {
        /// <summary>
        /// The per-metamodel facades the composite routes between, in registration order.
        /// </summary>
        private readonly IReadOnlyList<IXmiElementWriterFacade> facades;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeXmiElementWriterFacade"/> class.
        /// </summary>
        /// <param name="facades">the per-metamodel facades to union, in routing order</param>
        public CompositeXmiElementWriterFacade(params IXmiElementWriterFacade[] facades)
        {
            if (facades == null)
            {
                throw new ArgumentNullException(nameof(facades));
            }

            if (facades.Length == 0)
            {
                throw new ArgumentException("At least one facade is required.", nameof(facades));
            }

            this.facades = facades;
        }

        /// <summary>
        /// Whether any constituent facade has a writer registered for the supplied element's runtime type.
        /// </summary>
        /// <param name="element">the element to test</param>
        /// <returns>true when one of the constituent facades can write the element</returns>
        public bool CanWrite(IAurigaElement element)
        {
            return this.facades.Any(facade => facade.CanWrite(element));
        }

        /// <summary>
        /// Writes a contained element under <paramref name="roleName"/> by routing the element to the
        /// constituent facade that has a writer registered for its runtime type.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="element">the element to write</param>
        /// <param name="roleName">the containment feature's XML name</param>
        /// <param name="context">the write context</param>
        public void WriteElement(XmlWriter xmlWriter, IAurigaElement element, string roleName, IXmiWriteContext context)
        {
            this.ResolveFacade(element).WriteElement(xmlWriter, element, roleName, context);
        }

        /// <summary>
        /// Resolves the per-type writer for an element's runtime type by routing to the constituent
        /// facade that has it registered — used to write a document root and to collect the namespaces a
        /// document declares.
        /// </summary>
        /// <param name="element">the element to resolve a writer for</param>
        /// <returns>the writer for the element's type</returns>
        /// <exception cref="InvalidOperationException">
        /// no constituent facade has a writer registered for the element's type
        /// </exception>
        public IXmiElementWriter ResolveWriter(IAurigaElement element)
        {
            return this.ResolveFacade(element).ResolveWriter(element);
        }

        /// <summary>
        /// Resolves the constituent facade that has a writer registered for the supplied element's
        /// runtime type.
        /// </summary>
        /// <param name="element">the element to resolve a facade for</param>
        /// <returns>the constituent facade that owns the element's type</returns>
        /// <exception cref="InvalidOperationException">
        /// no constituent facade has a writer registered for the element's type
        /// </exception>
        private IXmiElementWriterFacade ResolveFacade(IAurigaElement element)
        {
            foreach (var facade in this.facades)
            {
                if (facade.CanWrite(element))
                {
                    return facade;
                }
            }

            throw new InvalidOperationException(
                $"No XMI writer is registered for the type '{element.GetType().FullName}' in any of the configured metamodel facades: {string.Join(", ", this.facades.Select(facade => facade.GetType().FullName))}.");
        }
    }
}
