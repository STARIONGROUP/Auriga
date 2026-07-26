// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionStorage.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Cybersecurity
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>FunctionStorage</c> interface.
    /// </summary>
    public partial interface IFunctionStorage : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Emde.IElementExtension
    {
        /// <summary>
        /// Gets or sets the data storage.
        /// </summary>
        bool? DataStorage { get; set; }

        /// <summary>
        /// Gets the exchanged items.
        /// </summary>
        List<Auriga.Model.Information.IExchangeItem> ExchangedItems { get; }

        /// <summary>
        /// Gets or sets the remanent data.
        /// </summary>
        bool? RemanentData { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
