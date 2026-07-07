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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IFunctionSpecification : Auriga.Capellacore.INamespace, Auriga.Activity.IAbstractActivity
    {
        List<Auriga.Fa.IExchangeLink> InExchangeLinks { get; }

        List<Auriga.Fa.IExchangeLink> OutExchangeLinks { get; }

        Auriga.IContainerList<Auriga.Fa.IFunctionPort> OwnedFunctionPorts { get; }

        IEnumerable<Auriga.Fa.IFunctionSpecification> SubFunctionSpecifications { get; }

    }
}
