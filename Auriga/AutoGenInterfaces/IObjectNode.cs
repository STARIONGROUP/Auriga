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
    public partial interface IObjectNode : global::Auriga.Activity.IActivityNode, global::Auriga.Modellingcore.IAbstractTypedElement
    {
        bool? IsControlType { get; set; }

        global::Auriga.Activity.ObjectNodeKind? KindOfNode { get; set; }

        global::Auriga.Activity.ObjectNodeOrderingKind? Ordering { get; set; }

        global::Auriga.Modellingcore.IValueSpecification UpperBound { get; set; }

        global::System.Collections.Generic.List<global::Auriga.Modellingcore.IIState> InState { get; }

        global::Auriga.Behavior.IAbstractBehavior Selection { get; set; }

    }
}
