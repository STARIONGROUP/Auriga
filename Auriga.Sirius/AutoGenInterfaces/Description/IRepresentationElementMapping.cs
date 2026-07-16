// ------------------------------------------------------------------------------------------------
// <copyright file="IRepresentationElementMapping.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>RepresentationElementMapping</c> interface.
    /// </summary>
    public partial interface IRepresentationElementMapping : Auriga.Sirius.Viewpoint.Description.IIdentifiedElement
    {
        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationCreationDescription> DetailDescriptions { get; }

        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationNavigationDescription> NavigationDescriptions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
