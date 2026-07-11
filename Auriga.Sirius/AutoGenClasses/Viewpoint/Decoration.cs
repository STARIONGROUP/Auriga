// ------------------------------------------------------------------------------------------------
// <copyright file="Decoration.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint
{
    /// <summary>
    /// Represent a decoration of a diagram element with a specific icon, based on its relationships with
    /// MetaElements of the MetaModel.
    /// </summary>
    public partial class Decoration : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.IDecoration
    {
        /// <summary>
        /// The referenced DecorationDescription.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.IDecorationDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
