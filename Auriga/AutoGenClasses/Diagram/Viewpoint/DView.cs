// ------------------------------------------------------------------------------------------------
// <copyright file="DView.cs" company="Starion Group S.A.">
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
    /// An view is the root element
    /// </summary>
    public partial class DView : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.IDView
    {
        /// <summary>
        /// Gets the models.
        /// </summary>
        public IEnumerable<object> Models => Enumerable.Empty<object>();

        /// <summary>
        /// The Meta Model extension for this analysis. It may be null.
        /// </summary>
        public Auriga.Diagram.Viewpoint.IMetaModelExtension OwnedExtensions
        {
            get => this.backingOwnedExtensions;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedExtensions = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.IMetaModelExtension backingOwnedExtensions;

        /// <summary>
        /// The representation descriptors that are owned by this DView
        /// .
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IDRepresentationDescriptor> OwnedRepresentationDescriptors => this.backingOwnedRepresentationDescriptors ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.IDRepresentationDescriptor>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRepresentationDescriptors"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IDRepresentationDescriptor> backingOwnedRepresentationDescriptors;

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// The viewpoint that is used for this view
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IViewpoint Viewpoint { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>DView</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.OwnedExtensions != null)
            {
                yield return this.OwnedExtensions;
            }

            foreach (var element in this.OwnedRepresentationDescriptors)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
