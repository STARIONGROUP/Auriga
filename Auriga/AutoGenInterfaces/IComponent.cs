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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IComponent : Auriga.Cs.IBlock, Auriga.Capellacore.IClassifier, Auriga.Cs.IInterfaceAllocator, Auriga.Information.Communication.ICommunicationLinkExchanger
    {
        bool Actor { get; set; }

        bool Human { get; set; }

        Auriga.IContainerList<Auriga.Cs.IInterfaceUse> OwnedInterfaceUses { get; }

        IEnumerable<Auriga.Cs.IInterfaceUse> UsedInterfaceLinks { get; }

        IEnumerable<Auriga.Cs.IInterface> UsedInterfaces { get; }

        Auriga.IContainerList<Auriga.Cs.IInterfaceImplementation> OwnedInterfaceImplementations { get; }

        IEnumerable<Auriga.Cs.IInterfaceImplementation> ImplementedInterfaceLinks { get; }

        IEnumerable<Auriga.Cs.IInterface> ImplementedInterfaces { get; }

        Auriga.IContainerList<Auriga.Cs.IComponentRealization> OwnedComponentRealizations { get; }

        IEnumerable<Auriga.Cs.IComponent> RealizedComponents { get; }

        IEnumerable<Auriga.Cs.IComponent> RealizingComponents { get; }

        IEnumerable<Auriga.Cs.IInterface> ProvidedInterfaces { get; }

        IEnumerable<Auriga.Cs.IInterface> RequiredInterfaces { get; }

        IEnumerable<Auriga.Fa.IComponentPort> ContainedComponentPorts { get; }

        IEnumerable<Auriga.Cs.IPart> ContainedParts { get; }

        IEnumerable<Auriga.Cs.IPhysicalPort> ContainedPhysicalPorts { get; }

        Auriga.IContainerList<Auriga.Cs.IPhysicalPath> OwnedPhysicalPath { get; }

        Auriga.IContainerList<Auriga.Cs.IPhysicalLink> OwnedPhysicalLinks { get; }

        Auriga.IContainerList<Auriga.Cs.IPhysicalLinkCategory> OwnedPhysicalLinkCategories { get; }

        IEnumerable<Auriga.Cs.IPart> RepresentingParts { get; }

    }
}
