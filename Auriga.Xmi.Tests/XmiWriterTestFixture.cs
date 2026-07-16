// ------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterTestFixture.cs" company="Starion Group S.A.">
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
    using System.Text;

    using Auriga.Xmi.Core.Readers;

    using NUnit.Framework;

    /// <summary>
    /// Round-trip tests for the XMI writer: reading a fixture, writing it back, and reading the result
    /// again must reproduce an equivalent object graph (issue #17). Formatting differences (attribute
    /// line-wrapping, ordering, the version comment) are benign and not asserted.
    /// </summary>
    [TestFixture]
    public class XmiWriterTestFixture
    {
        [Test]
        public void Verify_that_the_minimal_model_round_trips()
        {
            const string document = "minimal.melodymodeller";
            var original = XmiReaderBuilder.Create().Build().Read(ModelFile(document));

            var xml = WriteDocument(original.Root, document);

            Assert.Multiple(() =>
            {
                Assert.That(xml, Does.Contain("xsi:type=\"org.polarsys.capella.core.data.pa:PhysicalFunction\""));
                Assert.That(xml, Does.Contain("xsi:type=\"org.polarsys.capella.core.data.fa:FunctionalExchange\""));
                Assert.That(xml, Does.Contain("nature=\"NODE\""));
                Assert.That(xml, Does.Contain("name=\"Root Physical Function\""));
                Assert.That(xml, Does.Contain("source=\"#a0000000-0000-4000-8000-000000000013\""));
                Assert.That(xml, Does.Contain("xmlns:org.polarsys.capella.core.data.pa.deployment="));
                Assert.That(xml, Does.Not.Contain("xmlns:org.polarsys.capella.core.data.oa="), "only used namespaces are declared");
            });

            var roundTripped = ReadDocument(xml, document);

            AssertEquivalent(original, roundTripped);
        }

        [Test]
        public void Verify_that_writing_the_whole_project_reproduces_the_fragment_layout()
        {
            var original = XmiReaderBuilder.Create().Build().Read(ModelFile("fragmented-sysmodel/sysmodel.capella"));

            var directory = Path.Combine(Path.GetTempPath(), "auriga-writer-" + System.Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);

            try
            {
                var mainPath = Path.Combine(directory, "sysmodel.capella");
                XmiWriterBuilder.Create().Build().Write(original.Root, mainPath);

                Assert.That(File.Exists(mainPath), Is.True, "the main document is written");

                var fragmentFiles = Directory.GetFiles(directory, "*.capellafragment", SearchOption.AllDirectories);
                Assert.That(fragmentFiles, Is.Not.Empty, "at least one fragment is written");

                var mainText = File.ReadAllText(mainPath);
                Assert.That(mainText, Does.Contain(".capellafragment#"), "a cross-document href is written");

                var roundTripped = XmiReaderBuilder.Create().Build().Read(mainPath);

                AssertEquivalent(original, roundTripped);
            }
            finally
            {
                Directory.Delete(directory, recursive: true);
            }
        }

        [Test]
        public void Verify_that_a_new_element_is_written_into_its_containers_document()
        {
            var original = XmiReaderBuilder.Create().Build().Read(ModelFile("fragmented-sysmodel/sysmodel.capella"));

            // A container that was read from a fragment file, and a brand-new element (no SourceDocument of
            // its own) added to it. The policy is that an untracked new element belongs to its container's
            // document, so it must be written into the fragment — not the main file.
            var container = (Auriga.Model.Modellingcore.IModelElement)original.Elements.Values
                .First(e => e.SourceDocument is string document && document.EndsWith(".capellafragment", System.StringComparison.Ordinal));

            var newElement = new Auriga.Model.Capellacore.Constraint { Id = "aabbccdd-0000-4000-8000-000000000f18" };
            container.OwnedConstraints.Add(newElement);

            Assert.That(newElement.SourceDocument, Is.Null, "the new element has no source document of its own");

            var directory = Path.Combine(Path.GetTempPath(), "auriga-writer-" + System.Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);

            try
            {
                var mainPath = Path.Combine(directory, "sysmodel.capella");
                XmiWriterBuilder.Create().Build().Write(original.Root, mainPath);

                var fragmentPath = Path.Combine(directory, container.SourceDocument!.Replace('/', Path.DirectorySeparatorChar));

                Assert.Multiple(() =>
                {
                    Assert.That(File.ReadAllText(fragmentPath), Does.Contain(newElement.Id), "the new element is written into its container's fragment");
                    Assert.That(File.ReadAllText(mainPath), Does.Not.Contain(newElement.Id), "the new element is not written into the main document");
                });
            }
            finally
            {
                Directory.Delete(directory, recursive: true);
            }
        }

        [Test]
        public void Verify_that_the_writer_guards_its_arguments()
        {
            var writer = XmiWriterBuilder.Create().Build();
            using var stream = new MemoryStream();

            Assert.Multiple(() =>
            {
                Assert.That(() => writer.Write(null!, "x.capella"), Throws.ArgumentNullException);
                Assert.That(() => writer.Write(new Auriga.Model.Capellamodeller.Project(), string.Empty), Throws.ArgumentException);
                Assert.That(() => writer.WriteDocument(null!, stream, "x"), Throws.ArgumentNullException);
                Assert.That(() => writer.WriteDocument(new Auriga.Model.Capellamodeller.Project(), null!, "x"), Throws.ArgumentNullException);
                Assert.That(() => writer.WriteDocument(new Auriga.Model.Capellamodeller.Project(), stream, string.Empty), Throws.ArgumentException);
            });
        }

        private static string WriteDocument(IAurigaElement root, string document)
        {
            using var stream = new MemoryStream();
            XmiWriterBuilder.Create().Build().WriteDocument(root, stream, document);
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        private static XmiReaderResult ReadDocument(string xml, string document)
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            return XmiReaderBuilder.Create().Build().Read(stream, document);
        }

        private static void AssertEquivalent(XmiReaderResult expected, XmiReaderResult actual)
        {
            Assert.Multiple(() =>
            {
                // A reference token round-trips to the same target, but its encoding may differ (a cross-
                // document href re-reads without the original's optional xsi:type prefix), so references and
                // dangling references are compared by the target xmi:id, not by the raw token.
                Assert.That(Dangling(actual), Is.EquivalentTo(Dangling(expected)), "the same references dangle");
                Assert.That(actual.Elements.Keys, Is.EquivalentTo(expected.Elements.Keys), "the same elements are present");

                foreach (var id in expected.Elements.Keys)
                {
                    var a = expected.Elements[id];
                    var b = actual.Elements[id];

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
            var references = new SortedDictionary<string, string>(System.StringComparer.Ordinal);
            foreach (var pair in element.SingleValueReferencePropertyIdentifiers)
            {
                references[pair.Key] = TargetId(pair.Value);
            }

            return references;
        }

        private static SortedDictionary<string, string> MultiRefs(IAurigaElement element)
        {
            var flattened = new SortedDictionary<string, string>(System.StringComparer.Ordinal);
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

        private static string ModelFile(string relativePath)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", relativePath.Replace('/', Path.DirectorySeparatorChar));
        }
    }
}
