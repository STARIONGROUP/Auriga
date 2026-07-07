// ------------------------------------------------------------------------------------------------
// <copyright file="IObjectFlow.cs" company="Starion Group S.A.">
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
    public partial interface IObjectFlow : global::Auriga.Activity.IActivityEdge
    {
        bool? IsMulticast { get; set; }

        bool? IsMultireceive { get; set; }

        global::Auriga.Behavior.IAbstractBehavior Transformation { get; set; }

        global::Auriga.Behavior.IAbstractBehavior Selection { get; set; }

    }
}
