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
    public partial interface ISystemComponent : global::Auriga.Cs.IComponent, global::Auriga.Capellacore.IInvolvedElement
    {
        global::Auriga.IContainerList<global::Auriga.Ctx.ISystemComponent> OwnedSystemComponents { get; }

        global::Auriga.IContainerList<global::Auriga.Ctx.ISystemComponentPkg> OwnedSystemComponentPkgs { get; }

        bool? DataComponent { get; set; }

        global::System.Collections.Generic.List<global::Auriga.Capellacore.IClassifier> DataType { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ICapability> InvolvingCapabilities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ICapabilityInvolvement> CapabilityInvolvements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.IMission> InvolvingMissions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.IMissionInvolvement> MissionInvolvements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IEntity> RealizedEntities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalComponent> RealizingLogicalComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ISystemFunction> AllocatedSystemFunctions { get; }

    }
}
