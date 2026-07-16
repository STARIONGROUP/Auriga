// ------------------------------------------------------------------------------------------------
// <copyright file="IToolGroupInstance.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ToolGroupInstance</c> interface.
    /// </summary>
    public partial interface IToolGroupInstance : Auriga.Sirius.Viewpoint.IToolInstance
    {
        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        Auriga.Core.IAurigaElement Group { get; set; }

        /// <summary>
        /// Gets the tools.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.IToolInstance> Tools { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
