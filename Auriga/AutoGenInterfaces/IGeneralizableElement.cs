// ------------------------------------------------------------------------------------------------
// <copyright file="IGeneralizableElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacore
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IGeneralizableElement : Auriga.Capellacore.IType
    {
        bool? Abstract { get; set; }

        Auriga.IContainerList<Auriga.Capellacore.IGeneralization> OwnedGeneralizations { get; }

        IEnumerable<Auriga.Capellacore.IGeneralization> SuperGeneralizations { get; }

        IEnumerable<Auriga.Capellacore.IGeneralization> SubGeneralizations { get; }

        IEnumerable<Auriga.Capellacore.IGeneralizableElement> Super { get; }

        IEnumerable<Auriga.Capellacore.IGeneralizableElement> Sub { get; }

    }
}
