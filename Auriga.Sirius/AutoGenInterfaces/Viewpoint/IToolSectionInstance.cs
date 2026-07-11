// ------------------------------------------------------------------------------------------------
// <copyright file="IToolSectionInstance.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ToolSectionInstance</c> interface.
    /// </summary>
    public partial interface IToolSectionInstance : Auriga.Sirius.Viewpoint.IToolInstance
    {
        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        object Section { get; set; }

        /// <summary>
        /// Gets the sub sections.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Viewpoint.IToolSectionInstance> SubSections { get; }

        /// <summary>
        /// Gets the tools.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Viewpoint.IToolInstance> Tools { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
