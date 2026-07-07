// ------------------------------------------------------------------------------------------------
// <copyright file="ITimeExpression.cs" company="Starion Group S.A.">
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

namespace Auriga.Behavior
{
    /// <summary>
    /// Definition of the <c>TimeExpression</c> interface.
    /// </summary>
    public partial interface ITimeExpression : Auriga.Modellingcore.IValueSpecification
    {
        /// <summary>
        /// Gets or sets the expression.
        /// </summary>
        Auriga.Modellingcore.IValueSpecification Expression { get; set; }

        /// <summary>
        /// Gets or sets the observations.
        /// </summary>
        Auriga.Modellingcore.IAbstractNamedElement Observations { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
