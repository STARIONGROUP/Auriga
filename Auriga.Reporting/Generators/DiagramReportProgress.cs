// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramReportProgress.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Generators
{
    using System;

    /// <summary>
    /// Where a run has got to, reported to the <see cref="IProgress{T}"/> a caller supplies. A model
    /// of any size takes long enough that a caller with a user in front of it needs to say what is
    /// happening; a caller without one passes nothing and pays no cost.
    /// </summary>
    public sealed class DiagramReportProgress
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramReportProgress"/> class.
        /// </summary>
        /// <param name="stage">what the run is doing</param>
        /// <param name="subject">the representation being written, or the model being loaded</param>
        /// <param name="completed">how many representations have been written</param>
        /// <param name="total">how many representations will be written, or zero while that is unknown</param>
        public DiagramReportProgress(DiagramReportStage stage, string subject, int completed, int total)
        {
            this.Stage = stage;
            this.Subject = subject;
            this.Completed = completed;
            this.Total = total;
        }

        /// <summary>
        /// Gets what the run is doing.
        /// </summary>
        public DiagramReportStage Stage { get; }

        /// <summary>
        /// Gets the representation being written, or the model being loaded.
        /// </summary>
        public string Subject { get; }

        /// <summary>
        /// Gets how many representations have been written.
        /// </summary>
        public int Completed { get; }

        /// <summary>
        /// Gets how many representations will be written, or zero while that is not yet known —
        /// the count is only known once the model has been read and built.
        /// </summary>
        public int Total { get; }
    }
}
