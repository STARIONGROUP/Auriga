// ------------------------------------------------------------------------------------------------
// <copyright file="IOrderedElementCreationTool.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence.Description.Tool
{
    /// <summary>
    /// Definition of the <c>OrderedElementCreationTool</c> interface.
    /// </summary>
    public partial interface IOrderedElementCreationTool : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets or sets the finishing end predecessor.
        /// </summary>
        Auriga.Sirius.Sequence.Description.IMessageEndVariable FinishingEndPredecessor { get; set; }

        /// <summary>
        /// Gets or sets the starting end predecessor.
        /// </summary>
        Auriga.Sirius.Sequence.Description.IMessageEndVariable StartingEndPredecessor { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
