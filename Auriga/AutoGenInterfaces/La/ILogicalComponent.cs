// ------------------------------------------------------------------------------------------------
// <copyright file="ILogicalComponent.cs" company="Starion Group S.A.">
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

namespace Auriga.La
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>LogicalComponent</c> interface.
    /// </summary>
    public partial interface ILogicalComponent : Auriga.Cs.IComponent, Auriga.Capellacommon.ICapabilityRealizationInvolvedElement
    {
        /// <summary>
        /// Gets the allocated logical functions.
        /// </summary>
        IEnumerable<Auriga.La.ILogicalFunction> AllocatedLogicalFunctions { get; }

        /// <summary>
        /// Gets the owned logical architectures.
        /// </summary>
        Auriga.IContainerList<Auriga.La.ILogicalArchitecture> OwnedLogicalArchitectures { get; }

        /// <summary>
        /// Gets the owned logical component pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.La.ILogicalComponentPkg> OwnedLogicalComponentPkgs { get; }

        /// <summary>
        /// Gets the owned logical components.
        /// </summary>
        Auriga.IContainerList<Auriga.La.ILogicalComponent> OwnedLogicalComponents { get; }

        /// <summary>
        /// Gets the realized system components.
        /// </summary>
        IEnumerable<Auriga.Ctx.ISystemComponent> RealizedSystemComponents { get; }

        /// <summary>
        /// Gets the realizing physical components.
        /// </summary>
        IEnumerable<Auriga.Pa.IPhysicalComponent> RealizingPhysicalComponents { get; }

        /// <summary>
        /// Gets the sub logical components.
        /// </summary>
        IEnumerable<Auriga.La.ILogicalComponent> SubLogicalComponents { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
