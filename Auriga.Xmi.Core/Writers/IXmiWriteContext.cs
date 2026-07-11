// ------------------------------------------------------------------------------------------------
// <copyright file="IXmiWriteContext.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Writers
{
    /// <summary>
    /// The per-document state threaded through a write. It carries the name of the document currently
    /// being written so a reference to an element in another document is serialized as a relative
    /// <c>href</c> rather than a bare <c>#id</c>.
    /// </summary>
    public interface IXmiWriteContext
    {
        /// <summary>
        /// Gets the name of the document currently being written, relative to the model's main file
        /// (e.g. <c>sysmodel.capella</c> or <c>fragments/SA.capellafragment</c>).
        /// </summary>
        string DocumentName { get; }
    }
}
