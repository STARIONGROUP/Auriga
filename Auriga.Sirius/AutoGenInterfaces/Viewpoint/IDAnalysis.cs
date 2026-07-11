// ------------------------------------------------------------------------------------------------
// <copyright file="IDAnalysis.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DAnalysis</c> interface.
    /// </summary>
    public partial interface IDAnalysis : Auriga.Sirius.Viewpoint.IIdentifiedElement
    {
        /// <summary>
        /// Gets the e annotations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.IDAnnotationEntry> EAnnotations { get; }

        /// <summary>
        /// Gets the models.
        /// </summary>
        IEnumerable<object> Models { get; }

        /// <summary>
        /// Gets the owned feature extensions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.IDFeatureExtension> OwnedFeatureExtensions { get; }

        /// <summary>
        /// Gets the owned views.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.IDView> OwnedViews { get; }

        /// <summary>
        /// Gets the referenced analysis.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.IDAnalysis> ReferencedAnalysis { get; }

        /// <summary>
        /// Gets the selected views.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.IDView> SelectedViews { get; }

        /// <summary>
        /// Gets the semantic resources.
        /// </summary>
        List<string> SemanticResources { get; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        string Version { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
