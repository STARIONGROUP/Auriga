// ------------------------------------------------------------------------------------------------
// <copyright file="IReorderTool.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Sequence.Description.Tool
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>ReorderTool</c> interface.
    /// </summary>
    public partial interface IReorderTool : Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription, Auriga.Diagram.Sequence.Description.Tool.ISequenceDiagramToolDescription
    {
        /// <summary>
        /// Gets or sets the finishing end predecessor after.
        /// </summary>
        Auriga.Diagram.Sequence.Description.IMessageEndVariable FinishingEndPredecessorAfter { get; set; }

        /// <summary>
        /// Gets or sets the finishing end predecessor before.
        /// </summary>
        Auriga.Diagram.Sequence.Description.IMessageEndVariable FinishingEndPredecessorBefore { get; set; }

        /// <summary>
        /// Gets the mappings.
        /// </summary>
        List<Auriga.Diagram.Sequence.Description.IEventMapping> Mappings { get; }

        /// <summary>
        /// Gets or sets the on event moved operation.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation OnEventMovedOperation { get; set; }

        /// <summary>
        /// Gets or sets the starting end predecessor after.
        /// </summary>
        Auriga.Diagram.Sequence.Description.IMessageEndVariable StartingEndPredecessorAfter { get; set; }

        /// <summary>
        /// Gets or sets the starting end predecessor before.
        /// </summary>
        Auriga.Diagram.Sequence.Description.IMessageEndVariable StartingEndPredecessorBefore { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
