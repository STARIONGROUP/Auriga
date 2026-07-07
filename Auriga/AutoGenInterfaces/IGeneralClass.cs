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
    public partial interface IGeneralClass : global::Auriga.Capellacore.IClassifier, global::Auriga.Modellingcore.IFinalizableElement
    {
        global::Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IOperation> ContainedOperations { get; }

        global::Auriga.IContainerList<global::Auriga.Capellacore.IGeneralClass> NestedGeneralClasses { get; }

    }
}
