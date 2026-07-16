// ------------------------------------------------------------------------------------------------
// <copyright file="IWorkspaceImageDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Style
{
    /// <summary>
    /// A custom image that is present in the user workspace.
    /// </summary>
    public partial interface IWorkspaceImageDescription : Auriga.Sirius.Diagram.Description.Style.INodeStyleDescription, Auriga.Sirius.Diagram.Description.Style.IContainerStyleDescription
    {
        /// <summary>
        /// The path of the image to use in the form of /myProjectID/path/to/image.png,  if the image is not found in the workspace it will be looked for in the plugins.
        /// </summary>
        string WorkspacePath { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
