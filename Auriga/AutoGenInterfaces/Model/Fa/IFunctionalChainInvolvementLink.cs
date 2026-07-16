// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionalChainInvolvementLink.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>FunctionalChainInvolvementLink</c> interface.
    /// </summary>
    public partial interface IFunctionalChainInvolvementLink : Auriga.Model.Fa.IFunctionalChainInvolvement, Auriga.Model.Fa.IReferenceHierarchyContext
    {
        /// <summary>
        /// Gets or sets the exchange context.
        /// </summary>
        Auriga.Model.Capellacore.IConstraint ExchangeContext { get; set; }

        /// <summary>
        /// Gets the exchanged items.
        /// </summary>
        List<Auriga.Model.Information.IExchangeItem> ExchangedItems { get; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        Auriga.Model.Fa.IFunctionalChainInvolvementFunction Source { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        Auriga.Model.Fa.IFunctionalChainInvolvementFunction Target { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
