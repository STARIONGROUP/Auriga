// ------------------------------------------------------------------------------------------------
// <copyright file="IDiagramExtensionDescription.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DiagramExtensionDescription</c> interface.
    /// </summary>
    public partial interface IDiagramExtensionDescription : Auriga.Sirius.Viewpoint.Description.IRepresentationExtensionDescription
    {
        /// <summary>
        /// All concerns of the diagrams to add. A concern is a set of filters, validations and behaviors.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Concern.IConcernSet Concerns { get; set; }

        /// <summary>
        /// Gets the layers.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IAdditionalLayer> Layers { get; }

        /// <summary>
        /// The validations rules to add
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Validation.IValidationSet ValidationSet { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
