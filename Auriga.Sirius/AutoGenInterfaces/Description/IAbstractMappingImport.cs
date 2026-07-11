// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractMappingImport.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>AbstractMappingImport</c> interface.
    /// </summary>
    public partial interface IAbstractMappingImport : Auriga.IAurigaElement
    {
        /// <summary>
        /// Set to true if you don't want to inherit the sub mappings of the imported mapping.
        /// </summary>
        bool? HideSubMappings { get; set; }

        /// <summary>
        /// Set to true if you want the filters applying on the imported mappings apply on this one.
        /// </summary>
        bool? InheritsAncestorFilters { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
