// ------------------------------------------------------------------------------------------------
// <copyright file="IDecorationDescription.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DecorationDescription</c> interface.
    /// </summary>
    public partial interface IDecorationDescription : Auriga.IAurigaElement
    {
        /// <summary>
        /// Gets or sets the distribution direction.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.DecorationDistributionDirection DistributionDirection { get; set; }

        /// <summary>
        /// Expression that provides the decoration as the following choices :
        /// * a path to an image in the form of /myProjectID/path/to/image.png
        /// * an expression that gives a path to an image
        /// * an expression that provides an instance of org.eclipse.swt.graphics.Image
        /// * an expression that provides an instance of org.eclipse.draw2d.IFigure
        /// </summary>
        string ImageExpression { get; set; }

        /// <summary>
        /// The name of the decoration.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Position Position { get; set; }

        /// <summary>
        /// Expression that filters the elements on which we want to display the decoration.
        /// </summary>
        string PreconditionExpression { get; set; }

        /// <summary>
        /// Expression that provides the tool-tip as the following choices :
        /// * a fixed tool-tip string
        /// * an expression that provides a tool-tip string
        /// * an expression that provides an instance of org.eclipse.draw2d.IFigure
        /// </summary>
        string TooltipExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
