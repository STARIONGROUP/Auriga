// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractBehavior.cs" company="Starion Group S.A.">
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

namespace Auriga.Behavior
{
    public partial interface IAbstractBehavior : global::Auriga.Modellingcore.IAbstractNamedElement
    {
        bool? IsControlOperator { get; set; }

        global::System.Collections.Generic.List<global::Auriga.Modellingcore.IAbstractParameterSet> OwnedParameterSet { get; }

        global::System.Collections.Generic.List<global::Auriga.Modellingcore.IAbstractParameter> OwnedParameter { get; }

    }
}
