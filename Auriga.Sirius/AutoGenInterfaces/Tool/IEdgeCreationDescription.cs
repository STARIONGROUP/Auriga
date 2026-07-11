// ------------------------------------------------------------------------------------------------
// <copyright file="IEdgeCreationDescription.cs" company="Starion Group S.A.">
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
    /// Tools to create a ViewEdge it appears in the palette.
    /// </summary>
    public partial interface IEdgeCreationDescription : Auriga.Sirius.Viewpoint.Description.Tool.IMappingBasedToolDescription
    {
        /// <summary>
        /// The start precondition of the tool.
        /// </summary>
        string ConnectionStartPrecondition { get; set; }

        /// <summary>
        /// All EdgeMappings used by this tool.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IEdgeMapping> EdgeMappings { get; }

        /// <summary>
        /// All mappings that create views that are able to received a request to manage this creation
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> ExtraSourceMappings { get; }

        /// <summary>
        /// All mappings that create views that are able to received a request to manage this creation
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> ExtraTargetMappings { get; }

        /// <summary>
        /// The path of the icon to display in the palette. If unset, the icon corresponding to the semantic
        /// element associated with the mapping will be displayed.
        /// </summary>
        string IconPath { get; set; }

        /// <summary>
        /// The first operation.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IInitEdgeCreationOperation InitialOperation { get; set; }

        /// <summary>
        /// The semantic element of the source view.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Tool.ISourceEdgeCreationVariable SourceVariable { get; set; }

        /// <summary>
        /// The source view (instance of EdgeTarget)
        /// </summary>
        Auriga.Sirius.Diagram.Description.Tool.ISourceEdgeViewCreationVariable SourceViewVariable { get; set; }

        /// <summary>
        /// The semantic element of the target view.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Tool.ITargetEdgeCreationVariable TargetVariable { get; set; }

        /// <summary>
        /// The target view (instance of EdgeTarget)
        /// </summary>
        Auriga.Sirius.Diagram.Description.Tool.ITargetEdgeViewCreationVariable TargetViewVariable { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
