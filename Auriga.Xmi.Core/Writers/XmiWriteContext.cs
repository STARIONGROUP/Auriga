// ------------------------------------------------------------------------------------------------
// <copyright file="XmiWriteContext.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Writers
{
    using System;

    /// <summary>
    /// The default <see cref="IXmiWriteContext"/> implementation.
    /// </summary>
    public sealed class XmiWriteContext : IXmiWriteContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWriteContext"/> class.
        /// </summary>
        /// <param name="documentName">the document currently being written, relative to the main file</param>
        public XmiWriteContext(string documentName)
        {
            this.DocumentName = documentName ?? throw new ArgumentNullException(nameof(documentName));
        }

        /// <summary>
        /// Gets the name of the document currently being written, relative to the model's main file
        /// (e.g. <c>sysmodel.capella</c> or <c>fragments/SA.capellafragment</c>).
        /// </summary>
        public string DocumentName { get; }
    }
}
