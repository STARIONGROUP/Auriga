// ------------------------------------------------------------------------------------------------
// <copyright file="IBundledImage.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram
{
    /// <summary>
    /// The bundled image style allows to use the default images provide by the ViewPoint editor.
    /// </summary>
    public partial interface IBundledImage : Auriga.Sirius.Diagram.INodeStyle
    {
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        string Color { get; set; }

        /// <summary>
        /// Gets or sets the provided shape i d.
        /// </summary>
        string ProvidedShapeID { get; set; }

        /// <summary>
        /// The shape to use.
        /// </summary>
        Auriga.Sirius.Diagram.BundledImageShape Shape { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
