// ------------------------------------------------------------------------------------------------
// <copyright file="IEdgeTarget.cs" company="Starion Group S.A.">
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
    /// The target of a ViewEdge.
    /// </summary>
    public partial interface IEdgeTarget : Auriga.Sirius.Viewpoint.IIdentifiedElement
    {
        /// <summary>
        /// The incoming view edges.
        /// </summary>
        List<Auriga.Sirius.Diagram.IDEdge> IncomingEdges { get; }

        /// <summary>
        /// The outgoing view edges.
        /// </summary>
        List<Auriga.Sirius.Diagram.IDEdge> OutgoingEdges { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
