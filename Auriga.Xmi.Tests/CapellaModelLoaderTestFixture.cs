// ------------------------------------------------------------------------------------------------
// <copyright file="CapellaModelLoaderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System;
    using System.IO;

    using NUnit.Framework;

    /// <summary>
    /// Exercises <see cref="CapellaModelLoader"/>, the project-level entry point: loading a Capella project
    /// end-to-end from its semantic model file or its project directory, and its clear error surface for
    /// missing, ambiguous or non-model paths.
    /// </summary>
    [TestFixture]
    public class CapellaModelLoaderTestFixture
    {
        private string temporaryRoot = null!;

        [SetUp]
        public void SetUp()
        {
            this.temporaryRoot = Path.Combine(Path.GetTempPath(), "auriga-loader-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(this.temporaryRoot);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(this.temporaryRoot))
            {
                Directory.Delete(this.temporaryRoot, recursive: true);
            }
        }

        [Test]
        [TestCase("coffee-machine-demo.capella")]
        [TestCase("in-flight-entertainment-system.capella")]
        public void Verify_that_a_capella_file_loads_into_a_resolved_graph(string fileName)
        {
            var result = CapellaModelLoader.Create().Load(ModelFile(fileName));

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<Auriga.Capellamodeller.IProject>());
                Assert.That(result.Elements, Is.Not.Empty);
                Assert.That(result.UnresolvedReferences, Is.Empty);
            });
        }

        [Test]
        public void Verify_that_a_melodymodeller_file_loads()
        {
            var result = CapellaModelLoader.Create().Load(MinimalFile());

            Assert.That(result.Root, Is.InstanceOf<Auriga.Capellamodeller.IProject>());
        }

        [Test]
        public void Verify_that_a_project_directory_resolves_to_its_semantic_model_file()
        {
            // A real project directory carries the semantic .capella alongside its .aird / .afm siblings;
            // the loader must find the one semantic file and ignore the rest, yielding the same graph as
            // loading that file directly.
            var expected = CapellaModelLoader.Create().Load(CoffeeMachineFile());

            var projectDirectory = Path.Combine(this.temporaryRoot, "coffee-machine");
            Directory.CreateDirectory(projectDirectory);
            File.Copy(CoffeeMachineFile(), Path.Combine(projectDirectory, "coffee-machine-demo.capella"));
            File.WriteAllText(Path.Combine(projectDirectory, "coffee-machine-demo.aird"), "diagram data, ignored");
            File.WriteAllText(Path.Combine(projectDirectory, "coffee-machine-demo.afm"), "metadata, ignored");

            var result = CapellaModelLoader.Create().Load(projectDirectory);

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<Auriga.Capellamodeller.IProject>());
                Assert.That(result.Elements, Has.Count.EqualTo(expected.Elements.Count));
            });
        }

        [Test]
        public void Verify_that_a_fragmented_project_loads_from_its_directory()
        {
            // Pointing the loader at the fragmented project's directory must resolve the main .capella and
            // transitively load its fragments — the whole model in one documented call.
            var result = CapellaModelLoader.Create().Load(FragmentedProjectDirectory());

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<Auriga.Capellamodeller.IProject>());
                Assert.That(result.Elements, Is.Not.Empty);

                // Elements sourced from a fragment prove the fragments were loaded, not just the main file.
                Assert.That(
                    result.Elements.Values,
                    Has.Some.Matches<IAurigaElement>(e => e.SourceDocument != null && e.SourceDocument.StartsWith("fragments/")));
            });
        }

        [Test]
        public void Verify_that_a_null_or_blank_path_is_rejected()
        {
            var loader = CapellaModelLoader.Create();

            Assert.Multiple(() =>
            {
                Assert.That(() => loader.Load(null!), Throws.ArgumentException);
                Assert.That(() => loader.Load("   "), Throws.ArgumentException);
            });
        }

        [Test]
        public void Verify_that_a_missing_path_is_reported_clearly()
        {
            var loader = CapellaModelLoader.Create();
            var missing = Path.Combine(this.temporaryRoot, "does-not-exist.capella");

            Assert.That(() => loader.Load(missing), Throws.InstanceOf<FileNotFoundException>());
        }

        [Test]
        public void Verify_that_a_directory_without_a_semantic_model_is_reported_clearly()
        {
            var loader = CapellaModelLoader.Create();

            Assert.That(() => loader.Load(this.temporaryRoot), Throws.InstanceOf<FileNotFoundException>());
        }

        [Test]
        public void Verify_that_a_directory_with_several_semantic_models_is_reported_clearly()
        {
            File.WriteAllText(Path.Combine(this.temporaryRoot, "one.capella"), "<root/>");
            File.WriteAllText(Path.Combine(this.temporaryRoot, "two.capella"), "<root/>");

            Assert.That(() => CapellaModelLoader.Create().Load(this.temporaryRoot), Throws.InstanceOf<InvalidDataException>());
        }

        [Test]
        public void Verify_that_a_non_model_file_is_reported_clearly()
        {
            var notAModel = Path.Combine(this.temporaryRoot, "notes.txt");
            File.WriteAllText(notAModel, "not a model");

            Assert.That(() => CapellaModelLoader.Create().Load(notAModel), Throws.InstanceOf<InvalidDataException>());
        }

        private static string ModelFile(string fileName)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", fileName);
        }

        private static string CoffeeMachineFile()
        {
            return ModelFile("coffee-machine-demo.capella");
        }

        private static string MinimalFile()
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "minimal.melodymodeller");
        }

        private static string FragmentedProjectDirectory()
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "fragmented-sysmodel");
        }
    }
}
