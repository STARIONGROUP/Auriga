// ------------------------------------------------------------------------------------------------
// <copyright file="DAnalysis.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DAnalysis</c> class.
    /// </summary>
    public partial class DAnalysis : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.IDAnalysis
    {
        /// <summary>
        /// Gets the e annotations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IDAnnotationEntry> EAnnotations => this.backingEAnnotations ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IDAnnotationEntry>(this);

        /// <summary>
        /// Backing field for <see cref="EAnnotations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IDAnnotationEntry> backingEAnnotations;

        /// <summary>
        /// Gets the models.
        /// </summary>
        public IEnumerable<object> Models => Enumerable.Empty<object>();

        /// <summary>
        /// Gets the owned feature extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IDFeatureExtension> OwnedFeatureExtensions => this.backingOwnedFeatureExtensions ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.IDFeatureExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFeatureExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IDFeatureExtension> backingOwnedFeatureExtensions;

        /// <summary>
        /// Gets the owned views.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IDView> OwnedViews => this.backingOwnedViews ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.IDView>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedViews"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IDView> backingOwnedViews;

        /// <summary>
        /// Gets the referenced analysis.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.IDAnalysis> ReferencedAnalysis { get; } = new List<Auriga.Diagram.Viewpoint.IDAnalysis>();

        /// <summary>
        /// Gets the selected views.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.IDView> SelectedViews { get; } = new List<Auriga.Diagram.Viewpoint.IDView>();

        /// <summary>
        /// Gets the semantic resources.
        /// </summary>
        public List<string> SemanticResources { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>DAnalysis</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.EAnnotations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedFeatureExtensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedViews)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
