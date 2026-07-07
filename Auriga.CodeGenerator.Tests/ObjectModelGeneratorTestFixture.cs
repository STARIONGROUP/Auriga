// ------------------------------------------------------------------------------------------------
// <copyright file="ObjectModelGeneratorTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using NUnit.Framework;

    /// <summary>
    /// Tests for the <see cref="ObjectModelGenerator"/> prototype (issue #7), which generates the
    /// <c>pa</c> and <c>pa.deployment</c> packages.
    /// </summary>
    [TestFixture]
    public class ObjectModelGeneratorTestFixture
    {
        private static readonly string[] TargetPackages = { "pa", "deployment" };

        private string ecoreDirectory = string.Empty;

        private IReadOnlyDictionary<string, string> files = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void SetUp()
        {
            this.ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore");
            this.files = new ObjectModelGenerator(this.ecoreDirectory).Generate(TargetPackages);
        }

        [Test]
        public void Verify_that_generation_is_deterministic()
        {
            var second = new ObjectModelGenerator(this.ecoreDirectory).Generate(TargetPackages);

            Assert.That(second, Is.EqualTo(this.files));
        }

        [Test]
        public void Verify_that_pa_concrete_classes_and_their_interfaces_are_generated()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.files.Keys, Contains.Item("AutoGenClasses/PhysicalComponent.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenClasses/PhysicalFunction.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenInterfaces/IPhysicalComponent.cs"));

                // deployment subpackage classes are emitted too
                Assert.That(this.files.Keys, Contains.Item("AutoGenClasses/PartDeploymentLink.cs"));
            });
        }

        [Test]
        public void Verify_that_abstract_and_external_classes_get_an_interface_but_no_class()
        {
            Assert.Multiple(() =>
            {
                // cs::Component is an external supertype in the closure: interface only, no class here
                Assert.That(this.files.Keys, Contains.Item("AutoGenInterfaces/IComponent.cs"));
                Assert.That(this.files.Keys, Does.Not.Contain("AutoGenClasses/Component.cs"));
            });
        }

        [Test]
        public void Verify_that_the_enumerations_are_generated()
        {
            Assert.That(this.files.Keys, Contains.Item("AutoGenEnumeration/PhysicalComponentNature.cs"));

            var content = this.files["AutoGenEnumeration/PhysicalComponentNature.cs"];
            Assert.Multiple(() =>
            {
                Assert.That(content, Does.Contain("public enum PhysicalComponentNature"));
                Assert.That(content, Does.Contain("#nullable disable"));
            });
        }

        [Test]
        public void Verify_that_a_concrete_class_flattens_inheritance_and_implements_its_interface()
        {
            var content = this.files["AutoGenClasses/PhysicalComponent.cs"];

            Assert.Multiple(() =>
            {
                Assert.That(content, Does.Contain("public partial class PhysicalComponent : Auriga.AurigaElement, Auriga.Pa.IPhysicalComponent"));
                Assert.That(content, Does.Contain("#nullable disable"));
            });
        }

        [Test]
        public void Verify_that_containment_collections_use_the_container_list()
        {
            // every generated concrete class that has a containment collection uses IContainerList
            var anyContainerList = this.files
                .Where(f => f.Key.StartsWith("AutoGenClasses/"))
                .Any(f => f.Value.Contains("Auriga.IContainerList<"));

            Assert.That(anyContainerList, Is.True);
        }

        [Test]
        public void Verify_that_cross_reference_collections_use_a_plain_list()
        {
            var anyList = this.files
                .Where(f => f.Key.StartsWith("AutoGenClasses/"))
                .Any(f => f.Value.Contains("new List<"));

            Assert.That(anyList, Is.True);
        }

        [Test]
        public void Verify_that_generated_files_import_only_bcl_namespaces_and_use_no_global_alias()
        {
            var content = this.files["AutoGenClasses/PhysicalComponent.cs"];

            Assert.Multiple(() =>
            {
                // BCL namespaces are imported; Auriga model types stay fully qualified (no using, no global::)
                Assert.That(content, Does.Contain("    using System.Collections.Generic;"));
                Assert.That(content, Does.Contain("    using System.Linq;"));
                Assert.That(content, Does.Not.Contain("global::"));
                Assert.That(content, Does.Not.Contain("using Auriga"));
            });
        }

        /// <summary>
        /// Regenerates the committed <c>pa</c> object model into the <c>Auriga</c> project. Run this
        /// explicitly after changing the generator or a template, then review the diff and commit.
        /// </summary>
        [Test]
        [Explicit("Regenerates the committed pa object model in the Auriga project.")]
        public void Regenerate_pa_object_model()
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "Auriga.sln")))
            {
                directory = directory.Parent;
            }

            Assert.That(directory, Is.Not.Null, "could not locate the solution root");

            var aurigaProject = Path.Combine(directory!.FullName, "Auriga");
            new ObjectModelGenerator(this.ecoreDirectory).Write(aurigaProject, TargetPackages);
        }
    }
}
