// ------------------------------------------------------------------------------------------------
// <copyright file="IGuide.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>Guide</c> interface.
    /// </summary>
    public partial interface IGuide : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets the node map.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Notation.INodeEntry> NodeMap { get; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        int? Position { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
