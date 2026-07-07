// ------------------------------------------------------------------------------------------------
// <copyright file="IExchangeItemElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Information
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>ExchangeItemElement</c> interface.
    /// </summary>
    public partial interface IExchangeItemElement : Auriga.Capellacore.INamedElement, Auriga.Information.IMultiplicityElement, Auriga.Capellacore.ITypedElement
    {
        /// <summary>
        /// Gets or sets the composite.
        /// </summary>
        bool? Composite { get; set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        Auriga.Information.ParameterDirection? Direction { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Information.ElementKind? Kind { get; set; }

        /// <summary>
        /// Gets the referenced properties.
        /// </summary>
        List<Auriga.Information.IProperty> ReferencedProperties { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
