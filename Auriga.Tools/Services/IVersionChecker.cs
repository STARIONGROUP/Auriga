// ------------------------------------------------------------------------------------------------
// <copyright file="IVersionChecker.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Services
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Tells the user when a newer release of the tool exists. A courtesy, never a gate: it runs
    /// once at startup and a failure to reach GitHub is silent, because being offline is not a
    /// reason to refuse to export a diagram.
    /// </summary>
    public interface IVersionChecker
    {
        /// <summary>
        /// Checks for a newer release and writes a note when there is one.
        /// </summary>
        /// <param name="cancellationToken">the token cancelling the check</param>
        /// <returns>the running check</returns>
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
