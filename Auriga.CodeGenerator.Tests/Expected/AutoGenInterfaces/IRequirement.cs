// ------------------------------------------------------------------------------------------------
// <copyright file="IRequirement.cs" company="Starion Group S.A.">
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
    using System.Numerics;

    /// <summary>
    /// Definition of the <c>Requirement</c> interface.
    /// </summary>
    public partial interface IRequirement : Auriga.Requirements.IAttributeOwner, Auriga.Requirements.ISharedDirectAttributes
    {
        /// <summary>
        /// Gets the owned relations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Requirements.IAbstractRelation> OwnedRelations { get; }

        /// <summary>
        /// Gets or sets the req i f chapter name.
        /// </summary>
        string ReqIFChapterName { get; set; }

        /// <summary>
        /// Gets or sets the req i f foreign i d.
        /// </summary>
        BigInteger? ReqIFForeignID { get; set; }

        /// <summary>
        /// Gets or sets the req i f text.
        /// </summary>
        string ReqIFText { get; set; }

        /// <summary>
        /// Gets or sets the requirement type.
        /// </summary>
        Auriga.Requirements.IRequirementType RequirementType { get; set; }

        /// <summary>
        /// Gets or sets the requirement type proxy.
        /// </summary>
        string RequirementTypeProxy { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
