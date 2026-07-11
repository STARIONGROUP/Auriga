// ------------------------------------------------------------------------------------------------
// <copyright file="IToolFilterDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description.Tool
{
    /// <summary>
    /// filter to hide a tool in UI based on preconditon evaluated when specified elements to listen are modified
    /// </summary>
    public partial interface IToolFilterDescription : Auriga.IAurigaElement
    {
        /// <summary>
        /// The elements to listen by the filter.
        /// </summary>
        string ElementsToListen { get; set; }

        /// <summary>
        /// Gets the listeners.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IFeatureChangeListener> Listeners { get; }

        /// <summary>
        /// The precondition of the filter.
        /// </summary>
        string Precondition { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
