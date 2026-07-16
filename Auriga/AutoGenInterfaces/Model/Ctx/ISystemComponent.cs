// ------------------------------------------------------------------------------------------------
// <copyright file="ISystemComponent.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Ctx
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>SystemComponent</c> interface.
    /// </summary>
    public partial interface ISystemComponent : Auriga.Model.Cs.IComponent, Auriga.Model.Capellacore.IInvolvedElement
    {
        /// <summary>
        /// Gets the allocated system functions.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ISystemFunction> AllocatedSystemFunctions { get; }

        /// <summary>
        /// Gets the capability involvements.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ICapabilityInvolvement> CapabilityInvolvements { get; }

        /// <summary>
        /// Gets or sets the data component.
        /// </summary>
        bool? DataComponent { get; set; }

        /// <summary>
        /// Gets the data type.
        /// </summary>
        List<Auriga.Model.Capellacore.IClassifier> DataType { get; }

        /// <summary>
        /// Gets the involving capabilities.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ICapability> InvolvingCapabilities { get; }

        /// <summary>
        /// Gets the involving missions.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.IMission> InvolvingMissions { get; }

        /// <summary>
        /// Gets the mission involvements.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.IMissionInvolvement> MissionInvolvements { get; }

        /// <summary>
        /// Gets the owned system component pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Ctx.ISystemComponentPkg> OwnedSystemComponentPkgs { get; }

        /// <summary>
        /// Gets the owned system components.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Ctx.ISystemComponent> OwnedSystemComponents { get; }

        /// <summary>
        /// Gets the realized entities.
        /// </summary>
        IEnumerable<Auriga.Model.Oa.IEntity> RealizedEntities { get; }

        /// <summary>
        /// Gets the realizing logical components.
        /// </summary>
        IEnumerable<Auriga.Model.La.ILogicalComponent> RealizingLogicalComponents { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
