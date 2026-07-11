// ------------------------------------------------------------------------------------------------
// <copyright file="ITExecutionMapping.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable disable

namespace Auriga.Sirius.Sequence.Template
{
    /// <summary>
    /// Definition of the <c>TExecutionMapping</c> interface.
    /// </summary>
    public partial interface ITExecutionMapping : Auriga.Sirius.Sequence.Template.ITAbstractMapping, Auriga.Sirius.Sequence.Template.ITMessageExtremity
    {
        /// <summary>
        /// Gets the conditional styles.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Sequence.Template.ITConditionalExecutionStyle> ConditionalStyles { get; }

        /// <summary>
        /// Gets the execution mappings.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Sequence.Template.ITExecutionMapping> ExecutionMappings { get; }

        /// <summary>
        /// Gets or sets the finishing end finder expression.
        /// </summary>
        string FinishingEndFinderExpression { get; set; }

        /// <summary>
        /// Gets or sets the recursive.
        /// </summary>
        bool Recursive { get; set; }

        /// <summary>
        /// Gets or sets the starting end finder expression.
        /// </summary>
        string StartingEndFinderExpression { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        Auriga.Sirius.Sequence.Template.ITExecutionStyle Style { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
