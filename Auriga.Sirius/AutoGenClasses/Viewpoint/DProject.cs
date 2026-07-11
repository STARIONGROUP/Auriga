// ------------------------------------------------------------------------------------------------
// <copyright file="DProject.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint
{
    /// <summary>
    /// Definition of the <c>DProject</c> class.
    /// </summary>
    public partial class DProject : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.IDProject
    {
        /// <summary>
        /// Gets the members.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.IDResource> Members => this.backingMembers ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.IDResource>(this);

        /// <summary>
        /// Backing field for <see cref="Members"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.IDResource> backingMembers;

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
        /// Gets the elements directly contained by this <c>DProject</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
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
