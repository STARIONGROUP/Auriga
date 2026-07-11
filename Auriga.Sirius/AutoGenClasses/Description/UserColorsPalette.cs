// ------------------------------------------------------------------------------------------------
// <copyright file="UserColorsPalette.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description
{
    /// <summary>
    /// Definition of the <c>UserColorsPalette</c> class.
    /// </summary>
    public partial class UserColorsPalette : Auriga.Core.AurigaElement, Auriga.Sirius.Viewpoint.Description.IUserColorsPalette
    {
        /// <summary>
        /// Gets the entries.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.IUserColor> Entries => this.backingEntries ??= new Auriga.Core.ContainerList<Auriga.Sirius.Viewpoint.Description.IUserColor>(this);

        /// <summary>
        /// Backing field for <see cref="Entries"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.IUserColor> backingEntries;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>UserColorsPalette</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Entries)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
