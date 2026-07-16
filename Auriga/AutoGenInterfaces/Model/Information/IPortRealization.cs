// ------------------------------------------------------------------------------------------------
// <copyright file="IPortRealization.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Information
{
    /// <summary>
    /// Definition of the <c>PortRealization</c> interface.
    /// </summary>
    public partial interface IPortRealization : Auriga.Model.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the realized port.
        /// </summary>
        Auriga.Model.Information.IPort RealizedPort { get; }

        /// <summary>
        /// Gets the realizing port.
        /// </summary>
        Auriga.Model.Information.IPort RealizingPort { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
