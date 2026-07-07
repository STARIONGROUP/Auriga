// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionPkg.cs" company="Starion Group S.A.">
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
    public partial interface IFunctionPkg : global::Auriga.Capellacore.IStructure
    {
        global::Auriga.IContainerList<global::Auriga.Fa.IExchangeLink> OwnedFunctionalLinks { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IFunctionalExchangeSpecification> OwnedExchanges { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IExchangeSpecificationRealization> OwnedExchangeSpecificationRealizations { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IExchangeCategory> OwnedCategories { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IFunctionSpecification> OwnedFunctionSpecifications { get; }

    }
}
