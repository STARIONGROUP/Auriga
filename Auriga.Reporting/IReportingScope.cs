// ------------------------------------------------------------------------------------------------
// <copyright file="IReportingScope.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting
{
    using System;

    /// <summary>
    /// The scope that owns the lifecycle of the services composed for the rendering pipeline — the
    /// dependency-injection container behind <see cref="ReportingBuilder"/>. Disposing the scope disposes
    /// the container and with it every service built from it.
    /// </summary>
    public interface IReportingScope : IDisposable
    {
    }
}
