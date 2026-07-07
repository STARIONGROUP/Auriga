// ------------------------------------------------------------------------------------------------
// <copyright file="IConnectionInstance.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa.Deployment
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>ConnectionInstance</c> interface.
    /// </summary>
    public partial interface IConnectionInstance : Auriga.Pa.Deployment.IAbstractPhysicalInstance
    {
        /// <summary>
        /// Gets the connection ends.
        /// </summary>
        List<Auriga.Pa.Deployment.IPortInstance> ConnectionEnds { get; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        Auriga.Fa.IComponentExchange Type { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
