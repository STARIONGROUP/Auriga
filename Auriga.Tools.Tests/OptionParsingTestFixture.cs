// ------------------------------------------------------------------------------------------------
// <copyright file="OptionParsingTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Tests
{
    using System;

    using Auriga.Reporting.Generators;
    using Auriga.Tools.Commands;

    using NUnit.Framework;

    using ModelColor = Auriga.Reporting.Model.Color;

    /// <summary>
    /// Tests the two option values a user can get wrong: the format list and the background colour.
    /// Both must fail with something a user can act on rather than with a parser's own words.
    /// </summary>
    [TestFixture]
    public class OptionParsingTestFixture
    {
        [Test]
        public void Verify_that_the_format_list_is_read()
        {
            Assert.Multiple(() =>
            {
                Assert.That(OptionParsing.Formats("svg"), Is.EqualTo(DiagramFormats.Svg));
                Assert.That(OptionParsing.Formats("svg,png"), Is.EqualTo(DiagramFormats.Svg | DiagramFormats.Png));
                Assert.That(OptionParsing.Formats("SVG, PNG "), Is.EqualTo(DiagramFormats.Svg | DiagramFormats.Png), "case and spacing do not matter");
                Assert.That(OptionParsing.Formats("jpg"), Is.EqualTo(DiagramFormats.Jpeg), "jpg is jpeg");
                Assert.That(OptionParsing.Formats("excel"), Is.EqualTo(DiagramFormats.Xlsx), "excel is xlsx");
                Assert.That(OptionParsing.Formats("png,png"), Is.EqualTo(DiagramFormats.Png), "a repeat is not an error");
            });
        }

        [Test]
        public void Verify_that_an_unusable_format_list_says_what_is_allowed()
        {
            Assert.Multiple(() =>
            {
                Assert.That(
                    () => OptionParsing.Formats("bmp"),
                    Throws.ArgumentException.With.Message.Contains("svg, png, jpeg and xlsx"));

                Assert.That(() => OptionParsing.Formats(string.Empty), Throws.ArgumentException);
                Assert.That(() => OptionParsing.Formats(null), Throws.ArgumentException);
                Assert.That(() => OptionParsing.Formats(",, ,"), Throws.ArgumentException);
            });
        }

        [Test]
        public void Verify_that_a_colour_is_read_in_either_notation()
        {
            Assert.Multiple(() =>
            {
                Assert.That(OptionParsing.Colour("#FFFFFF"), Is.EqualTo(new ModelColor(255, 255, 255)));
                Assert.That(OptionParsing.Colour("#0080ff"), Is.EqualTo(new ModelColor(0, 128, 255)), "hex is case-insensitive");
                Assert.That(OptionParsing.Colour(" #000000 "), Is.EqualTo(new ModelColor(0, 0, 0)), "surrounding space is trimmed");
                Assert.That(OptionParsing.Colour("0,128,255"), Is.EqualTo(new ModelColor(0, 128, 255)), "the Sirius r,g,b notation");
            });
        }

        [Test]
        public void Verify_that_something_that_is_not_a_colour_says_what_a_colour_looks_like()
        {
            Assert.Multiple(() =>
            {
                Assert.That(
                    () => OptionParsing.Colour("puce"),
                    Throws.ArgumentException.With.Message.Contains("#RRGGBB"));

                Assert.That(() => OptionParsing.Colour("#FFF"), Throws.ArgumentException, "three-digit hex is not accepted");
                Assert.That(() => OptionParsing.Colour("#GGGGGG"), Throws.ArgumentException);
                Assert.That(() => OptionParsing.Colour("300,0,0"), Throws.ArgumentException, "a component outside a byte");
                Assert.That(() => OptionParsing.Colour(string.Empty), Throws.ArgumentException);
            });
        }
    }
}
