// ------------------------------------------------------------------------------------------------
// <copyright file="IDRepresentationElement.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// Definition of the <c>DRepresentationElement</c> interface.
    /// </summary>
    public partial interface IDRepresentationElement : Auriga.Diagram.Viewpoint.IIdentifiedElement, Auriga.Diagram.Viewpoint.IDMappingBased, Auriga.Diagram.Viewpoint.IDStylizable, Auriga.Diagram.Viewpoint.IDRefreshable, Auriga.Diagram.Viewpoint.IDSemanticDecorator
    {
        /// <summary>
        /// The name of the element. It is the name that is displayed on the diagram.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The semantic elements to show that represents this view point element.
        /// </summary>
        List<object> SemanticElements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
