// ------------------------------------------------------------------------------------------------
// <copyright file="EnumModel.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Models
{
    using System.Collections.Generic;

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
}
