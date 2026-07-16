// ------------------------------------------------------------------------------------------------
// <copyright file="IOrderedTreeLayout.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>OrderedTreeLayout</c> interface.
    /// </summary>
    public partial interface IOrderedTreeLayout : Auriga.Sirius.Diagram.Description.ILayout
    {
        /// <summary>
        /// An expression returning the semantic children of an element, the result of this expression is used to compute a hiearchical tree for the layout.
        /// </summary>
        string ChildrenExpression { get; set; }

        /// <summary>
        /// The list of mappings affected by the ordered tree routing.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IAbstractNodeMapping> NodeMapping { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
