// ------------------------------------------------------------------------------------------------
// <copyright file="ISequenceLink.cs" company="Starion Group S.A.">
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

namespace Auriga.Fa
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>SequenceLink</c> interface.
    /// </summary>
    public partial interface ISequenceLink : Auriga.Capellacore.ICapellaElement, Auriga.Fa.IReferenceHierarchyContext
    {
        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        Auriga.Capellacore.IConstraint Condition { get; set; }

        /// <summary>
        /// Gets the links.
        /// </summary>
        List<Auriga.Fa.IFunctionalChainInvolvementLink> Links { get; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        Auriga.Fa.ISequenceLinkEnd Source { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        Auriga.Fa.ISequenceLinkEnd Target { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
