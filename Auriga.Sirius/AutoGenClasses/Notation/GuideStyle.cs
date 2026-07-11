// ------------------------------------------------------------------------------------------------
// <copyright file="GuideStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Notation
{
    /// <summary>
    /// Definition of the <c>GuideStyle</c> class.
    /// </summary>
    public partial class GuideStyle : Auriga.AurigaElement, Auriga.Sirius.Notation.IGuideStyle
    {
        /// <summary>
        /// Gets the horizontal guides.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Notation.IGuide> HorizontalGuides => this.backingHorizontalGuides ??= new Auriga.ContainerList<Auriga.Sirius.Notation.IGuide>(this);

        /// <summary>
        /// Backing field for <see cref="HorizontalGuides"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Notation.IGuide> backingHorizontalGuides;

        /// <summary>
        /// Gets the vertical guides.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Notation.IGuide> VerticalGuides => this.backingVerticalGuides ??= new Auriga.ContainerList<Auriga.Sirius.Notation.IGuide>(this);

        /// <summary>
        /// Backing field for <see cref="VerticalGuides"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Notation.IGuide> backingVerticalGuides;

        /// <summary>
        /// Gets the elements directly contained by this <c>GuideStyle</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
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
