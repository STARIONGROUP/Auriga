// ------------------------------------------------------------------------------------------------
// <copyright file="IRequirementsTrace.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Requirement
{
    /// <summary>
    /// Definition of the <c>RequirementsTrace</c> interface.
    /// </summary>
    public partial interface IRequirementsTrace : Auriga.Model.Capellacore.ITrace
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        Auriga.Model.Modellingcore.ITraceableElement Source { get; }

        /// <summary>
        /// Gets the target.
        /// </summary>
        Auriga.Model.Modellingcore.ITraceableElement Target { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
