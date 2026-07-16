// ------------------------------------------------------------------------------------------------
// <copyright file="AirdModelLoaderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests.Diagram
{
    using System;
    using System.IO;
    using System.Linq;

    using Auriga.Core;
    using Auriga.Diagram.Viewpoint;
    using Auriga.Xmi.Core.Readers;

    using NUnit.Framework;

    /// <summary>
    /// Exercises <see cref="AirdModelLoader"/>, the diagram-model entry point: loading a Sirius
    /// <c>.aird</c> end-to-end from its file or its project directory — transitively following the
    /// <c>referencedAnalysis</c> hrefs into <c>.airdfragment</c> siblings (URL-encoded paths and stale,
    /// renamed-on-disk fragment references included) — and its clear error surface for missing, ambiguous
    /// or non-diagram paths. The <c>.capellafragment</c> documents the diagrams href into semantically
    /// must NOT be co-loaded: that is the deliberate cross-metamodel scope of the semantic-link
    /// resolution issue, not of fragment following.
    /// </summary>
    [TestFixture]
    public class AirdModelLoaderTestFixture
    {
        private string temporaryRoot = null!;

        [SetUp]
        public void SetUp()
        {
            this.temporaryRoot = Path.Combine(Path.GetTempPath(), "auriga-aird-loader-" + Guid.NewGuid().ToString("N"));
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
        public void Verify_that_an_aird_file_loads_into_a_typed_analysis()
        {
            var result = AirdModelLoader.Create().Load(TestDataPath("coffee-machine-demo.aird"));

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<IDAnalysis>());
                Assert.That(result.Elements, Is.Not.Empty);
            });
        }

        [Test]
        public void Verify_that_the_real_fragmented_aird_loads_its_airdfragments()
        {
            XmiReaderResult result;

            try
            {
                result = AirdModelLoader.Create().Load(FragmentedProjectDirectory());
            }
            catch (InvalidDataException exception) when (exception.Message.Contains("EStringToStringMapEntry", StringComparison.Ordinal))
            {
                // sysmodel.aird uses inline ecore:EStringToStringMapEntry map entries, which have no
                // reader yet (issue #66) — the same known gap that guards three of the four fixtures in
                // AirdReaderTestFixture. Once #66 lands this test runs for real.
                Assert.Ignore($"sysmodel.aird uses inline map entries, not yet supported: {exception.Message}");
                return;
            }

            var sourceDocuments = result.Elements.Values
                .Select(element => element.SourceDocument)
                .Where(document => document != null)
                .Distinct()
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<IDAnalysis>());

                // Elements sourced from an .airdfragment prove the referencedAnalysis hrefs were followed;
                // the SysOA2_1 fragment is referenced only from other fragments, with a URL-encoded (%20)
                // href, so its presence proves transitive discovery and href decoding. The load must also
                // survive the stale reference to fragments/LA-Logical Functions-RLF-OA2.airdfragment,
                // which was renamed on disk without the href being updated.
                Assert.That(sourceDocuments, Contains.Item("fragments/LA-Logical Functions-RLF-OA2-SysOA2_1.airdfragment"));

                // The .aird also carries hundreds of semantic hrefs into .capellafragment documents;
                // a diagram session must not co-load the other metamodel family.
                Assert.That(sourceDocuments, Has.None.Matches<string>(d => d!.EndsWith(".capellafragment", StringComparison.Ordinal)));
            });
        }

        [Test]
        public void Verify_that_airdfragments_are_followed_transitively_with_url_encoded_and_stale_hrefs()
        {
            // A minimal fragmented diagram project, faithful to the real serialization (xmi:XMI wrapper,
            // viewpoint:DAnalysis roots, referencedAnalysis hrefs): the main .aird references one fragment
            // through a URL-encoded path and one stale (missing) fragment; the first fragment chains to a
            // second one; and a .capellafragment that exists on disk is referenced but must not be loaded.
            var project = this.CreateSyntheticFragmentedProject();

            var result = AirdModelLoader.Create().Load(project);

            var sourceDocuments = result.Elements.Values
                .Select(element => element.SourceDocument)
                .Where(document => document != null)
                .Distinct()
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<IDAnalysis>());

                // The %20-encoded href resolved to the on-disk "frag one.airdfragment".
                Assert.That(sourceDocuments, Contains.Item("fragments/frag one.airdfragment"));

                // The chain fragment is referenced only from the first fragment, relative to fragments/.
                Assert.That(sourceDocuments, Contains.Item("fragments/chain.airdfragment"));

                // The referenced .capellafragment exists on disk but belongs to the semantic family and
                // must not be co-loaded by a diagram session.
                Assert.That(sourceDocuments, Has.None.Matches<string>(d => d!.EndsWith(".capellafragment", StringComparison.Ordinal)));
            });
        }

        [Test]
        public void Verify_that_referenced_analyses_resolve_across_fragments()
        {
            var result = AirdModelLoader.Create().Load(this.CreateSyntheticFragmentedProject());

            var analysis = (IDAnalysis)result.Root;

            // Two of the three referencedAnalysis hrefs of the main analysis point at documents that
            // load (the URL-encoded fragment and the semantic-family one that is skipped); only the
            // loaded .airdfragment analysis resolves — the stale and the .capellafragment references
            // stay unresolved rather than aborting the load.
            Assert.Multiple(() =>
            {
                Assert.That(analysis.ReferencedAnalysis.Count, Is.EqualTo(1));
                Assert.That(((IAurigaElement)analysis.ReferencedAnalysis[0]).Id, Is.EqualTo("_frag1"));
                Assert.That(result.UnresolvedReferences, Is.Not.Empty);
            });
        }

        /// <summary>
        /// Writes the minimal synthetic fragmented diagram project into the fixture's temporary
        /// directory: <c>synthetic.aird</c> referencing <c>fragments/frag one.airdfragment</c> (URL-encoded),
        /// a missing <c>fragments/missing.airdfragment</c> and an on-disk <c>fragments/sem.capellafragment</c>;
        /// the first fragment chains to <c>fragments/chain.airdfragment</c>.
        /// </summary>
        /// <returns>the path of the synthetic <c>.aird</c> file</returns>
        private string CreateSyntheticFragmentedProject()
        {
            var fragments = Path.Combine(this.temporaryRoot, "fragments");
            Directory.CreateDirectory(fragments);

            File.WriteAllText(
                Path.Combine(this.temporaryRoot, "synthetic.aird"),
                Wrap(@"<viewpoint:DAnalysis uid='_main'>
    <referencedAnalysis xmi:type='viewpoint:DAnalysis' href='fragments/frag%20one.airdfragment#_frag1'/>
    <referencedAnalysis xmi:type='viewpoint:DAnalysis' href='fragments/missing.airdfragment#_gone'/>
    <referencedAnalysis xmi:type='viewpoint:DAnalysis' href='fragments/sem.capellafragment#_sem'/>
  </viewpoint:DAnalysis>"));

            File.WriteAllText(
                Path.Combine(fragments, "frag one.airdfragment"),
                Wrap(@"<viewpoint:DAnalysis uid='_frag1'>
    <referencedAnalysis xmi:type='viewpoint:DAnalysis' href='chain.airdfragment#_frag2'/>
  </viewpoint:DAnalysis>"));

            File.WriteAllText(
                Path.Combine(fragments, "chain.airdfragment"),
                Wrap("<viewpoint:DAnalysis uid='_frag2'/>"));

            // A semantic-family fragment that is present on disk: if the diagram session wrongly followed
            // its href, this document would load and contribute elements.
            File.WriteAllText(
                Path.Combine(fragments, "sem.capellafragment"),
                Wrap("<viewpoint:DAnalysis uid='_sem'/>"));

            return Path.Combine(this.temporaryRoot, "synthetic.aird");
        }

        /// <summary>
        /// Wraps the supplied top-level elements in the <c>xmi:XMI</c> wrapper every <c>.aird</c> /
        /// <c>.airdfragment</c> document carries, with the namespace declarations the reader needs.
        /// </summary>
        /// <param name="content">the top-level elements</param>
        /// <returns>the document text</returns>
        private static string Wrap(string content)
        {
            return "<?xml version='1.0' encoding='UTF-8'?>\n"
                + "<xmi:XMI xmi:version='2.0' xmlns:xmi='http://www.omg.org/XMI' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:viewpoint='http://www.eclipse.org/sirius/1.1.0'>\n  "
                + content
                + "\n</xmi:XMI>\n";
        }

        [Test]
        public void Verify_that_a_null_or_blank_path_is_rejected()
        {
            var loader = AirdModelLoader.Create();

            Assert.Multiple(() =>
            {
                Assert.That(() => loader.Load(null!), Throws.ArgumentException);
                Assert.That(() => loader.Load("   "), Throws.ArgumentException);
            });
        }

        [Test]
        public void Verify_that_a_missing_path_is_reported_clearly()
        {
            var missing = Path.Combine(this.temporaryRoot, "does-not-exist.aird");

            Assert.That(() => AirdModelLoader.Create().Load(missing), Throws.InstanceOf<FileNotFoundException>());
        }

        [Test]
        public void Verify_that_a_directory_without_a_diagram_file_is_reported_clearly()
        {
            Assert.That(() => AirdModelLoader.Create().Load(this.temporaryRoot), Throws.InstanceOf<FileNotFoundException>());
        }

        [Test]
        public void Verify_that_a_directory_with_several_diagram_files_is_reported_clearly()
        {
            File.WriteAllText(Path.Combine(this.temporaryRoot, "one.aird"), "<root/>");
            File.WriteAllText(Path.Combine(this.temporaryRoot, "two.aird"), "<root/>");

            Assert.That(() => AirdModelLoader.Create().Load(this.temporaryRoot), Throws.InstanceOf<InvalidDataException>());
        }

        [Test]
        public void Verify_that_a_non_diagram_file_is_reported_clearly()
        {
            var notADiagram = Path.Combine(this.temporaryRoot, "notes.txt");
            File.WriteAllText(notADiagram, "not a diagram");

            Assert.Multiple(() =>
            {
                Assert.That(() => AirdModelLoader.Create().Load(notADiagram), Throws.InstanceOf<InvalidDataException>());
                Assert.That(
                    () => AirdModelLoader.Create().Load(TestDataPath("coffee-machine-demo.capella")),
                    Throws.InstanceOf<InvalidDataException>());
            });
        }

        private static string TestDataPath(string fileName)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", fileName);
        }

        private static string FragmentedProjectDirectory()
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "fragmented-sysmodel");
        }
    }
}
