// ------------------------------------------------------------------------------------------------
// <copyright file="AurigaElement.cs" company="Starion Group S.A.">
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
    /// The hand-written base class of every generated concrete Capella element. It provides the
    /// identity and container plumbing the generated object graph rests on (the analogue of
    /// EMF's <c>EObjectImpl</c> and uml4net's <c>XmiElement</c>). Generated classes are emitted as
    /// <c>partial class Foo : AurigaElement, IFoo</c>.
    /// </summary>
    public abstract class AurigaElement : IAurigaElement
    {
        /// <summary>
        /// Gets or sets the <c>xmi:id</c> of the element.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the element that contains this element, or <c>null</c> when this element is a root.
        /// </summary>
        public IAurigaElement? Container { get; set; }

        /// <summary>
        /// Gets or sets the document the element was read from, relative to the model's main file — the
        /// main <c>.capella</c>/<c>.melodymodeller</c> or a <c>.capellafragment</c>. <c>null</c> until set
        /// by the reader.
        /// </summary>
        public string? SourceDocument { get; set; }

        /// <summary>
        /// Gets or sets the <c>xsi:type</c> the element was read from, verbatim (e.g.
        /// <c>org.polarsys.capella.core.data.capellacommon:AbstractStateRealization</c>), or <c>null</c>
        /// for a document root whose type is fixed by its element tag. Recorded by the reader as
        /// round-trip groundwork so a write can re-emit the exact declared type. (Type dispatch on read is
        /// done by the reader facade, not from this value.)
        /// </summary>
        public string? XsiType { get; set; }

        /// <summary>
        /// Gets or sets the XML namespace URI in scope when the element was read (e.g.
        /// <c>http://www.polarsys.org/capella/core/capellacommon/7.0.0</c>). <c>null</c> until set by the
        /// reader; round-trip groundwork alongside <see cref="XsiType"/>.
        /// </summary>
        public string? XmiNamespaceUri { get; set; }

        /// <summary>
        /// Gets the single-valued reference features whose targets are not yet resolved, keyed by the
        /// property name, with the referenced <c>xmi:id</c> as the value. Populated on the reader's
        /// first pass and resolved on the second.
        /// </summary>
        public IDictionary<string, string> SingleValueReferencePropertyIdentifiers { get; }
            = new Dictionary<string, string>();

        /// <summary>
        /// Gets the multi-valued reference features whose targets are not yet resolved, keyed by the
        /// property name, with the list of referenced <c>xmi:id</c>s as the value. Populated on the
        /// reader's first pass and resolved on the second.
        /// </summary>
        public IDictionary<string, List<string>> MultiValueReferencePropertyIdentifiers { get; }
            = new Dictionary<string, List<string>>();

        /// <summary>
        /// Gets the elements directly contained by this element (the analogue of EMF's <c>eContents()</c>).
        /// The base returns none; a generated class with containment features overrides this to yield them.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public virtual IEnumerable<IAurigaElement> QueryContainedElements()
        {
            yield break;
        }

        /// <summary>
        /// Gets every element in this element's containment subtree — all descendants, depth-first.
        /// </summary>
        /// <returns>the transitive containment closure of this element</returns>
        public IEnumerable<IAurigaElement> QueryAllContainedElements()
        {
            foreach (var child in this.QueryContainedElements())
            {
                yield return child;

                foreach (var descendant in child.QueryAllContainedElements())
                {
                    yield return descendant;
                }
            }
        }
    }
}
