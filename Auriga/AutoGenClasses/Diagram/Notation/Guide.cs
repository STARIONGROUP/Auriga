// ------------------------------------------------------------------------------------------------
// <copyright file="Guide.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>Guide</c> class.
    /// </summary>
    public partial class Guide : Auriga.Core.AurigaElement, Auriga.Diagram.Notation.IGuide
    {
        /// <summary>
        /// Gets the node map.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Notation.INodeEntry> NodeMap => this.backingNodeMap ??= new Auriga.Core.ContainerList<Auriga.Diagram.Notation.INodeEntry>(this);

        /// <summary>
        /// Backing field for <see cref="NodeMap"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Notation.INodeEntry> backingNodeMap;

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        public int? Position { get; set; } = 0;

        /// <summary>
        /// Gets the elements directly contained by this <c>Guide</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.NodeMap)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
