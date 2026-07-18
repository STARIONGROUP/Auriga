// ------------------------------------------------------------------------------------------------
// <copyright file="CapellaDefaultPalette.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Capella default colors, applied when an item carries no persisted style values. The
    /// values are the "migration palette" of Capella's <c>common.odesign</c>, as catalogued by
    /// py-capellambse's <c>diagram/capstyle.py</c> (Apache-2.0) — the same fills and borders
    /// Capella itself applies to a freshly created element. Lookup is by the Capella semantic
    /// element's type name (e.g. <c>LogicalComponent</c>, <c>SystemFunction</c>), with suffix
    /// matching so every Arcadia layer's variant of a concept shares its family color, and a
    /// plain black-on-unfilled default for anything unknown. Stateless: register it in the
    /// application's container as the <see cref="ICapellaDefaultPalette"/>, or construct it
    /// directly.
    /// </summary>
    public sealed class CapellaDefaultPalette : ICapellaDefaultPalette
    {
        /// <summary>
        /// The global default stroke and font color (<c>black</c>).
        /// </summary>
        private static readonly Color Black = new(0, 0, 0);

        /// <summary>
        /// The function fill (<c>_CAP_xDFB_Function_Green</c>), shared by every Arcadia layer's
        /// function concept.
        /// </summary>
        private static readonly Color FunctionGreen = new(197, 255, 166);

        /// <summary>
        /// The function border (<c>_CAP_xDFB_Function_Border_Green</c>).
        /// </summary>
        private static readonly Color FunctionBorderGreen = new(77, 137, 20);

        /// <summary>
        /// The operational-activity fill (<c>_CAP_Activity_Orange</c>).
        /// </summary>
        private static readonly Color ActivityOrange = new(247, 218, 116);

        /// <summary>
        /// The operational-activity border (<c>_CAP_Activity_Border_Orange</c>).
        /// </summary>
        private static readonly Color ActivityBorderOrange = new(91, 64, 64);

        /// <summary>
        /// The actor fill (<c>_CAP_Actor_Blue</c>).
        /// </summary>
        private static readonly Color ActorBlue = new(198, 230, 255);

        /// <summary>
        /// The component fill (<c>_CAP_Component_Blue</c>), shared by components and parts.
        /// </summary>
        private static readonly Color ComponentBlue = new(150, 177, 218);

        /// <summary>
        /// The component and actor border (<c>_CAP_Component_Border_Blue</c> /
        /// <c>_CAP_Actor_Border_Blue</c> — the same value in the Capella palette).
        /// </summary>
        private static readonly Color ComponentBorderBlue = new(74, 74, 151);

        /// <summary>
        /// The operational-entity fill (<c>_CAP_Entity_Gray</c>).
        /// </summary>
        private static readonly Color EntityGray = new(221, 221, 200);

        /// <summary>
        /// The operational-entity border (<c>_CAP_Entity_Gray_border</c>).
        /// </summary>
        private static readonly Color EntityBorderGray = new(69, 69, 69);

        /// <summary>
        /// The physical-port fill (<c>_CAP_PhysicalPort_Yellow</c>).
        /// </summary>
        private static readonly Color PhysicalPortYellow = new(255, 244, 119);

        /// <summary>
        /// The brown border of class-like boxes, reused for physical ports
        /// (<c>_CAP_Class_Border_Brown</c>).
        /// </summary>
        private static readonly Color ClassBorderBrown = new(123, 105, 79);

        /// <summary>
        /// The physical-link stroke (the Capella system palette's <c>red</c>).
        /// </summary>
        private static readonly Color Red = new(239, 41, 41);

        /// <summary>
        /// The box defaults per semantic type-name suffix, in match order: the first suffix the
        /// type name ends with wins.
        /// </summary>
        private static readonly List<(string Suffix, Color Fill, Color Stroke)> BoxDefaults = new()
        {
            ("OperationalActivity", ActivityOrange, ActivityBorderOrange),
            ("Function", FunctionGreen, FunctionBorderGreen),
            ("Actor", ActorBlue, ComponentBorderBlue),
            ("OperationalEntity", EntityGray, EntityBorderGray),
            ("Entity", EntityGray, EntityBorderGray),
            ("Component", ComponentBlue, ComponentBorderBlue),
            ("Part", ComponentBlue, ComponentBorderBlue),
            ("PhysicalPort", PhysicalPortYellow, ClassBorderBrown),
        };

        /// <summary>
        /// The default visual properties of a box representing the supplied semantic type: the
        /// Capella family fill/border when the type is recognized, an unfilled black-bordered box
        /// otherwise (Capella's global box default).
        /// </summary>
        /// <param name="semanticTypeName">the Capella semantic element's type name, or <c>null</c></param>
        /// <returns>the default fill (or <c>null</c> for none) and stroke</returns>
        public (Color? Fill, Color Stroke) ForBox(string? semanticTypeName)
        {
            if (!string.IsNullOrEmpty(semanticTypeName))
            {
                foreach (var (suffix, fill, stroke) in BoxDefaults)
                {
                    if (semanticTypeName!.EndsWith(suffix, StringComparison.Ordinal))
                    {
                        return (fill, stroke);
                    }
                }
            }

            return (null, Black);
        }

        /// <summary>
        /// The default visual properties of an edge representing the supplied semantic type: red
        /// double-width for a <c>PhysicalLink</c>, the plain black hairline otherwise (Capella's
        /// global edge default).
        /// </summary>
        /// <param name="semanticTypeName">the Capella semantic element's type name, or <c>null</c></param>
        /// <returns>the default stroke and stroke width</returns>
        public (Color Stroke, double Width) ForEdge(string? semanticTypeName)
        {
            if (semanticTypeName != null && semanticTypeName.EndsWith("PhysicalLink", StringComparison.Ordinal))
            {
                return (Red, 2);
            }

            return (Black, 1);
        }
    }
}
