// ------------------------------------------------------------------------------------------------
// <copyright file="BackgroundStyleProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="BackgroundStyleProvider"/> is to convert between the
    /// <see cref="Auriga.Diagram.Diagram.BackgroundStyle"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class BackgroundStyleProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Diagram.Diagram.BackgroundStyle"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Diagram.Diagram.BackgroundStyle"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>BackgroundStyle</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Diagram.Diagram.BackgroundStyle Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid BackgroundStyle", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Diagram.Diagram.BackgroundStyle"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Diagram.Diagram.BackgroundStyle result)
        {
            if (value.Length == 19 && value.Equals("GradientLeftToRight".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.BackgroundStyle.GradientLeftToRight;
                return true;
            }

            if (value.Length == 6 && value.Equals("Liquid".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.BackgroundStyle.Liquid;
                return true;
            }

            if (value.Length == 19 && value.Equals("GradientTopToBottom".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.BackgroundStyle.GradientTopToBottom;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Diagram.Diagram.BackgroundStyle"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>BackgroundStyle</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToLiteralString(Auriga.Diagram.Diagram.BackgroundStyle value)
        {
            return value switch
            {
                Auriga.Diagram.Diagram.BackgroundStyle.GradientLeftToRight => "GradientLeftToRight",
                Auriga.Diagram.Diagram.BackgroundStyle.Liquid => "Liquid",
                Auriga.Diagram.Diagram.BackgroundStyle.GradientTopToBottom => "GradientTopToBottom",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
