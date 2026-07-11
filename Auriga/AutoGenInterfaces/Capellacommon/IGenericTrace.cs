// ------------------------------------------------------------------------------------------------
// <copyright file="IGenericTrace.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacommon
{
    /// <summary>
    /// Definition of the <c>GenericTrace</c> interface.
    /// </summary>
    public partial interface IGenericTrace : Auriga.Capellacore.ITrace
    {
        /// <summary>
        /// Gets the key value pairs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Capellacore.IKeyValue> KeyValuePairs { get; }

        /// <summary>
        /// Gets the source.
        /// </summary>
        Auriga.Modellingcore.ITraceableElement Source { get; }

        /// <summary>
        /// Gets the target.
        /// </summary>
        Auriga.Modellingcore.ITraceableElement Target { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
