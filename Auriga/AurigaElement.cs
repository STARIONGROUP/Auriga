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
    }
}
