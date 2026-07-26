// ------------------------------------------------------------------------------------------------
// <copyright file="IInformationPrimaryAsset.cs" company="Starion Group S.A.">
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
    using System.Linq;

    /// <summary>
    /// Definition of the <c>InformationPrimaryAsset</c> interface.
    /// </summary>
    public partial interface IInformationPrimaryAsset : Auriga.Model.Cybersecurity.IPrimaryAsset
    {
        /// <summary>
        /// Gets the exchange items.
        /// </summary>
        IEnumerable<Auriga.Model.Information.IExchangeItem> ExchangeItems { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
