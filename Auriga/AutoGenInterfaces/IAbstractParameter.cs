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
    public partial interface IAbstractParameter : global::Auriga.Modellingcore.IAbstractTypedElement
    {
        bool? IsException { get; set; }

        bool? IsStream { get; set; }

        bool? IsOptional { get; set; }

        global::Auriga.Modellingcore.RateKind? KindOfRate { get; set; }

        global::Auriga.Modellingcore.ParameterEffectKind? Effect { get; set; }

        global::Auriga.Modellingcore.IValueSpecification Rate { get; set; }

        global::Auriga.Modellingcore.IValueSpecification Probability { get; set; }

        global::System.Collections.Generic.List<global::Auriga.Modellingcore.IAbstractParameterSet> ParameterSet { get; }

    }
}
