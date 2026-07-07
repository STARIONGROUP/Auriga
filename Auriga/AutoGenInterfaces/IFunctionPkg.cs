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

namespace Auriga.Fa
{
    /// <summary>
    /// Definition of the <c>FunctionPkg</c> interface.
    /// </summary>
    public partial interface IFunctionPkg : Auriga.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned categories.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IExchangeCategory> OwnedCategories { get; }

        /// <summary>
        /// Gets the owned exchange specification realizations.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IExchangeSpecificationRealization> OwnedExchangeSpecificationRealizations { get; }

        /// <summary>
        /// Gets the owned exchanges.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IFunctionalExchangeSpecification> OwnedExchanges { get; }

        /// <summary>
        /// Gets the owned function specifications.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IFunctionSpecification> OwnedFunctionSpecifications { get; }

        /// <summary>
        /// Gets the owned functional links.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IExchangeLink> OwnedFunctionalLinks { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
