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
        /// <summary>
        /// Gets or sets a value indicating whether the output is indented. Defaults to <c>true</c>.
        /// </summary>
        public bool Indent { get; set; } = true;

        /// <summary>
        /// Gets or sets the string used for a single level of indentation. Defaults to two spaces, matching
        /// Capella.
        /// </summary>
        public string IndentChars { get; set; } = "  ";

        /// <summary>
        /// Gets or sets the leading comment written just before the document root — Capella emits its tool
        /// version here — or <c>null</c> to omit it. Defaults to <c>Capella_Version_7.0.0</c>.
        /// </summary>
        public string? VersionComment { get; set; } = "Capella_Version_7.0.0";
    }
}
