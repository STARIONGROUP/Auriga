// ------------------------------------------------------------------------------------------------
// <copyright file="PhysicalComponentKindProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="PhysicalComponentKindProvider"/> is to convert between the
    /// <see cref="Auriga.Model.Pa.PhysicalComponentKind"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class PhysicalComponentKindProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Model.Pa.PhysicalComponentKind"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Model.Pa.PhysicalComponentKind"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>PhysicalComponentKind</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Model.Pa.PhysicalComponentKind Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid PhysicalComponentKind", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Model.Pa.PhysicalComponentKind"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Model.Pa.PhysicalComponentKind result)
        {
            if (value.Length == 5 && value.Equals("UNSET".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.UNSET;
                return true;
            }

            if (value.Length == 8 && value.Equals("HARDWARE".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.HARDWARE;
                return true;
            }

            if (value.Length == 17 && value.Equals("HARDWARE_COMPUTER".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.HARDWARE_COMPUTER;
                return true;
            }

            if (value.Length == 8 && value.Equals("SOFTWARE".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.SOFTWARE;
                return true;
            }

            if (value.Length == 24 && value.Equals("SOFTWARE_DEPLOYMENT_UNIT".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.SOFTWARE_DEPLOYMENT_UNIT;
                return true;
            }

            if (value.Length == 23 && value.Equals("SOFTWARE_EXECUTION_UNIT".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.SOFTWARE_EXECUTION_UNIT;
                return true;
            }

            if (value.Length == 20 && value.Equals("SOFTWARE_APPLICATION".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.SOFTWARE_APPLICATION;
                return true;
            }

            if (value.Length == 8 && value.Equals("FIRMWARE".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.FIRMWARE;
                return true;
            }

            if (value.Length == 6 && value.Equals("PERSON".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.PERSON;
                return true;
            }

            if (value.Length == 10 && value.Equals("FACILITIES".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.FACILITIES;
                return true;
            }

            if (value.Length == 4 && value.Equals("DATA".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.DATA;
                return true;
            }

            if (value.Length == 9 && value.Equals("MATERIALS".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.MATERIALS;
                return true;
            }

            if (value.Length == 8 && value.Equals("SERVICES".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.SERVICES;
                return true;
            }

            if (value.Length == 9 && value.Equals("PROCESSES".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Pa.PhysicalComponentKind.PROCESSES;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Model.Pa.PhysicalComponentKind"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>PhysicalComponentKind</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToXmlLiteral(Auriga.Model.Pa.PhysicalComponentKind value)
        {
            return value switch
            {
                Auriga.Model.Pa.PhysicalComponentKind.UNSET => "UNSET",
                Auriga.Model.Pa.PhysicalComponentKind.HARDWARE => "HARDWARE",
                Auriga.Model.Pa.PhysicalComponentKind.HARDWARE_COMPUTER => "HARDWARE_COMPUTER",
                Auriga.Model.Pa.PhysicalComponentKind.SOFTWARE => "SOFTWARE",
                Auriga.Model.Pa.PhysicalComponentKind.SOFTWARE_DEPLOYMENT_UNIT => "SOFTWARE_DEPLOYMENT_UNIT",
                Auriga.Model.Pa.PhysicalComponentKind.SOFTWARE_EXECUTION_UNIT => "SOFTWARE_EXECUTION_UNIT",
                Auriga.Model.Pa.PhysicalComponentKind.SOFTWARE_APPLICATION => "SOFTWARE_APPLICATION",
                Auriga.Model.Pa.PhysicalComponentKind.FIRMWARE => "FIRMWARE",
                Auriga.Model.Pa.PhysicalComponentKind.PERSON => "PERSON",
                Auriga.Model.Pa.PhysicalComponentKind.FACILITIES => "FACILITIES",
                Auriga.Model.Pa.PhysicalComponentKind.DATA => "DATA",
                Auriga.Model.Pa.PhysicalComponentKind.MATERIALS => "MATERIALS",
                Auriga.Model.Pa.PhysicalComponentKind.SERVICES => "SERVICES",
                Auriga.Model.Pa.PhysicalComponentKind.PROCESSES => "PROCESSES",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
