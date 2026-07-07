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
    using System.Collections.Generic;

    public partial interface IAbstractParameterSet : Auriga.Modellingcore.IAbstractNamedElement
    {
        Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConditions { get; }

        Auriga.Modellingcore.IValueSpecification Probability { get; set; }

        List<Auriga.Modellingcore.IAbstractParameter> Parameters { get; }

    }
}
