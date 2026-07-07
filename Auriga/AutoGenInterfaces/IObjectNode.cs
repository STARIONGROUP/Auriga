// ------------------------------------------------------------------------------------------------
// <copyright file="IObjectNode.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    public partial interface IObjectNode : Auriga.Activity.IActivityNode, Auriga.Modellingcore.IAbstractTypedElement
    {
        bool? IsControlType { get; set; }

        Auriga.Activity.ObjectNodeKind? KindOfNode { get; set; }

        Auriga.Activity.ObjectNodeOrderingKind? Ordering { get; set; }

        Auriga.Modellingcore.IValueSpecification UpperBound { get; set; }

        List<Auriga.Modellingcore.IIState> InState { get; }

        Auriga.Behavior.IAbstractBehavior Selection { get; set; }

    }
}
