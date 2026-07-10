// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderSettings.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Readers
{
    /// <summary>
    /// The default <see cref="IXmiReaderSettings"/>. Its defaults preserve the reader's lenient behavior:
    /// unknown child elements are skipped with a warning rather than throwing.
    /// </summary>
    public sealed class XmiReaderSettings : IXmiReaderSettings
    {
        /// <inheritdoc />
        public bool UseStrictReading { get; set; }
    }
}
