// ------------------------------------------------------------------------------------------------
// <copyright file="IAcceptEventAction.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>AcceptEventAction</c> interface.
    /// </summary>
    public partial interface IAcceptEventAction : Auriga.Activity.IAbstractAction
    {
        /// <summary>
        /// Gets or sets the is unmarshall.
        /// </summary>
        bool? IsUnmarshall { get; set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Activity.IOutputPin> Result { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
