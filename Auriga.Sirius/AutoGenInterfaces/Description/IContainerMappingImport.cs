// ------------------------------------------------------------------------------------------------
// <copyright file="IContainerMappingImport.cs" company="Starion Group S.A.">
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
    /// Ease the reuse of existing mappings. If the feature is not defined in this instance it will re-use
    /// the feature value of the imported one.
    /// </summary>
    public partial interface IContainerMappingImport : Auriga.Sirius.Diagram.Description.IContainerMapping, Auriga.Sirius.Viewpoint.Description.IAbstractMappingImport
    {
        /// <summary>
        /// The imported mapping used to define default values for the current mapping.
        /// </summary>
        Auriga.Sirius.Diagram.Description.IContainerMapping ImportedMapping { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
