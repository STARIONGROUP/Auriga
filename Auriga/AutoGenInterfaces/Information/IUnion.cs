// ------------------------------------------------------------------------------------------------
// <copyright file="IUnion.cs" company="Starion Group S.A.">
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

namespace Auriga.Information
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Union</c> interface.
    /// </summary>
    public partial interface IUnion : Auriga.Information.IClass
    {
        /// <summary>
        /// Gets the contained union properties.
        /// </summary>
        IEnumerable<Auriga.Information.IUnionProperty> ContainedUnionProperties { get; }

        /// <summary>
        /// Gets or sets the default property.
        /// </summary>
        Auriga.Information.IUnionProperty DefaultProperty { get; set; }

        /// <summary>
        /// Gets or sets the discriminant.
        /// </summary>
        Auriga.Information.IUnionProperty Discriminant { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Information.UnionKind? Kind { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
