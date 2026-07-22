// ------------------------------------------------------------------------------------------------
// <copyright file="WorkspaceImageTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Auriga.Xmi;

    using NUnit.Framework;

    /// <summary>
    /// The project-local workspace-image tests (issue #98): a <c>WorkspaceImage</c> whose path
    /// points inside the model project (e.g. <c>In-Flight Entertainment System/images/Operator.svg</c>)
    /// is served from the file beside the loaded <c>.aird</c> by a <see cref="WorkspaceImageRegistry"/>,
    /// composed after the vendored <see cref="CapellaIconRegistry"/>. Verified against the In-Flight
    /// <c>[SC] System Actors</c>, whose Ground Operator carries a custom image.
    /// </summary>
    [TestFixture]
    public class WorkspaceImageTestFixture
    {
        private const string SystemActorsScUid = "_LzrP8LclEd6PZMYM-Vvo5g";

        private const string OperatorPath = "In-Flight Entertainment System/images/Operator.svg";

        private static readonly XNamespace Svg = "http://www.w3.org/2000/svg";

        private static string ProjectRoot => Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

        [Test]
        public void Verify_that_a_project_local_image_resolves_from_the_project_root()
        {
            var registry = new WorkspaceImageRegistry(ProjectRoot);

            Assert.Multiple(() =>
            {
                Assert.That(() => new WorkspaceImageRegistry(string.Empty), Throws.ArgumentException);
                Assert.That(registry.Resolve(OperatorPath), Does.StartWith("data:image/svg+xml;base64,"), "the project-name-prefixed path resolves against the root");
                Assert.That(registry.Resolve("images/Operator.svg"), Does.StartWith("data:image/svg+xml;base64,"), "the un-prefixed path resolves too");
                Assert.That(registry.Resolve("In-Flight Entertainment System/images/NoSuchImage.png"), Is.Null, "an unknown file resolves to null");
                Assert.That(registry.Resolve(string.Empty), Is.Null);
            });
        }

        [Test]
        public void Verify_that_the_composite_serves_plugin_and_project_images_and_falls_through()
        {
            var registry = new CompositeIconRegistry(new CapellaIconRegistry(), new WorkspaceImageRegistry(ProjectRoot));

            Assert.Multiple(() =>
            {
                Assert.That(() => new CompositeIconRegistry(null!), Throws.ArgumentNullException);
                Assert.That(registry.Resolve("/org.polarsys.capella.core.sirius.analysis/description/images/Actor.svg"), Does.StartWith("data:image/svg+xml;base64,"), "vendored plugin artwork still serves");
                Assert.That(registry.Resolve(OperatorPath), Does.StartWith("data:image/svg+xml;base64,"), "a project-local image falls through to the workspace source");
                Assert.That(registry.Resolve("Some Project/images/NotVendored.png"), Is.Null, "an image no registry knows resolves to null");
            });
        }

        [Test]
        public void Verify_that_the_ground_operator_renders_as_its_project_image()
        {
            var path = Path.Combine(ProjectRoot, "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);
            var diagram = new DiagramBuilder().BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == SystemActorsScUid);

            var operatorBox = diagram.QueryAllBoxes().Single(box => box.Style.Resolved.ImagePath == OperatorPath);

            var composed = new SvgExporter(new CompositeIconRegistry(new CapellaIconRegistry(), new WorkspaceImageRegistry(ProjectRoot)));
            var group = XDocument.Parse(composed.Export(diagram)).Descendants(Svg + "g").Single(g => (string?)g.Attribute("id") == operatorBox.Identifier);
            var image = group.Element(Svg + "image");

            // With only the vendored registry the project image is unknown, so the box degrades to
            // its outline; the workspace registry serves the file beside the .aird.
            var plainGroup = XDocument.Parse(new SvgExporter().Export(diagram)).Descendants(Svg + "g").Single(g => (string?)g.Attribute("id") == operatorBox.Identifier);

            Assert.Multiple(() =>
            {
                Assert.That(image, Is.Not.Null, "the Ground Operator renders as its image");
                Assert.That((string?)image!.Attribute("href"), Does.StartWith("data:image/svg+xml;base64,"));
                Assert.That((string?)image.Attribute("width"), Is.EqualTo((operatorBox.Width ?? 0).ToString(System.Globalization.CultureInfo.InvariantCulture)), "the image is sized to its box");
                Assert.That(plainGroup.Element(Svg + "image"), Is.Null, "without the workspace registry the project image is a placeholder outline");
            });
        }
    }
}
