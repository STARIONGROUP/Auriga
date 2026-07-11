// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderSettings.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Readers
{
    /// <summary>
    /// The default <see cref="IXmiReaderSettings"/>. Its defaults preserve the reader's lenient behavior:
    /// unknown child elements are skipped with a warning rather than throwing.
    /// </summary>
    public sealed class XmiReaderSettings : IXmiReaderSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the reader reads strictly. When <c>true</c>, a child
        /// element whose role is not part of the vendored metamodel makes the reader throw a
        /// <see cref="System.NotSupportedException"/>; when <c>false</c> (the default) that element is
        /// logged as a warning and skipped, so a model carrying unknown content still loads.
        /// </summary>
        public bool UseStrictReading { get; set; }
    }
}
