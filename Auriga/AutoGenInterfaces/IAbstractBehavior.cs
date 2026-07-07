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
    using System.Collections.Generic;

    public partial interface IAbstractBehavior : Auriga.Modellingcore.IAbstractNamedElement
    {
        bool? IsControlOperator { get; set; }

        List<Auriga.Modellingcore.IAbstractParameterSet> OwnedParameterSet { get; }

        List<Auriga.Modellingcore.IAbstractParameter> OwnedParameter { get; }

    }
}
