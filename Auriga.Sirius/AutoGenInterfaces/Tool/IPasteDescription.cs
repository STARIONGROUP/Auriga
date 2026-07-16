// ------------------------------------------------------------------------------------------------
// <copyright file="IPasteDescription.cs" company="Starion Group S.A.">
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
    /// Tool that describes a paste operation.
    /// </summary>
    public partial interface IPasteDescription : Auriga.Sirius.Viewpoint.Description.Tool.IMappingBasedToolDescription
    {
        /// <summary>
        /// The new view container (DRepresentation of DRepresentationElement).
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IContainerViewVariable ContainerView { get; set; }

        /// <summary>
        /// The copied semantic element.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IElementVariable CopiedElement { get; set; }

        /// <summary>
        /// The copied view.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IElementViewVariable CopiedView { get; set; }

        /// <summary>
        /// The first operation.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IInitialOperation InitialOperation { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
