// ------------------------------------------------------------------------------------------------
// <copyright file="INodeMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description
{
    /// <summary>
    /// Represents a node mapping. A node mapping allows to create nodes (ViewNode).
    /// </summary>
    public partial interface INodeMapping : Auriga.Diagram.Diagram.Description.IAbstractNodeMapping, Auriga.Diagram.Diagram.Description.IDragAndDropTargetDescription
    {
        /// <summary>
        /// All conditional styles.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.IConditionalNodeStyleDescription> ConditionnalStyles { get; }

        /// <summary>
        /// The style of the node.
        /// </summary>
        Auriga.Diagram.Diagram.Description.Style.INodeStyleDescription Style { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
