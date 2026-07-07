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
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    using NUnit.Framework;

    /// <summary>
    /// Tests for the <see cref="ObjectModelGenerator"/>, which generates the whole Capella v1 metamodel
    /// (issue #8). The expected classifier counts are the ground truth established in the metamodel
    /// inventory (<c>docs/metamodel-inventory.md</c>, issue #1): 430 EClasses, 275 of them concrete,
    /// and 35 EEnums, across 25 Ecore packages.
    /// </summary>
    [TestFixture]
    public class ObjectModelGeneratorTestFixture
    {
        private const int ExpectedInterfaceCount = 430;

        private const int ExpectedClassCount = 275;

        private const int ExpectedEnumCount = 35;

        private string ecoreDirectory = string.Empty;

        private IReadOnlyDictionary<string, string> files = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void SetUp()
        {
            this.ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore");
            this.files = new ObjectModelGenerator(this.ecoreDirectory).Generate();
        }

        [Test]
        public void Verify_that_generation_is_deterministic()
        {
            var second = new ObjectModelGenerator(this.ecoreDirectory).Generate();

            Assert.That(second, Is.EqualTo(this.files));
        }

        [Test]
        public void Verify_that_the_whole_metamodel_is_generated()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Count("AutoGenInterfaces/"), Is.EqualTo(ExpectedInterfaceCount), "interfaces");
                Assert.That(Count("AutoGenClasses/"), Is.EqualTo(ExpectedClassCount), "classes");
                Assert.That(Count("AutoGenEnumeration/"), Is.EqualTo(ExpectedEnumCount), "enums");
            });
        }

        [Test]
        public void Verify_that_every_class_has_an_interface()
        {
            var interfaces = this.files.Keys
                .Where(k => k.StartsWith("AutoGenInterfaces/"))
                .Select(k => Path.GetFileName(k)[1..]) // strip the leading 'I'
                .ToHashSet(StringComparer.Ordinal);

            var classesWithoutInterface = this.files.Keys
                .Where(k => k.StartsWith("AutoGenClasses/"))
                .Select(Path.GetFileName)
                .Where(name => !interfaces.Contains(name!))
                .ToList();

            Assert.That(classesWithoutInterface, Is.Empty);
        }

        [Test]
        public void Verify_that_classes_are_emitted_across_every_architecture_layer()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.files.Keys, Contains.Item("AutoGenClasses/Oa/OperationalAnalysis.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenClasses/Ctx/SystemAnalysis.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenClasses/La/LogicalArchitecture.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenClasses/Pa/PhysicalComponent.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenClasses/Epbs/ConfigurationItem.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenClasses/Deployment/PartDeploymentLink.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenClasses/Requirements/Requirement.cs"));
            });
        }

        [Test]
        public void Verify_that_same_named_classes_in_different_packages_do_not_collide()
        {
            // Folder is defined in both capellamodeller and Requirements; AbstractType in both
            // modellingcore and Requirements. Per-package folders keep them apart.
            Assert.Multiple(() =>
            {
                Assert.That(this.files.Keys, Contains.Item("AutoGenClasses/Capellamodeller/Folder.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenClasses/Requirements/Folder.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenInterfaces/Modellingcore/IAbstractType.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenInterfaces/Requirements/IAbstractType.cs"));
            });
        }

        [Test]
        public void Verify_that_abstract_classes_get_an_interface_but_no_class()
        {
            Assert.Multiple(() =>
            {
                // modellingcore::ModelElement and cs::Component are abstract
                Assert.That(this.files.Keys, Contains.Item("AutoGenInterfaces/Modellingcore/IModelElement.cs"));
                Assert.That(this.files.Keys, Does.Not.Contain("AutoGenClasses/Modellingcore/ModelElement.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenInterfaces/Cs/IComponent.cs"));
                Assert.That(this.files.Keys, Does.Not.Contain("AutoGenClasses/Cs/Component.cs"));
            });
        }

        [Test]
        public void Verify_that_the_enumerations_are_generated()
        {
            var content = this.files["AutoGenEnumeration/Pa/PhysicalComponentNature.cs"];

            Assert.Multiple(() =>
            {
                Assert.That(content, Does.Contain("public enum PhysicalComponentNature"));
                Assert.That(content, Does.Contain("#nullable disable"));
            });
        }

        [Test]
        public void Verify_that_a_concrete_class_flattens_inheritance_and_implements_its_interface()
        {
            var content = this.files["AutoGenClasses/Pa/PhysicalComponent.cs"];

            Assert.Multiple(() =>
            {
                Assert.That(content, Does.Contain("public partial class PhysicalComponent : Auriga.AurigaElement, Auriga.Pa.IPhysicalComponent"));
                Assert.That(content, Does.Contain("#nullable disable"));
            });
        }

        [Test]
        public void Verify_that_containment_collections_use_the_container_list()
        {
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
            var content = this.files["AutoGenClasses/Pa/PhysicalComponent.cs"];

            Assert.Multiple(() =>
            {
                Assert.That(content, Does.Contain("    using System.Collections.Generic;"));
                Assert.That(content, Does.Contain("    using System.Linq;"));
                Assert.That(content, Does.Not.Contain("global::"));
                Assert.That(content, Does.Not.Contain("using Auriga"));
            });
        }

        [Test]
        public void Verify_that_types_and_members_are_documented_even_without_model_documentation()
        {
            var content = this.files["AutoGenClasses/Pa/PhysicalComponent.cs"];

            Assert.Multiple(() =>
            {
                Assert.That(content, Does.Contain("/// Definition of the <c>PhysicalComponent</c> class."));
                Assert.That(content, Does.Contain("/// Gets or sets the "));
                Assert.That(content, Does.Contain("/// Gets the "));
            });
        }

        [Test]
        public void Verify_that_enum_literals_are_documented()
        {
            var content = this.files["AutoGenEnumeration/Pa/PhysicalComponentNature.cs"];

            Assert.That(content, Does.Contain("/// The <c>UNSET</c> literal."));
        }

        [Test]
        public void Verify_that_members_are_sorted_alphabetically()
        {
            var content = this.files["AutoGenInterfaces/Pa/IPhysicalComponent.cs"];

            var names = Regex
                .Matches(content, @"^\s+\S.* (?<name>\w+) \{ get;", RegexOptions.Multiline)
                .Select(m => m.Groups["name"].Value)
                .ToList();

            Assert.That(names, Is.Not.Empty);
            Assert.That(names, Is.Ordered.Using<string>(StringComparer.Ordinal));
        }

        [Test]
        public void Verify_that_generated_files_carry_the_auto_generated_banner_at_the_top_and_bottom()
        {
            const string Banner = "THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!";

            foreach (var file in this.files.Values)
            {
                var trimmed = file.TrimEnd();

                Assert.Multiple(() =>
                {
                    Assert.That(CountOccurrences(file, Banner), Is.EqualTo(2));
                    Assert.That(trimmed, Does.EndWith("// ------------------------------------------------------------------------------------------------"));
                });
            }
        }

        private int Count(string folderPrefix)
        {
            return this.files.Keys.Count(k => k.StartsWith(folderPrefix, StringComparison.Ordinal));
        }

        private static int CountOccurrences(string text, string value)
        {
            var count = 0;
            var index = text.IndexOf(value, StringComparison.Ordinal);

            while (index >= 0)
            {
                count++;
                index = text.IndexOf(value, index + value.Length, StringComparison.Ordinal);
            }

            return count;
        }

        /// <summary>
        /// Regenerates the committed object model into the <c>Auriga</c> project. Run this explicitly
        /// after changing the generator or a template, then review the diff and commit.
        /// </summary>
        [Test]
        [Explicit("Regenerates the committed object model in the Auriga project.")]
        public void Regenerate_object_model()
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "Auriga.sln")))
            {
                directory = directory.Parent;
            }

            Assert.That(directory, Is.Not.Null, "could not locate the solution root");

            var aurigaProject = Path.Combine(directory!.FullName, "Auriga");
            new ObjectModelGenerator(this.ecoreDirectory).Write(aurigaProject);
        }
    }
}
