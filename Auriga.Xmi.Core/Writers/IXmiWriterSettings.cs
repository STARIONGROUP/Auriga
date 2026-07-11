// ------------------------------------------------------------------------------------------------
// <copyright file="IXmiWriterSettings.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Writers
{
    /// <summary>
    /// The formatting options the <see cref="IXmiWriter"/> applies when serializing a Capella model.
    /// </summary>
    public interface IXmiWriterSettings
    {
        /// <summary>
        /// Gets a value indicating whether the output is indented.
        /// </summary>
        bool Indent { get; }

        /// <summary>
        /// Gets the string used for a single level of indentation (Capella uses two spaces).
        /// </summary>
        string IndentChars { get; }

        /// <summary>
        /// Gets the leading comment written just before the document root — Capella emits its tool version
        /// here (e.g. <c>Capella_Version_7.0.0</c>) — or <c>null</c> to omit it.
        /// </summary>
        string? VersionComment { get; }
    }
}
