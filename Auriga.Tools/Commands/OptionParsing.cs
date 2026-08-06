// ------------------------------------------------------------------------------------------------
// <copyright file="OptionParsing.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Commands
{
    using System;
    using System.Globalization;

    using Auriga.Reporting.Generators;

    using ModelColor = Auriga.Reporting.Model.Color;

    /// <summary>
    /// Turns the free-text option values into the types the generator takes. Kept apart from the
    /// commands because these are the two places a user can be wrong in a way worth explaining,
    /// and because they are worth testing without a command line.
    /// </summary>
    internal static class OptionParsing
    {
        /// <summary>
        /// The formats a comma-separated list names.
        /// </summary>
        /// <param name="value">the list, as in <c>svg,png</c></param>
        /// <returns>the formats</returns>
        /// <exception cref="ArgumentException">the list names an unknown format, or none at all</exception>
        public static DiagramFormats Formats(string? value)
        {
            var formats = DiagramFormats.None;

            foreach (var token in (value ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                formats |= token.ToLowerInvariant() switch
                {
                    "svg" => DiagramFormats.Svg,
                    "png" => DiagramFormats.Png,
                    "jpg" or "jpeg" => DiagramFormats.Jpeg,
                    "xlsx" or "excel" => DiagramFormats.Xlsx,
                    _ => throw new ArgumentException($"'{token}' is not a format this tool writes. Choose from svg, png, jpeg and xlsx."),
                };
            }

            if (formats == DiagramFormats.None)
            {
                throw new ArgumentException("No format was given, so there would be nothing to write.");
            }

            return formats;
        }

        /// <summary>
        /// The colour a <c>#RRGGBB</c> or <c>r,g,b</c> value names.
        /// </summary>
        /// <param name="value">the value</param>
        /// <returns>the colour</returns>
        /// <exception cref="ArgumentException">the value names no colour</exception>
        public static ModelColor Colour(string value)
        {
            var text = (value ?? string.Empty).Trim();

            if (text.Length == 7 && text[0] == '#'
                && byte.TryParse(text.AsSpan(1, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var red)
                && byte.TryParse(text.AsSpan(3, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var green)
                && byte.TryParse(text.AsSpan(5, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var blue))
            {
                return new ModelColor(red, green, blue);
            }

            if (ModelColor.TryParse(text, out var parsed))
            {
                return parsed;
            }

            throw new ArgumentException($"'{value}' is not a colour. Write it as #RRGGBB or as r,g,b.");
        }
    }
}
