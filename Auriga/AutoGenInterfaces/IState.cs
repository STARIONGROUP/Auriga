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
    public partial interface IState : global::Auriga.Capellacommon.IAbstractState
    {
        global::Auriga.IContainerList<global::Auriga.Capellacommon.IRegion> OwnedRegions { get; }

        global::Auriga.IContainerList<global::Auriga.Capellacommon.IPseudostate> OwnedConnectionPoints { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IAbstractFunction> AvailableAbstractFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalChain> AvailableFunctionalChains { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractCapability> AvailableAbstractCapabilities { get; }

        global::System.Collections.Generic.List<global::Auriga.Behavior.IAbstractEvent> Entry { get; }

        global::System.Collections.Generic.List<global::Auriga.Behavior.IAbstractEvent> DoActivity { get; }

        global::System.Collections.Generic.List<global::Auriga.Behavior.IAbstractEvent> Exit { get; }

        global::Auriga.Modellingcore.IAbstractConstraint StateInvariant { get; set; }

    }
}
