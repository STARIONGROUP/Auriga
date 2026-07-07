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
    public partial interface IOperation : global::Auriga.Capellacore.IFeature, global::Auriga.Behavior.IAbstractEvent, global::Auriga.Information.IAbstractEventOperation
    {
        global::Auriga.IContainerList<global::Auriga.Information.IParameter> OwnedParameters { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IOperation> AllocatingOperations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IOperation> AllocatedOperations { get; }

        global::Auriga.IContainerList<global::Auriga.Information.IOperationAllocation> OwnedOperationAllocation { get; }

        global::Auriga.IContainerList<global::Auriga.Information.IExchangeItemRealization> OwnedExchangeItemRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IExchangeItem> RealizedExchangeItems { get; }

    }
}
