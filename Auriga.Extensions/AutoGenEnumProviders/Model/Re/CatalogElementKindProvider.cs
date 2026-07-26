// ------------------------------------------------------------------------------------------------
// <copyright file="CatalogElementKindProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="CatalogElementKindProvider"/> is to convert between the
    /// <see cref="Auriga.Model.Re.CatalogElementKind"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class CatalogElementKindProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Model.Re.CatalogElementKind"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Model.Re.CatalogElementKind"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>CatalogElementKind</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Model.Re.CatalogElementKind Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid CatalogElementKind", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Model.Re.CatalogElementKind"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Model.Re.CatalogElementKind result)
        {
            if (value.Length == 3 && value.Equals("REC".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Re.CatalogElementKind.REC;
                return true;
            }

            if (value.Length == 3 && value.Equals("RPL".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Re.CatalogElementKind.RPL;
                return true;
            }

            if (value.Length == 7 && value.Equals("REC_RPL".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Re.CatalogElementKind.REC_RPL;
                return true;
            }

            if (value.Length == 8 && value.Equals("GROUPING".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Re.CatalogElementKind.GROUPING;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Model.Re.CatalogElementKind"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>CatalogElementKind</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToXmlLiteral(Auriga.Model.Re.CatalogElementKind value)
        {
            return value switch
            {
                Auriga.Model.Re.CatalogElementKind.REC => "REC",
                Auriga.Model.Re.CatalogElementKind.RPL => "RPL",
                Auriga.Model.Re.CatalogElementKind.REC_RPL => "REC_RPL",
                Auriga.Model.Re.CatalogElementKind.GROUPING => "GROUPING",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
