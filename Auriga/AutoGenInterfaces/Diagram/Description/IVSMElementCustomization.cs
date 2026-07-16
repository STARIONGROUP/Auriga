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

namespace Auriga.Diagram.Viewpoint.Description
{
    /// <summary>
    /// Definition of the <c>VSMElementCustomization</c> interface.
    /// </summary>
    public partial interface IVSMElementCustomization : Auriga.Diagram.Viewpoint.Description.IIVSMElementCustomization
    {
        /// <summary>
        /// Gets the feature customizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IEStructuralFeatureCustomization> FeatureCustomizations { get; }

        /// <summary>
        /// Gets or sets the predicate expression.
        /// </summary>
        string PredicateExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
