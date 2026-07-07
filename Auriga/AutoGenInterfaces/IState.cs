// ------------------------------------------------------------------------------------------------
// <copyright file="IState.cs" company="Starion Group S.A.">
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Capellacommon
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IState : Auriga.Capellacommon.IAbstractState
    {
        Auriga.IContainerList<Auriga.Capellacommon.IRegion> OwnedRegions { get; }

        Auriga.IContainerList<Auriga.Capellacommon.IPseudostate> OwnedConnectionPoints { get; }

        IEnumerable<Auriga.Fa.IAbstractFunction> AvailableAbstractFunctions { get; }

        IEnumerable<Auriga.Fa.IFunctionalChain> AvailableFunctionalChains { get; }

        IEnumerable<Auriga.Interaction.IAbstractCapability> AvailableAbstractCapabilities { get; }

        List<Auriga.Behavior.IAbstractEvent> Entry { get; }

        List<Auriga.Behavior.IAbstractEvent> DoActivity { get; }

        List<Auriga.Behavior.IAbstractEvent> Exit { get; }

        Auriga.Modellingcore.IAbstractConstraint StateInvariant { get; set; }

    }
}
