// ------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterSettings.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Writers
{
    /// <summary>
    /// The default <see cref="IXmiWriterSettings"/>: two-space indentation and the Capella 7.0.0 version
    /// comment, matching the formatting Capella itself emits.
    /// </summary>
    public sealed class XmiWriterSettings : IXmiWriterSettings
    {
        /// <inheritdoc/>
        public bool Indent { get; set; } = true;

        /// <inheritdoc/>
        public string IndentChars { get; set; } = "  ";

        /// <inheritdoc/>
        public string? VersionComment { get; set; } = "Capella_Version_7.0.0";
    }
}
