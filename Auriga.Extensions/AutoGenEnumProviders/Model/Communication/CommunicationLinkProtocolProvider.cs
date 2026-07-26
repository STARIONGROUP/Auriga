// ------------------------------------------------------------------------------------------------
// <copyright file="CommunicationLinkProtocolProvider.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="CommunicationLinkProtocolProvider"/> is to convert between the
    /// <see cref="Auriga.Model.Information.Communication.CommunicationLinkProtocol"/> enumeration and the literal names the Ecore metamodel
    /// declares, which are what a Capella or Sirius document carries.
    /// </summary>
    /// <remarks>
    /// The C# member names are capitalized to be legal, conventional identifiers, so they do not always
    /// reproduce the Ecore literal (Sirius declares <c>italic</c>, generated as <c>Italic</c>). EMF matches
    /// literal names case-sensitively, so both directions go through this provider rather than through
    /// <see cref="Enum.Parse(Type, string)"/> or <see cref="object.ToString"/>.
    /// </remarks>
    public static class CommunicationLinkProtocolProvider
    {
        /// <summary>
        /// Parses the supplied span into a <see cref="Auriga.Model.Information.Communication.CommunicationLinkProtocol"/>.
        /// </summary>
        /// <param name="value">the Ecore literal name to parse</param>
        /// <returns>the matching <see cref="Auriga.Model.Information.Communication.CommunicationLinkProtocol"/> literal</returns>
        /// <exception cref="ArgumentException">
        /// thrown when the span is not a valid <c>CommunicationLinkProtocol</c> literal
        /// </exception>
        /// <remarks>
        /// Zero allocations, no boxing, fast short-circuit evaluation, JIT friendly.
        /// </remarks>
        public static Auriga.Model.Information.Communication.CommunicationLinkProtocol Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"'{new string(value)}' is not a valid CommunicationLinkProtocol", nameof(value));
        }

        /// <summary>
        /// Tries to parse the supplied span into a <see cref="Auriga.Model.Information.Communication.CommunicationLinkProtocol"/>.
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
        public static bool TryParse(ReadOnlySpan<char> value, out Auriga.Model.Information.Communication.CommunicationLinkProtocol result)
        {
            if (value.Length == 5 && value.Equals("UNSET".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Communication.CommunicationLinkProtocol.UNSET;
                return true;
            }

            if (value.Length == 7 && value.Equals("UNICAST".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Communication.CommunicationLinkProtocol.UNICAST;
                return true;
            }

            if (value.Length == 9 && value.Equals("MULTICAST".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Communication.CommunicationLinkProtocol.MULTICAST;
                return true;
            }

            if (value.Length == 9 && value.Equals("BROADCAST".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Communication.CommunicationLinkProtocol.BROADCAST;
                return true;
            }

            if (value.Length == 11 && value.Equals("SYNCHRONOUS".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Communication.CommunicationLinkProtocol.SYNCHRONOUS;
                return true;
            }

            if (value.Length == 12 && value.Equals("ASYNCHRONOUS".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Communication.CommunicationLinkProtocol.ASYNCHRONOUS;
                return true;
            }

            if (value.Length == 4 && value.Equals("READ".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Communication.CommunicationLinkProtocol.READ;
                return true;
            }

            if (value.Length == 6 && value.Equals("ACCEPT".AsSpan(), StringComparison.Ordinal))
            {
                result = Auriga.Model.Information.Communication.CommunicationLinkProtocol.ACCEPT;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// The Ecore literal name of the supplied <see cref="Auriga.Model.Information.Communication.CommunicationLinkProtocol"/>, as it must be
        /// written to a Capella or Sirius document.
        /// </summary>
        /// <param name="value">the enumeration literal</param>
        /// <returns>the Ecore literal name</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// thrown when the value is not a defined <c>CommunicationLinkProtocol</c> literal
        /// </exception>
        /// <remarks>
        /// No allocations, no boxing, branch-predictable switch, JIT friendly.
        /// </remarks>
        public static string ToLiteralString(Auriga.Model.Information.Communication.CommunicationLinkProtocol value)
        {
            return value switch
            {
                Auriga.Model.Information.Communication.CommunicationLinkProtocol.UNSET => "UNSET",
                Auriga.Model.Information.Communication.CommunicationLinkProtocol.UNICAST => "UNICAST",
                Auriga.Model.Information.Communication.CommunicationLinkProtocol.MULTICAST => "MULTICAST",
                Auriga.Model.Information.Communication.CommunicationLinkProtocol.BROADCAST => "BROADCAST",
                Auriga.Model.Information.Communication.CommunicationLinkProtocol.SYNCHRONOUS => "SYNCHRONOUS",
                Auriga.Model.Information.Communication.CommunicationLinkProtocol.ASYNCHRONOUS => "ASYNCHRONOUS",
                Auriga.Model.Information.Communication.CommunicationLinkProtocol.READ => "READ",
                Auriga.Model.Information.Communication.CommunicationLinkProtocol.ACCEPT => "ACCEPT",

                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
