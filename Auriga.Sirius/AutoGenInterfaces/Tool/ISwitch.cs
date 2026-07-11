// ------------------------------------------------------------------------------------------------
// <copyright file="ISwitch.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description.Tool
{
    /// <summary>
    /// Swich contains 1 or more Case and 1 Default Case. If no Case condition return true, Default Case is executed. If there are more Case condition who return true it's the first Condition Case true who is executed.
    /// </summary>
    public partial interface ISwitch : Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation
    {
        /// <summary>
        /// Gets the cases.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.ICase> Cases { get; }

        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IDefault Default { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
