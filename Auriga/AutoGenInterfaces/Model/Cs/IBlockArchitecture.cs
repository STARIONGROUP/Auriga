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

namespace Auriga.Model.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>BlockArchitecture</c> interface.
    /// </summary>
    public partial interface IBlockArchitecture : Auriga.Model.Fa.IAbstractFunctionalArchitecture
    {
        /// <summary>
        /// Gets the allocated architectures.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IBlockArchitecture> AllocatedArchitectures { get; }

        /// <summary>
        /// Gets the allocating architectures.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IBlockArchitecture> AllocatingArchitectures { get; }

        /// <summary>
        /// Gets or sets the owned abstract capability pkg.
        /// </summary>
        Auriga.Model.Capellacommon.IAbstractCapabilityPkg OwnedAbstractCapabilityPkg { get; set; }

        /// <summary>
        /// Gets or sets the owned data pkg.
        /// </summary>
        Auriga.Model.Information.IDataPkg OwnedDataPkg { get; set; }

        /// <summary>
        /// Gets or sets the owned interface pkg.
        /// </summary>
        Auriga.Model.Cs.IInterfacePkg OwnedInterfacePkg { get; set; }

        /// <summary>
        /// Gets the provisioned architecture allocations.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IArchitectureAllocation> ProvisionedArchitectureAllocations { get; }

        /// <summary>
        /// Gets the provisioning architecture allocations.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IArchitectureAllocation> ProvisioningArchitectureAllocations { get; }

        /// <summary>
        /// Gets the system.
        /// </summary>
        Auriga.Model.Cs.IComponent System { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
