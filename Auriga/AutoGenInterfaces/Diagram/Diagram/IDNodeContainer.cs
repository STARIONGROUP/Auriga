// ------------------------------------------------------------------------------------------------
// <copyright file="IDNodeContainer.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram
{
    /// <summary>
    /// A classic container.
    /// </summary>
    public partial interface IDNodeContainer : Auriga.Diagram.Diagram.IDDiagramElementContainer
    {
        /// <summary>
        /// Gets or sets the children presentation.
        /// </summary>
        Auriga.Diagram.Diagram.ContainerLayout ChildrenPresentation { get; set; }

        /// <summary>
        /// elements owned by this container.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IDDiagramElement> OwnedDiagramElements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
