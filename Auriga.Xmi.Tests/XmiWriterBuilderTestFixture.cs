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
    /// Unit tests for the <see cref="XmiWriterBuilder"/> fluent entry point and its Autofac-backed
    /// <see cref="XmiWriterScope"/>: that it builds a usable writer, that the configured logger and
    /// settings flow through to the produced <see cref="IXmiWriter"/>, and that the scope disposes
    /// safely.
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
        public void Verify_that_the_fluent_methods_return_the_same_scope()
        {
            using var scope = XmiWriterBuilder.Create();

            Assert.Multiple(() =>
            {
                Assert.That(scope.WithLogger(NullLoggerFactory.Instance), Is.SameAs(scope));
                Assert.That(scope.WithSettings(new XmiWriterSettings()), Is.SameAs(scope));
            });
        }

        [Test]
        public void Verify_that_each_build_yields_an_independent_writer()
        {
            using var scope = XmiWriterBuilder.Create();

            var first = scope.Build();
            var second = scope.Build();

            Assert.Multiple(() =>
            {
                Assert.That(first, Is.Not.SameAs(second));
                Assert.That(Write(first), Does.Contain("Project"));
                Assert.That(Write(second), Does.Contain("Project"));
            });
        }

        [Test]
        public void Verify_that_an_unused_scope_disposes_safely()
        {
            var scope = XmiWriterBuilder.Create();

            Assert.That(() => scope.Dispose(), Throws.Nothing);
        }

        [Test]
        public void Verify_that_the_fluent_methods_guard_their_arguments()
        {
            using var scope = XmiWriterBuilder.Create();

            Assert.Multiple(() =>
            {
                Assert.That(() => XmiWriterBuilder.Build(null!), Throws.ArgumentNullException);
                Assert.That(() => XmiWriterBuilder.WithLogger(null!, NullLoggerFactory.Instance), Throws.ArgumentNullException);
                Assert.That(() => scope.WithLogger(null!), Throws.ArgumentNullException);
                Assert.That(() => XmiWriterBuilder.WithSettings(null!, new XmiWriterSettings()), Throws.ArgumentNullException);
                Assert.That(() => scope.WithSettings(null!), Throws.ArgumentNullException);
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
            writer.WriteDocument(new Auriga.Model.Capellamodeller.Project { Id = "p1" }, stream, "model.capella");
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
