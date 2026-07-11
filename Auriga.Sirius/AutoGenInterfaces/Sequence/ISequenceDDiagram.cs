// ------------------------------------------------------------------------------------------------
// <copyright file="ISequenceDDiagram.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence
{
    /// <summary>
    /// Definition of the <c>SequenceDDiagram</c> interface.
    /// </summary>
    public partial interface ISequenceDDiagram : Auriga.Sirius.Diagram.IDSemanticDiagram
    {
        /// <summary>
        /// Gets the graphical ordering.
        /// </summary>
        Auriga.Sirius.Sequence.Ordering.IEventEndsOrdering GraphicalOrdering { get; }

        /// <summary>
        /// Gets the instance role semantic ordering.
        /// </summary>
        Auriga.Sirius.Sequence.Ordering.IInstanceRolesOrdering InstanceRoleSemanticOrdering { get; }

        /// <summary>
        /// Gets the semantic ordering.
        /// </summary>
        Auriga.Sirius.Sequence.Ordering.IEventEndsOrdering SemanticOrdering { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
