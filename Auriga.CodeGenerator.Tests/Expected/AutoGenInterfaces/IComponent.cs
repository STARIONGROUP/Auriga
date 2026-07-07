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

namespace Auriga.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Component</c> interface.
    /// </summary>
    public partial interface IComponent : Auriga.Cs.IBlock, Auriga.Capellacore.IClassifier, Auriga.Cs.IInterfaceAllocator, Auriga.Information.Communication.ICommunicationLinkExchanger
    {
        /// <summary>
        /// Gets or sets the actor.
        /// </summary>
        bool Actor { get; set; }

        /// <summary>
        /// Gets the contained component ports.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentPort> ContainedComponentPorts { get; }

        /// <summary>
        /// Gets the contained parts.
        /// </summary>
        IEnumerable<Auriga.Cs.IPart> ContainedParts { get; }

        /// <summary>
        /// Gets the contained physical ports.
        /// </summary>
        IEnumerable<Auriga.Cs.IPhysicalPort> ContainedPhysicalPorts { get; }

        /// <summary>
        /// Gets or sets the human.
        /// </summary>
        bool Human { get; set; }

        /// <summary>
        /// Gets the implemented interface links.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterfaceImplementation> ImplementedInterfaceLinks { get; }

        /// <summary>
        /// Gets the implemented interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> ImplementedInterfaces { get; }

        /// <summary>
        /// Gets the owned component realizations.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IComponentRealization> OwnedComponentRealizations { get; }

        /// <summary>
        /// Gets the owned interface implementations.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IInterfaceImplementation> OwnedInterfaceImplementations { get; }

        /// <summary>
        /// Gets the owned interface uses.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IInterfaceUse> OwnedInterfaceUses { get; }

        /// <summary>
        /// Gets the owned physical link categories.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IPhysicalLinkCategory> OwnedPhysicalLinkCategories { get; }

        /// <summary>
        /// Gets the owned physical links.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IPhysicalLink> OwnedPhysicalLinks { get; }

        /// <summary>
        /// Gets the owned physical path.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IPhysicalPath> OwnedPhysicalPath { get; }

        /// <summary>
        /// Gets the provided interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> ProvidedInterfaces { get; }

        /// <summary>
        /// Gets the realized components.
        /// </summary>
        IEnumerable<Auriga.Cs.IComponent> RealizedComponents { get; }

        /// <summary>
        /// Gets the realizing components.
        /// </summary>
        IEnumerable<Auriga.Cs.IComponent> RealizingComponents { get; }

        /// <summary>
        /// Gets the representing parts.
        /// </summary>
        IEnumerable<Auriga.Cs.IPart> RepresentingParts { get; }

        /// <summary>
        /// Gets the required interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> RequiredInterfaces { get; }

        /// <summary>
        /// Gets the used interface links.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterfaceUse> UsedInterfaceLinks { get; }

        /// <summary>
        /// Gets the used interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> UsedInterfaces { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
