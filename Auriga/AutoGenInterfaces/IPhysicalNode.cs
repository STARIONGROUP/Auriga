// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalNode.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PhysicalNode</c> interface.
    /// </summary>
    public partial interface IPhysicalNode : Auriga.Pa.IPhysicalComponent
    {
        /// <summary>
        /// Gets the sub physical nodes.
        /// </summary>
        IEnumerable<Auriga.Pa.IPhysicalNode> SubPhysicalNodes { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
