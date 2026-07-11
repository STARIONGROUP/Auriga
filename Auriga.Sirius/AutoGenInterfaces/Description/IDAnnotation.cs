// ------------------------------------------------------------------------------------------------
// <copyright file="IDAnnotation.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>DAnnotation</c> interface.
    /// </summary>
    public partial interface IDAnnotation : Auriga.Sirius.Viewpoint.IIdentifiedElement
    {
        /// <summary>
        /// Gets the details.
        /// </summary>
        Auriga.IContainerList<Auriga.IAurigaElement> Details { get; }

        /// <summary>
        /// Gets the references.
        /// </summary>
        List<object> References { get; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        string Source { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
