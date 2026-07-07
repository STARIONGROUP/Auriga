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
    }
}
