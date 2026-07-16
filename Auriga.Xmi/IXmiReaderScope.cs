// ------------------------------------------------------------------------------------------------
// <copyright file="IXmiReaderScope.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    using System;

    /// <summary>
    /// The scope that owns the lifecycle of the services composed for the XMI reading process — the
    /// dependency-injection container behind <see cref="XmiReaderBuilder"/>. Disposing the scope disposes
    /// the container and with it every reader graph built from it.
    /// </summary>
    public interface IXmiReaderScope : IDisposable
    {
    }
}
