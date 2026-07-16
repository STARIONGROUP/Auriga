// ------------------------------------------------------------------------------------------------
// <copyright file="EdgeStyle.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// The style of an edge.
    /// </summary>
    public partial class EdgeStyle : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.IEdgeStyle
    {
        /// <summary>
        /// Gets or sets the begin label style.
        /// </summary>
        public Auriga.Diagram.Diagram.IBeginLabelStyle BeginLabelStyle
        {
            get => this.backingBeginLabelStyle;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingBeginLabelStyle = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="BeginLabelStyle"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.IBeginLabelStyle backingBeginLabelStyle;

        /// <summary>
        /// Gets or sets the center label style.
        /// </summary>
        public Auriga.Diagram.Diagram.ICenterLabelStyle CenterLabelStyle
        {
            get => this.backingCenterLabelStyle;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingCenterLabelStyle = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="CenterLabelStyle"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.ICenterLabelStyle backingCenterLabelStyle;

        /// <summary>
        /// Gets or sets the centered.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.CenteringStyle Centered { get; set; }

        /// <summary>
        /// Gets the custom features.
        /// </summary>
        public List<string> CustomFeatures { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Style.IStyleDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the end label style.
        /// </summary>
        public Auriga.Diagram.Diagram.IEndLabelStyle EndLabelStyle
        {
            get => this.backingEndLabelStyle;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingEndLabelStyle = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="EndLabelStyle"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.IEndLabelStyle backingEndLabelStyle;

        /// <summary>
        /// Gets or sets the folding style.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.FoldingStyle FoldingStyle { get; set; }

        /// <summary>
        /// The style of the line.
        /// </summary>
        public Auriga.Diagram.Diagram.LineStyle? LineStyle { get; set; }

        /// <summary>
        /// The routing style of the edge.
        /// </summary>
        public Auriga.Diagram.Diagram.EdgeRouting RoutingStyle { get; set; }

        /// <summary>
        /// The line width.
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// The source decoration.
        /// </summary>
        public Auriga.Diagram.Diagram.EdgeArrows SourceArrow { get; set; }

        /// <summary>
        /// The color of the edge.
        /// </summary>
        public string StrokeColor { get; set; }

        /// <summary>
        /// The target decoration.
        /// </summary>
        public Auriga.Diagram.Diagram.EdgeArrows TargetArrow { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>EdgeStyle</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.BeginLabelStyle != null)
            {
                yield return this.BeginLabelStyle;
            }

            if (this.CenterLabelStyle != null)
            {
                yield return this.CenterLabelStyle;
            }

            if (this.EndLabelStyle != null)
            {
                yield return this.EndLabelStyle;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
