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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IBlockArchitecture : Auriga.Fa.IAbstractFunctionalArchitecture
    {
        Auriga.Capellacommon.IAbstractCapabilityPkg OwnedAbstractCapabilityPkg { get; set; }

        Auriga.Cs.IInterfacePkg OwnedInterfacePkg { get; set; }

        Auriga.Information.IDataPkg OwnedDataPkg { get; set; }

        IEnumerable<Auriga.Cs.IArchitectureAllocation> ProvisionedArchitectureAllocations { get; }

        IEnumerable<Auriga.Cs.IArchitectureAllocation> ProvisioningArchitectureAllocations { get; }

        IEnumerable<Auriga.Cs.IBlockArchitecture> AllocatedArchitectures { get; }

        IEnumerable<Auriga.Cs.IBlockArchitecture> AllocatingArchitectures { get; }

        Auriga.Cs.IComponent System { get; }

    }
}
