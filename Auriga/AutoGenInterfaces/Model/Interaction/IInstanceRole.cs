// ------------------------------------------------------------------------------------------------
// <copyright file="IInstanceRole.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>InstanceRole</c> interface.
    /// </summary>
    public partial interface IInstanceRole : Auriga.Model.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the abstract ends.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IAbstractEnd> AbstractEnds { get; }

        /// <summary>
        /// Gets or sets the represented instance.
        /// </summary>
        Auriga.Model.Information.IAbstractInstance RepresentedInstance { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
