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

namespace Auriga.Model.Information.Communication
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>CommunicationItem</c> interface.
    /// </summary>
    public partial interface ICommunicationItem : Auriga.Model.Capellacore.IClassifier, Auriga.Model.Information.Datavalue.IDataValueContainer
    {
        /// <summary>
        /// Gets the owned state machines.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IStateMachine> OwnedStateMachines { get; }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        IEnumerable<Auriga.Model.Information.IProperty> Properties { get; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        Auriga.Model.Capellacore.VisibilityKind? Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
