// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractFunctionalArchitecture.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>AbstractFunctionalArchitecture</c> interface.
    /// </summary>
    public partial interface IAbstractFunctionalArchitecture : Auriga.Capellacore.IModellingArchitecture
    {
        /// <summary>
        /// Gets the owned component exchange categories.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories { get; }

        /// <summary>
        /// Gets the owned component exchange realizations.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations { get; }

        /// <summary>
        /// Gets the owned component exchanges.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IComponentExchange> OwnedComponentExchanges { get; }

        /// <summary>
        /// Gets or sets the owned function pkg.
        /// </summary>
        Auriga.Fa.IFunctionPkg OwnedFunctionPkg { get; set; }

        /// <summary>
        /// Gets the owned functional allocations.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocations { get; }

        /// <summary>
        /// Gets the owned functional links.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IExchangeLink> OwnedFunctionalLinks { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
