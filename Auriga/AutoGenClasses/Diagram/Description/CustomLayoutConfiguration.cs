// ------------------------------------------------------------------------------------------------
// <copyright file="CustomLayoutConfiguration.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description
{
    /// <summary>
    /// Definition of the <c>CustomLayoutConfiguration</c> class.
    /// </summary>
    public partial class CustomLayoutConfiguration : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.ICustomLayoutConfiguration
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; } = "";

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets the layout options.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.ILayoutOption> LayoutOptions => this.backingLayoutOptions ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.Description.ILayoutOption>(this);

        /// <summary>
        /// Backing field for <see cref="LayoutOptions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.Description.ILayoutOption> backingLayoutOptions;

        /// <summary>
        /// Gets the elements directly contained by this <c>CustomLayoutConfiguration</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.LayoutOptions)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
