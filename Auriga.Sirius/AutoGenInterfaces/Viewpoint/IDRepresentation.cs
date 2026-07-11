// ------------------------------------------------------------------------------------------------
// <copyright file="IDRepresentation.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DRepresentation</c> interface.
    /// </summary>
    public partial interface IDRepresentation : Auriga.Sirius.Viewpoint.IIdentifiedElement, Auriga.Sirius.Viewpoint.Description.IDModelElement, Auriga.Sirius.Viewpoint.IDRefreshable
    {
        /// <summary>
        /// Gets the documentation.
        /// </summary>
        string Documentation { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the owned annotation entries.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IAnnotationEntry> OwnedAnnotationEntries { get; }

        /// <summary>
        /// The directly contained representation elements
        /// </summary>
        IEnumerable<Auriga.Sirius.Viewpoint.IDRepresentationElement> OwnedRepresentationElements { get; }

        /// <summary>
        /// The directly and indirectly contained representation elements
        /// </summary>
        IEnumerable<Auriga.Sirius.Viewpoint.IDRepresentationElement> RepresentationElements { get; }

        /// <summary>
        /// Gets the ui state.
        /// </summary>
        Auriga.Sirius.Viewpoint.IUIState UiState { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
