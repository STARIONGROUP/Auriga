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
    public partial interface IAbstractAction : global::Auriga.Activity.IExecutableNode, global::Auriga.Modellingcore.IAbstractNamedElement
    {
        global::Auriga.Modellingcore.IAbstractConstraint LocalPrecondition { get; set; }

        global::Auriga.Modellingcore.IAbstractConstraint LocalPostcondition { get; set; }

        global::Auriga.Modellingcore.IAbstractType Context { get; set; }

        global::Auriga.IContainerList<global::Auriga.Activity.IInputPin> Inputs { get; }

        global::Auriga.IContainerList<global::Auriga.Activity.IOutputPin> Outputs { get; }

    }
}
