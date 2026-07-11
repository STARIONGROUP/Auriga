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

namespace Auriga.Sirius.Notation
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Diagram</c> interface.
    /// </summary>
    public partial interface IDiagram : Auriga.Sirius.Notation.IView
    {
        /// <summary>
        /// Gets or sets the measurement unit.
        /// </summary>
        Auriga.Sirius.Notation.MeasurementUnit? MeasurementUnit { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the persisted edges.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Notation.IEdge> PersistedEdges { get; }

        /// <summary>
        /// Gets the transient edges.
        /// </summary>
        IEnumerable<Auriga.Sirius.Notation.IEdge> TransientEdges { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
