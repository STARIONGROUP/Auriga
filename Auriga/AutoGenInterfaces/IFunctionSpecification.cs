// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionSpecification.cs" company="Starion Group S.A.">
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

namespace Auriga.Fa
{
    public partial interface IFunctionSpecification : global::Auriga.Capellacore.INamespace, global::Auriga.Activity.IAbstractActivity
    {
        global::System.Collections.Generic.List<global::Auriga.Fa.IExchangeLink> InExchangeLinks { get; }

        global::System.Collections.Generic.List<global::Auriga.Fa.IExchangeLink> OutExchangeLinks { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IFunctionPort> OwnedFunctionPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionSpecification> SubFunctionSpecifications { get; }

    }
}
