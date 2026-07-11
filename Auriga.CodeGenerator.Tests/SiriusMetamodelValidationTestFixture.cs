// ------------------------------------------------------------------------------------------------
// <copyright file="SiriusMetamodelValidationTestFixture.cs" company="Starion Group S.A.">
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

    using ECoreNetto;
    using ECoreNetto.Resource;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    /// <summary>
    /// Regression tests proving that ECoreNetto loads the complete vendored Sirius + GMF metamodel
    /// (resources/ecore-sirius) with fully resolved cross-file references. This is the metamodel
    /// behind the Sirius `.aird` diagram/representation files; the fixture guards the code
    /// generator's second input against ECoreNetto regressions and re-vendoring mistakes. It
    /// mirrors <see cref="CapellaMetamodelValidationTestFixture"/>; see
    /// docs/sirius-ecorenetto-validation.md and docs/sirius-metamodel-inventory.md.
    /// </summary>
    [TestFixture]
    public class SiriusMetamodelValidationTestFixture
    {
        private List<string> ecoreFiles = new();

        private readonly Dictionary<string, EPackage> rootPackages = new();

        private readonly List<string> loadFailures = new();

        [OneTimeSetUp]
        public void SetUp()
        {
            var ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore-sirius");
            this.ecoreFiles = Directory.GetFiles(ecoreDirectory, "*.ecore").OrderBy(f => f).ToList();

            ILoggerFactory? loggerFactory = null;
            var resourceSet = new ResourceSet(loggerFactory);

            foreach (var file in this.ecoreFiles)
            {
                var name = Path.GetFileName(file);

                try
                {
                    // demand-loading may already have pulled this file in as a dependency of an
                    // earlier one; in that case the root package is fetched from the existing
                    // resource instead of loading twice.
                    var uri = new Uri(file);
                    var resource = resourceSet.Resources.SingleOrDefault(x => x.URI == uri) ?? resourceSet.CreateResource(uri);
                    var root = resource.IsLoaded()
                        ? resource.Contents.OfType<EPackage>().FirstOrDefault()
                          ?? resource.GetEObject($"{Path.GetFileNameWithoutExtension(file)}.ecore#/") as EPackage
                        : resource.Load(null);

                    if (root == null)
                    {
                        this.loadFailures.Add($"{name}: loaded but the root EPackage could not be retrieved");
                        continue;
                    }

                    this.rootPackages[name] = root;

                    foreach (var error in resource.Errors)
                    {
                        this.loadFailures.Add($"{name}: {error}");
                    }
                }
                catch (Exception ex)
                {
                    this.loadFailures.Add($"{name}: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        [Test]
        public void Verify_that_all_ecore_files_load_through_a_single_resource_set()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.loadFailures, Is.Empty);
                Assert.That(this.rootPackages, Has.Count.EqualTo(this.ecoreFiles.Count));
                Assert.That(this.ecoreFiles, Has.Count.EqualTo(5));
            });
        }

        [Test]
        public void Verify_that_classifier_counts_match_the_metamodel_inventory()
        {
            // expected EClass/EEnum/EDataType counts per package, from docs/sirius-metamodel-inventory.md
            var expectedCounts = new Dictionary<string, (int Classes, int Enums, int DataTypes)>
            {
                ["viewpoint"] = (30, 3, 2),
                ["viewpoint.description"] = (49, 3, 6),
                ["viewpoint.description.style"] = (6, 0, 0),
                ["viewpoint.description.tool"] = (57, 1, 0),
                ["viewpoint.description.validation"] = (6, 1, 0),
                ["viewpoint.description.audit"] = (2, 0, 0),
                ["diagram"] = (47, 11, 0),
                ["diagram.description"] = (32, 4, 0),
                ["diagram.description.style"] = (23, 1, 0),
                ["diagram.description.tool"] = (26, 1, 0),
                ["diagram.description.filter"] = (5, 1, 0),
                ["diagram.description.concern"] = (2, 0, 0),
                ["sequence"] = (1, 0, 0),
                ["sequence.description"] = (21, 0, 0),
                ["sequence.description.tool"] = (15, 0, 0),
                ["sequence.ordering"] = (5, 0, 0),
                ["sequence.template"] = (18, 0, 0),
                ["table"] = (10, 0, 0),
                ["table.description"] = (29, 0, 0),
                ["notation"] = (70, 13, 4),
            };

            var problems = new List<string>();
            var allPackages = this.GetAllPackages();

            foreach (var package in allPackages)
            {
                var qualifiedName = QualifiedName(package);
                var classes = package.EClassifiers.OfType<EClass>().Count();
                var enums = package.EClassifiers.OfType<EEnum>().Count();
                var dataTypes = package.EClassifiers.OfType<EDataType>().Count() - enums;

                if (!expectedCounts.TryGetValue(qualifiedName, out var expected))
                {
                    problems.Add($"unexpected package: {qualifiedName}");
                    continue;
                }

                if (classes != expected.Classes || enums != expected.Enums || dataTypes != expected.DataTypes)
                {
                    problems.Add($"{qualifiedName}: expected {expected.Classes} classes/{expected.Enums} enums/{expected.DataTypes} datatypes, got {classes}/{enums}/{dataTypes}");
                }
            }

            problems.AddRange(expectedCounts.Keys.Except(allPackages.Select(QualifiedName))
                .Select(missing => $"package not found: {missing}"));

            Assert.That(problems, Is.Empty);
        }

        [Test]
        public void Verify_that_all_supertypes_and_feature_types_resolve()
        {
            var problems = new List<string>();
            var allClasses = this.GetAllClasses();

            foreach (var eClass in allClasses)
            {
                for (var i = 0; i < eClass.ESuperTypes.Count; i++)
                {
                    if (eClass.ESuperTypes[i] == null)
                    {
                        problems.Add($"{QualifiedName(eClass.EPackage)}::{eClass.Name}: unresolved supertype at index {i}");
                    }
                }

                problems.AddRange(eClass.EStructuralFeatures.Where(feature => feature.EType == null)
                    .Select(feature => $"{QualifiedName(eClass.EPackage)}::{eClass.Name}.{feature.Name}: unresolved feature type"));
            }

            Assert.Multiple(() =>
            {
                Assert.That(problems, Is.Empty);
                Assert.That(allClasses.Sum(c => c.ESuperTypes.Count), Is.GreaterThan(0));
                Assert.That(allClasses.Sum(c => c.EStructuralFeatures.Count), Is.GreaterThan(0));
            });
        }

        [Test]
        public void Verify_that_cross_file_inheritance_chains_resolve()
        {
            var inheritanceProbes = new (string Package, string Class, string ExpectedAncestorPackage, string ExpectedAncestor)[]
            {
                ("diagram", "DSemanticDiagram", "viewpoint", "DRepresentation"),
                ("diagram", "DNodeContainer", "viewpoint", "DSemanticDecorator"),
                ("diagram", "DEdge", "viewpoint", "DSemanticDecorator"),
                ("table", "DTable", "viewpoint", "DRepresentation"),
                ("sequence", "SequenceDDiagram", "diagram", "DSemanticDiagram"),
                ("sequence", "SequenceDDiagram", "viewpoint", "DRepresentation"),
            };

            var problems = new List<string>();
            var allClasses = this.GetAllClasses();

            foreach (var probe in inheritanceProbes)
            {
                var eClass = allClasses.FirstOrDefault(c => c.Name == probe.Class && QualifiedName(c.EPackage) == probe.Package);

                if (eClass == null)
                {
                    problems.Add($"class not found: {probe.Package}::{probe.Class}");
                    continue;
                }

                var ancestors = AllSuperTypes(eClass).ToList();

                if (!ancestors.Any(a => a.Name == probe.ExpectedAncestor && QualifiedName(a.EPackage) == probe.ExpectedAncestorPackage))
                {
                    problems.Add($"{probe.Package}::{probe.Class} does not reach {probe.ExpectedAncestorPackage}::{probe.ExpectedAncestor} " +
                                 $"(found: {string.Join(", ", ancestors.Select(a => a.Name))})");
                }
            }

            Assert.That(problems, Is.Empty);
        }

        [Test]
        public void Verify_that_eOpposite_pairs_are_mutual_and_complete()
        {
            var allReferences = this.GetAllClasses().SelectMany(c => c.EStructuralFeatures.OfType<EReference>()).ToList();
            var resolvedOpposites = allReferences.Where(r => r.EOpposite != null).ToList();
            var nonMutual = resolvedOpposites
                .Where(reference => !ReferenceEquals(reference.EOpposite!.EOpposite, reference))
                .Select(reference => $"{reference.EContainingClass.Name}.{reference.Name}")
                .ToList();

            var declaredOpposites = this.ecoreFiles.Sum(f => CountOccurrences(File.ReadAllText(f), "eOpposite=\""));

            Assert.Multiple(() =>
            {
                Assert.That(nonMutual, Is.Empty);
                Assert.That(resolvedOpposites, Has.Count.EqualTo(declaredOpposites));
            });
        }

        [Test]
        public void Verify_that_annotations_survive_loading()
        {
            var classAnnotations = this.GetAllClasses()
                .SelectMany(c => c.EAnnotations)
                .Where(a => a.Source != null)
                .ToList();

            Assert.That(classAnnotations, Is.Not.Empty);
        }

        private List<EPackage> GetAllPackages()
        {
            return this.rootPackages.Values.SelectMany(AllPackages).ToList();
        }

        private List<EClass> GetAllClasses()
        {
            return this.GetAllPackages().SelectMany(p => p.EClassifiers.OfType<EClass>()).ToList();
        }

        private static IEnumerable<EPackage> AllPackages(EPackage package)
        {
            yield return package;

            foreach (var nested in package.ESubPackages.SelectMany(AllPackages))
            {
                yield return nested;
            }
        }

        private static int CountOccurrences(string text, string value)
        {
            var count = 0;
            var index = 0;

            while ((index = text.IndexOf(value, index, StringComparison.Ordinal)) >= 0)
            {
                count++;
                index += value.Length;
            }

            return count;
        }

        private static string QualifiedName(EPackage package)
        {
            var parts = new List<string>();
            var current = package;

            while (current != null)
            {
                parts.Insert(0, current.Name ?? "?");
                current = current.ESuperPackage;
            }

            return string.Join(".", parts);
        }

        private static IEnumerable<EClass> AllSuperTypes(EClass eClass)
        {
            var seen = new HashSet<EClass>();
            var queue = new Queue<EClass>(eClass.ESuperTypes.Where(s => s != null));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (!seen.Add(current))
                {
                    continue;
                }

                yield return current;

                foreach (var super in current.ESuperTypes.Where(s => s != null))
                {
                    queue.Enqueue(super);
                }
            }
        }
    }
}
