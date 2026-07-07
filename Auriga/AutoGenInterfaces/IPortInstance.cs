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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Pa.Deployment
{
    using System.Collections.Generic;

    public partial interface IPortInstance : Auriga.Pa.Deployment.IAbstractPhysicalInstance
    {
        List<Auriga.Pa.Deployment.IConnectionInstance> Connections { get; }

        Auriga.Pa.Deployment.IComponentInstance Component { get; }

        Auriga.Fa.IComponentPort Type { get; set; }

    }
}
