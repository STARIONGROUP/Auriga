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

namespace Auriga.Sirius.Diagram.Description
{
    /// <summary>
    /// Represents a node mapping. A node mapping allows to create nodes (ViewNode).
    /// </summary>
    public partial interface INodeMapping : Auriga.Sirius.Diagram.Description.IAbstractNodeMapping, Auriga.Sirius.Diagram.Description.IDragAndDropTargetDescription
    {
        /// <summary>
        /// All conditional styles.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IConditionalNodeStyleDescription> ConditionnalStyles { get; }

        /// <summary>
        /// The style of the node.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Style.INodeStyleDescription Style { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
