// ------------------------------------------------------------------------------------------------
// <copyright file="IStateEvent.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Capellacommon
{
    /// <summary>
    /// Definition of the <c>StateEvent</c> interface.
    /// </summary>
    public partial interface IStateEvent : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Behavior.IAbstractEvent
    {
        /// <summary>
        /// Gets or sets the expression.
        /// </summary>
        Auriga.Model.Capellacore.IConstraint Expression { get; set; }

        /// <summary>
        /// Gets the owned state event realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IStateEventRealization> OwnedStateEventRealizations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
