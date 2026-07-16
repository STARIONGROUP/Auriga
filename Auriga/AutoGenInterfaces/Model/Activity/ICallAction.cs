// ------------------------------------------------------------------------------------------------
// <copyright file="ICallAction.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>CallAction</c> interface.
    /// </summary>
    public partial interface ICallAction : Auriga.Model.Activity.IInvocationAction
    {
        /// <summary>
        /// Gets the results.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Activity.IOutputPin> Results { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
