// ------------------------------------------------------------------------------------------------
// <copyright file="DAnalysisSessionEObject.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>DAnalysisSessionEObject</c> class.
    /// </summary>
    public partial class DAnalysisSessionEObject : Auriga.Core.AurigaElement, Auriga.Sirius.Viewpoint.IDAnalysisSessionEObject
    {
        /// <summary>
        /// Gets the activated viewpoints.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.Description.IViewpoint> ActivatedViewpoints { get; } = new List<Auriga.Sirius.Viewpoint.Description.IViewpoint>();

        /// <summary>
        /// Gets the analyses.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.IDAnalysis> Analyses { get; } = new List<Auriga.Sirius.Viewpoint.IDAnalysis>();

        /// <summary>
        /// Gets the controlled resources.
        /// </summary>
        public IEnumerable<object> ControlledResources => Enumerable.Empty<object>();

        /// <summary>
        /// Gets or sets the open.
        /// </summary>
        public bool Open { get; set; }

        /// <summary>
        /// Gets the resources.
        /// </summary>
        public IEnumerable<object> Resources => Enumerable.Empty<object>();

        /// <summary>
        /// Gets or sets the synchronization status.
        /// </summary>
        public Auriga.Sirius.Viewpoint.SyncStatus SynchronizationStatus { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
