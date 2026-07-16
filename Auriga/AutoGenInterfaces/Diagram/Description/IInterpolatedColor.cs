// ------------------------------------------------------------------------------------------------
// <copyright file="IInterpolatedColor.cs" company="Starion Group S.A.">
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
    /// Describes a color which varies between two level color depending on the values of dynamically computed expressions.
    /// @Deprecated : Describes a color which varies between two extremes (red and green)
    /// depending on the values of dynamically computed expressions.
    /// </summary>
    public partial interface IInterpolatedColor : Auriga.Diagram.Viewpoint.Description.IColorDescription, Auriga.Diagram.Viewpoint.Description.IUserColor
    {
        /// <summary>
        /// Gets the color steps.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IColorStep> ColorSteps { get; }

        /// <summary>
        /// An expression computing the value of the color. The value of the color must be include in the scale bounds
        /// </summary>
        string ColorValueComputationExpression { get; set; }

        /// <summary>
        /// Gets or sets the max value computation expression.
        /// </summary>
        string MaxValueComputationExpression { get; set; }

        /// <summary>
        /// Gets or sets the min value computation expression.
        /// </summary>
        string MinValueComputationExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
