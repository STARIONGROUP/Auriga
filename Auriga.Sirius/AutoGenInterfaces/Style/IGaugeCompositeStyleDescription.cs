// ------------------------------------------------------------------------------------------------
// <copyright file="IGaugeCompositeStyleDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Style
{
    /// <summary>
    /// This style groups many GaugeSection.
    /// </summary>
    public partial interface IGaugeCompositeStyleDescription : Auriga.Sirius.Diagram.Description.Style.INodeStyleDescription
    {
        /// <summary>
        /// The alignment of the gauges
        /// </summary>
        Auriga.Sirius.Diagram.AlignmentKind? Alignment { get; set; }

        /// <summary>
        /// The sections.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.Style.IGaugeSectionDescription> Sections { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
