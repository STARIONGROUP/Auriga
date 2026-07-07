// ------------------------------------------------------------------------------------------------
// <copyright file="IGeneralClass.cs" company="Starion Group S.A.">
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

    public partial interface IGeneralClass : Auriga.Capellacore.IClassifier, Auriga.Modellingcore.IFinalizableElement
    {
        Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

        IEnumerable<Auriga.Information.IOperation> ContainedOperations { get; }

        Auriga.IContainerList<Auriga.Capellacore.IGeneralClass> NestedGeneralClasses { get; }

    }
}
