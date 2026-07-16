// ------------------------------------------------------------------------------------------------
// <copyright file="INodeMappingImport.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description
{
    /// <summary>
    /// Ease the reuse of existing mappings. If the feature is not defined in this instance it will re-use the feature value of the imported one.
    /// </summary>
    public partial interface INodeMappingImport : Auriga.Diagram.Diagram.Description.INodeMapping, Auriga.Diagram.Viewpoint.Description.IAbstractMappingImport
    {
        /// <summary>
        /// The imported mapping used to define default values for the current mapping.
        /// </summary>
        Auriga.Diagram.Diagram.Description.INodeMapping ImportedMapping { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
