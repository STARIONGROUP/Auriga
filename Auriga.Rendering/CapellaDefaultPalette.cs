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
    /// plain black-on-unfilled default for anything unknown.
    /// </summary>
    public static class CapellaDefaultPalette
    {
        private static readonly Color Black = new(0, 0, 0);

        private static readonly Color FunctionGreen = new(197, 255, 166);

        private static readonly Color FunctionBorderGreen = new(77, 137, 20);

        private static readonly Color ActivityOrange = new(247, 218, 116);

        private static readonly Color ActivityBorderOrange = new(91, 64, 64);

        private static readonly Color ActorBlue = new(198, 230, 255);

        private static readonly Color ComponentBlue = new(150, 177, 218);

        private static readonly Color ComponentBorderBlue = new(74, 74, 151);

        private static readonly Color EntityGray = new(221, 221, 200);

        private static readonly Color EntityBorderGray = new(69, 69, 69);

        private static readonly Color PhysicalPortYellow = new(255, 244, 119);

        private static readonly Color ClassBorderBrown = new(123, 105, 79);

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
        public static (Color? Fill, Color Stroke) ForBox(string? semanticTypeName)
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
        public static (Color Stroke, double Width) ForEdge(string? semanticTypeName)
        {
            if (semanticTypeName != null && semanticTypeName.EndsWith("PhysicalLink", StringComparison.Ordinal))
            {
                return (Red, 2);
            }

            return (Black, 1);
        }
    }
}
