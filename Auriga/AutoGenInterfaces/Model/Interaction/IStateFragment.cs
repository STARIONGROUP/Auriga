// ------------------------------------------------------------------------------------------------
// <copyright file="IStateFragment.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Interaction
{
    /// <summary>
    /// Definition of the <c>StateFragment</c> interface.
    /// </summary>
    public partial interface IStateFragment : Auriga.Model.Interaction.ITimeLapse
    {
        /// <summary>
        /// Gets or sets the related abstract function.
        /// </summary>
        Auriga.Model.Fa.IAbstractFunction RelatedAbstractFunction { get; set; }

        /// <summary>
        /// Gets or sets the related abstract state.
        /// </summary>
        Auriga.Model.Capellacommon.IAbstractState RelatedAbstractState { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
