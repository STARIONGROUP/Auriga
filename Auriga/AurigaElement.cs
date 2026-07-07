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
    }
}
