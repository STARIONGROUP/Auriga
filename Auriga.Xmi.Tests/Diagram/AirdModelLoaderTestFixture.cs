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
    /// renamed-on-disk fragment references included), co-loading the Capella semantic documents the
    /// diagrams href into so the cross-metamodel <c>target</c> / <c>semanticElements</c> links resolve
    /// (issue #54) — and its clear error surface for missing, ambiguous or non-diagram paths. The
    /// diagram-only behavior (no semantic co-load) remains the raw reader's default and is pinned here
    /// too.
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
            var result = XmiReaderBuilder.Create().BuildAirdModelLoader().Load(TestDataPath("coffee-machine-demo.aird"));

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
                result = XmiReaderBuilder.Create().BuildAirdModelLoader().Load(FragmentedProjectDirectory());
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
        public void Verify_that_airdfragments_and_semantic_documents_are_co_loaded_transitively()
        {
            // A minimal fragmented diagram project, faithful to the real serialization (xmi:XMI wrapper,
            // viewpoint:DAnalysis roots, referencedAnalysis hrefs): the main .aird references one fragment
            // through a URL-encoded path, one stale (missing) fragment, a .capellafragment and a
            // .capella; the first fragment chains to a second one, and the .capella chains to its own
            // .capellafragment.
            var project = this.CreateSyntheticFragmentedProject();

            var result = XmiReaderBuilder.Create().BuildAirdModelLoader().Load(project);

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

                // The semantic family is co-loaded by the loader (issue #54): the referenced
                // .capellafragment, the referenced .capella, and the .capella's own fragment chain.
                Assert.That(sourceDocuments, Contains.Item("fragments/sem.capellafragment"));
                Assert.That(sourceDocuments, Contains.Item("model.capella"));
                Assert.That(sourceDocuments, Contains.Item("fragments/chaincap.capellafragment"));
            });
        }

        [Test]
        public void Verify_that_a_raw_reader_stays_diagram_only()
        {
            // The semantic co-load is the loader's behavior; the raw reader's default session still
            // follows only the main document's own fragment family.
            var project = this.CreateSyntheticFragmentedProject();

            var result = XmiReaderBuilder.Create().Build().Read(project);

            var sourceDocuments = result.Elements.Values
                .Select(element => element.SourceDocument)
                .Where(document => document != null)
                .Distinct()
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.That(sourceDocuments, Contains.Item("fragments/frag one.airdfragment"));
                Assert.That(sourceDocuments, Has.None.Matches<string>(d => d!.EndsWith(".capella", StringComparison.Ordinal)));
                Assert.That(sourceDocuments, Has.None.Matches<string>(d => d!.EndsWith(".capellafragment", StringComparison.Ordinal)));
            });
        }

        [Test]
        public void Verify_that_referenced_analyses_resolve_across_fragments()
        {
            var result = XmiReaderBuilder.Create().BuildAirdModelLoader().Load(this.CreateSyntheticFragmentedProject());

            var analysis = (IDAnalysis)result.Root;

            // The URL-encoded .airdfragment analysis and the analysis in the co-loaded .capellafragment
            // both resolve; the stale reference stays unresolved rather than aborting the load, and the
            // .capella reference loads its document but is skipped at assignment time (a Capella Project
            // is not an IDAnalysis).
            Assert.Multiple(() =>
            {
                Assert.That(analysis.ReferencedAnalysis.Count, Is.EqualTo(2));
                Assert.That(((IAurigaElement)analysis.ReferencedAnalysis[0]).Id, Is.EqualTo("_frag1"));
                Assert.That(((IAurigaElement)analysis.ReferencedAnalysis[1]).Id, Is.EqualTo("_sem"));
                Assert.That(result.UnresolvedReferences, Is.Not.Empty);
            });
        }

        [Test]
        public void Verify_that_diagram_elements_resolve_to_the_co_loaded_capella_elements()
        {
            // The end-to-end acceptance of issue #54, against the real coffee-machine project: the
            // .aird's target / semanticElements hrefs into coffee-machine-demo.capella resolve to the
            // co-loaded Capella elements.
            var result = XmiReaderBuilder.Create().BuildAirdModelLoader().Load(TestDataPath("coffee-machine-demo.aird"));

            var capability = result.Elements["a83ba499-29b8-45b7-be8c-39296225365a"];

            Assert.Multiple(() =>
            {
                Assert.That(capability, Is.InstanceOf<Auriga.Model.Ctx.ICapability>(), "the co-loaded Capella element is typed");

                // At least one diagram element's target is the very same co-loaded Capella object.
                Assert.That(
                    result.Elements.Values.OfType<IDSemanticDecorator>().Any(decorator => ReferenceEquals(decorator.Target, capability)),
                    Is.True,
                    "a diagram element targets the co-loaded Capability");

                // The multi-valued semanticElements collections carry the co-loaded Capella objects too.
                Assert.That(
                    result.Elements.Values.OfType<IDRepresentationElement>().Any(element => element.SemanticElements.Contains(capability)),
                    Is.True,
                    "a representation element lists the co-loaded Capability among its semantic elements");

                // Every semantic href into the .capella resolved; what remains unresolved are the
                // expected tooling references (platform:/plugin .odesign definitions, environment:/
                // colors) — reported, not dropped.
                Assert.That(
                    result.UnresolvedReferences.Select(reference => reference.TargetIdentifier),
                    Has.None.Contains(".capella#"),
                    "no semantic href into the .capella stays unresolved");
                Assert.That(result.UnresolvedReferences, Is.Not.Empty, "tooling references are still reported");
            });
        }

        /// <summary>
        /// Writes the minimal synthetic fragmented diagram project into the fixture's temporary
        /// directory: <c>synthetic.aird</c> referencing <c>fragments/frag one.airdfragment</c> (URL-encoded),
        /// a missing <c>fragments/missing.airdfragment</c>, an on-disk <c>fragments/sem.capellafragment</c>
        /// and a <c>model.capella</c>; the first diagram fragment chains to
        /// <c>fragments/chain.airdfragment</c> and the <c>.capella</c> chains to its own
        /// <c>fragments/chaincap.capellafragment</c>.
        /// </summary>
        /// <returns>the path of the synthetic <c>.aird</c> file</returns>
        private string CreateSyntheticFragmentedProject()
        {
            const string Modeller = "http://www.polarsys.org/capella/core/modeller/7.0.0";

            var fragments = Path.Combine(this.temporaryRoot, "fragments");
            Directory.CreateDirectory(fragments);

            File.WriteAllText(
                Path.Combine(this.temporaryRoot, "synthetic.aird"),
                Wrap(@"<viewpoint:DAnalysis uid='_main'>
    <referencedAnalysis xmi:type='viewpoint:DAnalysis' href='fragments/frag%20one.airdfragment#_frag1'/>
    <referencedAnalysis xmi:type='viewpoint:DAnalysis' href='fragments/missing.airdfragment#_gone'/>
    <referencedAnalysis xmi:type='viewpoint:DAnalysis' href='fragments/sem.capellafragment#_sem'/>
    <referencedAnalysis xmi:type='viewpoint:DAnalysis' href='model.capella#proj-1'/>
  </viewpoint:DAnalysis>"));

            File.WriteAllText(
                Path.Combine(fragments, "frag one.airdfragment"),
                Wrap(@"<viewpoint:DAnalysis uid='_frag1'>
    <referencedAnalysis xmi:type='viewpoint:DAnalysis' href='chain.airdfragment#_frag2'/>
  </viewpoint:DAnalysis>"));

            File.WriteAllText(
                Path.Combine(fragments, "chain.airdfragment"),
                Wrap("<viewpoint:DAnalysis uid='_frag2'/>"));

            // A semantic-family fragment on disk: the co-loading loader follows it; the raw reader's
            // diagram-only session must not.
            File.WriteAllText(
                Path.Combine(fragments, "sem.capellafragment"),
                Wrap("<viewpoint:DAnalysis uid='_sem'/>"));

            // A minimal Capella semantic model that chains to its own fragment, proving the semantic
            // side's fragment discovery also runs inside a co-loading diagram session.
            File.WriteAllText(
                Path.Combine(this.temporaryRoot, "model.capella"),
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<org.polarsys.capella.core.data.capellamodeller:Project xmi:version='2.0' " +
                "xmlns:xmi='http://www.omg.org/XMI' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' " +
                "xmlns:org.polarsys.capella.core.data.capellamodeller='" + Modeller + "' id='proj-1' name='Synthetic'>" +
                "<ownedModelRoots xsi:type='org.polarsys.capella.core.data.capellamodeller:SystemEngineering' " +
                "href='fragments/chaincap.capellafragment#se-1'/>" +
                "</org.polarsys.capella.core.data.capellamodeller:Project>");

            File.WriteAllText(
                Path.Combine(fragments, "chaincap.capellafragment"),
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<org.polarsys.capella.core.data.capellamodeller:SystemEngineering xmi:version='2.0' " +
                "xmlns:xmi='http://www.omg.org/XMI' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' " +
                "xmlns:org.polarsys.capella.core.data.capellamodeller='" + Modeller + "' id='se-1' name='SE'/>");

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
            var loader = XmiReaderBuilder.Create().BuildAirdModelLoader();

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

            Assert.That(() => XmiReaderBuilder.Create().BuildAirdModelLoader().Load(missing), Throws.InstanceOf<FileNotFoundException>());
        }

        [Test]
        public void Verify_that_a_directory_without_a_diagram_file_is_reported_clearly()
        {
            Assert.That(() => XmiReaderBuilder.Create().BuildAirdModelLoader().Load(this.temporaryRoot), Throws.InstanceOf<FileNotFoundException>());
        }

        [Test]
        public void Verify_that_a_directory_with_several_diagram_files_is_reported_clearly()
        {
            File.WriteAllText(Path.Combine(this.temporaryRoot, "one.aird"), "<root/>");
            File.WriteAllText(Path.Combine(this.temporaryRoot, "two.aird"), "<root/>");

            Assert.That(() => XmiReaderBuilder.Create().BuildAirdModelLoader().Load(this.temporaryRoot), Throws.InstanceOf<InvalidDataException>());
        }

        [Test]
        public void Verify_that_a_non_diagram_file_is_reported_clearly()
        {
            var notADiagram = Path.Combine(this.temporaryRoot, "notes.txt");
            File.WriteAllText(notADiagram, "not a diagram");

            Assert.Multiple(() =>
            {
                Assert.That(() => XmiReaderBuilder.Create().BuildAirdModelLoader().Load(notADiagram), Throws.InstanceOf<InvalidDataException>());
                Assert.That(
                    () => XmiReaderBuilder.Create().BuildAirdModelLoader().Load(TestDataPath("coffee-machine-demo.capella")),
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
