// ------------------------------------------------------------------------------------------------
// <copyright file="IMappingBasedDecoration.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// A MappingBasedDecoration applies decorations on views that are issued from one or more mappings.
    /// </summary>
    public partial interface IMappingBasedDecoration : Auriga.Sirius.Viewpoint.Description.IDecorationDescription
    {
        /// <summary>
        /// Gets the mappings.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> Mappings { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
