// ------------------------------------------------------------------------------------------------
// <copyright file="IFeatureColumnMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Table.Description
{
    /// <summary>
    /// Definition of the <c>FeatureColumnMapping</c> interface.
    /// </summary>
    public partial interface IFeatureColumnMapping : Auriga.Sirius.Table.Description.IColumnMapping, Auriga.Sirius.Table.Description.ICellUpdater, Auriga.Sirius.Table.Description.IStyleUpdater
    {
        /// <summary>
        /// Gets or sets the feature name.
        /// </summary>
        string FeatureName { get; set; }

        /// <summary>
        /// An expression to get the parent of the feature. By default, the parent of the feature is the semantic element of the line.
        /// </summary>
        string FeatureParentExpression { get; set; }

        /// <summary>
        /// Gets or sets the label expression.
        /// </summary>
        string LabelExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
