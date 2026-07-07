// ------------------------------------------------------------------------------------------------
// <copyright file="ClassModel.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Models
{
    using System.Collections.Generic;

    /// <summary>The context for the implementation-class template.</summary>
    public sealed class ClassModel
    {
        /// <summary>Gets the C# namespace.</summary>
        public string Namespace { get; init; } = string.Empty;

        /// <summary>Gets the BCL namespaces to import as <c>using</c> directives.</summary>
        public IReadOnlyList<string> Usings { get; init; } = new List<string>();

        /// <summary>Gets the class name.</summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>Gets the XML documentation comment lines.</summary>
        public IReadOnlyList<string> Documentation { get; init; } = new List<string>();

        /// <summary>Gets the base-type list, e.g. <c> : Auriga.AurigaElement, Auriga.Pa.IPhysicalFunction</c>.</summary>
        public string Bases { get; init; } = string.Empty;

        /// <summary>Gets the flattened members (own plus inherited).</summary>
        public IReadOnlyList<MemberModel> Members { get; init; } = new List<MemberModel>();
    }
}
