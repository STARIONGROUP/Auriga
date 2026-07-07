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
    using System.Collections.Generic;

    public partial interface IAbstractConstraint : Auriga.Modellingcore.IModelElement
    {
        List<Auriga.Modellingcore.IModelElement> ConstrainedElements { get; }

        Auriga.Modellingcore.IValueSpecification OwnedSpecification { get; set; }

        Auriga.Modellingcore.IModelElement Context { get; }

    }
}
