// ------------------------------------------------------------------------------------------------
// <copyright file="LiteralModel.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Models
{
    using System.Collections.Generic;

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
}
