// ------------------------------------------------------------------------------------------------
// <copyright file="ISignal.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Information.Communication
{
    /// <summary>
    /// Definition of the <c>Signal</c> interface.
    /// </summary>
    public partial interface ISignal : Auriga.Model.Information.Communication.ICommunicationItem, Auriga.Model.Behavior.IAbstractSignal
    {
        /// <summary>
        /// Gets the signal instances.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.Communication.ISignalInstance> SignalInstances { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
