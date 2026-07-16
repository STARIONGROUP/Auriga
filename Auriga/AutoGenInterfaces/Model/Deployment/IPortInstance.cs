// ------------------------------------------------------------------------------------------------
// <copyright file="IPortInstance.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Pa.Deployment
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>PortInstance</c> interface.
    /// </summary>
    public partial interface IPortInstance : Auriga.Model.Pa.Deployment.IAbstractPhysicalInstance
    {
        /// <summary>
        /// Gets the component.
        /// </summary>
        Auriga.Model.Pa.Deployment.IComponentInstance Component { get; }

        /// <summary>
        /// Gets the connections.
        /// </summary>
        List<Auriga.Model.Pa.Deployment.IConnectionInstance> Connections { get; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        Auriga.Model.Fa.IComponentPort Type { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
