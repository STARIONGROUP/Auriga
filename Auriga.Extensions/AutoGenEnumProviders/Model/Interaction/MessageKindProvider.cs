// ------------------------------------------------------------------------------------------------
// <copyright file="MessageKindProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="MessageKindProvider"/> is to convert between the
    /// <see cref="Auriga.Model.Interaction.MessageKind"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class MessageKindProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Model.Interaction.MessageKind"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Model.Interaction.MessageKind"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>MessageKind</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Model.Interaction.MessageKind Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid MessageKind", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Model.Interaction.MessageKind"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Model.Interaction.MessageKind result)
        {
            if (value.Length == 5 && value.Equals("UNSET".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.MessageKind.UNSET;
                return true;
            }

            if (value.Length == 17 && value.Equals("ASYNCHRONOUS_CALL".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.MessageKind.ASYNCHRONOUS_CALL;
                return true;
            }

            if (value.Length == 16 && value.Equals("SYNCHRONOUS_CALL".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.MessageKind.SYNCHRONOUS_CALL;
                return true;
            }

            if (value.Length == 5 && value.Equals("REPLY".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.MessageKind.REPLY;
                return true;
            }

            if (value.Length == 6 && value.Equals("DELETE".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.MessageKind.DELETE;
                return true;
            }

            if (value.Length == 6 && value.Equals("CREATE".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.MessageKind.CREATE;
                return true;
            }

            if (value.Length == 5 && value.Equals("TIMER".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Interaction.MessageKind.TIMER;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Model.Interaction.MessageKind"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>MessageKind</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToXmlLiteral(Auriga.Model.Interaction.MessageKind value)
        {
            return value switch
            {
                Auriga.Model.Interaction.MessageKind.UNSET => "UNSET",
                Auriga.Model.Interaction.MessageKind.ASYNCHRONOUS_CALL => "ASYNCHRONOUS_CALL",
                Auriga.Model.Interaction.MessageKind.SYNCHRONOUS_CALL => "SYNCHRONOUS_CALL",
                Auriga.Model.Interaction.MessageKind.REPLY => "REPLY",
                Auriga.Model.Interaction.MessageKind.DELETE => "DELETE",
                Auriga.Model.Interaction.MessageKind.CREATE => "CREATE",
                Auriga.Model.Interaction.MessageKind.TIMER => "TIMER",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
