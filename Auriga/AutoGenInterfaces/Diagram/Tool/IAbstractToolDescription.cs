// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractToolDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint.Description.Tool
{
    /// <summary>
    /// Base class of all tools.
    /// </summary>
    public partial interface IAbstractToolDescription : Auriga.Diagram.Viewpoint.Description.Tool.IToolEntry
    {
        /// <summary>
        /// An expression used to define the selected elements after the tool execution.
        /// </summary>
        string ElementsToSelect { get; set; }

        /// <summary>
        /// Gets the filters.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IToolFilterDescription> Filters { get; }

        /// <summary>
        /// If true then a refresh for the whole representation is executed after every execution of the tool.
        /// </summary>
        bool? ForceRefresh { get; set; }

        /// <summary>
        /// By default the elements to select are listed in the creation order. If true, the order is inverted.
        /// </summary>
        bool? InverseSelectionOrder { get; set; }

        /// <summary>
        /// The precondition of the tool.
        /// </summary>
        string Precondition { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
