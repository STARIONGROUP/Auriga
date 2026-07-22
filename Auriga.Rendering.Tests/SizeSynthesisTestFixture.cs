// ------------------------------------------------------------------------------------------------
// <copyright file="SizeSynthesisTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Auriga.Xmi;

    using NUnit.Framework;

    /// <summary>
    /// The size-synthesis acceptance tests (issue #94): Capella auto-sizes many nodes from their
    /// content and persists no size (the GMF <c>-1</c> sentinel), and persists ports at a <c>1×1</c>
    /// sentinel. The builder synthesizes those sizes from the children and label extents — so
    /// functions, components and states render at their content size instead of collapsing to the
    /// default footprint — and gives border ports the GMF <c>10×10</c> footprint. Verified on the
    /// In-Flight <c>[CDI]</c>, <c>[SDFB]</c> and <c>[MSM]</c> representations.
    /// </summary>
    [TestFixture]
    public class SizeSynthesisTestFixture
    {
        private const string StreamingServerCdiUid = "_au4DgLm1EeSceeI4mBNpyA";

        private const string ProvideVideoServicesSdfbUid = "_EsbcMLKzEeSZM9DbsSoyxw";

        private const string SeatTvModesMsmUid = "_8Rf4kPhoEeyYD7A3qrV3tA";

        private List<Diagram> diagrams = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagrams = new DiagramBuilder().BuildAll(result.Elements.Values).ToList();
        }

        [Test]
        public void Verify_that_unsized_ports_take_the_default_footprint()
        {
            var diagram = this.diagrams.Single(d => d.Identifier == ProvideVideoServicesSdfbUid);
            var ports = diagram.QueryAllBoxes().Where(box => box.SemanticElement is Auriga.Model.Information.IPort).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(ports, Is.Not.Empty, "the functions expose ports");
                Assert.That(ports, Has.All.Matches<Box>(port => port.Width == 10 && port.Height == 10), "a port takes the 10x10 footprint, not the persisted 1x1 sentinel");
            });
        }

        [Test]
        public void Verify_that_a_component_sizes_to_its_border_ports()
        {
            var diagram = this.diagrams.Single(d => d.Identifier == StreamingServerCdiUid);
            var component = diagram.QueryAllBoxes().Single(box => box.Label?.Text == "Streaming Server");
            var ports = component.Children.Where(child => child.SemanticElement is Auriga.Model.Information.IPort).ToList();

            Assert.Multiple(() =>
            {
                // The component persists no width; it is synthesized from its four border ports,
                // the right-most sitting at x=370 (its glyph reaching 380), so ~150 wide from x=230.
                Assert.That(component.Width, Is.Not.Null.And.GreaterThan(100).And.LessThan(200), "the width covers the border ports");
                Assert.That(component.Height, Is.EqualTo(241), "the persisted height is kept");
                Assert.That(ports, Has.Count.EqualTo(4).And.All.Matches<Box>(port => port.Width == 10 && port.Height == 10));
            });
        }

        [Test]
        public void Verify_that_state_modes_do_not_collapse_to_the_default_footprint()
        {
            var diagram = this.diagrams.Single(d => d.Identifier == SeatTvModesMsmUid);
            var modes = diagram.QueryAllBoxes().Where(box => box.SemanticElement?.GetType().Name == "Mode").ToList();
            var interrupted = modes.Single(box => box.Label?.Text == "Seat TV - Interrupted");

            Assert.Multiple(() =>
            {
                Assert.That(modes, Is.Not.Empty, "the state machine renders its modes");
                Assert.That(modes, Has.All.Matches<Box>(mode => mode.Width > 10 && mode.Height > 10), "no mode collapses to the default footprint");

                // Its single Region child persists 319x414; the mode takes that content extent.
                Assert.That(interrupted.Width, Is.EqualTo(319).Within(1), "the mode sizes to its region's width");
                Assert.That(interrupted.Height, Is.EqualTo(414).Within(1), "the mode sizes to its region's height");
            });
        }
    }
}
