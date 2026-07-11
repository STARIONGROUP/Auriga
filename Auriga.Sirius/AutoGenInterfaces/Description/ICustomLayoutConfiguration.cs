// ------------------------------------------------------------------------------------------------
// <copyright file="ICustomLayoutConfiguration.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description
{
    /// <summary>
    /// Definition of the <c>CustomLayoutConfiguration</c> interface.
    /// </summary>
    public partial interface ICustomLayoutConfiguration : Auriga.Sirius.Diagram.Description.ILayout
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// Gets the layout options.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Diagram.Description.ILayoutOption> LayoutOptions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
