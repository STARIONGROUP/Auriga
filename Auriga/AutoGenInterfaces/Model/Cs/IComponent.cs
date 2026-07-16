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

namespace Auriga.Model.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Component</c> interface.
    /// </summary>
    public partial interface IComponent : Auriga.Model.Cs.IBlock, Auriga.Model.Capellacore.IClassifier, Auriga.Model.Cs.IInterfaceAllocator, Auriga.Model.Information.Communication.ICommunicationLinkExchanger
    {
        /// <summary>
        /// Gets or sets the actor.
        /// </summary>
        bool Actor { get; set; }

        /// <summary>
        /// Gets the contained component ports.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentPort> ContainedComponentPorts { get; }

        /// <summary>
        /// Gets the contained parts.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IPart> ContainedParts { get; }

        /// <summary>
        /// Gets the contained physical ports.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IPhysicalPort> ContainedPhysicalPorts { get; }

        /// <summary>
        /// Gets or sets the human.
        /// </summary>
        bool Human { get; set; }

        /// <summary>
        /// Gets the implemented interface links.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterfaceImplementation> ImplementedInterfaceLinks { get; }

        /// <summary>
        /// Gets the implemented interfaces.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterface> ImplementedInterfaces { get; }

        /// <summary>
        /// Gets the owned component realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IComponentRealization> OwnedComponentRealizations { get; }

        /// <summary>
        /// Gets the owned interface implementations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IInterfaceImplementation> OwnedInterfaceImplementations { get; }

        /// <summary>
        /// Gets the owned interface uses.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IInterfaceUse> OwnedInterfaceUses { get; }

        /// <summary>
        /// Gets the owned physical link categories.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IPhysicalLinkCategory> OwnedPhysicalLinkCategories { get; }

        /// <summary>
        /// Gets the owned physical links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IPhysicalLink> OwnedPhysicalLinks { get; }

        /// <summary>
        /// Gets the owned physical path.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IPhysicalPath> OwnedPhysicalPath { get; }

        /// <summary>
        /// Gets the provided interfaces.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterface> ProvidedInterfaces { get; }

        /// <summary>
        /// Gets the realized components.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IComponent> RealizedComponents { get; }

        /// <summary>
        /// Gets the realizing components.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IComponent> RealizingComponents { get; }

        /// <summary>
        /// Gets the representing parts.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IPart> RepresentingParts { get; }

        /// <summary>
        /// Gets the required interfaces.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterface> RequiredInterfaces { get; }

        /// <summary>
        /// Gets the used interface links.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterfaceUse> UsedInterfaceLinks { get; }

        /// <summary>
        /// Gets the used interfaces.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterface> UsedInterfaces { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
