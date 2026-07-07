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

namespace Auriga.Information
{
    /// <summary>
    /// Definition of the <c>PortRealization</c> interface.
    /// </summary>
    public partial interface IPortRealization : Auriga.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the realized port.
        /// </summary>
        Auriga.Information.IPort RealizedPort { get; }

        /// <summary>
        /// Gets the realizing port.
        /// </summary>
        Auriga.Information.IPort RealizingPort { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
