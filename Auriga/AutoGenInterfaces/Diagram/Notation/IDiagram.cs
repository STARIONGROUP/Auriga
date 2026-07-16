// ------------------------------------------------------------------------------------------------
// <copyright file="IDiagram.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Notation
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Diagram</c> interface.
    /// </summary>
    public partial interface IDiagram : Auriga.Diagram.Notation.IView
    {
        /// <summary>
        /// Gets or sets the measurement unit.
        /// </summary>
        Auriga.Diagram.Notation.MeasurementUnit? MeasurementUnit { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the persisted edges.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Notation.IEdge> PersistedEdges { get; }

        /// <summary>
        /// Gets the transient edges.
        /// </summary>
        IEnumerable<Auriga.Diagram.Notation.IEdge> TransientEdges { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
