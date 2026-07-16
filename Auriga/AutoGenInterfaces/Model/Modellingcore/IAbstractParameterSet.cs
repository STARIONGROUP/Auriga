// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractParameterSet.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Modellingcore
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>AbstractParameterSet</c> interface.
    /// </summary>
    public partial interface IAbstractParameterSet : Auriga.Model.Modellingcore.IAbstractNamedElement
    {
        /// <summary>
        /// Gets the owned conditions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IAbstractConstraint> OwnedConditions { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        List<Auriga.Model.Modellingcore.IAbstractParameter> Parameters { get; }

        /// <summary>
        /// Gets or sets the probability.
        /// </summary>
        Auriga.Model.Modellingcore.IValueSpecification Probability { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
