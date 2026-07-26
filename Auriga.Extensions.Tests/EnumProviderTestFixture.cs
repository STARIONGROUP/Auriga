// ------------------------------------------------------------------------------------------------
// <copyright file="EnumProviderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Extensions.Tests
{
    using System;

    using Auriga.Diagram.Viewpoint;
    using Auriga.Extensions;
    using Auriga.Model.Pa;

    using NUnit.Framework;

    /// <summary>
    /// Tests the generated enumeration providers (issue #129): the conversion between an enumeration and
    /// the Ecore literal names a Capella or Sirius document carries. The C# member names are capitalized
    /// to be legal identifiers, so they do not always reproduce the Ecore literal — Sirius declares
    /// <c>italic</c>, generated as <c>Italic</c> — and EMF matches literal names case-sensitively.
    /// </summary>
    [TestFixture]
    public class EnumProviderTestFixture
    {
        [Test]
        public void Verify_that_the_ecore_literal_is_written_not_the_member_name()
        {
            Assert.Multiple(() =>
            {
                Assert.That(FontFormatProvider.ToLiteralString(FontFormat.Italic), Is.EqualTo("italic"), "Sirius declares a lower-case literal");
                Assert.That(FontFormatProvider.ToLiteralString(FontFormat.Bold), Is.EqualTo("bold"));
                Assert.That(FontFormatProvider.ToLiteralString(FontFormat.Strike_through), Is.EqualTo("strike_through"));

                Assert.That(PhysicalComponentNatureProvider.ToLiteralString(PhysicalComponentNature.NODE), Is.EqualTo("NODE"), "Capella's literals are upper-case and unchanged");
            });
        }

        [Test]
        public void Verify_that_parsing_is_case_sensitive()
        {
            Assert.Multiple(() =>
            {
                Assert.That(FontFormatProvider.TryParse("italic".AsSpan(), out var parsed), Is.True);
                Assert.That(parsed, Is.EqualTo(FontFormat.Italic));

                // EMF matches literal names case-sensitively, so the C# spelling is deliberately rejected.
                Assert.That(FontFormatProvider.TryParse("Italic".AsSpan(), out _), Is.False, "the C# member spelling is not an Ecore literal");
                Assert.That(FontFormatProvider.TryParse("ITALIC".AsSpan(), out _), Is.False);
            });
        }

        [Test]
        public void Verify_that_an_unknown_literal_is_reported()
        {
            Assert.Multiple(() =>
            {
                Assert.That(FontFormatProvider.TryParse("nonsense".AsSpan(), out var parsed), Is.False);
                Assert.That(parsed, Is.EqualTo(default(FontFormat)));

                Assert.That(() => FontFormatProvider.Parse("nonsense".AsSpan()), Throws.ArgumentException.With.Message.Contains("nonsense"));
                Assert.That(() => FontFormatProvider.Parse(ReadOnlySpan<char>.Empty), Throws.ArgumentException);
            });
        }

        [Test]
        public void Verify_that_every_literal_round_trips()
        {
            foreach (FontFormat value in Enum.GetValues(typeof(FontFormat)))
            {
                var literal = FontFormatProvider.ToLiteralString(value);

                Assert.That(FontFormatProvider.Parse(literal.AsSpan()), Is.EqualTo(value), $"'{literal}' must parse back to {value}");
            }

            foreach (PhysicalComponentNature value in Enum.GetValues(typeof(PhysicalComponentNature)))
            {
                var literal = PhysicalComponentNatureProvider.ToLiteralString(value);

                Assert.That(PhysicalComponentNatureProvider.Parse(literal.AsSpan()), Is.EqualTo(value), $"'{literal}' must parse back to {value}");
            }
        }

        [Test]
        public void Verify_that_an_undefined_value_cannot_be_written()
        {
            Assert.That(() => FontFormatProvider.ToLiteralString((FontFormat)9999), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}
