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

namespace Auriga.Model.Fa
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>SequenceLink</c> interface.
    /// </summary>
    public partial interface ISequenceLink : Auriga.Model.Capellacore.ICapellaElement, Auriga.Model.Fa.IReferenceHierarchyContext
    {
        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        Auriga.Model.Capellacore.IConstraint Condition { get; set; }

        /// <summary>
        /// Gets the links.
        /// </summary>
        List<Auriga.Model.Fa.IFunctionalChainInvolvementLink> Links { get; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        Auriga.Model.Fa.ISequenceLinkEnd Source { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        Auriga.Model.Fa.ISequenceLinkEnd Target { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
