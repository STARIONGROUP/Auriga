// ------------------------------------------------------------------------------------------------
// <copyright file="IBlockArchitecture.cs" company="Starion Group S.A.">
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

namespace Auriga.Cs
{
    public partial interface IBlockArchitecture : global::Auriga.Fa.IAbstractFunctionalArchitecture
    {
        global::Auriga.Capellacommon.IAbstractCapabilityPkg OwnedAbstractCapabilityPkg { get; set; }

        global::Auriga.Cs.IInterfacePkg OwnedInterfacePkg { get; set; }

        global::Auriga.Information.IDataPkg OwnedDataPkg { get; set; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IArchitectureAllocation> ProvisionedArchitectureAllocations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IArchitectureAllocation> ProvisioningArchitectureAllocations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IBlockArchitecture> AllocatedArchitectures { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IBlockArchitecture> AllocatingArchitectures { get; }

        global::Auriga.Cs.IComponent System { get; }

    }
}
