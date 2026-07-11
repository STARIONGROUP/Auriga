// ------------------------------------------------------------------------------------------------
// <copyright file="ITypesFolder.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>TypesFolder</c> interface.
    /// </summary>
    public partial interface ITypesFolder : Auriga.Requirements.IReqIFElement
    {
        /// <summary>
        /// Gets the owned definition types.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Requirements.IDataTypeDefinition> OwnedDefinitionTypes { get; }

        /// <summary>
        /// Gets the owned types.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Requirements.IAbstractType> OwnedTypes { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
