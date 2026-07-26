// ------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationItemKindProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ConfigurationItemKindProvider"/> is to convert between the
    /// <see cref="Auriga.Model.Epbs.ConfigurationItemKind"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class ConfigurationItemKindProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Model.Epbs.ConfigurationItemKind"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Model.Epbs.ConfigurationItemKind"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>ConfigurationItemKind</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Model.Epbs.ConfigurationItemKind Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid ConfigurationItemKind", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Model.Epbs.ConfigurationItemKind"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Model.Epbs.ConfigurationItemKind result)
        {
            if (value.Length == 5 && value.Equals("Unset".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Epbs.ConfigurationItemKind.Unset;
                return true;
            }

            if (value.Length == 6 && value.Equals("COTSCI".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Epbs.ConfigurationItemKind.COTSCI;
                return true;
            }

            if (value.Length == 4 && value.Equals("CSCI".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Epbs.ConfigurationItemKind.CSCI;
                return true;
            }

            if (value.Length == 4 && value.Equals("HWCI".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Epbs.ConfigurationItemKind.HWCI;
                return true;
            }

            if (value.Length == 11 && value.Equals("InterfaceCI".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Epbs.ConfigurationItemKind.InterfaceCI;
                return true;
            }

            if (value.Length == 5 && value.Equals("NDICI".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Epbs.ConfigurationItemKind.NDICI;
                return true;
            }

            if (value.Length == 11 && value.Equals("PrimeItemCI".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Epbs.ConfigurationItemKind.PrimeItemCI;
                return true;
            }

            if (value.Length == 8 && value.Equals("SystemCI".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Epbs.ConfigurationItemKind.SystemCI;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Model.Epbs.ConfigurationItemKind"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>ConfigurationItemKind</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToLiteralString(Auriga.Model.Epbs.ConfigurationItemKind value)
        {
            return value switch
            {
                Auriga.Model.Epbs.ConfigurationItemKind.Unset => "Unset",
                Auriga.Model.Epbs.ConfigurationItemKind.COTSCI => "COTSCI",
                Auriga.Model.Epbs.ConfigurationItemKind.CSCI => "CSCI",
                Auriga.Model.Epbs.ConfigurationItemKind.HWCI => "HWCI",
                Auriga.Model.Epbs.ConfigurationItemKind.InterfaceCI => "InterfaceCI",
                Auriga.Model.Epbs.ConfigurationItemKind.NDICI => "NDICI",
                Auriga.Model.Epbs.ConfigurationItemKind.PrimeItemCI => "PrimeItemCI",
                Auriga.Model.Epbs.ConfigurationItemKind.SystemCI => "SystemCI",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
