// ------------------------------------------------------------------------------------------------
// <copyright file="IAttributeDefinition.cs" company="Starion Group S.A.">
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

namespace Auriga.Requirements
{
    /// <summary>
    /// Definition of the <c>AttributeDefinition</c> interface.
    /// </summary>
    public partial interface IAttributeDefinition : Auriga.Requirements.IReqIFElement
    {
        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        Auriga.Requirements.IAttribute DefaultValue { get; set; }

        /// <summary>
        /// Gets or sets the definition type.
        /// </summary>
        Auriga.Requirements.IDataTypeDefinition DefinitionType { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
