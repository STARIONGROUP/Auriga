// ------------------------------------------------------------------------------------------------
// <copyright file="IService.cs" company="Starion Group S.A.">
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

namespace Auriga.Information
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Service</c> interface.
    /// </summary>
    public partial interface IService : Auriga.Information.IOperation
    {
        /// <summary>
        /// Gets the message references.
        /// </summary>
        List<Auriga.Information.Communication.IMessageReference> MessageReferences { get; }

        /// <summary>
        /// Gets the messages.
        /// </summary>
        IEnumerable<Auriga.Information.Communication.IMessage> Messages { get; }

        /// <summary>
        /// Gets or sets the synchronism kind.
        /// </summary>
        Auriga.Information.SynchronismKind? SynchronismKind { get; set; }

        /// <summary>
        /// Gets the thrown exceptions.
        /// </summary>
        List<Auriga.Information.Communication.IException> ThrownExceptions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
