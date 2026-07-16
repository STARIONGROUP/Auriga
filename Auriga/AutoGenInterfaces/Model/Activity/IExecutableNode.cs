// ------------------------------------------------------------------------------------------------
// <copyright file="IExecutableNode.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Activity
{
    /// <summary>
    /// Definition of the <c>ExecutableNode</c> interface.
    /// </summary>
    public partial interface IExecutableNode : Auriga.Model.Activity.IActivityNode
    {
        /// <summary>
        /// Gets the owned handlers.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Activity.IExceptionHandler> OwnedHandlers { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
