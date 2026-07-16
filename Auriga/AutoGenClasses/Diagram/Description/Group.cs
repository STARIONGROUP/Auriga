// ------------------------------------------------------------------------------------------------
// <copyright file="Group.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint.Description
{
    /// <summary>
    /// Definition of the <c>Group</c> class.
    /// </summary>
    public partial class Group : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.IGroup
    {
        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Gets the e annotations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IDAnnotation> EAnnotations => this.backingEAnnotations ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IDAnnotation>(this);

        /// <summary>
        /// Backing field for <see cref="EAnnotations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IDAnnotation> backingEAnnotations;

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IExtension> Extensions => this.backingExtensions ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IExtension>(this);

        /// <summary>
        /// Backing field for <see cref="Extensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IExtension> backingExtensions;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the owned viewpoints.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IViewpoint> OwnedViewpoints => this.backingOwnedViewpoints ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IViewpoint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedViewpoints"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IViewpoint> backingOwnedViewpoints;

        /// <summary>
        /// Gets the system colors palette.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.ISytemColorsPalette SystemColorsPalette => default;

        /// <summary>
        /// Gets the user colors palettes.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IUserColorsPalette> UserColorsPalettes => this.backingUserColorsPalettes ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IUserColorsPalette>(this);

        /// <summary>
        /// Backing field for <see cref="UserColorsPalettes"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IUserColorsPalette> backingUserColorsPalettes;

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>Group</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.EAnnotations)
            {
                yield return element;
            }

            foreach (var element in this.Extensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedViewpoints)
            {
                yield return element;
            }

            foreach (var element in this.UserColorsPalettes)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
