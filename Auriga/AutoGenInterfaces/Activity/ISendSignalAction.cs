// ------------------------------------------------------------------------------------------------
// <copyright file="ISendSignalAction.cs" company="Starion Group S.A.">
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

namespace Auriga.Activity
{
    /// <summary>
    /// Definition of the <c>SendSignalAction</c> interface.
    /// </summary>
    public partial interface ISendSignalAction : Auriga.Activity.IInvocationAction
    {
        /// <summary>
        /// Gets or sets the signal.
        /// </summary>
        Auriga.Behavior.IAbstractSignal Signal { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        Auriga.Activity.IInputPin Target { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
