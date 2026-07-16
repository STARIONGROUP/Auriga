// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractCapability.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Interaction
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>AbstractCapability</c> interface.
    /// </summary>
    public partial interface IAbstractCapability : Auriga.Model.Capellacore.IStructure, Auriga.Model.Capellacore.IInvolverElement, Auriga.Model.Fa.IAbstractFunctionalChainContainer
    {
        /// <summary>
        /// Gets the abstract capability extension points.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IAbstractCapabilityExtensionPoint> AbstractCapabilityExtensionPoints { get; }

        /// <summary>
        /// Gets the available in states.
        /// </summary>
        List<Auriga.Model.Capellacommon.IState> AvailableInStates { get; }

        /// <summary>
        /// Gets the extended abstract capabilities.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IAbstractCapability> ExtendedAbstractCapabilities { get; }

        /// <summary>
        /// Gets the extending.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IAbstractCapabilityExtend> Extending { get; }

        /// <summary>
        /// Gets the extending abstract capabilities.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IAbstractCapability> ExtendingAbstractCapabilities { get; }

        /// <summary>
        /// Gets the extends.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IAbstractCapabilityExtend> Extends { get; }

        /// <summary>
        /// Gets the included abstract capabilities.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IAbstractCapability> IncludedAbstractCapabilities { get; }

        /// <summary>
        /// Gets the includes.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IAbstractCapabilityInclude> Includes { get; }

        /// <summary>
        /// Gets the including.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IAbstractCapabilityInclude> Including { get; }

        /// <summary>
        /// Gets the including abstract capabilities.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IAbstractCapability> IncludingAbstractCapabilities { get; }

        /// <summary>
        /// Gets the incoming capability allocation.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IAbstractCapabilityRealization> IncomingCapabilityAllocation { get; }

        /// <summary>
        /// Gets the involved abstract functions.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IAbstractFunction> InvolvedAbstractFunctions { get; }

        /// <summary>
        /// Gets the involved functional chains.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalChain> InvolvedFunctionalChains { get; }

        /// <summary>
        /// Gets the outgoing capability allocation.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IAbstractCapabilityRealization> OutgoingCapabilityAllocation { get; }

        /// <summary>
        /// Gets the owned abstract capability realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IAbstractCapabilityRealization> OwnedAbstractCapabilityRealizations { get; }

        /// <summary>
        /// Gets the owned abstract function abstract capability involvements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IAbstractFunctionAbstractCapabilityInvolvement> OwnedAbstractFunctionAbstractCapabilityInvolvements { get; }

        /// <summary>
        /// Gets the owned functional chain abstract capability involvements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IFunctionalChainAbstractCapabilityInvolvement> OwnedFunctionalChainAbstractCapabilityInvolvements { get; }

        /// <summary>
        /// Gets the owned scenarios.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IScenario> OwnedScenarios { get; }

        /// <summary>
        /// Gets or sets the post condition.
        /// </summary>
        Auriga.Model.Capellacore.IConstraint PostCondition { get; set; }

        /// <summary>
        /// Gets or sets the pre condition.
        /// </summary>
        Auriga.Model.Capellacore.IConstraint PreCondition { get; set; }

        /// <summary>
        /// Gets the sub.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IAbstractCapability> Sub { get; }

        /// <summary>
        /// Gets the sub generalizations.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IAbstractCapabilityGeneralization> SubGeneralizations { get; }

        /// <summary>
        /// Gets the super.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IAbstractCapability> Super { get; }

        /// <summary>
        /// Gets the super generalizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IAbstractCapabilityGeneralization> SuperGeneralizations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
