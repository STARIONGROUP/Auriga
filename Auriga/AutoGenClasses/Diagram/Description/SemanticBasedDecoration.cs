// ------------------------------------------------------------------------------------------------
// <copyright file="SemanticBasedDecoration.cs" company="Starion Group S.A.">
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
    /// A SemanticBasedDecoration applies decoration on views that targeted an element of the given type.
    /// </summary>
    public partial class SemanticBasedDecoration : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.ISemanticBasedDecoration
    {
        /// <summary>
        /// Gets or sets the distribution direction.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.DecorationDistributionDirection DistributionDirection { get; set; }

        /// <summary>
        /// The path of the icon of the decoration.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// Expression that provides the decoration as the following choices :
        /// * a path to an image in the form of /myProjectID/path/to/image.png
        /// * an expression that gives a path to an image
        /// * an expression that provides an instance of org.eclipse.swt.graphics.Image
        /// * an expression that provides an instance of org.eclipse.draw2d.IFigure
        /// </summary>
        public string ImageExpression { get; set; }

        /// <summary>
        /// The name of the decoration.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Position Position { get; set; } = Auriga.Diagram.Viewpoint.Description.Position.SOUTH_WEST;

        /// <summary>
        /// Expression that filters the elements on which we want to display the decoration.
        /// </summary>
        public string PreconditionExpression { get; set; }

        /// <summary>
        /// Expression that provides the tool-tip as the following choices :
        /// * a fixed tool-tip string
        /// * an expression that provides a tool-tip string
        /// * an expression that provides an instance of org.eclipse.draw2d.IFigure
        /// </summary>
        public string TooltipExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
