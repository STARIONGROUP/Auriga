// ------------------------------------------------------------------------------------------------
// <copyright file="OrderedTreeLayout.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable disable

namespace Auriga.Sirius.Diagram.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>OrderedTreeLayout</c> class.
    /// </summary>
    public partial class OrderedTreeLayout : Auriga.Core.AurigaElement, Auriga.Sirius.Diagram.Description.IOrderedTreeLayout
    {
        /// <summary>
        /// An expression returning the semantic children of an element, the result of this expression is used to compute a hiearchical tree for the layout.
        /// </summary>
        public string ChildrenExpression { get; set; }

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// The list of mappings affected by the ordered tree routing.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.IAbstractNodeMapping> NodeMapping { get; } = new List<Auriga.Sirius.Diagram.Description.IAbstractNodeMapping>();

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
