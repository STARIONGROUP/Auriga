// ------------------------------------------------------------------------------------------------
// <copyright file="InteractionOperatorKindProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="InteractionOperatorKindProvider"/> is to convert between the
    /// <see cref="Auriga.Model.Interaction.InteractionOperatorKind"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class InteractionOperatorKindProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Model.Interaction.InteractionOperatorKind"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Model.Interaction.InteractionOperatorKind"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>InteractionOperatorKind</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Model.Interaction.InteractionOperatorKind Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid InteractionOperatorKind", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Model.Interaction.InteractionOperatorKind"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Model.Interaction.InteractionOperatorKind result)
        {
            if (value.Length == 5 && value.Equals("UNSET".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.InteractionOperatorKind.UNSET;
                return true;
            }

            if (value.Length == 3 && value.Equals("ALT".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.InteractionOperatorKind.ALT;
                return true;
            }

            if (value.Length == 3 && value.Equals("OPT".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.InteractionOperatorKind.OPT;
                return true;
            }

            if (value.Length == 3 && value.Equals("PAR".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.InteractionOperatorKind.PAR;
                return true;
            }

            if (value.Length == 4 && value.Equals("LOOP".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.InteractionOperatorKind.LOOP;
                return true;
            }

            if (value.Length == 8 && value.Equals("CRITICAL".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.InteractionOperatorKind.CRITICAL;
                return true;
            }

            if (value.Length == 3 && value.Equals("NEG".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.InteractionOperatorKind.NEG;
                return true;
            }

            if (value.Length == 6 && value.Equals("ASSERT".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.InteractionOperatorKind.ASSERT;
                return true;
            }

            if (value.Length == 6 && value.Equals("STRICT".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.InteractionOperatorKind.STRICT;
                return true;
            }

            if (value.Length == 3 && value.Equals("SEQ".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.InteractionOperatorKind.SEQ;
                return true;
            }

            if (value.Length == 6 && value.Equals("IGNORE".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.InteractionOperatorKind.IGNORE;
                return true;
            }

            if (value.Length == 8 && value.Equals("CONSIDER".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.InteractionOperatorKind.CONSIDER;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Model.Interaction.InteractionOperatorKind"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>InteractionOperatorKind</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToXmlLiteral(Auriga.Model.Interaction.InteractionOperatorKind value)
        {
            return value switch
            {
                Auriga.Model.Interaction.InteractionOperatorKind.UNSET => "UNSET",
                Auriga.Model.Interaction.InteractionOperatorKind.ALT => "ALT",
                Auriga.Model.Interaction.InteractionOperatorKind.OPT => "OPT",
                Auriga.Model.Interaction.InteractionOperatorKind.PAR => "PAR",
                Auriga.Model.Interaction.InteractionOperatorKind.LOOP => "LOOP",
                Auriga.Model.Interaction.InteractionOperatorKind.CRITICAL => "CRITICAL",
                Auriga.Model.Interaction.InteractionOperatorKind.NEG => "NEG",
                Auriga.Model.Interaction.InteractionOperatorKind.ASSERT => "ASSERT",
                Auriga.Model.Interaction.InteractionOperatorKind.STRICT => "STRICT",
                Auriga.Model.Interaction.InteractionOperatorKind.SEQ => "SEQ",
                Auriga.Model.Interaction.InteractionOperatorKind.IGNORE => "IGNORE",
                Auriga.Model.Interaction.InteractionOperatorKind.CONSIDER => "CONSIDER",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
