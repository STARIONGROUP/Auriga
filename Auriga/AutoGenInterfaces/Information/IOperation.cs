// ------------------------------------------------------------------------------------------------
// <copyright file="IOperation.cs" company="Starion Group S.A.">
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

namespace Auriga.Information
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Operation</c> interface.
    /// </summary>
    public partial interface IOperation : Auriga.Capellacore.IFeature, Auriga.Behavior.IAbstractEvent, Auriga.Information.IAbstractEventOperation
    {
        /// <summary>
        /// Gets the allocated operations.
        /// </summary>
        IEnumerable<Auriga.Information.IOperation> AllocatedOperations { get; }

        /// <summary>
        /// Gets the allocating operations.
        /// </summary>
        IEnumerable<Auriga.Information.IOperation> AllocatingOperations { get; }

        /// <summary>
        /// Gets the owned exchange item realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Information.IExchangeItemRealization> OwnedExchangeItemRealizations { get; }

        /// <summary>
        /// Gets the owned operation allocation.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Information.IOperationAllocation> OwnedOperationAllocation { get; }

        /// <summary>
        /// Gets the owned parameters.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Information.IParameter> OwnedParameters { get; }

        /// <summary>
        /// Gets the realized exchange items.
        /// </summary>
        IEnumerable<Auriga.Information.IExchangeItem> RealizedExchangeItems { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
