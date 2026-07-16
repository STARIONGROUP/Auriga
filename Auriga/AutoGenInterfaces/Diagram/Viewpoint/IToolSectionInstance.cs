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

namespace Auriga.Diagram.Viewpoint
{
    /// <summary>
    /// Definition of the <c>ToolSectionInstance</c> interface.
    /// </summary>
    public partial interface IToolSectionInstance : Auriga.Diagram.Viewpoint.IToolInstance
    {
        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        object Section { get; set; }

        /// <summary>
        /// Gets the sub sections.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IToolSectionInstance> SubSections { get; }

        /// <summary>
        /// Gets the tools.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IToolInstance> Tools { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
