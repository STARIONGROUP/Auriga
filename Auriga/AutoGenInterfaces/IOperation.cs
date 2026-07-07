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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Information
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IOperation : Auriga.Capellacore.IFeature, Auriga.Behavior.IAbstractEvent, Auriga.Information.IAbstractEventOperation
    {
        Auriga.IContainerList<Auriga.Information.IParameter> OwnedParameters { get; }

        IEnumerable<Auriga.Information.IOperation> AllocatingOperations { get; }

        IEnumerable<Auriga.Information.IOperation> AllocatedOperations { get; }

        Auriga.IContainerList<Auriga.Information.IOperationAllocation> OwnedOperationAllocation { get; }

        Auriga.IContainerList<Auriga.Information.IExchangeItemRealization> OwnedExchangeItemRealizations { get; }

        IEnumerable<Auriga.Information.IExchangeItem> RealizedExchangeItems { get; }

    }
}
