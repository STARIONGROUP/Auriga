// ------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterBuilderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System.IO;
    using System.Text;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the <see cref="XmiWriterBuilder"/> fluent factory: that it builds a usable writer and
    /// that the configured logger and settings flow through to the produced <see cref="IXmiWriter"/>.
    /// </summary>
    [TestFixture]
    public class XmiWriterBuilderTestFixture
    {
        [Test]
        public void Verify_that_create_and_build_produce_a_writer()
        {
            var writer = XmiWriterBuilder.Create().Build();

            Assert.That(writer, Is.Not.Null);
        }

        [Test]
        public void Verify_that_the_fluent_methods_return_the_same_builder()
        {
            var builder = XmiWriterBuilder.Create();

            Assert.Multiple(() =>
            {
                Assert.That(builder.WithLogger(NullLoggerFactory.Instance), Is.SameAs(builder));
                Assert.That(builder.WithSettings(new XmiWriterSettings()), Is.SameAs(builder));
            });
        }

        [Test]
        public void Verify_that_a_configured_logger_produces_a_usable_writer()
        {
            var writer = XmiWriterBuilder.Create().WithLogger(NullLoggerFactory.Instance).Build();

            Assert.That(Write(writer), Does.Contain("Project"));
        }

        [Test]
        public void Verify_that_the_configured_settings_flow_through_to_the_output()
        {
            var settings = new XmiWriterSettings { VersionComment = "Capella_Version_Custom" };
            var writer = XmiWriterBuilder.Create().WithSettings(settings).Build();

            Assert.That(Write(writer), Does.Contain("Capella_Version_Custom"));
        }

        [Test]
        public void Verify_that_a_null_version_comment_is_omitted()
        {
            var settings = new XmiWriterSettings { VersionComment = null };
            var writer = XmiWriterBuilder.Create().WithSettings(settings).Build();

            Assert.That(Write(writer), Does.Not.Contain("<!--"));
        }

        private static string Write(IXmiWriter writer)
        {
            using var stream = new MemoryStream();
            writer.WriteDocument(new Auriga.Capellamodeller.Project { Id = "p1" }, stream, "model.capella");
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
