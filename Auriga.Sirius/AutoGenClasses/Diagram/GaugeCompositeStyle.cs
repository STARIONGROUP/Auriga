// ------------------------------------------------------------------------------------------------
// <copyright file="GaugeCompositeStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram
{
    using System.Collections.Generic;

    /// <summary>
    /// This style groups many GaugeSection.
    /// </summary>
    public partial class GaugeCompositeStyle : Auriga.AurigaElement, Auriga.Sirius.Diagram.IGaugeCompositeStyle
    {
        /// <summary>
        /// The alignment of the gauges
        /// </summary>
        public Auriga.Sirius.Diagram.AlignmentKind? Alignment { get; set; }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        public string BorderColor { get; set; }

        /// <summary>
        /// The style of the border line.
        /// </summary>
        public Auriga.Sirius.Diagram.LineStyle? BorderLineStyle { get; set; }

        /// <summary>
        /// Gets or sets the border size.
        /// </summary>
        public int BorderSize { get; set; }

        /// <summary>
        /// Gets or sets the border size computation expression.
        /// </summary>
        public string BorderSizeComputationExpression { get; set; }

        /// <summary>
        /// Gets the custom features.
        /// </summary>
        public List<string> CustomFeatures { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Style.IStyleDescription Description { get; set; }

        /// <summary>
        /// The default visibility of the label (available only if labelPosition equals BORDER).
        /// A change of this option does not affect already existing elements.
        /// </summary>
        public bool? HideLabelByDefault { get; set; }

        /// <summary>
        /// The path of the icon to display on the element. If unset, the icon corresponding to the semantic element will be displayed.
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// Gets or sets the label alignment.
        /// </summary>
        public Auriga.Sirius.Viewpoint.LabelAlignment? LabelAlignment { get; set; }

        /// <summary>
        /// Gets or sets the label color.
        /// </summary>
        public string LabelColor { get; set; }

        /// <summary>
        /// The font format.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.FontFormat> LabelFormat { get; } = new List<Auriga.Sirius.Viewpoint.FontFormat>();

        /// <summary>
        /// The position of the label :
        /// BORDER : The label is around the node, on the border.
        /// NODE : the label is in the node.
        /// </summary>
        public Auriga.Sirius.Diagram.LabelPosition? LabelPosition { get; set; }

        /// <summary>
        /// The font size.
        /// </summary>
        public int? LabelSize { get; set; }

        /// <summary>
        /// The sections.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Diagram.IGaugeSection> Sections => this.backingSections ??= new Auriga.ContainerList<Auriga.Sirius.Diagram.IGaugeSection>(this);

        /// <summary>
        /// Backing field for <see cref="Sections"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Diagram.IGaugeSection> backingSections;

        /// <summary>
        /// True, if the icon shoud be dispayed on the element.
        /// </summary>
        public bool? ShowIcon { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>GaugeCompositeStyle</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Sections)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
