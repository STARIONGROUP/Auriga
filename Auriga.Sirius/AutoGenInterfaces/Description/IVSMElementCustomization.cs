// ------------------------------------------------------------------------------------------------
// <copyright file="IVSMElementCustomization.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description
{
    /// <summary>
    /// Definition of the <c>VSMElementCustomization</c> interface.
    /// </summary>
    public partial interface IVSMElementCustomization : Auriga.Sirius.Viewpoint.Description.IIVSMElementCustomization
    {
        /// <summary>
        /// Gets the feature customizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.IEStructuralFeatureCustomization> FeatureCustomizations { get; }

        /// <summary>
        /// Gets or sets the predicate expression.
        /// </summary>
        string PredicateExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
