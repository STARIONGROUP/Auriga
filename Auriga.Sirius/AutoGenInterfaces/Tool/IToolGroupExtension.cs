// ------------------------------------------------------------------------------------------------
// <copyright file="IToolGroupExtension.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Tool
{
    /// <summary>
    /// Definition of the <c>ToolGroupExtension</c> interface.
    /// </summary>
    public partial interface IToolGroupExtension : Auriga.IAurigaElement
    {
        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Tool.IToolGroup Group { get; set; }

        /// <summary>
        /// Gets the tools.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IAbstractToolDescription> Tools { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
