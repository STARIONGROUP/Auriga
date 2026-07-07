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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Ctx
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface ISystemComponent : Auriga.Cs.IComponent, Auriga.Capellacore.IInvolvedElement
    {
        Auriga.IContainerList<Auriga.Ctx.ISystemComponent> OwnedSystemComponents { get; }

        Auriga.IContainerList<Auriga.Ctx.ISystemComponentPkg> OwnedSystemComponentPkgs { get; }

        bool? DataComponent { get; set; }

        List<Auriga.Capellacore.IClassifier> DataType { get; }

        IEnumerable<Auriga.Ctx.ICapability> InvolvingCapabilities { get; }

        IEnumerable<Auriga.Ctx.ICapabilityInvolvement> CapabilityInvolvements { get; }

        IEnumerable<Auriga.Ctx.IMission> InvolvingMissions { get; }

        IEnumerable<Auriga.Ctx.IMissionInvolvement> MissionInvolvements { get; }

        IEnumerable<Auriga.Oa.IEntity> RealizedEntities { get; }

        IEnumerable<Auriga.La.ILogicalComponent> RealizingLogicalComponents { get; }

        IEnumerable<Auriga.Ctx.ISystemFunction> AllocatedSystemFunctions { get; }

    }
}
