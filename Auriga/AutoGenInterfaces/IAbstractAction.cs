// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractAction.cs" company="Starion Group S.A.">
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

namespace Auriga.Activity
{
    public partial interface IAbstractAction : Auriga.Activity.IExecutableNode, Auriga.Modellingcore.IAbstractNamedElement
    {
        Auriga.Modellingcore.IAbstractConstraint LocalPrecondition { get; set; }

        Auriga.Modellingcore.IAbstractConstraint LocalPostcondition { get; set; }

        Auriga.Modellingcore.IAbstractType Context { get; set; }

        Auriga.IContainerList<Auriga.Activity.IInputPin> Inputs { get; }

        Auriga.IContainerList<Auriga.Activity.IOutputPin> Outputs { get; }

    }
}
