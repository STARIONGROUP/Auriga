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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface ILogicalComponent : Auriga.Cs.IComponent, Auriga.Capellacommon.ICapabilityRealizationInvolvedElement
    {
        Auriga.IContainerList<Auriga.La.ILogicalComponent> OwnedLogicalComponents { get; }

        Auriga.IContainerList<Auriga.La.ILogicalArchitecture> OwnedLogicalArchitectures { get; }

        Auriga.IContainerList<Auriga.La.ILogicalComponentPkg> OwnedLogicalComponentPkgs { get; }

        IEnumerable<Auriga.La.ILogicalComponent> SubLogicalComponents { get; }

        IEnumerable<Auriga.La.ILogicalFunction> AllocatedLogicalFunctions { get; }

        IEnumerable<Auriga.Ctx.ISystemComponent> RealizedSystemComponents { get; }

        IEnumerable<Auriga.Pa.IPhysicalComponent> RealizingPhysicalComponents { get; }

    }
}
