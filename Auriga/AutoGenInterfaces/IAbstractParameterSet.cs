// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractParameterSet.cs" company="Starion Group S.A.">
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
    public partial interface IAbstractParameterSet : global::Auriga.Modellingcore.IAbstractNamedElement
    {
        global::Auriga.IContainerList<global::Auriga.Modellingcore.IAbstractConstraint> OwnedConditions { get; }

        global::Auriga.Modellingcore.IValueSpecification Probability { get; set; }

        global::System.Collections.Generic.List<global::Auriga.Modellingcore.IAbstractParameter> Parameters { get; }

    }
}
