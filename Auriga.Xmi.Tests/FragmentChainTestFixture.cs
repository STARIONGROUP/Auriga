// ------------------------------------------------------------------------------------------------
// <copyright file="FragmentChainTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using Auriga.Core;
    using System;
    using System.IO;
    using System.Linq;

    using Auriga.Xmi.Core.Readers;

    using NUnit.Framework;

    /// <summary>
    /// Verifies the uml4net-style transitive, document-relative fragment loading: a main file references
    /// fragment <c>a</c>, and fragment <c>a</c> references fragment <c>b</c> that the main file never
    /// names. Both hrefs are resolved relative to their own referring document, and the whole chain loads
    /// into one resolved graph.
    /// </summary>
    [TestFixture]
    public class FragmentChainTestFixture
    {
        private const string Modeller = "http://www.polarsys.org/capella/core/modeller/7.0.0";
        private const string Pa = "http://www.polarsys.org/capella/core/pa/7.0.0";

        private static readonly string[] ExpectedElementKeys = { "proj-1", "se-1", "pa-1" };

        private string directory = null!;
        private XmiReaderResult result = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.directory = Path.Combine(Path.GetTempPath(), "auriga-fragment-chain-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(Path.Combine(this.directory, "fragments"));

            // main references fragment a (fragments/a); fragment a references fragment b (a sibling, so a
            // path relative to the fragments/ directory) — the main never mentions b.
            File.WriteAllText(
                Path.Combine(this.directory, "chain.capella"),
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<org.polarsys.capella.core.data.capellamodeller:Project xmi:version=\"2.0\" " +
                "xmlns:xmi=\"http://www.omg.org/XMI\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:org.polarsys.capella.core.data.capellamodeller=\"" + Modeller + "\" id=\"proj-1\" name=\"Chain\">" +
                "<ownedModelRoots xsi:type=\"org.polarsys.capella.core.data.capellamodeller:SystemEngineering\" " +
                "href=\"fragments/a.capellafragment#se-1\"/>" +
                "</org.polarsys.capella.core.data.capellamodeller:Project>");

            File.WriteAllText(
                Path.Combine(this.directory, "fragments", "a.capellafragment"),
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<org.polarsys.capella.core.data.capellamodeller:SystemEngineering xmi:version=\"2.0\" " +
                "xmlns:xmi=\"http://www.omg.org/XMI\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:org.polarsys.capella.core.data.capellamodeller=\"" + Modeller + "\" " +
                "xmlns:org.polarsys.capella.core.data.pa=\"" + Pa + "\" id=\"se-1\" name=\"SE\">" +
                "<ownedArchitectures xsi:type=\"org.polarsys.capella.core.data.pa:PhysicalArchitecture\" " +
                "href=\"b.capellafragment#pa-1\"/>" +
                "</org.polarsys.capella.core.data.capellamodeller:SystemEngineering>");

            File.WriteAllText(
                Path.Combine(this.directory, "fragments", "b.capellafragment"),
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<org.polarsys.capella.core.data.pa:PhysicalArchitecture xmi:version=\"2.0\" " +
                "xmlns:xmi=\"http://www.omg.org/XMI\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:org.polarsys.capella.core.data.pa=\"" + Pa + "\" id=\"pa-1\" name=\"PA\"/>");

            this.result = XmiReaderBuilder.Create().Build().Read(Path.Combine(this.directory, "chain.capella"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (Directory.Exists(this.directory))
            {
                Directory.Delete(this.directory, recursive: true);
            }
        }

        [Test]
        public void Verify_that_the_whole_fragment_chain_loads()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.result.Elements.Keys, Is.EquivalentTo(ExpectedElementKeys));
                Assert.That(this.result.UnresolvedReferences, Is.Empty);
            });
        }

        [Test]
        public void Verify_that_a_fragment_referencing_another_fragment_resolves()
        {
            var project = (Auriga.Model.Capellamodeller.IProject)this.result.Root;
            var systemEngineering = project.OwnedModelRoots.OfType<Auriga.Model.Capellamodeller.ISystemEngineering>().Single();

            Assert.Multiple(() =>
            {
                // main -> fragment a (cross-document containment resolved into the collection)
                Assert.That(systemEngineering.Id, Is.EqualTo("se-1"));

                // fragment a -> fragment b (the main never names b; resolved relative to a's own directory)
                var architecture = systemEngineering.OwnedArchitectures.Single();
                Assert.That(architecture, Is.SameAs(this.result.Elements["pa-1"]));
            });
        }

        [Test]
        public void Verify_that_each_element_tracks_its_own_fragment()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.result.Elements["proj-1"].SourceDocument, Is.EqualTo("chain.capella"));
                Assert.That(this.result.Elements["se-1"].SourceDocument, Is.EqualTo("fragments/a.capellafragment"));
                Assert.That(this.result.Elements["pa-1"].SourceDocument, Is.EqualTo("fragments/b.capellafragment"));
            });
        }

        [Test]
        public void Verify_that_walking_the_container_of_a_fragment_element_reaches_the_root()
        {
            // pa-1 lives in fragment b, se-1 in fragment a, proj-1 in the main file. Cross-document
            // containment resolved through the ContainerList must have re-parented each element, so
            // walking IAurigaElement.Container from the deepest fragment element reaches the Project root.
            var physicalArchitecture = this.result.Elements["pa-1"];

            var ancestors = Ancestors(physicalArchitecture).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(physicalArchitecture.Container, Is.SameAs(this.result.Elements["se-1"]));
                Assert.That(ancestors, Does.Contain(this.result.Root));
                Assert.That(ancestors.Last(), Is.SameAs(this.result.Root));
            });
        }

        [Test]
        public void Verify_that_the_root_can_enumerate_all_fragment_sourced_descendants()
        {
            var descendants = this.result.Root.QueryAllContainedElements().ToList();

            Assert.Multiple(() =>
            {
                // se-1 (fragment a) and pa-1 (fragment b) are both reachable as descendants of the main root
                Assert.That(descendants, Does.Contain(this.result.Elements["se-1"]));
                Assert.That(descendants, Does.Contain(this.result.Elements["pa-1"]));

                // the LINQ-over-the-whole-model pattern the issue calls for
                Assert.That(
                    this.result.Root.QueryAllContainedElements().OfType<Auriga.Model.Capellamodeller.ISystemEngineering>().Single().Id,
                    Is.EqualTo("se-1"));
            });
        }

        /// <summary>
        /// Walks the <see cref="Auriga.Core.IAurigaElement.Container"/> chain of an element from its immediate
        /// container up to the root, in order.
        /// </summary>
        /// <param name="element">the element whose ancestors are enumerated</param>
        /// <returns>the ancestor chain, nearest first</returns>
        private static System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> Ancestors(Auriga.Core.IAurigaElement element)
        {
            for (var current = element.Container; current != null; current = current.Container)
            {
                yield return current;
            }
        }
    }
}
