// ------------------------------------------------------------------------------------------------
// <copyright file="EdgeArrowsProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="EdgeArrowsProvider"/> is to convert between the
    /// <see cref="Auriga.Diagram.Diagram.EdgeArrows"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class EdgeArrowsProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Diagram.Diagram.EdgeArrows"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Diagram.Diagram.EdgeArrows"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>EdgeArrows</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Diagram.Diagram.EdgeArrows Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid EdgeArrows", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Diagram.Diagram.EdgeArrows"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Diagram.Diagram.EdgeArrows result)
        {
            if (value.Length == 12 && value.Equals("NoDecoration".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.NoDecoration;
                return true;
            }

            if (value.Length == 11 && value.Equals("OutputArrow".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.OutputArrow;
                return true;
            }

            if (value.Length == 10 && value.Equals("InputArrow".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.InputArrow;
                return true;
            }

            if (value.Length == 17 && value.Equals("OutputClosedArrow".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.OutputClosedArrow;
                return true;
            }

            if (value.Length == 16 && value.Equals("InputClosedArrow".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.InputClosedArrow;
                return true;
            }

            if (value.Length == 21 && value.Equals("OutputFillClosedArrow".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.OutputFillClosedArrow;
                return true;
            }

            if (value.Length == 20 && value.Equals("InputFillClosedArrow".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.InputFillClosedArrow;
                return true;
            }

            if (value.Length == 7 && value.Equals("Diamond".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.Diamond;
                return true;
            }

            if (value.Length == 11 && value.Equals("FillDiamond".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.FillDiamond;
                return true;
            }

            if (value.Length == 21 && value.Equals("InputArrowWithDiamond".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.InputArrowWithDiamond;
                return true;
            }

            if (value.Length == 25 && value.Equals("InputArrowWithFillDiamond".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.InputArrowWithFillDiamond;
                return true;
            }

            if (value.Length == 10 && value.Equals("CirclePlus".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.CirclePlus;
                return true;
            }

            if (value.Length == 3 && value.Equals("Dot".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.Dot;
                return true;
            }

            if (value.Length == 17 && value.Equals("InputArrowWithDot".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.InputArrowWithDot;
                return true;
            }

            if (value.Length == 14 && value.Equals("DiamondWithDot".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.DiamondWithDot;
                return true;
            }

            if (value.Length == 18 && value.Equals("FillDiamondWithDot".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.FillDiamondWithDot;
                return true;
            }

            if (value.Length == 27 && value.Equals("InputArrowWithDiamondAndDot".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.InputArrowWithDiamondAndDot;
                return true;
            }

            if (value.Length == 31 && value.Equals("InputArrowWithFillDiamondAndDot".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Diagram.Diagram.EdgeArrows.InputArrowWithFillDiamondAndDot;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Diagram.Diagram.EdgeArrows"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>EdgeArrows</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToXmlLiteral(Auriga.Diagram.Diagram.EdgeArrows value)
        {
            return value switch
            {
                Auriga.Diagram.Diagram.EdgeArrows.NoDecoration => "NoDecoration",
                Auriga.Diagram.Diagram.EdgeArrows.OutputArrow => "OutputArrow",
                Auriga.Diagram.Diagram.EdgeArrows.InputArrow => "InputArrow",
                Auriga.Diagram.Diagram.EdgeArrows.OutputClosedArrow => "OutputClosedArrow",
                Auriga.Diagram.Diagram.EdgeArrows.InputClosedArrow => "InputClosedArrow",
                Auriga.Diagram.Diagram.EdgeArrows.OutputFillClosedArrow => "OutputFillClosedArrow",
                Auriga.Diagram.Diagram.EdgeArrows.InputFillClosedArrow => "InputFillClosedArrow",
                Auriga.Diagram.Diagram.EdgeArrows.Diamond => "Diamond",
                Auriga.Diagram.Diagram.EdgeArrows.FillDiamond => "FillDiamond",
                Auriga.Diagram.Diagram.EdgeArrows.InputArrowWithDiamond => "InputArrowWithDiamond",
                Auriga.Diagram.Diagram.EdgeArrows.InputArrowWithFillDiamond => "InputArrowWithFillDiamond",
                Auriga.Diagram.Diagram.EdgeArrows.CirclePlus => "CirclePlus",
                Auriga.Diagram.Diagram.EdgeArrows.Dot => "Dot",
                Auriga.Diagram.Diagram.EdgeArrows.InputArrowWithDot => "InputArrowWithDot",
                Auriga.Diagram.Diagram.EdgeArrows.DiamondWithDot => "DiamondWithDot",
                Auriga.Diagram.Diagram.EdgeArrows.FillDiamondWithDot => "FillDiamondWithDot",
                Auriga.Diagram.Diagram.EdgeArrows.InputArrowWithDiamondAndDot => "InputArrowWithDiamondAndDot",
                Auriga.Diagram.Diagram.EdgeArrows.InputArrowWithFillDiamondAndDot => "InputArrowWithFillDiamondAndDot",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
