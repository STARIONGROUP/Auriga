// ------------------------------------------------------------------------------------------------
// <copyright file="ISystemCommunicationHook.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Ctx
{
    /// <summary>
    /// Definition of the <c>SystemCommunicationHook</c> interface.
    /// </summary>
    public partial interface ISystemCommunicationHook : Auriga.Model.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets or sets the communication.
        /// </summary>
        Auriga.Model.Ctx.ISystemCommunication Communication { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        Auriga.Model.Cs.IComponent Type { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
