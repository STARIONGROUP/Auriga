// ------------------------------------------------------------------------------------------------
// <copyright file="IDRepresentationDescriptor.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>DRepresentationDescriptor</c> interface.
    /// </summary>
    public partial interface IDRepresentationDescriptor : Auriga.Sirius.Viewpoint.IIdentifiedElement, Auriga.Sirius.Viewpoint.Description.IDModelElement, Auriga.Sirius.Viewpoint.Description.IDocumentedElement
    {
        /// <summary>
        /// Gets or sets the change id.
        /// </summary>
        string ChangeId { get; set; }

        /// <summary>
        /// The description of the representation targeted by this descriptor.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.IRepresentationDescription Description { get; set; }

        /// <summary>
        /// The name of the representation.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the rep path.
        /// </summary>
        string RepPath { get; set; }

        /// <summary>
        /// The representation targeted by this descriptor.
        /// </summary>
        Auriga.Sirius.Viewpoint.IDRepresentation Representation { get; }

        /// <summary>
        /// The referenced EObject.
        /// </summary>
        object Target { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
