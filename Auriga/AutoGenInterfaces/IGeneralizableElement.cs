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
    public partial interface IGeneralizableElement : global::Auriga.Capellacore.IType
    {
        bool? Abstract { get; set; }

        global::Auriga.IContainerList<global::Auriga.Capellacore.IGeneralization> OwnedGeneralizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacore.IGeneralization> SuperGeneralizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacore.IGeneralization> SubGeneralizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacore.IGeneralizableElement> Super { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacore.IGeneralizableElement> Sub { get; }

    }
}
