// ------------------------------------------------------------------------------------------------
// <copyright file="IComponent.cs" company="Starion Group S.A.">
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

namespace Auriga.Cs
{
    public partial interface IComponent : global::Auriga.Cs.IBlock, global::Auriga.Capellacore.IClassifier, global::Auriga.Cs.IInterfaceAllocator, global::Auriga.Information.Communication.ICommunicationLinkExchanger
    {
        bool Actor { get; set; }

        bool Human { get; set; }

        global::Auriga.IContainerList<global::Auriga.Cs.IInterfaceUse> OwnedInterfaceUses { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterfaceUse> UsedInterfaceLinks { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> UsedInterfaces { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IInterfaceImplementation> OwnedInterfaceImplementations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterfaceImplementation> ImplementedInterfaceLinks { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> ImplementedInterfaces { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IComponentRealization> OwnedComponentRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IComponent> RealizedComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IComponent> RealizingComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> ProvidedInterfaces { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> RequiredInterfaces { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentPort> ContainedComponentPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPart> ContainedParts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalPort> ContainedPhysicalPorts { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalPath> OwnedPhysicalPath { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalLink> OwnedPhysicalLinks { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalLinkCategory> OwnedPhysicalLinkCategories { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPart> RepresentingParts { get; }

    }
}
