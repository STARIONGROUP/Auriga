// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractBehavior.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>AbstractBehavior</c> interface.
    /// </summary>
    public partial interface IAbstractBehavior : Auriga.Modellingcore.IAbstractNamedElement
    {
        /// <summary>
        /// Gets or sets the is control operator.
        /// </summary>
        bool? IsControlOperator { get; set; }

        /// <summary>
        /// Gets the owned parameter.
        /// </summary>
        List<Auriga.Modellingcore.IAbstractParameter> OwnedParameter { get; }

        /// <summary>
        /// Gets the owned parameter set.
        /// </summary>
        List<Auriga.Modellingcore.IAbstractParameterSet> OwnedParameterSet { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
