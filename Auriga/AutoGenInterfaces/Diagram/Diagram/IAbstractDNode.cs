// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractDNode.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>AbstractDNode</c> interface.
    /// </summary>
    public partial interface IAbstractDNode : Auriga.Diagram.Diagram.IDDiagramElement
    {
        /// <summary>
        /// Gets the arrange constraints.
        /// </summary>
        List<Auriga.Diagram.Diagram.ArrangeConstraint> ArrangeConstraints { get; }

        /// <summary>
        /// The nodes that are on the border of the container.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IDNode> OwnedBorderedNodes { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
