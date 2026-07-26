// ------------------------------------------------------------------------------------------------
// <copyright file="FunctionKindProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="FunctionKindProvider"/> is to convert between the
    /// <see cref="Auriga.Model.Fa.FunctionKind"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class FunctionKindProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Model.Fa.FunctionKind"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Model.Fa.FunctionKind"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>FunctionKind</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Model.Fa.FunctionKind Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid FunctionKind", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Model.Fa.FunctionKind"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Model.Fa.FunctionKind result)
        {
            if (value.Length == 8 && value.Equals("FUNCTION".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Fa.FunctionKind.FUNCTION;
                return true;
            }

            if (value.Length == 9 && value.Equals("DUPLICATE".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Fa.FunctionKind.DUPLICATE;
                return true;
            }

            if (value.Length == 6 && value.Equals("GATHER".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Fa.FunctionKind.GATHER;
                return true;
            }

            if (value.Length == 6 && value.Equals("SELECT".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Fa.FunctionKind.SELECT;
                return true;
            }

            if (value.Length == 5 && value.Equals("SPLIT".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Fa.FunctionKind.SPLIT;
                return true;
            }

            if (value.Length == 5 && value.Equals("ROUTE".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Fa.FunctionKind.ROUTE;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Model.Fa.FunctionKind"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>FunctionKind</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToLiteralString(Auriga.Model.Fa.FunctionKind value)
        {
            return value switch
            {
                Auriga.Model.Fa.FunctionKind.FUNCTION => "FUNCTION",
                Auriga.Model.Fa.FunctionKind.DUPLICATE => "DUPLICATE",
                Auriga.Model.Fa.FunctionKind.GATHER => "GATHER",
                Auriga.Model.Fa.FunctionKind.SELECT => "SELECT",
                Auriga.Model.Fa.FunctionKind.SPLIT => "SPLIT",
                Auriga.Model.Fa.FunctionKind.ROUTE => "ROUTE",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
