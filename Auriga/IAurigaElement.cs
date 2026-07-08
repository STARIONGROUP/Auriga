// ------------------------------------------------------------------------------------------------
// <copyright file="IAurigaElement.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga
{
    using System.Collections.Generic;

    /// <summary>
    /// The minimal contract implemented by every element in the Auriga Capella object model.
    /// The generated <c>modellingcore::ModelElement</c> interface extends this, so every model
    /// element carries an identity and a container back-pointer independently of the generated code.
    /// </summary>
    public interface IAurigaElement
    {
        /// <summary>
        /// Gets or sets the <c>xmi:id</c> of the element.
        /// </summary>
        string? Id { get; set; }

        /// <summary>
        /// Gets or sets the element that contains this element, or <c>null</c> when this element is a root.
        /// </summary>
        IAurigaElement? Container { get; set; }

        /// <summary>
        /// Gets or sets the document the element was read from, relative to the model's main file — the
        /// main <c>.capella</c>/<c>.melodymodeller</c> or a <c>.capellafragment</c>. This makes the origin
        /// of every element queryable in a model split across fragment files, and is what a
        /// fragment-preserving write uses to route each element back to its file. <c>null</c> until set by
        /// the reader.
        /// </summary>
        string? SourceDocument { get; set; }

        /// <summary>
        /// Gets the single-valued reference features whose targets are not yet resolved, keyed by the
        /// property name, with the referenced <c>xmi:id</c> as the value. The XMI reader records
        /// cross-references here on the first pass and resolves them to object references on the second
        /// pass, once every element has been instantiated (the uml4net two-pass pattern).
        /// </summary>
        IDictionary<string, string> SingleValueReferencePropertyIdentifiers { get; }

        /// <summary>
        /// Gets the multi-valued reference features whose targets are not yet resolved, keyed by the
        /// property name, with the list of referenced <c>xmi:id</c>s as the value. Populated on the
        /// reader's first pass and resolved on the second.
        /// </summary>
        IDictionary<string, List<string>> MultiValueReferencePropertyIdentifiers { get; }

        /// <summary>
        /// Gets the elements directly contained by this element (the analogue of EMF's <c>eContents()</c>) —
        /// the values of its containment features. The reader and the containment collections keep these
        /// consistent with each element's <see cref="Container"/>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        IEnumerable<IAurigaElement> QueryContainedElements();

        /// <summary>
        /// Gets every element in this element's containment subtree — all descendants, depth-first — so a
        /// loaded model can be queried with LINQ, e.g. <c>project.QueryAllContainedElements().OfType&lt;…&gt;()</c>.
        /// </summary>
        /// <returns>the transitive containment closure of this element</returns>
        IEnumerable<IAurigaElement> QueryAllContainedElements();
    }
}
