// ------------------------------------------------------------------------------------------------
// <copyright file="Color.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;
    using System.Globalization;

    /// <summary>
    /// An immutable RGB color. Both diagram serializations resolve into this one type: Sirius
    /// persists colors as <c>"r,g,b"</c> strings (the <c>RGBValues</c> datatype), GMF notation as a
    /// packed integer in <c>blue&lt;&lt;16 | green&lt;&lt;8 | red</c> order (the encoding of GMF's
    /// <c>FigureUtilities</c>).
    /// </summary>
    public readonly struct Color : IEquatable<Color>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="red">the red component</param>
        /// <param name="green">the green component</param>
        /// <param name="blue">the blue component</param>
        public Color(byte red, byte green, byte blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        /// <summary>
        /// Gets the red component.
        /// </summary>
        public byte Red { get; }

        /// <summary>
        /// Gets the green component.
        /// </summary>
        public byte Green { get; }

        /// <summary>
        /// Gets the blue component.
        /// </summary>
        public byte Blue { get; }

        /// <summary>
        /// Parses a Sirius <c>RGBValues</c> string of the form <c>"r,g,b"</c>.
        /// </summary>
        /// <param name="rgbValues">the raw persisted value</param>
        /// <param name="color">the parsed color, or default when parsing fails</param>
        /// <returns>true when the value parsed</returns>
        public static bool TryParse(string? rgbValues, out Color color)
        {
            color = default;

            if (string.IsNullOrEmpty(rgbValues))
            {
                return false;
            }

            var parts = rgbValues!.Split(',');
            if (parts.Length == 3
                && byte.TryParse(parts[0].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var red)
                && byte.TryParse(parts[1].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var green)
                && byte.TryParse(parts[2].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var blue))
            {
                color = new Color(red, green, blue);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Decodes a GMF notation packed color integer: red in the low byte, green in the middle,
        /// blue in the high byte (the order GMF's <c>FigureUtilities.integerToColor</c> uses).
        /// </summary>
        /// <param name="packed">the packed color</param>
        /// <returns>the decoded color</returns>
        public static Color FromNotationColor(int packed)
        {
            return new Color((byte)(packed & 0xFF), (byte)((packed >> 8) & 0xFF), (byte)((packed >> 16) & 0xFF));
        }

        /// <summary>
        /// The <c>#RRGGBB</c> hexadecimal representation.
        /// </summary>
        /// <returns>the hexadecimal representation</returns>
        public string ToHex()
        {
            return string.Format(CultureInfo.InvariantCulture, "#{0:X2}{1:X2}{2:X2}", this.Red, this.Green, this.Blue);
        }

        /// <summary>
        /// Whether the two colors are equal.
        /// </summary>
        /// <param name="left">the left color</param>
        /// <param name="right">the right color</param>
        /// <returns>true when the colors are equal</returns>
        public static bool operator ==(Color left, Color right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Whether the two colors differ.
        /// </summary>
        /// <param name="left">the left color</param>
        /// <param name="right">the right color</param>
        /// <returns>true when the colors differ</returns>
        public static bool operator !=(Color left, Color right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Whether this color equals the other color.
        /// </summary>
        /// <param name="other">the color to compare with</param>
        /// <returns>true when all components are equal</returns>
        public bool Equals(Color other)
        {
            return this.Red == other.Red && this.Green == other.Green && this.Blue == other.Blue;
        }

        /// <summary>
        /// Whether this color equals the supplied object.
        /// </summary>
        /// <param name="obj">the object to compare with</param>
        /// <returns>true when the object is an equal <see cref="Color"/></returns>
        public override bool Equals(object? obj)
        {
            return obj is Color other && this.Equals(other);
        }

        /// <summary>
        /// The hash code combining the components.
        /// </summary>
        /// <returns>the hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Red, this.Green, this.Blue);
        }

        /// <summary>
        /// The <c>#RRGGBB</c> representation.
        /// </summary>
        /// <returns>the textual representation</returns>
        public override string ToString()
        {
            return this.ToHex();
        }
    }
}
