// ------------------------------------------------------------------------------------------------
// <copyright file="InterfaceModel.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Models
{
    using System.Collections.Generic;

    /// <summary>The context for the interface template.</summary>
    public sealed class InterfaceModel
    {
        /// <summary>Gets the C# namespace.</summary>
        public string Namespace { get; init; } = string.Empty;

        /// <summary>Gets the BCL namespaces to import as <c>using</c> directives.</summary>
        public IReadOnlyList<string> Usings { get; init; } = new List<string>();

        /// <summary>Gets the interface name, without the leading <c>I</c>.</summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>Gets the XML documentation comment lines.</summary>
        public IReadOnlyList<string> Documentation { get; init; } = new List<string>();

        /// <summary>Gets the base-interface list, e.g. <c> : A, B</c> (empty when none).</summary>
        public string Extends { get; init; } = string.Empty;

        /// <summary>Gets the own members declared on this interface.</summary>
        public IReadOnlyList<MemberModel> Members { get; init; } = new List<MemberModel>();
    }
}
