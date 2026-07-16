// ------------------------------------------------------------------------------------------------
// <copyright file="LabelBorderStyles.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint.Description.Style
{
    /// <summary>
    /// A group of LabelBorderStyleDescription to store in Environment.odesign.
    /// </summary>
    public partial class LabelBorderStyles : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.Style.ILabelBorderStyles
    {
        /// <summary>
        /// Gets the label border style descriptions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Style.ILabelBorderStyleDescription> LabelBorderStyleDescriptions => this.backingLabelBorderStyleDescriptions ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.Style.ILabelBorderStyleDescription>(this);

        /// <summary>
        /// Backing field for <see cref="LabelBorderStyleDescriptions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Style.ILabelBorderStyleDescription> backingLabelBorderStyleDescriptions;

        /// <summary>
        /// Gets the elements directly contained by this <c>LabelBorderStyles</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.LabelBorderStyleDescriptions)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
