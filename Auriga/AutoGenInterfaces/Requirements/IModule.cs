// ------------------------------------------------------------------------------------------------
// <copyright file="IModule.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Module</c> interface.
    /// </summary>
    public partial interface IModule : Auriga.Requirements.IAttributeOwner, Auriga.Requirements.ISharedDirectAttributes
    {
        /// <summary>
        /// Gets or sets the module type.
        /// </summary>
        Auriga.Requirements.IModuleType ModuleType { get; set; }

        /// <summary>
        /// Gets the owned requirements.
        /// </summary>
        Auriga.IContainerList<Auriga.Requirements.IRequirement> OwnedRequirements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
