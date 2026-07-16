// ------------------------------------------------------------------------------------------------
// <copyright file="IView.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Notation
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>View</c> interface.
    /// </summary>
    public partial interface IView : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets the diagram.
        /// </summary>
        Auriga.Diagram.Notation.IDiagram Diagram_ { get; }

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        object Element { get; set; }

        /// <summary>
        /// Gets the mutable.
        /// </summary>
        bool? Mutable { get; }

        /// <summary>
        /// Gets the persisted children.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Notation.INode> PersistedChildren { get; }

        /// <summary>
        /// Gets the source edges.
        /// </summary>
        IEnumerable<Auriga.Diagram.Notation.IEdge> SourceEdges { get; }

        /// <summary>
        /// Gets the styles.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Notation.IStyle> Styles { get; }

        /// <summary>
        /// Gets the target edges.
        /// </summary>
        IEnumerable<Auriga.Diagram.Notation.IEdge> TargetEdges { get; }

        /// <summary>
        /// Gets the transient children.
        /// </summary>
        IEnumerable<Auriga.Diagram.Notation.INode> TransientChildren { get; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        bool? Visible { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
