// ------------------------------------------------------------------------------------------------
// <copyright file="IInstanceRole.cs" company="Starion Group S.A.">
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

namespace Auriga.Interaction
{
    public partial interface IInstanceRole : global::Auriga.Capellacore.INamedElement
    {
        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractEnd> AbstractEnds { get; }

        global::Auriga.Information.IAbstractInstance RepresentedInstance { get; set; }

    }
}
