// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramStyle.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DiagramStyle</c> class.
    /// </summary>
    public partial class DiagramStyle : Auriga.Core.AurigaElement, Auriga.Diagram.Notation.IDiagramStyle
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// Gets the horizontal guides.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Notation.IGuide> HorizontalGuides => this.backingHorizontalGuides ??= new Auriga.Core.ContainerList<Auriga.Diagram.Notation.IGuide>(this);

        /// <summary>
        /// Backing field for <see cref="HorizontalGuides"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Notation.IGuide> backingHorizontalGuides;

        /// <summary>
        /// Gets or sets the page height.
        /// </summary>
        public int? PageHeight { get; set; } = 100;

        /// <summary>
        /// Gets or sets the page width.
        /// </summary>
        public int? PageWidth { get; set; } = 100;

        /// <summary>
        /// Gets or sets the page x.
        /// </summary>
        public int? PageX { get; set; } = 0;

        /// <summary>
        /// Gets or sets the page y.
        /// </summary>
        public int? PageY { get; set; } = 0;

        /// <summary>
        /// Gets the vertical guides.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Notation.IGuide> VerticalGuides => this.backingVerticalGuides ??= new Auriga.Core.ContainerList<Auriga.Diagram.Notation.IGuide>(this);

        /// <summary>
        /// Backing field for <see cref="VerticalGuides"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Notation.IGuide> backingVerticalGuides;

        /// <summary>
        /// Gets the elements directly contained by this <c>DiagramStyle</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.HorizontalGuides)
            {
                yield return element;
            }

            foreach (var element in this.VerticalGuides)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
