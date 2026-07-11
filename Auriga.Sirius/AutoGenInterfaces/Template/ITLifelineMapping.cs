// ------------------------------------------------------------------------------------------------
// <copyright file="ITLifelineMapping.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>TLifelineMapping</c> interface.
    /// </summary>
    public partial interface ITLifelineMapping : Auriga.Sirius.Sequence.Template.ITAbstractMapping, Auriga.Sirius.Sequence.Template.ITMessageExtremity
    {
        /// <summary>
        /// All conditional styles.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Sequence.Template.ITConditionalLifelineStyle> ConditionalLifeLineStyles { get; }

        /// <summary>
        /// Gets or sets the end of life style.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Style.INodeStyleDescription EndOfLifeStyle { get; set; }

        /// <summary>
        /// Gets or sets the eol visible expression.
        /// </summary>
        string EolVisibleExpression { get; set; }

        /// <summary>
        /// Gets the execution mappings.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Sequence.Template.ITExecutionMapping> ExecutionMappings { get; }

        /// <summary>
        /// Gets or sets the instance role style.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Style.INodeStyleDescription InstanceRoleStyle { get; set; }

        /// <summary>
        /// Gets or sets the lifeline style.
        /// </summary>
        Auriga.Sirius.Sequence.Template.ITLifelineStyle LifelineStyle { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
