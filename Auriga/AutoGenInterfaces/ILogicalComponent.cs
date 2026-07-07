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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.La
{
    public partial interface ILogicalComponent : global::Auriga.Cs.IComponent, global::Auriga.Capellacommon.ICapabilityRealizationInvolvedElement
    {
        global::Auriga.IContainerList<global::Auriga.La.ILogicalComponent> OwnedLogicalComponents { get; }

        global::Auriga.IContainerList<global::Auriga.La.ILogicalArchitecture> OwnedLogicalArchitectures { get; }

        global::Auriga.IContainerList<global::Auriga.La.ILogicalComponentPkg> OwnedLogicalComponentPkgs { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalComponent> SubLogicalComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalFunction> AllocatedLogicalFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ISystemComponent> RealizedSystemComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalComponent> RealizingPhysicalComponents { get; }

    }
}
