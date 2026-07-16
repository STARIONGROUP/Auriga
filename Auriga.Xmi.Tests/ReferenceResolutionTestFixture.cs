// ------------------------------------------------------------------------------------------------
// <copyright file="ReferenceResolutionTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System.IO;
    using System.Linq;
    using System.Text;

    using Auriga.Xmi.Core.Readers;

    using NUnit.Framework;

    /// <summary>
    /// Tests the two-pass cross-reference resolution (issue #11): intra-file <c>#id</c> references
    /// resolve to typed object references regardless of the order the target appears in the document
    /// (forward references), and references whose target is missing are collected into a diagnosable
    /// report rather than aborting the load.
    /// </summary>
    [TestFixture]
    public class ReferenceResolutionTestFixture
    {
        private const string FunctionalExchange = "a0000000-0000-4000-8000-000000000016";
        private const string Fop1 = "a0000000-0000-4000-8000-000000000013";
        private const string Fip1 = "a0000000-0000-4000-8000-000000000015";

        private XmiReaderResult result = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "minimal.melodymodeller");
            this.result = XmiReaderBuilder.Create().Build().Read(path);
        }

        [Test]
        public void Verify_that_a_forward_reference_is_resolved()
        {
            // The FunctionalExchange is serialized before its source (FOP1) and target (FIP1) ports, which
            // appear later in the document. The two-pass resolver must still resolve both to the ports.
            var exchange = (Auriga.Fa.IFunctionalExchange)this.result.Elements[FunctionalExchange];

            Assert.Multiple(() =>
            {
                Assert.That(exchange.Source, Is.SameAs(this.result.Elements[Fop1]));
                Assert.That(exchange.Target, Is.SameAs(this.result.Elements[Fip1]));
            });
        }

        [Test]
        public void Verify_that_a_fully_resolvable_model_reports_no_unresolved_references()
        {
            Assert.That(this.result.UnresolvedReferences, Is.Empty);
        }

        [Test]
        public void Verify_that_a_dangling_reference_is_collected_and_reported()
        {
            // The Part references an abstractType whose id is not present anywhere in the document. The
            // load must not fail; instead the dangling reference is collected so it can be reported.
            const string Xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<org.polarsys.capella.core.data.capellamodeller:Project xmi:version=\"2.0\" " +
                "xmlns:xmi=\"http://www.omg.org/XMI\" " +
                "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:org.polarsys.capella.core.data.capellamodeller=\"http://www.polarsys.org/capella/core/modeller/7.0.0\" " +
                "xmlns:org.polarsys.capella.core.data.pa=\"http://www.polarsys.org/capella/core/pa/7.0.0\" " +
                "xmlns:org.polarsys.capella.core.data.cs=\"http://www.polarsys.org/capella/core/cs/7.0.0\" " +
                "id=\"proj-1\" name=\"Dangling\">" +
                "<ownedModelRoots xsi:type=\"org.polarsys.capella.core.data.capellamodeller:SystemEngineering\" id=\"se-1\" name=\"SE\">" +
                "<ownedArchitectures xsi:type=\"org.polarsys.capella.core.data.pa:PhysicalArchitecture\" id=\"pa-1\" name=\"PA\">" +
                "<ownedPhysicalComponentPkg xsi:type=\"org.polarsys.capella.core.data.pa:PhysicalComponentPkg\" id=\"pkg-1\" name=\"Structure\">" +
                "<ownedParts xsi:type=\"org.polarsys.capella.core.data.cs:Part\" id=\"part-1\" name=\"P\" abstractType=\"#missing-1\"/>" +
                "</ownedPhysicalComponentPkg>" +
                "</ownedArchitectures>" +
                "</ownedModelRoots>" +
                "</org.polarsys.capella.core.data.capellamodeller:Project>";

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(Xml));
            var danglingResult = XmiReaderBuilder.Create().Build().Read(stream, "dangling");

            var unresolved = danglingResult.UnresolvedReferences.Single();

            Assert.Multiple(() =>
            {
                Assert.That(danglingResult.Root, Is.Not.Null, "the load must not be aborted by the dangling reference");
                Assert.That(unresolved.OwningElementId, Is.EqualTo("part-1"));
                Assert.That(unresolved.OwningElementType, Is.EqualTo("Part"));
                Assert.That(unresolved.PropertyName, Is.EqualTo("AbstractType"));
                Assert.That(unresolved.TargetIdentifier, Is.EqualTo("missing-1"));
            });
        }
    }
}
