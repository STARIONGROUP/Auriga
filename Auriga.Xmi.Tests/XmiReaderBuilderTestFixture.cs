// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderBuilderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System.IO;

    using Auriga.Diagram.Viewpoint;
    using Auriga.Model.Capellamodeller;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the <see cref="XmiReaderBuilder"/> fluent entry point and its Autofac-backed
    /// <see cref="XmiReaderScope"/>: that it builds a usable reader, that the single built reader reads
    /// both metamodels' documents — a Capella <c>.capella</c> semantic model and a Sirius <c>.aird</c>
    /// diagram file — through the unioned dispatch tables, that every terminal <c>Build*</c> call yields
    /// an independent reader graph, and that the scope disposes safely.
    /// </summary>
    [TestFixture]
    public class XmiReaderBuilderTestFixture
    {
        [Test]
        public void Verify_that_the_fluent_methods_return_the_same_scope()
        {
            using var scope = XmiReaderBuilder.Create();

            Assert.Multiple(() =>
            {
                Assert.That(scope.WithLogger(NullLoggerFactory.Instance), Is.SameAs(scope));
                Assert.That(scope.UsingSettings(settings => settings.UseStrictReading = false), Is.SameAs(scope));
            });
        }

        [Test]
        public void Verify_that_one_reader_reads_both_a_capella_and_an_aird_document()
        {
            var reader = XmiReaderBuilder.Create().Build();

            var semantic = reader.Read(TestDataPath("coffee-machine-demo.capella"));
            var diagram = reader.Read(TestDataPath("coffee-machine-demo.aird"));

            Assert.Multiple(() =>
            {
                Assert.That(semantic.Root, Is.InstanceOf<IProject>(), "the .capella root is a Capella project");
                Assert.That(diagram.Root, Is.InstanceOf<IDAnalysis>(), "the .aird root is a Sirius analysis");
            });
        }

        [Test]
        public void Verify_that_each_build_yields_an_independent_reader_graph()
        {
            using var scope = XmiReaderBuilder.Create();

            var first = scope.Build();
            var second = scope.Build();

            // Each Build() resolves from a fresh child lifetime scope, so the readers share no cache:
            // reading through one must not disturb a result read through the other.
            var semantic = first.Read(TestDataPath("coffee-machine-demo.capella"));
            var diagram = second.Read(TestDataPath("coffee-machine-demo.aird"));

            Assert.Multiple(() =>
            {
                Assert.That(first, Is.Not.SameAs(second));
                Assert.That(semantic.Root, Is.InstanceOf<IProject>());
                Assert.That(diagram.Root, Is.InstanceOf<IDAnalysis>());
                Assert.That(semantic.Elements, Is.Not.Empty);
            });
        }

        [Test]
        public void Verify_that_the_loader_terminals_build_working_loaders()
        {
            using var scope = XmiReaderBuilder.Create();

            var capellaLoader = scope.BuildCapellaModelLoader();
            var airdLoader = scope.BuildAirdModelLoader();

            Assert.Multiple(() =>
            {
                Assert.That(capellaLoader.Load(TestDataPath("coffee-machine-demo.capella")).Root, Is.InstanceOf<IProject>());
                Assert.That(airdLoader.Load(TestDataPath("coffee-machine-demo.aird")).Root, Is.InstanceOf<IDAnalysis>());
            });
        }

        [Test]
        public void Verify_that_an_unused_scope_disposes_safely()
        {
            var scope = XmiReaderBuilder.Create();

            Assert.That(() => scope.Dispose(), Throws.Nothing);
        }

        [Test]
        public void Verify_that_the_fluent_methods_guard_their_arguments()
        {
            using var scope = XmiReaderBuilder.Create();

            Assert.Multiple(() =>
            {
                Assert.That(() => XmiReaderBuilder.Build(null!), Throws.ArgumentNullException);
                Assert.That(() => XmiReaderBuilder.BuildCapellaModelLoader(null!), Throws.ArgumentNullException);
                Assert.That(() => XmiReaderBuilder.BuildAirdModelLoader(null!), Throws.ArgumentNullException);
                Assert.That(() => XmiReaderBuilder.WithLogger(null!, NullLoggerFactory.Instance), Throws.ArgumentNullException);
                Assert.That(() => scope.WithLogger(null!), Throws.ArgumentNullException);
                Assert.That(() => XmiReaderBuilder.UsingSettings(null!, settings => { }), Throws.ArgumentNullException);
                Assert.That(() => scope.UsingSettings(null!), Throws.ArgumentNullException);
            });
        }

        private static string TestDataPath(string fileName)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", fileName);
        }
    }
}
