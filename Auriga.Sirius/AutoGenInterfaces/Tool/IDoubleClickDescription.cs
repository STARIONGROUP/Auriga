// ------------------------------------------------------------------------------------------------
// <copyright file="IDoubleClickDescription.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Tool that describes double click behaviour.
    /// </summary>
    public partial interface IDoubleClickDescription : Auriga.Sirius.Viewpoint.Description.Tool.IMappingBasedToolDescription
    {
        /// <summary>
        /// The semantic element of the ViewPointElement to delete.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Tool.IElementDoubleClickVariable Element { get; set; }

        /// <summary>
        /// Gets or sets the element view.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Tool.IElementDoubleClickVariable ElementView { get; set; }

        /// <summary>
        /// The first operation.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IInitialOperation InitialOperation { get; set; }

        /// <summary>
        /// Mappings associated with this deletion behavior.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> Mappings { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
