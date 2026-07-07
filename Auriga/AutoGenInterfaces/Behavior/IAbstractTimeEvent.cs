// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractTimeEvent.cs" company="Starion Group S.A.">
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

namespace Auriga.Behavior
{
    /// <summary>
    /// Definition of the <c>AbstractTimeEvent</c> interface.
    /// </summary>
    public partial interface IAbstractTimeEvent : Auriga.Behavior.IAbstractEvent
    {
        /// <summary>
        /// Gets or sets the is relative.
        /// </summary>
        bool? IsRelative { get; set; }

        /// <summary>
        /// Gets or sets the when.
        /// </summary>
        Auriga.Behavior.ITimeExpression When { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
