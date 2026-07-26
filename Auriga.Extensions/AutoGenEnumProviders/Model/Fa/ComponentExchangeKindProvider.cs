// ------------------------------------------------------------------------------------------------
// <copyright file="ComponentExchangeKindProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ComponentExchangeKindProvider"/> is to convert between the
    /// <see cref="Auriga.Model.Fa.ComponentExchangeKind"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class ComponentExchangeKindProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Model.Fa.ComponentExchangeKind"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Model.Fa.ComponentExchangeKind"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>ComponentExchangeKind</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Model.Fa.ComponentExchangeKind Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid ComponentExchangeKind", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Model.Fa.ComponentExchangeKind"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Model.Fa.ComponentExchangeKind result)
        {
            if (value.Length == 5 && value.Equals("UNSET".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Fa.ComponentExchangeKind.UNSET;
                return true;
            }

            if (value.Length == 10 && value.Equals("DELEGATION".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Fa.ComponentExchangeKind.DELEGATION;
                return true;
            }

            if (value.Length == 8 && value.Equals("ASSEMBLY".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Fa.ComponentExchangeKind.ASSEMBLY;
                return true;
            }

            if (value.Length == 4 && value.Equals("FLOW".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Fa.ComponentExchangeKind.FLOW;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Model.Fa.ComponentExchangeKind"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>ComponentExchangeKind</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToXmlLiteral(Auriga.Model.Fa.ComponentExchangeKind value)
        {
            return value switch
            {
                Auriga.Model.Fa.ComponentExchangeKind.UNSET => "UNSET",
                Auriga.Model.Fa.ComponentExchangeKind.DELEGATION => "DELEGATION",
                Auriga.Model.Fa.ComponentExchangeKind.ASSEMBLY => "ASSEMBLY",
                Auriga.Model.Fa.ComponentExchangeKind.FLOW => "FLOW",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
