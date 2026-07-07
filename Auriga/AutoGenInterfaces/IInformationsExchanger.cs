// ------------------------------------------------------------------------------------------------
// <copyright file="IInformationsExchanger.cs" company="Starion Group S.A.">
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

namespace Auriga.Modellingcore
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>InformationsExchanger</c> interface.
    /// </summary>
    public partial interface IInformationsExchanger : Auriga.Modellingcore.IModelElement
    {
        /// <summary>
        /// Gets the incoming information flows.
        /// </summary>
        IEnumerable<Auriga.Modellingcore.IAbstractInformationFlow> IncomingInformationFlows { get; }

        /// <summary>
        /// Gets the information flows.
        /// </summary>
        IEnumerable<Auriga.Modellingcore.IAbstractInformationFlow> InformationFlows { get; }

        /// <summary>
        /// Gets the outgoing information flows.
        /// </summary>
        IEnumerable<Auriga.Modellingcore.IAbstractInformationFlow> OutgoingInformationFlows { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
