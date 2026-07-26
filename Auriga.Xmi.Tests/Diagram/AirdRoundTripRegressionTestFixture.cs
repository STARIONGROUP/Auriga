// ------------------------------------------------------------------------------------------------
// <copyright file="AirdRoundTripRegressionTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests.Diagram
{
    using Auriga.Core;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;

    using Auriga.Xmi.Core.Readers;

    using NUnit.Framework;

    /// <summary>
    /// The round-trip regression suite for Sirius <c>.aird</c> diagram files, the counterpart
    /// of <see cref="RoundTripRegressionTestFixture"/> for the Capella semantic models. For every
    /// <c>.aird</c> fixture under <c>TestData/</c> it reads the model, writes it back, re-reads the result
    /// and asserts the two object graphs are equivalent — proving read → write → read is stable.
    ///
    /// <para>An <c>.aird</c> is a multi-root <c>xmi:XMI</c> document: one <c>viewpoint:DAnalysis</c> plus N
    /// parallel representation roots that are not contained under it, reachable only through
    /// <see cref="XmiReaderResult.Elements"/>. The suite therefore gathers every top-level root (each
    /// element whose <see cref="IAurigaElement.Container"/> is <c>null</c>) and writes them together through
    /// the multi-root <see cref="IXmiWriter.Write(System.Collections.Generic.IReadOnlyCollection{IAurigaElement}, string)"/>
    /// overload.</para>
    /// </summary>
    [TestFixture]
    public class AirdRoundTripRegressionTestFixture
    {
        /// <summary>
        /// Reads every <c>.aird</c> fixture, writes it back (preserving the <c>.aird</c> / <c>.airdfragment</c>
        /// fragment layout), reads the result, and asserts the two object graphs are equivalent.
        /// </summary>
        /// <param name="relativePath">the fixture's main <c>.aird</c> file, relative to <c>TestData/</c></param>
        [TestCaseSource(nameof(Fixtures))]
        public void Verify_that_the_aird_round_trips_semantically(string relativePath)
        {
            var mainPath = FixturePath(relativePath);
            var original = ReadSupportedOrIgnore(mainPath);
            var directory = CreateTempDirectory();

            try
            {
                var outputPath = Path.Combine(directory, Path.GetFileName(mainPath));
                XmiWriterBuilder.Create().Build().Write(TopLevelRoots(original), outputPath);

                var roundTripped = XmiReaderBuilder.Create().Build().Read(outputPath);

                AssertEquivalent(original, roundTripped);
            }
            finally
            {
                Directory.Delete(directory, recursive: true);
            }
        }

        /// <summary>
        /// Reads every <c>.aird</c> fixture, writes it back, and asserts that no simple-attribute value was
        /// dropped — the scalar-fidelity half of the round-trip guarantee.
        ///
        /// <para>This is where the multi-valued simple attributes are most dense: a Sirius
        /// <c>DAnalysis</c>'s <c>semanticResources</c> (its <c>.afm</c> / <c>.capella</c> pointers, without
        /// which the written <c>.aird</c> no longer names its semantic model) and every
        /// <c>DDiagramElement</c>'s <c>arrangeConstraints</c>. The semantic round-trip cannot see these:
        /// dropping a list of strings leaves the object graph structurally identical.</para>
        /// </summary>
        /// <param name="relativePath">the fixture's main <c>.aird</c> file, relative to <c>TestData/</c></param>
        [TestCaseSource(nameof(Fixtures))]
        public void Verify_that_no_simple_attribute_values_are_dropped(string relativePath)
        {
            var mainPath = FixturePath(relativePath);
            var original = ReadSupportedOrIgnore(mainPath);
            var originalDirectory = Path.GetDirectoryName(mainPath)!;
            var directory = CreateTempDirectory();

            try
            {
                XmiWriterBuilder.Create().Build().Write(TopLevelRoots(original), Path.Combine(directory, Path.GetFileName(mainPath)));

                var dropped = new List<string>();
                foreach (var writtenFile in Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories).OrderBy(p => p, StringComparer.Ordinal))
                {
                    var relative = Path.GetRelativePath(directory, writtenFile);
                    var originalFile = Path.Combine(originalDirectory, relative);

                    if (File.Exists(originalFile))
                    {
                        dropped.AddRange(SimpleAttributeFidelity
                            .Dropped(System.Xml.Linq.XDocument.Load(originalFile), System.Xml.Linq.XDocument.Load(writtenFile))
                            .Select(difference => $"{relative}: {difference}"));
                    }
                }

                Assert.That(dropped, Is.Empty, "simple-attribute values lost on write:\n  " + string.Join("\n  ", dropped.Take(20)));
            }
            finally
            {
                Directory.Delete(directory, recursive: true);
            }
        }

        /// <summary>
        /// The top-level roots of a read <c>.aird</c>, in read order with the returned <see cref="XmiReaderResult.Root"/>
        /// first: the <c>viewpoint:DAnalysis</c> and every representation root the reader loaded as a parallel
        /// top-level element (those whose <see cref="IAurigaElement.Container"/> is <c>null</c>).
        /// </summary>
        /// <param name="result">the read result</param>
        /// <returns>the ordered top-level roots</returns>
        private static List<IAurigaElement> TopLevelRoots(XmiReaderResult result)
        {
            var roots = new List<IAurigaElement> { result.Root };
            roots.AddRange(result.Elements.Values.Where(element => element.Container is null && !ReferenceEquals(element, result.Root)));
            return roots;
        }

        /// <summary>
        /// Guards against a broken or incomplete <c>TestData</c> deployment silently reducing the
        /// round-trip suite to zero cases: asserts the enumeration discovers the committed <c>.aird</c>
        /// fixtures. Every model file is thereby read and written by
        /// <see cref="Verify_that_the_aird_round_trips_semantically"/> (the <c>.airdfragment</c> files are
        /// pulled in transitively by <c>sysmodel.aird</c>).
        /// </summary>
        private static readonly string[] ExpectedAirdFixtures =
        {
            "coffee-machine-demo.aird",
            "Crowd_Surveillance_System_in_DARC.aird",
            "In-Flight Entertainment System.aird",
            "Level Crossing Traffic Control.aird",
            "sysmodel.aird",
        };

        [Test]
        public void Verify_that_every_aird_fixture_is_discovered()
        {
            var discovered = Fixtures().Select(Path.GetFileName).ToList();

            Assert.That(discovered, Is.SupersetOf(ExpectedAirdFixtures), "an expected .aird fixture is missing from the TestData deployment");
        }

        /// <summary>
        /// The main <c>.aird</c> file of every fixture under <c>TestData/</c> (its <c>.airdfragment</c>
        /// fragments are pulled in by their main file, so they are not enumerated directly).
        /// </summary>
        /// <returns>the fixture test cases</returns>
        private static IEnumerable<string> Fixtures()
        {
            var directory = TestDataDirectory();
            if (!Directory.Exists(directory))
            {
                yield break;
            }

            var mains = Directory.EnumerateFiles(directory, "*.aird", SearchOption.AllDirectories)
                .OrderBy(path => path, StringComparer.Ordinal);

            foreach (var path in mains)
            {
                yield return Path.GetRelativePath(directory, path);
            }
        }

        private static string TestDataDirectory()
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");
        }

        private static string FixturePath(string relativePath)
        {
            return Path.Combine(TestDataDirectory(), relativePath);
        }

        /// <summary>
        /// Reads the fixture, or ignores the test when the <c>.aird</c> is out of scope: the <c>Level
        /// Crossing Traffic Control</c> sample carries an illegal raw <c>U+001A</c> control character and so
        /// cannot be parsed as XML (a fixture defect, not a reader defect — documented in
        /// <c>TestData/README.md</c>), and a model referencing a package outside the vendored metamodel is an
        /// add-on viewpoint the v1 reader does not support.
        /// </summary>
        /// <param name="mainPath">the fixture's main <c>.aird</c> file</param>
        /// <returns>the read result</returns>
        private static XmiReaderResult ReadSupportedOrIgnore(string mainPath)
        {
            try
            {
                return XmiReaderBuilder.Create().Build().Read(mainPath);
            }
            catch (XmlException exception)
            {
                Assert.Ignore($"{Path.GetFileName(mainPath)} is not well-formed XML ({exception.Message}); round-trip is out of scope (see TestData/README.md).");
                throw; // unreachable — Assert.Ignore throws
            }
            catch (InvalidDataException exception) when (exception.Message.Contains("to a known package", StringComparison.Ordinal))
            {
                Assert.Ignore($"{Path.GetFileName(mainPath)} references a package outside the vendored metamodel (an add-on viewpoint the v1 reader does not support): {exception.Message}");
                throw; // unreachable — Assert.Ignore throws
            }
        }

        private static string CreateTempDirectory()
        {
            var directory = Path.Combine(Path.GetTempPath(), "auriga-aird-roundtrip-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);
            return directory;
        }

        // ---- semantic round-trip --------------------------------------------------------------------

        private static void AssertEquivalent(XmiReaderResult expected, XmiReaderResult actual)
        {
            Assert.Multiple(() =>
            {
                Assert.That(Dangling(actual), Is.EquivalentTo(Dangling(expected)), "the same references dangle");
                Assert.That(actual.Elements.Keys, Is.EquivalentTo(expected.Elements.Keys), "the same elements are present");

                foreach (var id in expected.Elements.Keys)
                {
                    if (!actual.Elements.TryGetValue(id, out var b))
                    {
                        continue;
                    }

                    var a = expected.Elements[id];

                    Assert.That(b.GetType(), Is.EqualTo(a.GetType()), $"type of {id}");
                    Assert.That(b.Container?.Id, Is.EqualTo(a.Container?.Id), $"container of {id}");
                    Assert.That(b.SourceDocument, Is.EqualTo(a.SourceDocument), $"source document of {id}");
                    Assert.That(SingleRefs(b), Is.EqualTo(SingleRefs(a)), $"single references of {id}");
                    Assert.That(MultiRefs(b), Is.EqualTo(MultiRefs(a)), $"multi references of {id}");
                }
            });
        }

        private static List<string> Dangling(XmiReaderResult result)
        {
            return result.UnresolvedReferences
                .Select(reference => $"{reference.OwningElementId}.{reference.PropertyName}->{TargetId(reference.TargetIdentifier)}")
                .ToList();
        }

        private static SortedDictionary<string, string> SingleRefs(IAurigaElement element)
        {
            var references = new SortedDictionary<string, string>(StringComparer.Ordinal);
            foreach (var pair in element.SingleValueReferencePropertyIdentifiers)
            {
                references[pair.Key] = TargetId(pair.Value);
            }

            return references;
        }

        private static SortedDictionary<string, string> MultiRefs(IAurigaElement element)
        {
            var flattened = new SortedDictionary<string, string>(StringComparer.Ordinal);
            foreach (var pair in element.MultiValueReferencePropertyIdentifiers)
            {
                flattened[pair.Key] = string.Join(" ", pair.Value.Select(TargetId));
            }

            return flattened;
        }

        private static string TargetId(string token)
        {
            var hash = token.LastIndexOf('#');
            return hash >= 0 ? token.Substring(hash + 1) : token;
        }
    }
}
