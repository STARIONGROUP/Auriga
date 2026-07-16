// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractEventOperation.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Information
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>AbstractEventOperation</c> interface.
    /// </summary>
    public partial interface IAbstractEventOperation : Auriga.Model.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the invoking sequence messages.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.ISequenceMessage> InvokingSequenceMessages { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
