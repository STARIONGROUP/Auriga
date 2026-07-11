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

namespace Auriga.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>FunctionSpecification</c> interface.
    /// </summary>
    public partial interface IFunctionSpecification : Auriga.Capellacore.INamespace, Auriga.Activity.IAbstractActivity
    {
        /// <summary>
        /// Gets the in exchange links.
        /// </summary>
        List<Auriga.Fa.IExchangeLink> InExchangeLinks { get; }

        /// <summary>
        /// Gets the out exchange links.
        /// </summary>
        List<Auriga.Fa.IExchangeLink> OutExchangeLinks { get; }

        /// <summary>
        /// Gets the owned function ports.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Fa.IFunctionPort> OwnedFunctionPorts { get; }

        /// <summary>
        /// Gets the sub function specifications.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionSpecification> SubFunctionSpecifications { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
