// ------------------------------------------------------------------------------------------------
// <copyright file="PositionProvider.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Extensions
{
    using System;

    /// <summary>
    /// The purpose of the <see cref="PositionProvider"/> is to convert between the
    /// <see cref="Auriga.Diagram.Viewpoint.Description.Position"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class PositionProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Diagram.Viewpoint.Description.Position"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Diagram.Viewpoint.Description.Position"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>Position</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Diagram.Viewpoint.Description.Position Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid Position", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Diagram.Viewpoint.Description.Position"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <param name="result">
        /// when this method returns, the matching literal if the conversion succeeded, or <c>default</c>
        /// </param>
        /// <returns>true when the span was converted successfully</returns>
        /// <remarks>
        /// The comparison is <see cref="StringComparison.Ordinal"/>: EMF matches literal names
        /// case-sensitively and this stays close to it.
        /// </remarks>
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Diagram.Viewpoint.Description.Position result)
        {
            if (value.Length == 5 && value.Equals("NORTH".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.Position.NORTH;
                return true;
            }

            if (value.Length == 4 && value.Equals("WEST".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.Position.WEST;
                return true;
            }

            if (value.Length == 5 && value.Equals("SOUTH".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.Position.SOUTH;
                return true;
            }

            if (value.Length == 4 && value.Equals("EAST".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.Position.EAST;
                return true;
            }

            if (value.Length == 10 && value.Equals("NORTH_WEST".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.Position.NORTH_WEST;
                return true;
            }

            if (value.Length == 10 && value.Equals("NORTH_EAST".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.Position.NORTH_EAST;
                return true;
            }

            if (value.Length == 10 && value.Equals("SOUTH_WEST".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.Position.SOUTH_WEST;
                return true;
            }

            if (value.Length == 10 && value.Equals("SOUTH_EAST".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.Position.SOUTH_EAST;
                return true;
            }

            if (value.Length == 6 && value.Equals("CENTER".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.Position.CENTER;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Diagram.Viewpoint.Description.Position"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>Position</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToLiteralString(Auriga.Diagram.Viewpoint.Description.Position value)
        {
            return value switch
            {
                Auriga.Diagram.Viewpoint.Description.Position.NORTH => "NORTH",
                Auriga.Diagram.Viewpoint.Description.Position.WEST => "WEST",
                Auriga.Diagram.Viewpoint.Description.Position.SOUTH => "SOUTH",
                Auriga.Diagram.Viewpoint.Description.Position.EAST => "EAST",
                Auriga.Diagram.Viewpoint.Description.Position.NORTH_WEST => "NORTH_WEST",
                Auriga.Diagram.Viewpoint.Description.Position.NORTH_EAST => "NORTH_EAST",
                Auriga.Diagram.Viewpoint.Description.Position.SOUTH_WEST => "SOUTH_WEST",
                Auriga.Diagram.Viewpoint.Description.Position.SOUTH_EAST => "SOUTH_EAST",
                Auriga.Diagram.Viewpoint.Description.Position.CENTER => "CENTER",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
