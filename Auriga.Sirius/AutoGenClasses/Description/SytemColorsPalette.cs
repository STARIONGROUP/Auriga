// ------------------------------------------------------------------------------------------------
// <copyright file="SytemColorsPalette.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>SytemColorsPalette</c> class.
    /// </summary>
    public partial class SytemColorsPalette : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.ISytemColorsPalette
    {
        /// <summary>
        /// Gets the entries.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.ISystemColor> Entries => this.backingEntries ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.ISystemColor>(this);

        /// <summary>
        /// Backing field for <see cref="Entries"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.ISystemColor> backingEntries;

        /// <summary>
        /// Gets the elements directly contained by this <c>SytemColorsPalette</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
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
