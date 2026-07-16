// ------------------------------------------------------------------------------------------------
// <copyright file="TExecutionStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Sequence.Template
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>TExecutionStyle</c> class.
    /// </summary>
    public partial class TExecutionStyle : Auriga.Core.AurigaElement, Auriga.Diagram.Sequence.Template.ITExecutionStyle
    {
        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IColorDescription BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IColorDescription BorderColor { get; set; }

        /// <summary>
        /// An expression computing the size of the border.
        /// </summary>
        public string BorderSizeComputationExpression { get; set; }

        /// <summary>
        /// Gets the outputs.
        /// </summary>
        public List<object> Outputs { get; } = new List<object>();

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
