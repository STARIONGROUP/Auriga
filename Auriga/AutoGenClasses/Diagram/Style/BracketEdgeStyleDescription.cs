// ------------------------------------------------------------------------------------------------
// <copyright file="BracketEdgeStyleDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description.Style
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>BracketEdgeStyleDescription</c> class.
    /// </summary>
    public partial class BracketEdgeStyleDescription : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.Style.IBracketEdgeStyleDescription
    {
        /// <summary>
        /// Gets or sets the begin label style description.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Style.IBeginLabelStyleDescription BeginLabelStyleDescription
        {
            get => this.backingBeginLabelStyleDescription;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingBeginLabelStyleDescription = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="BeginLabelStyleDescription"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.Style.IBeginLabelStyleDescription backingBeginLabelStyleDescription;

        /// <summary>
        /// Gets or sets the center label style description.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Style.ICenterLabelStyleDescription CenterLabelStyleDescription
        {
            get => this.backingCenterLabelStyleDescription;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingCenterLabelStyleDescription = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="CenterLabelStyleDescription"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.Style.ICenterLabelStyleDescription backingCenterLabelStyleDescription;

        /// <summary>
        /// The mappings for which the edge source will be centered.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping> CenteredSourceMappings { get; } = new List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping>();

        /// <summary>
        /// The mappings for which the edge target will be centered.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping> CenteredTargetMappings { get; } = new List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping>();

        /// <summary>
        /// Gets or sets the end label style description.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Style.IEndLabelStyleDescription EndLabelStyleDescription
        {
            get => this.backingEndLabelStyleDescription;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingEndLabelStyleDescription = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="EndLabelStyleDescription"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.Style.IEndLabelStyleDescription backingEndLabelStyleDescription;

        /// <summary>
        /// Use this feature to generalize the ends centering behavior to all source mappings, all target mappings or both. If "None", you have to select the source and target mappings manually.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.CenteringStyle? EndsCentering { get; set; } = Auriga.Diagram.Diagram.Description.CenteringStyle.None;

        /// <summary>
        /// A folding style allow to collapse the elements targeted by the edge.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.FoldingStyle? FoldingStyle { get; set; }

        /// <summary>
        /// The style of the line.
        /// </summary>
        public Auriga.Diagram.Diagram.LineStyle? LineStyle { get; set; }

        /// <summary>
        /// The routing style for your edge.
        /// </summary>
        public Auriga.Diagram.Diagram.EdgeRouting RoutingStyle { get; set; } = Auriga.Diagram.Diagram.EdgeRouting.Straight;

        /// <summary>
        /// An expression to compute the thickness of the link.
        /// </summary>
        public string SizeComputationExpression { get; set; } = "1";

        /// <summary>
        /// The source decoration.
        /// </summary>
        public Auriga.Diagram.Diagram.EdgeArrows SourceArrow { get; set; } = Auriga.Diagram.Diagram.EdgeArrows.NoDecoration;

        /// <summary>
        /// The color of the edge.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IColorDescription StrokeColor { get; set; }

        /// <summary>
        /// The target decoration.
        /// </summary>
        public Auriga.Diagram.Diagram.EdgeArrows TargetArrow { get; set; } = Auriga.Diagram.Diagram.EdgeArrows.InputArrow;

        /// <summary>
        /// Gets the elements directly contained by this <c>BracketEdgeStyleDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.BeginLabelStyleDescription != null)
            {
                yield return this.BeginLabelStyleDescription;
            }

            if (this.CenterLabelStyleDescription != null)
            {
                yield return this.CenterLabelStyleDescription;
            }

            if (this.EndLabelStyleDescription != null)
            {
                yield return this.EndLabelStyleDescription;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
