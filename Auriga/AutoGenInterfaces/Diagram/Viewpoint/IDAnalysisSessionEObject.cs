// ------------------------------------------------------------------------------------------------
// <copyright file="IDAnalysisSessionEObject.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>DAnalysisSessionEObject</c> interface.
    /// </summary>
    public partial interface IDAnalysisSessionEObject : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets the activated viewpoints.
        /// </summary>
        List<Auriga.Diagram.Viewpoint.Description.IViewpoint> ActivatedViewpoints { get; }

        /// <summary>
        /// Gets the analyses.
        /// </summary>
        List<Auriga.Diagram.Viewpoint.IDAnalysis> Analyses { get; }

        /// <summary>
        /// Gets the controlled resources.
        /// </summary>
        IEnumerable<object> ControlledResources { get; }

        /// <summary>
        /// Gets or sets the open.
        /// </summary>
        bool Open { get; set; }

        /// <summary>
        /// Gets the resources.
        /// </summary>
        IEnumerable<object> Resources { get; }

        /// <summary>
        /// Gets or sets the synchronization status.
        /// </summary>
        Auriga.Diagram.Viewpoint.SyncStatus SynchronizationStatus { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
