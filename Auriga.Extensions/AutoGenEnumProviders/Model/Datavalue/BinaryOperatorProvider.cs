// ------------------------------------------------------------------------------------------------
// <copyright file="BinaryOperatorProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="BinaryOperatorProvider"/> is to convert between the
    /// <see cref="Auriga.Model.Information.Datavalue.BinaryOperator"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class BinaryOperatorProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Model.Information.Datavalue.BinaryOperator"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Model.Information.Datavalue.BinaryOperator"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>BinaryOperator</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Model.Information.Datavalue.BinaryOperator Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid BinaryOperator", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Model.Information.Datavalue.BinaryOperator"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Model.Information.Datavalue.BinaryOperator result)
        {
            if (value.Length == 5 && value.Equals("UNSET".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Datavalue.BinaryOperator.UNSET;
                return true;
            }

            if (value.Length == 3 && value.Equals("ADD".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Datavalue.BinaryOperator.ADD;
                return true;
            }

            if (value.Length == 3 && value.Equals("MUL".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Datavalue.BinaryOperator.MUL;
                return true;
            }

            if (value.Length == 3 && value.Equals("SUB".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Datavalue.BinaryOperator.SUB;
                return true;
            }

            if (value.Length == 3 && value.Equals("DIV".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Datavalue.BinaryOperator.DIV;
                return true;
            }

            if (value.Length == 3 && value.Equals("POW".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Datavalue.BinaryOperator.POW;
                return true;
            }

            if (value.Length == 3 && value.Equals("MIN".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Datavalue.BinaryOperator.MIN;
                return true;
            }

            if (value.Length == 3 && value.Equals("MAX".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Datavalue.BinaryOperator.MAX;
                return true;
            }

            if (value.Length == 3 && value.Equals("EQU".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Datavalue.BinaryOperator.EQU;
                return true;
            }

            if (value.Length == 3 && value.Equals("IOR".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Datavalue.BinaryOperator.IOR;
                return true;
            }

            if (value.Length == 3 && value.Equals("XOR".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Datavalue.BinaryOperator.XOR;
                return true;
            }

            if (value.Length == 3 && value.Equals("AND".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Datavalue.BinaryOperator.AND;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Model.Information.Datavalue.BinaryOperator"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>BinaryOperator</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToLiteralString(Auriga.Model.Information.Datavalue.BinaryOperator value)
        {
            return value switch
            {
                Auriga.Model.Information.Datavalue.BinaryOperator.UNSET => "UNSET",
                Auriga.Model.Information.Datavalue.BinaryOperator.ADD => "ADD",
                Auriga.Model.Information.Datavalue.BinaryOperator.MUL => "MUL",
                Auriga.Model.Information.Datavalue.BinaryOperator.SUB => "SUB",
                Auriga.Model.Information.Datavalue.BinaryOperator.DIV => "DIV",
                Auriga.Model.Information.Datavalue.BinaryOperator.POW => "POW",
                Auriga.Model.Information.Datavalue.BinaryOperator.MIN => "MIN",
                Auriga.Model.Information.Datavalue.BinaryOperator.MAX => "MAX",
                Auriga.Model.Information.Datavalue.BinaryOperator.EQU => "EQU",
                Auriga.Model.Information.Datavalue.BinaryOperator.IOR => "IOR",
                Auriga.Model.Information.Datavalue.BinaryOperator.XOR => "XOR",
                Auriga.Model.Information.Datavalue.BinaryOperator.AND => "AND",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
