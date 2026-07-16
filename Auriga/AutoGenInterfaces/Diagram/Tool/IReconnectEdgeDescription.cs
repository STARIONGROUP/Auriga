// ------------------------------------------------------------------------------------------------
// <copyright file="IReconnectEdgeDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description.Tool
{
    /// <summary>
    /// A tool that describes how to reconnect a ViewEdge.
    /// </summary>
    public partial interface IReconnectEdgeDescription : Auriga.Diagram.Viewpoint.Description.Tool.IMappingBasedToolDescription
    {
        /// <summary>
        /// Gets or sets the edge view.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IElementSelectVariable EdgeView { get; set; }

        /// <summary>
        /// The semantic element of the ViewEdge.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IElementSelectVariable Element { get; set; }

        /// <summary>
        /// The first operation.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation InitialOperation { get; set; }

        /// <summary>
        /// The kind of reconnection :
        /// SOURCE : the source of the ViewEdge can be reconnected but not the target.
        /// TARGET : the target of the ViewEdge can be reconnected but not the source.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Tool.ReconnectionKind ReconnectionKind { get; set; }

        /// <summary>
        /// The semantic element of the source view of the reconnection operation.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Tool.ISourceEdgeCreationVariable Source { get; set; }

        /// <summary>
        /// The source view of the reconnection operation.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Tool.ISourceEdgeViewCreationVariable SourceView { get; set; }

        /// <summary>
        /// The semantic element of the target view of the reconnection operation.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Tool.ITargetEdgeCreationVariable Target { get; set; }

        /// <summary>
        /// The target view of the reconnection operation.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Tool.ITargetEdgeViewCreationVariable TargetView { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
