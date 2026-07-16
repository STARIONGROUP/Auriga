// ------------------------------------------------------------------------------------------------
// <copyright file="Viewpoint.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// A Viewpoint defines a "way of looking at your model", you could make an analogy with "What is your current concern about your analysis". It defines representations and might also define specific data only relevant for this concern.
    /// </summary>
    public partial class Viewpoint : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.IViewpoint
    {
        /// <summary>
        /// Gets the conflicts.
        /// </summary>
        public List<string> Conflicts { get; } = new List<string>();

        /// <summary>
        /// Gets the customizes.
        /// </summary>
        public List<string> Customizes { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Gets or sets the end user documentation.
        /// </summary>
        public string EndUserDocumentation { get; set; }

        /// <summary>
        /// image path to use as an icon for the viewpoint
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Might be used to restrict your viewpoint to a set of file extensions, for instance "ecore"
        /// </summary>
        public string ModelFileExtension { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the owned feature extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IFeatureExtensionDescription> OwnedFeatureExtensions => this.backingOwnedFeatureExtensions ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IFeatureExtensionDescription>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFeatureExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IFeatureExtensionDescription> backingOwnedFeatureExtensions;

        /// <summary>
        /// Gets the owned java extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IJavaExtension> OwnedJavaExtensions => this.backingOwnedJavaExtensions ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IJavaExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedJavaExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IJavaExtension> backingOwnedJavaExtensions;

        /// <summary>
        /// Gets the owned m m extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IMetamodelExtensionSetting> OwnedMMExtensions => this.backingOwnedMMExtensions ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IMetamodelExtensionSetting>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMMExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IMetamodelExtensionSetting> backingOwnedMMExtensions;

        /// <summary>
        /// Gets the owned representation extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IRepresentationExtensionDescription> OwnedRepresentationExtensions => this.backingOwnedRepresentationExtensions ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IRepresentationExtensionDescription>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRepresentationExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IRepresentationExtensionDescription> backingOwnedRepresentationExtensions;

        /// <summary>
        /// Gets the owned representations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IRepresentationDescription> OwnedRepresentations => this.backingOwnedRepresentations ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IRepresentationDescription>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRepresentations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IRepresentationDescription> backingOwnedRepresentations;

        /// <summary>
        /// Gets the owned templates.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IRepresentationTemplate> OwnedTemplates => this.backingOwnedTemplates ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.IRepresentationTemplate>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTemplates"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IRepresentationTemplate> backingOwnedTemplates;

        /// <summary>
        /// Gets the reuses.
        /// </summary>
        public List<string> Reuses { get; } = new List<string>();

        /// <summary>
        /// The validations rules
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Validation.IValidationSet ValidationSet
        {
            get => this.backingValidationSet;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingValidationSet = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="ValidationSet"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Validation.IValidationSet backingValidationSet;

        /// <summary>
        /// Gets the elements directly contained by this <c>Viewpoint</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedFeatureExtensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedJavaExtensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedMMExtensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedRepresentationExtensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedRepresentations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedTemplates)
            {
                yield return element;
            }

            if (this.ValidationSet != null)
            {
                yield return this.ValidationSet;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
