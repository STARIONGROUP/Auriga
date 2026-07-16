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

namespace Auriga.Model.Requirements
{
    /// <summary>
    /// Definition of the <c>Module</c> interface.
    /// </summary>
    public partial interface IModule : Auriga.Model.Requirements.IAttributeOwner, Auriga.Model.Requirements.ISharedDirectAttributes
    {
        /// <summary>
        /// Gets or sets the module type.
        /// </summary>
        Auriga.Model.Requirements.IModuleType ModuleType { get; set; }

        /// <summary>
        /// Gets the owned requirements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Requirements.IRequirement> OwnedRequirements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
