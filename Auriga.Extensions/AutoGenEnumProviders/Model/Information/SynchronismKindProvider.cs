// ------------------------------------------------------------------------------------------------
// <copyright file="SynchronismKindProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="SynchronismKindProvider"/> is to convert between the
    /// <see cref="Auriga.Model.Information.SynchronismKind"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class SynchronismKindProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Model.Information.SynchronismKind"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Model.Information.SynchronismKind"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>SynchronismKind</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Model.Information.SynchronismKind Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid SynchronismKind", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Model.Information.SynchronismKind"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Model.Information.SynchronismKind result)
        {
            if (value.Length == 5 && value.Equals("UNSET".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.SynchronismKind.UNSET;
                return true;
            }

            if (value.Length == 11 && value.Equals("SYNCHRONOUS".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.SynchronismKind.SYNCHRONOUS;
                return true;
            }

            if (value.Length == 12 && value.Equals("ASYNCHRONOUS".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.SynchronismKind.ASYNCHRONOUS;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Model.Information.SynchronismKind"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>SynchronismKind</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToLiteralString(Auriga.Model.Information.SynchronismKind value)
        {
            return value switch
            {
                Auriga.Model.Information.SynchronismKind.UNSET => "UNSET",
                Auriga.Model.Information.SynchronismKind.SYNCHRONOUS => "SYNCHRONOUS",
                Auriga.Model.Information.SynchronismKind.ASYNCHRONOUS => "ASYNCHRONOUS",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
