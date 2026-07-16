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

namespace Auriga.Model.Fa
{
    /// <summary>
    /// Definition of the <c>FunctionPkg</c> interface.
    /// </summary>
    public partial interface IFunctionPkg : Auriga.Model.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned categories.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IExchangeCategory> OwnedCategories { get; }

        /// <summary>
        /// Gets the owned exchange specification realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IExchangeSpecificationRealization> OwnedExchangeSpecificationRealizations { get; }

        /// <summary>
        /// Gets the owned exchanges.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalExchangeSpecification> OwnedExchanges { get; }

        /// <summary>
        /// Gets the owned function specifications.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionSpecification> OwnedFunctionSpecifications { get; }

        /// <summary>
        /// Gets the owned functional links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IExchangeLink> OwnedFunctionalLinks { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
