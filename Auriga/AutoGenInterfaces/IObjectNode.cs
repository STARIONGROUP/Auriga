// ------------------------------------------------------------------------------------------------
// <copyright file="IObjectNode.cs" company="Starion Group S.A.">
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

namespace Auriga.Activity
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>ObjectNode</c> interface.
    /// </summary>
    public partial interface IObjectNode : Auriga.Activity.IActivityNode, Auriga.Modellingcore.IAbstractTypedElement
    {
        /// <summary>
        /// Gets the in state.
        /// </summary>
        List<Auriga.Modellingcore.IIState> InState { get; }

        /// <summary>
        /// Gets or sets the is control type.
        /// </summary>
        bool? IsControlType { get; set; }

        /// <summary>
        /// Gets or sets the kind of node.
        /// </summary>
        Auriga.Activity.ObjectNodeKind? KindOfNode { get; set; }

        /// <summary>
        /// Gets or sets the ordering.
        /// </summary>
        Auriga.Activity.ObjectNodeOrderingKind? Ordering { get; set; }

        /// <summary>
        /// Gets or sets the selection.
        /// </summary>
        Auriga.Behavior.IAbstractBehavior Selection { get; set; }

        /// <summary>
        /// Gets or sets the upper bound.
        /// </summary>
        Auriga.Modellingcore.IValueSpecification UpperBound { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
