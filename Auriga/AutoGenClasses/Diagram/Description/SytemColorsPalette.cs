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

namespace Auriga.Diagram.Viewpoint.Description
{
    /// <summary>
    /// Definition of the <c>SytemColorsPalette</c> class.
    /// </summary>
    public partial class SytemColorsPalette : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.ISytemColorsPalette
    {
        /// <summary>
        /// Gets the entries.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.ISystemColor> Entries => this.backingEntries ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.ISystemColor>(this);

        /// <summary>
        /// Backing field for <see cref="Entries"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.ISystemColor> backingEntries;

        /// <summary>
        /// Gets the elements directly contained by this <c>SytemColorsPalette</c>.
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
