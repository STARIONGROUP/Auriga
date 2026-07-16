// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractType.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Modellingcore
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>AbstractType</c> interface.
    /// </summary>
    public partial interface IAbstractType : Auriga.Model.Modellingcore.IAbstractNamedElement
    {
        /// <summary>
        /// Gets the abstract typed elements.
        /// </summary>
        IEnumerable<Auriga.Model.Modellingcore.IAbstractTypedElement> AbstractTypedElements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
