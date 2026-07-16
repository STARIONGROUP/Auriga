// ------------------------------------------------------------------------------------------------
// <copyright file="DResourceContainer.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint
{
    /// <summary>
    /// Definition of the <c>DResourceContainer</c> class.
    /// </summary>
    public partial class DResourceContainer : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.IDResourceContainer
    {
        /// <summary>
        /// Gets the members.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IDResource> Members => this.backingMembers ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.IDResource>(this);

        /// <summary>
        /// Backing field for <see cref="Members"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IDResource> backingMembers;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>DResourceContainer</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Members)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
