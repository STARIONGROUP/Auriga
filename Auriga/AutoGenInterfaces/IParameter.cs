// ------------------------------------------------------------------------------------------------
// <copyright file="IParameter.cs" company="Starion Group S.A.">
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

namespace Auriga.Information
{
    /// <summary>
    /// Definition of the <c>Parameter</c> interface.
    /// </summary>
    public partial interface IParameter : Auriga.Capellacore.ITypedElement, Auriga.Information.IMultiplicityElement, Auriga.Modellingcore.IAbstractParameter
    {
        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        Auriga.Information.ParameterDirection? Direction { get; set; }

        /// <summary>
        /// Gets or sets the passing mode.
        /// </summary>
        Auriga.Information.PassingMode? PassingMode { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
