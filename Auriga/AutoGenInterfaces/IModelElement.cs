// ------------------------------------------------------------------------------------------------
// <copyright file="IModelElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Modellingcore
{
    public partial interface IModelElement : global::Auriga.Emde.IExtensibleElement
    {
        string Sid { get; set; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Modellingcore.IAbstractConstraint> Constraints { get; }

        global::Auriga.IContainerList<global::Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints { get; }

        global::Auriga.IContainerList<global::Auriga.Modellingcore.IModelElement> OwnedMigratedElements { get; }

    }
}
