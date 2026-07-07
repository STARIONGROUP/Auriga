// ------------------------------------------------------------------------------------------------
// <copyright file="GenerationModels.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator
{
    using System.Collections.Generic;

    /// <summary>
    /// A documented C# member declaration, rendered verbatim into a generated interface or class.
    /// </summary>
    public sealed class MemberModel
    {
        /// <summary>Gets the XML documentation comment lines (already wrapped in summary tags).</summary>
        public IReadOnlyList<string> Documentation { get; init; } = new List<string>();

        /// <summary>Gets the C# declaration (may span multiple lines).</summary>
        public string Declaration { get; init; } = string.Empty;
    }

    /// <summary>A generated enumeration literal.</summary>
    public sealed class LiteralModel
    {
        /// <summary>Gets the XML documentation comment lines.</summary>
        public IReadOnlyList<string> Documentation { get; init; } = new List<string>();

        /// <summary>Gets the C# literal name.</summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>Gets a value indicating whether this is the last literal (no trailing comma).</summary>
        public bool IsLast { get; init; }
    }

    /// <summary>The context for the enumeration template.</summary>
    public sealed class EnumModel
    {
        /// <summary>Gets the C# namespace.</summary>
        public string Namespace { get; init; } = string.Empty;

        /// <summary>Gets the enum name.</summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>Gets the XML documentation comment lines.</summary>
        public IReadOnlyList<string> Documentation { get; init; } = new List<string>();

        /// <summary>Gets the literals.</summary>
        public IReadOnlyList<LiteralModel> Literals { get; init; } = new List<LiteralModel>();
    }

    /// <summary>The context for the interface template.</summary>
    public sealed class InterfaceModel
    {
        /// <summary>Gets the C# namespace.</summary>
        public string Namespace { get; init; } = string.Empty;

        /// <summary>Gets the interface name, without the leading <c>I</c>.</summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>Gets the XML documentation comment lines.</summary>
        public IReadOnlyList<string> Documentation { get; init; } = new List<string>();

        /// <summary>Gets the base-interface list, e.g. <c> : A, B</c> (empty when none).</summary>
        public string Extends { get; init; } = string.Empty;

        /// <summary>Gets the own members declared on this interface.</summary>
        public IReadOnlyList<MemberModel> Members { get; init; } = new List<MemberModel>();
    }

    /// <summary>The context for the implementation-class template.</summary>
    public sealed class ClassModel
    {
        /// <summary>Gets the C# namespace.</summary>
        public string Namespace { get; init; } = string.Empty;

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
