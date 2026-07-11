// ------------------------------------------------------------------------------------------------
// <copyright file="DRepresentationDescriptor.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DRepresentationDescriptor</c> class.
    /// </summary>
    public partial class DRepresentationDescriptor : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.IDRepresentationDescriptor
    {
        /// <summary>
        /// Gets or sets the change id.
        /// </summary>
        public string ChangeId { get; set; }

        /// <summary>
        /// The description of the representation targeted by this descriptor.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.IRepresentationDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Gets the e annotations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IDAnnotation> EAnnotations => this.backingEAnnotations ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.IDAnnotation>(this);

        /// <summary>
        /// Backing field for <see cref="EAnnotations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IDAnnotation> backingEAnnotations;

        /// <summary>
        /// The name of the representation.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the rep path.
        /// </summary>
        public string RepPath { get; set; }

        /// <summary>
        /// The representation targeted by this descriptor.
        /// </summary>
        public Auriga.Sirius.Viewpoint.IDRepresentation Representation => default;

        /// <summary>
        /// The referenced EObject.
        /// </summary>
        public object Target { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>DRepresentationDescriptor</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.EAnnotations)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
