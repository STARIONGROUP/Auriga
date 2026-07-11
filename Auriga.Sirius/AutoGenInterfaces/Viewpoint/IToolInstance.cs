// ------------------------------------------------------------------------------------------------
// <copyright file="IToolInstance.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint
{
    /// <summary>
    /// Definition of the <c>ToolInstance</c> interface.
    /// </summary>
    public partial interface IToolInstance : Auriga.IAurigaElement
    {
        /// <summary>
        /// Gets or sets the enabled.
        /// </summary>
        bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets the filtered.
        /// </summary>
        bool? Filtered { get; set; }

        /// <summary>
        /// Gets or sets the tool entry.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry ToolEntry { get; set; }

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        bool? Visible { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
