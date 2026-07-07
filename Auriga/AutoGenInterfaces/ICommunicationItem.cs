// ------------------------------------------------------------------------------------------------
// <copyright file="ICommunicationItem.cs" company="Starion Group S.A.">
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

namespace Auriga.Information.Communication
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>CommunicationItem</c> interface.
    /// </summary>
    public partial interface ICommunicationItem : Auriga.Capellacore.IClassifier, Auriga.Information.Datavalue.IDataValueContainer
    {
        /// <summary>
        /// Gets the owned state machines.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> OwnedStateMachines { get; }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        IEnumerable<Auriga.Information.IProperty> Properties { get; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
