// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractParameter.cs" company="Starion Group S.A.">
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

    public partial interface IAbstractParameter : Auriga.Modellingcore.IAbstractTypedElement
    {
        bool? IsException { get; set; }

        bool? IsStream { get; set; }

        bool? IsOptional { get; set; }

        Auriga.Modellingcore.RateKind? KindOfRate { get; set; }

        Auriga.Modellingcore.ParameterEffectKind? Effect { get; set; }

        Auriga.Modellingcore.IValueSpecification Rate { get; set; }

        Auriga.Modellingcore.IValueSpecification Probability { get; set; }

        List<Auriga.Modellingcore.IAbstractParameterSet> ParameterSet { get; }

    }
}
