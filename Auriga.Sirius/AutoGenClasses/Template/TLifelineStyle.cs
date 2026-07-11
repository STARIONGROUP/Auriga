// ------------------------------------------------------------------------------------------------
// <copyright file="TLifelineStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence.Template
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>TLifelineStyle</c> class.
    /// </summary>
    public partial class TLifelineStyle : Auriga.AurigaElement, Auriga.Sirius.Sequence.Template.ITLifelineStyle
    {
        /// <summary>
        /// Gets or sets the lifeline color.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.IColorDescription LifelineColor { get; set; }

        /// <summary>
        /// An expression computing the size of the border.
        /// </summary>
        public string LifelineWidthComputationExpression { get; set; }

        /// <summary>
        /// Gets the outputs.
        /// </summary>
        public List<object> Outputs { get; } = new List<object>();

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
