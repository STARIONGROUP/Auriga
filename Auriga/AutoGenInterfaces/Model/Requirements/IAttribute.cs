// ------------------------------------------------------------------------------------------------
// <copyright file="IAttribute.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Requirements
{
    /// <summary>
    /// Definition of the <c>Attribute</c> interface.
    /// </summary>
    public partial interface IAttribute : Auriga.Model.Requirements.IIdentifiableElement
    {
        /// <summary>
        /// Gets or sets the definition.
        /// </summary>
        Auriga.Model.Requirements.IAttributeDefinition Definition { get; set; }

        /// <summary>
        /// Gets or sets the definition proxy.
        /// </summary>
        string DefinitionProxy { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
