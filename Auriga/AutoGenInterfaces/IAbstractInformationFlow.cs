// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractInformationFlow.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// Definition of the <c>AbstractInformationFlow</c> interface.
    /// </summary>
    public partial interface IAbstractInformationFlow : Auriga.Modellingcore.IAbstractNamedElement, Auriga.Modellingcore.IAbstractRelationship
    {
        /// <summary>
        /// Gets the convoyed informations.
        /// </summary>
        List<Auriga.Modellingcore.IAbstractExchangeItem> ConvoyedInformations { get; }

        /// <summary>
        /// Gets the realizations.
        /// </summary>
        List<Auriga.Modellingcore.IAbstractRelationship> Realizations { get; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        Auriga.Modellingcore.IInformationsExchanger Source { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        Auriga.Modellingcore.IInformationsExchanger Target { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
