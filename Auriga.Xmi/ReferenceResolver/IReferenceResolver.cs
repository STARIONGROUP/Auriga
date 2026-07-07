// ------------------------------------------------------------------------------------------------
// <copyright file="IReferenceResolver.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.ReferenceResolver
{
    using Auriga.Xmi.Cache;

    /// <summary>
    /// The second pass of the XMI read: once every element has been instantiated and cached, the
    /// resolver turns the <c>#id</c> references collected on each element into object references
    /// (the uml4net <c>Assembler.Synchronize</c> step).
    /// </summary>
    public interface IReferenceResolver
    {
        /// <summary>
        /// Resolves every deferred single- and multi-valued reference of every element in the cache.
        /// </summary>
        /// <param name="cache">the cache holding all instantiated elements</param>
        void Resolve(IXmiElementCache cache);
    }
}
