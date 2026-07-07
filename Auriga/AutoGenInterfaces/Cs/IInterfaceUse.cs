// ------------------------------------------------------------------------------------------------
// <copyright file="IInterfaceUse.cs" company="Starion Group S.A.">
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

namespace Auriga.Cs
{
    /// <summary>
    /// Definition of the <c>InterfaceUse</c> interface.
    /// </summary>
    public partial interface IInterfaceUse : Auriga.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets the interface user.
        /// </summary>
        Auriga.Cs.IComponent InterfaceUser { get; }

        /// <summary>
        /// Gets or sets the used interface.
        /// </summary>
        Auriga.Cs.IInterface UsedInterface { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
