// ------------------------------------------------------------------------------------------------
// <copyright file="IDiagramImportDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description
{
    /// <summary>
    /// Definition of the <c>DiagramImportDescription</c> interface.
    /// </summary>
    public partial interface IDiagramImportDescription : Auriga.Sirius.Viewpoint.Description.IRepresentationImportDescription, Auriga.Sirius.Diagram.Description.IDiagramDescription
    {
        /// <summary>
        /// Diagram representation to import.
        /// </summary>
        Auriga.Sirius.Diagram.Description.IDiagramDescription ImportedDiagram { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
