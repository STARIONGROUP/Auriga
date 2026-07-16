// ------------------------------------------------------------------------------------------------
// <copyright file="IDView.cs" company="Starion Group S.A.">
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
    /// An view is the root element
    /// </summary>
    public partial interface IDView : Auriga.Sirius.Viewpoint.IIdentifiedElement, Auriga.Sirius.Viewpoint.IDRefreshable
    {
        /// <summary>
        /// Gets the models.
        /// </summary>
        IEnumerable<object> Models { get; }

        /// <summary>
        /// The Meta Model extension for this analysis. It may be null.
        /// </summary>
        Auriga.Sirius.Viewpoint.IMetaModelExtension OwnedExtensions { get; set; }

        /// <summary>
        /// The representation descriptors that are owned by this DView
        /// .
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.IDRepresentationDescriptor> OwnedRepresentationDescriptors { get; }

        /// <summary>
        /// The viewpoint that is used for this view
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.IViewpoint Viewpoint { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
