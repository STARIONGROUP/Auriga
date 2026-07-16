// ------------------------------------------------------------------------------------------------
// <copyright file="IViewpoint.cs" company="Starion Group S.A.">
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
    public partial interface IViewpoint : Auriga.Diagram.Viewpoint.Description.IDocumentedElement, Auriga.Diagram.Viewpoint.Description.IComponent, Auriga.Diagram.Viewpoint.Description.IEndUserDocumentedElement, Auriga.Diagram.Viewpoint.Description.IIdentifiedElement
    {
        /// <summary>
        /// Gets the conflicts.
        /// </summary>
        List<string> Conflicts { get; }

        /// <summary>
        /// Gets the customizes.
        /// </summary>
        List<string> Customizes { get; }

        /// <summary>
        /// image path to use as an icon for the viewpoint
        /// </summary>
        string Icon { get; set; }

        /// <summary>
        /// Might be used to restrict your viewpoint to a set of file extensions, for instance "ecore"
        /// </summary>
        string ModelFileExtension { get; set; }

        /// <summary>
        /// Gets the owned feature extensions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IFeatureExtensionDescription> OwnedFeatureExtensions { get; }

        /// <summary>
        /// Gets the owned java extensions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IJavaExtension> OwnedJavaExtensions { get; }

        /// <summary>
        /// Gets the owned m m extensions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IMetamodelExtensionSetting> OwnedMMExtensions { get; }

        /// <summary>
        /// Gets the owned representation extensions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IRepresentationExtensionDescription> OwnedRepresentationExtensions { get; }

        /// <summary>
        /// Gets the owned representations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IRepresentationDescription> OwnedRepresentations { get; }

        /// <summary>
        /// Gets the owned templates.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IRepresentationTemplate> OwnedTemplates { get; }

        /// <summary>
        /// Gets the reuses.
        /// </summary>
        List<string> Reuses { get; }

        /// <summary>
        /// The validations rules
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Validation.IValidationSet ValidationSet { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
