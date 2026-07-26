// ------------------------------------------------------------------------------------------------
// <copyright file="ViewpointExtensionsRoundTripTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System.IO;
    using System.Text;

    using Auriga.Core;
    using Auriga.Xmi.Core.Readers;

    using NUnit.Framework;

    /// <summary>
    /// Round-trip coverage for the vendored Capella add-on viewpoints — Mass
    /// (<c>mass:PartMass</c>), Basic Requirement (<c>requirement:RequirementsPkg</c> /
    /// <c>requirement:Requirement</c>) and Cybersecurity (<c>cybersecurity:CybersecurityConfiguration</c>).
    /// Each is an <c>eMDE</c> element extension held on a Capella element's <c>ownedExtensions</c>. The
    /// Cybersecurity viewpoint is also exercised end to end by the real Crowd Surveillance fixture; this
    /// fixture is a small self-contained model so the Mass and Basic Requirement viewpoints are covered
    /// too, independently of the (large, external) models that use them.
    /// </summary>
    [TestFixture]
    public class ViewpointExtensionsRoundTripTestFixture
    {
        private const string Model =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
            "<org.polarsys.capella.core.data.capellamodeller:Project xmi:version=\"2.0\" " +
            "xmlns:xmi=\"http://www.omg.org/XMI\" " +
            "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
            "xmlns:org.polarsys.capella.core.data.capellamodeller=\"http://www.polarsys.org/capella/core/modeller/7.0.0\" " +
            "xmlns:mass=\"http://www.polarsys.org/capella/mass\" " +
            "xmlns:cybersecurity=\"http://www.polarsys.org/capella/cybersecurity/1.0\" " +
            "xmlns:requirement=\"http://www.polarsys.org/capella/basic/requirement\" " +
            "id=\"_project\" name=\"Viewpoint Extensions\">\n" +
            "  <ownedExtensions xsi:type=\"mass:PartMass\" id=\"_partmass\" value=\"42\" minValue=\"0\" maxValue=\"100\"/>\n" +
            "  <ownedExtensions xsi:type=\"cybersecurity:CybersecurityConfiguration\" id=\"_cyber\"/>\n" +
            "  <ownedExtensions xsi:type=\"requirement:RequirementsPkg\" id=\"_reqpkg\" name=\"Requirements\">\n" +
            "    <ownedRequirements xsi:type=\"requirement:SystemUserRequirement\" id=\"_req\" name=\"R-1\"/>\n" +
            "  </ownedExtensions>\n" +
            "</org.polarsys.capella.core.data.capellamodeller:Project>\n";

        [Test]
        public void Verify_that_the_add_on_viewpoint_elements_read_into_their_generated_types()
        {
            var result = Read(Model);

            Assert.Multiple(() =>
            {
                Assert.That(result.Elements["_partmass"], Is.InstanceOf<Auriga.Model.Mass.IPartMass>());
                Assert.That(result.Elements["_cyber"], Is.InstanceOf<Auriga.Model.Cybersecurity.ICybersecurityConfiguration>());
                Assert.That(result.Elements["_reqpkg"], Is.InstanceOf<Auriga.Model.Requirement.IRequirementsPkg>());
                Assert.That(result.Elements["_req"], Is.InstanceOf<Auriga.Model.Requirement.ISystemUserRequirement>());

                // The extensions hang off the project; the requirement off its package.
                Assert.That(result.Elements["_partmass"].Container?.Id, Is.EqualTo("_project"));
                Assert.That(result.Elements["_req"].Container?.Id, Is.EqualTo("_reqpkg"));

                // A scalar of the Mass viewpoint survives the read.
                Assert.That(((Auriga.Model.Mass.IPartMass)result.Elements["_partmass"]).Value, Is.EqualTo(42));
            });
        }

        [Test]
        public void Verify_that_the_add_on_viewpoint_elements_round_trip()
        {
            var original = Read(Model);

            using var stream = new MemoryStream();
            XmiWriterBuilder.Create().Build().WriteDocument(original.Root, stream, "viewpoint-extensions.capella");
            var roundTripped = Read(Encoding.UTF8.GetString(stream.ToArray()));

            Assert.Multiple(() =>
            {
                Assert.That(roundTripped.Elements.Keys, Is.EquivalentTo(original.Elements.Keys), "the same elements are present after a round-trip");

                foreach (var id in new[] { "_partmass", "_cyber", "_reqpkg", "_req" })
                {
                    Assert.That(roundTripped.Elements.TryGetValue(id, out var element), Is.True, $"{id} is present");
                    Assert.That(element!.GetType(), Is.EqualTo(original.Elements[id].GetType()), $"type of {id}");
                }

                Assert.That(((Auriga.Model.Mass.IPartMass)roundTripped.Elements["_partmass"]).Value, Is.EqualTo(42), "the Mass value survives the round-trip");
            });
        }

        private static XmiReaderResult Read(string xml)
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            return XmiReaderBuilder.Create().Build().Read(stream, "viewpoint-extensions.capella");
        }
    }
}
