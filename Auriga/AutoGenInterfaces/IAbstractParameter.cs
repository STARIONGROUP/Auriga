// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractParameter.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>AbstractParameter</c> interface.
    /// </summary>
    public partial interface IAbstractParameter : Auriga.Modellingcore.IAbstractTypedElement
    {
        /// <summary>
        /// Gets or sets the effect.
        /// </summary>
        Auriga.Modellingcore.ParameterEffectKind? Effect { get; set; }

        /// <summary>
        /// Gets or sets the is exception.
        /// </summary>
        bool? IsException { get; set; }

        /// <summary>
        /// Gets or sets the is optional.
        /// </summary>
        bool? IsOptional { get; set; }

        /// <summary>
        /// Gets or sets the is stream.
        /// </summary>
        bool? IsStream { get; set; }

        /// <summary>
        /// Gets or sets the kind of rate.
        /// </summary>
        Auriga.Modellingcore.RateKind? KindOfRate { get; set; }

        /// <summary>
        /// Gets the parameter set.
        /// </summary>
        List<Auriga.Modellingcore.IAbstractParameterSet> ParameterSet { get; }

        /// <summary>
        /// Gets or sets the probability.
        /// </summary>
        Auriga.Modellingcore.IValueSpecification Probability { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        Auriga.Modellingcore.IValueSpecification Rate { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
