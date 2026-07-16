// ------------------------------------------------------------------------------------------------
// <copyright file="ComputedStyleDescriptionRegistry.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>ComputedStyleDescriptionRegistry</c> class.
    /// </summary>
    public partial class ComputedStyleDescriptionRegistry : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.IComputedStyleDescriptionRegistry
    {
        /// <summary>
        /// Gets the computed style descriptions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Style.IStyleDescription> ComputedStyleDescriptions => this.backingComputedStyleDescriptions ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.Style.IStyleDescription>(this);

        /// <summary>
        /// Backing field for <see cref="ComputedStyleDescriptions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Style.IStyleDescription> backingComputedStyleDescriptions;

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>ComputedStyleDescriptionRegistry</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.ComputedStyleDescriptions)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
