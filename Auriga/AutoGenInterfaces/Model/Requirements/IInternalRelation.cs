// ------------------------------------------------------------------------------------------------
// <copyright file="IInternalRelation.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Requirements
{
    /// <summary>
    /// Definition of the <c>InternalRelation</c> interface.
    /// </summary>
    public partial interface IInternalRelation : Auriga.Model.Requirements.IAbstractRelation
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        Auriga.Model.Requirements.IRequirement Source { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        Auriga.Model.Requirements.IRequirement Target { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
