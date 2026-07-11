// ------------------------------------------------------------------------------------------------
// <copyright file="IEnvironment.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description
{
    /// <summary>
    /// Definition of the <c>Environment</c> interface.
    /// </summary>
    public partial interface IEnvironment : Auriga.IAurigaElement
    {
        /// <summary>
        /// Gets the default tools.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry> DefaultTools { get; }

        /// <summary>
        /// Gets or sets the label border styles.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Style.ILabelBorderStyles LabelBorderStyles { get; set; }

        /// <summary>
        /// Gets or sets the system colors.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.ISytemColorsPalette SystemColors { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
