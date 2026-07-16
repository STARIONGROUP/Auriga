// ------------------------------------------------------------------------------------------------
// <copyright file="IOpaqueExpression.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Information.Datavalue
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>OpaqueExpression</c> interface.
    /// </summary>
    public partial interface IOpaqueExpression : Auriga.Model.Capellacore.ICapellaElement, Auriga.Model.Modellingcore.IValueSpecification
    {
        /// <summary>
        /// Gets the bodies.
        /// </summary>
        List<string> Bodies { get; }

        /// <summary>
        /// Gets the languages.
        /// </summary>
        List<string> Languages { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
