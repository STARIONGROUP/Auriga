// ------------------------------------------------------------------------------------------------
// <copyright file="ISequenceDiagramDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Sequence.Description
{
    /// <summary>
    /// Definition of the <c>SequenceDiagramDescription</c> interface.
    /// </summary>
    public partial interface ISequenceDiagramDescription : Auriga.Diagram.Diagram.Description.IDiagramDescription
    {
        /// <summary>
        /// Gets or sets the ends ordering.
        /// </summary>
        string EndsOrdering { get; set; }

        /// <summary>
        /// Gets or sets the instance roles ordering.
        /// </summary>
        string InstanceRolesOrdering { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
