// ------------------------------------------------------------------------------------------------
// <copyright file="MetaModelExtension.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint
{
    /// <summary>
    /// Represent a Meta Model extension.
    /// A meta model extension adds types, attributes and references into an existing meta model
    /// </summary>
    public partial class MetaModelExtension : Auriga.Core.AurigaElement, Auriga.Sirius.Viewpoint.IMetaModelExtension
    {
        /// <summary>
        /// The referenced meta model extension. It should be an instance of ExtensionGroup.
        /// </summary>
        public object ExtensionGroup { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
