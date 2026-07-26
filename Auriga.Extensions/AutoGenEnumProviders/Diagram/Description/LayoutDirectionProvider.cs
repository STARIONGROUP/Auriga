// ------------------------------------------------------------------------------------------------
// <copyright file="LayoutDirectionProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="LayoutDirectionProvider"/> is to convert between the
    /// <see cref="Auriga.Diagram.Diagram.Description.LayoutDirection"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class LayoutDirectionProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Diagram.Diagram.Description.LayoutDirection"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Diagram.Diagram.Description.LayoutDirection"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>LayoutDirection</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Diagram.Diagram.Description.LayoutDirection Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid LayoutDirection", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Diagram.Diagram.Description.LayoutDirection"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Diagram.Diagram.Description.LayoutDirection result)
        {
            if (value.Length == 11 && value.Equals("TopToBottom".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.Description.LayoutDirection.TopToBottom;
                return true;
            }

            if (value.Length == 11 && value.Equals("LeftToRight".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.Description.LayoutDirection.LeftToRight;
                return true;
            }

            if (value.Length == 11 && value.Equals("BottomToTop".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.Description.LayoutDirection.BottomToTop;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Diagram.Diagram.Description.LayoutDirection"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>LayoutDirection</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToXmlLiteral(Auriga.Diagram.Diagram.Description.LayoutDirection value)
        {
            return value switch
            {
                Auriga.Diagram.Diagram.Description.LayoutDirection.TopToBottom => "TopToBottom",
                Auriga.Diagram.Diagram.Description.LayoutDirection.LeftToRight => "LeftToRight",
                Auriga.Diagram.Diagram.Description.LayoutDirection.BottomToTop => "BottomToTop",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
