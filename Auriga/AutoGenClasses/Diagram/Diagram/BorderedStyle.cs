// ------------------------------------------------------------------------------------------------
// <copyright file="BorderedStyle.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>BorderedStyle</c> class.
    /// </summary>
    public partial class BorderedStyle : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.IBorderedStyle
    {
        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        public string BorderColor { get; set; } = "0,0,0";

        /// <summary>
        /// The style of the border line.
        /// </summary>
        public Auriga.Diagram.Diagram.LineStyle? BorderLineStyle { get; set; }

        /// <summary>
        /// Gets or sets the border size.
        /// </summary>
        public int BorderSize { get; set; } = 0;

        /// <summary>
        /// Gets or sets the border size computation expression.
        /// </summary>
        public string BorderSizeComputationExpression { get; set; } = "0";

        /// <summary>
        /// Gets the custom features.
        /// </summary>
        public List<string> CustomFeatures { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Style.IStyleDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
