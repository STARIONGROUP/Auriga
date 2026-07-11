// ------------------------------------------------------------------------------------------------
// <copyright file="InterpolatedColor.cs" company="Starion Group S.A.">
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
    /// Describes a color which varies between two level color depending on the values of dynamically computed expressions.
    /// @Deprecated : Describes a color which varies between two extremes (red and green)
    /// depending on the values of dynamically computed expressions.
    /// </summary>
    public partial class InterpolatedColor : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.IInterpolatedColor
    {
        /// <summary>
        /// Gets the color steps.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IColorStep> ColorSteps => this.backingColorSteps ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.IColorStep>(this);

        /// <summary>
        /// Backing field for <see cref="ColorSteps"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.IColorStep> backingColorSteps;

        /// <summary>
        /// An expression computing the value of the color. The value of the color must be include in the scale bounds
        /// </summary>
        public string ColorValueComputationExpression { get; set; }

        /// <summary>
        /// Gets or sets the max value computation expression.
        /// </summary>
        public string MaxValueComputationExpression { get; set; }

        /// <summary>
        /// Gets or sets the min value computation expression.
        /// </summary>
        public string MinValueComputationExpression { get; set; }

        /// <summary>
        /// The name of the color description, as shown to the user in color palettes.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>InterpolatedColor</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.ColorSteps)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
