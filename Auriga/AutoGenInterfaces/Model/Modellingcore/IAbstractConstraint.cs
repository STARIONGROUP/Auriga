// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractConstraint.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// Definition of the <c>AbstractConstraint</c> interface.
    /// </summary>
    public partial interface IAbstractConstraint : Auriga.Model.Modellingcore.IModelElement
    {
        /// <summary>
        /// Gets the constrained elements.
        /// </summary>
        List<Auriga.Model.Modellingcore.IModelElement> ConstrainedElements { get; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        Auriga.Model.Modellingcore.IModelElement Context { get; }

        /// <summary>
        /// Gets or sets the owned specification.
        /// </summary>
        Auriga.Model.Modellingcore.IValueSpecification OwnedSpecification { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
