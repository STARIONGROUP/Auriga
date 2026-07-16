// ------------------------------------------------------------------------------------------------
// <copyright file="RealModelReaderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using Auriga.Core;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Auriga.Xmi.Core.Readers;

    using NUnit.Framework;

    /// <summary>
    /// Exercises the <see cref="XmiReader"/> against the real, non-trivial Capella models in
    /// <c>TestData</c> (the coffee-machine demo, the In-Flight Entertainment System, and the fragmented
    /// system model). These stress the reader far beyond the minimal fixture: every identified element
    /// must load into a typed object and the vast majority of intra-file cross-references must resolve.
    /// </summary>
    [TestFixture]
    public class RealModelReaderTestFixture
    {
        [Test]
        [TestCase("coffee-machine-demo.capella")]
        [TestCase("in-flight-entertainment-system.capella")]
        public void Verify_that_every_element_of_a_single_file_model_is_read(string fileName)
        {
            var path = ModelPath(fileName);
            var expectedIdentifiers = DistinctIdentifiers(path);

            var result = XmiReaderBuilder.Create().Build().Read(path);

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<Auriga.Model.Capellamodeller.IProject>());
                Assert.That(result.Elements, Has.Count.EqualTo(expectedIdentifiers.Count));
                Assert.That(result.Elements.Values, Has.All.Matches<IAurigaElement>(e => !string.IsNullOrEmpty(e.Id)));
                Assert.That(result.Elements.Keys, Is.EquivalentTo(expectedIdentifiers));
            });
        }

        [Test]
        [TestCase("coffee-machine-demo.capella")]
        [TestCase("in-flight-entertainment-system.capella")]
        public void Verify_that_intra_file_references_resolve(string fileName)
        {
            var result = XmiReaderBuilder.Create().Build().Read(ModelPath(fileName));

            var (total, resolved) = CountReferences(result);

            Assert.That(total, Is.GreaterThan(0), "the model is expected to contain cross-references");
            Assert.That(resolved, Is.EqualTo(total), "every intra-file reference of a single-file model should resolve");
        }

        [Test]
        public void Verify_that_a_fragmented_model_loads_as_one_resolved_graph()
        {
            // The system model is split across sysmodel.capella and four .capellafragment files. Reading
            // the main file must transitively load the fragments into one object graph, so every element
            // defined in any file is present and cross-fragment href references resolve to real objects.
            var mainPath = FragmentedModelPath();
            var expectedIdentifiers = DistinctIdentifiersAcross(ModelFiles(mainPath));

            var result = XmiReaderBuilder.Create().Build().Read(mainPath);

            // Cross-fragment href references whose target was loaded from another fragment: the model
            // genuinely exercises cross-fragment resolution.
            var crossFragmentToLoaded = result.Elements.Values
                .SelectMany(ReferenceTokens)
                .Where(t => t.Contains(".capellafragment#"))
                .Count(t => expectedIdentifiers.Contains(FragmentUuid(t)));

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<Auriga.Model.Capellamodeller.IProject>());
                Assert.That(result.Elements.Keys, Is.EquivalentTo(expectedIdentifiers));
                Assert.That(crossFragmentToLoaded, Is.GreaterThan(50), "the fixture exercises cross-fragment references");

                // The fixture is a near-complete export: the only references that stay unresolved are the
                // few whose target is absent from every provided file. No reference to a loaded element may
                // remain unresolved.
                Assert.That(
                    result.UnresolvedReferences.Where(u => expectedIdentifiers.Contains(FragmentUuid(u.TargetIdentifier))),
                    Is.Empty,
                    "no reference to an element present in the provided files is left unresolved");
            });
        }

        [Test]
        public void Verify_that_every_element_tracks_its_source_document()
        {
            var result = XmiReaderBuilder.Create().Build().Read(FragmentedModelPath());

            var sources = result.Elements.Values.Select(e => e.SourceDocument).Distinct().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(result.Elements.Values, Has.All.Matches<IAurigaElement>(e => !string.IsNullOrEmpty(e.SourceDocument)));
                Assert.That(sources, Has.Some.EqualTo("sysmodel.capella"), "elements from the main file are tracked to it");
                Assert.That(
                    sources,
                    Has.Some.Matches<string>(s => s.StartsWith("fragments/") && s.EndsWith(".capellafragment")),
                    "elements from a fragment are tracked to their fragment file");
            });
        }

        private static (int Total, int Resolved) CountReferences(XmiReaderResult result)
        {
            var total = 0;
            var resolved = 0;

            foreach (var element in result.Elements.Values)
            {
                foreach (var id in element.SingleValueReferencePropertyIdentifiers.Values)
                {
                    total++;
                    if (result.Elements.ContainsKey(id))
                    {
                        resolved++;
                    }
                }

                foreach (var ids in element.MultiValueReferencePropertyIdentifiers.Values)
                {
                    foreach (var id in ids)
                    {
                        total++;
                        if (result.Elements.ContainsKey(id))
                        {
                            resolved++;
                        }
                    }
                }
            }

            return (total, resolved);
        }

        private static HashSet<string> DistinctIdentifiers(string path)
        {
            var text = File.ReadAllText(path);
            return Regex.Matches(text, "\\sid=\"([^\"]+)\"")
                .Select(m => m.Groups[1].Value)
                .ToHashSet(System.StringComparer.Ordinal);
        }

        private static string FragmentUuid(string token)
        {
            var separator = token.IndexOf('#');
            return separator >= 0 ? token.Substring(separator + 1) : token;
        }

        private static IEnumerable<string> ReferenceTokens(IAurigaElement element)
        {
            foreach (var token in element.SingleValueReferencePropertyIdentifiers.Values)
            {
                yield return token;
            }

            foreach (var tokens in element.MultiValueReferencePropertyIdentifiers.Values)
            {
                foreach (var token in tokens)
                {
                    yield return token;
                }
            }
        }

        private static HashSet<string> DistinctIdentifiersAcross(IEnumerable<string> paths)
        {
            var identifiers = new HashSet<string>(System.StringComparer.Ordinal);
            foreach (var path in paths)
            {
                identifiers.UnionWith(DistinctIdentifiers(path));
            }

            return identifiers;
        }

        private static string ModelPath(string fileName)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", fileName);
        }

        private static string FragmentedModelPath()
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "fragmented-sysmodel", "sysmodel.capella");
        }

        private static IEnumerable<string> ModelFiles(string mainPath)
        {
            var directory = Path.GetDirectoryName(mainPath)!;

            return new[] { mainPath }
                .Concat(Directory.EnumerateFiles(Path.Combine(directory, "fragments"), "*.capellafragment"));
        }
    }
}
