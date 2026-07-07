// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractConstraint.cs" company="Starion Group S.A.">
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
    public partial interface IAbstractConstraint : global::Auriga.Modellingcore.IModelElement
    {
        global::System.Collections.Generic.List<global::Auriga.Modellingcore.IModelElement> ConstrainedElements { get; }

        global::Auriga.Modellingcore.IValueSpecification OwnedSpecification { get; set; }

        global::Auriga.Modellingcore.IModelElement Context { get; }

    }
}
