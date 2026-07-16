// ------------------------------------------------------------------------------------------------
// <copyright file="ICombinedFragment.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Interaction
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>CombinedFragment</c> interface.
    /// </summary>
    public partial interface ICombinedFragment : Auriga.Model.Interaction.IAbstractFragment
    {
        /// <summary>
        /// Gets the expression gates.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IGate> ExpressionGates { get; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        Auriga.Model.Interaction.InteractionOperatorKind? Operator { get; set; }

        /// <summary>
        /// Gets the referenced operands.
        /// </summary>
        List<Auriga.Model.Interaction.IInteractionOperand> ReferencedOperands { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
