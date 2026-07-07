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
    public partial interface IFunctionPkg : Auriga.Capellacore.IStructure
    {
        Auriga.IContainerList<Auriga.Fa.IExchangeLink> OwnedFunctionalLinks { get; }

        Auriga.IContainerList<Auriga.Fa.IFunctionalExchangeSpecification> OwnedExchanges { get; }

        Auriga.IContainerList<Auriga.Fa.IExchangeSpecificationRealization> OwnedExchangeSpecificationRealizations { get; }

        Auriga.IContainerList<Auriga.Fa.IExchangeCategory> OwnedCategories { get; }

        Auriga.IContainerList<Auriga.Fa.IFunctionSpecification> OwnedFunctionSpecifications { get; }

    }
}
