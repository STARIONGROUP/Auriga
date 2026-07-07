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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Information
{
    using System.Collections.Generic;

    public partial interface IExchangeItemElement : Auriga.Capellacore.INamedElement, Auriga.Information.IMultiplicityElement, Auriga.Capellacore.ITypedElement
    {
        Auriga.Information.ElementKind? Kind { get; set; }

        Auriga.Information.ParameterDirection? Direction { get; set; }

        bool? Composite { get; set; }

        List<Auriga.Information.IProperty> ReferencedProperties { get; }

    }
}
