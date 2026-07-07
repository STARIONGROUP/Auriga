// ------------------------------------------------------------------------------------------------
// <copyright file="MemberModel.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Models
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
}
