// ------------------------------------------------------------------------------------------------
// <copyright file="IDNodeListElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram
{
    using System.Collections.Generic;

    /// <summary>
    /// An element of a list.
    /// </summary>
    public partial interface IDNodeListElement : Auriga.Sirius.Diagram.IAbstractDNode
    {
        /// <summary>
        /// The actual mapping of this node.
        /// </summary>
        Auriga.Sirius.Diagram.Description.INodeMapping ActualMapping { get; set; }

        /// <summary>
        /// The candidates mapping of this node.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.INodeMapping> CandidatesMapping { get; }

        /// <summary>
        /// The instance of style that is contained by the mapping. The ownedStyle reference should be a copy of
        /// this style.
        /// </summary>
        Auriga.Sirius.Viewpoint.IStyle OriginalStyle { get; set; }

        /// <summary>
        /// The style of this element.
        /// </summary>
        Auriga.Sirius.Diagram.INodeStyle OwnedStyle { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
