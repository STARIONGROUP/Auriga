// ------------------------------------------------------------------------------------------------
// <copyright file="SystemColorsProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="SystemColorsProvider"/> is to convert between the
    /// <see cref="Auriga.Diagram.Viewpoint.Description.SystemColors"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class SystemColorsProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Diagram.Viewpoint.Description.SystemColors"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Diagram.Viewpoint.Description.SystemColors"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>SystemColors</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Diagram.Viewpoint.Description.SystemColors Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid SystemColors", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Diagram.Viewpoint.Description.SystemColors"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Diagram.Viewpoint.Description.SystemColors result)
        {
            if (value.Length == 5 && value.Equals("black".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Black;
                return true;
            }

            if (value.Length == 4 && value.Equals("blue".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Blue;
                return true;
            }

            if (value.Length == 3 && value.Equals("red".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Red;
                return true;
            }

            if (value.Length == 5 && value.Equals("green".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Green;
                return true;
            }

            if (value.Length == 6 && value.Equals("yellow".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Yellow;
                return true;
            }

            if (value.Length == 6 && value.Equals("purple".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Purple;
                return true;
            }

            if (value.Length == 6 && value.Equals("orange".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Orange;
                return true;
            }

            if (value.Length == 9 && value.Equals("chocolate".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Chocolate;
                return true;
            }

            if (value.Length == 4 && value.Equals("gray".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Gray;
                return true;
            }

            if (value.Length == 5 && value.Equals("white".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.White;
                return true;
            }

            if (value.Length == 9 && value.Equals("dark_blue".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_blue;
                return true;
            }

            if (value.Length == 8 && value.Equals("dark_red".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_red;
                return true;
            }

            if (value.Length == 10 && value.Equals("dark_green".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_green;
                return true;
            }

            if (value.Length == 11 && value.Equals("dark_yellow".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_yellow;
                return true;
            }

            if (value.Length == 11 && value.Equals("dark_purple".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_purple;
                return true;
            }

            if (value.Length == 11 && value.Equals("dark_orange".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_orange;
                return true;
            }

            if (value.Length == 14 && value.Equals("dark_chocolate".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_chocolate;
                return true;
            }

            if (value.Length == 9 && value.Equals("dark_gray".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_gray;
                return true;
            }

            if (value.Length == 10 && value.Equals("light_blue".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Light_blue;
                return true;
            }

            if (value.Length == 9 && value.Equals("light_red".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Light_red;
                return true;
            }

            if (value.Length == 11 && value.Equals("light_green".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Light_green;
                return true;
            }

            if (value.Length == 12 && value.Equals("light_yellow".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Light_yellow;
                return true;
            }

            if (value.Length == 12 && value.Equals("light_purple".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Light_purple;
                return true;
            }

            if (value.Length == 12 && value.Equals("light_orange".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Light_orange;
                return true;
            }

            if (value.Length == 15 && value.Equals("light_chocolate".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Light_chocolate;
                return true;
            }

            if (value.Length == 10 && value.Equals("light_gray".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Viewpoint.Description.SystemColors.Light_gray;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Diagram.Viewpoint.Description.SystemColors"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>SystemColors</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToLiteralString(Auriga.Diagram.Viewpoint.Description.SystemColors value)
        {
            return value switch
            {
                Auriga.Diagram.Viewpoint.Description.SystemColors.Black => "black",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Blue => "blue",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Red => "red",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Green => "green",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Yellow => "yellow",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Purple => "purple",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Orange => "orange",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Chocolate => "chocolate",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Gray => "gray",
                Auriga.Diagram.Viewpoint.Description.SystemColors.White => "white",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_blue => "dark_blue",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_red => "dark_red",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_green => "dark_green",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_yellow => "dark_yellow",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_purple => "dark_purple",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_orange => "dark_orange",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_chocolate => "dark_chocolate",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Dark_gray => "dark_gray",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Light_blue => "light_blue",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Light_red => "light_red",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Light_green => "light_green",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Light_yellow => "light_yellow",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Light_purple => "light_purple",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Light_orange => "light_orange",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Light_chocolate => "light_chocolate",
                Auriga.Diagram.Viewpoint.Description.SystemColors.Light_gray => "light_gray",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
