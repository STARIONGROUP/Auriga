// ------------------------------------------------------------------------------------------------
// <copyright file="IXmiReaderSettings.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Readers
{
    /// <summary>
    /// The settings that tune how the XMI reader behaves, shared with every generated per-type reader.
    /// The analogue of uml4net's <c>IXmiReaderSettings</c>.
    /// </summary>
    public interface IXmiReaderSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the reader reads strictly. When <c>true</c>, a child
        /// element whose role is not part of the vendored metamodel makes the reader throw a
        /// <see cref="System.NotSupportedException"/>; when <c>false</c> (the default) that element is
        /// logged as a warning and skipped, so a model carrying unknown content still loads.
        /// </summary>
        bool UseStrictReading { get; set; }
    }
}
