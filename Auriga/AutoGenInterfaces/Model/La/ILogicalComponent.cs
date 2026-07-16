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

namespace Auriga.Model.La
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>LogicalComponent</c> interface.
    /// </summary>
    public partial interface ILogicalComponent : Auriga.Model.Cs.IComponent, Auriga.Model.Capellacommon.ICapabilityRealizationInvolvedElement
    {
        /// <summary>
        /// Gets the allocated logical functions.
        /// </summary>
        IEnumerable<Auriga.Model.La.ILogicalFunction> AllocatedLogicalFunctions { get; }

        /// <summary>
        /// Gets the owned logical architectures.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.La.ILogicalArchitecture> OwnedLogicalArchitectures { get; }

        /// <summary>
        /// Gets the owned logical component pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.La.ILogicalComponentPkg> OwnedLogicalComponentPkgs { get; }

        /// <summary>
        /// Gets the owned logical components.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.La.ILogicalComponent> OwnedLogicalComponents { get; }

        /// <summary>
        /// Gets the realized system components.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ISystemComponent> RealizedSystemComponents { get; }

        /// <summary>
        /// Gets the realizing physical components.
        /// </summary>
        IEnumerable<Auriga.Model.Pa.IPhysicalComponent> RealizingPhysicalComponents { get; }

        /// <summary>
        /// Gets the sub logical components.
        /// </summary>
        IEnumerable<Auriga.Model.La.ILogicalComponent> SubLogicalComponents { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
