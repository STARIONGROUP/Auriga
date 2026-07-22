// ------------------------------------------------------------------------------------------------
// <copyright file="PortOrientationTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System;
    using System.IO;
    using System.Linq;

    using Auriga.Xmi;

    using NUnit.Framework;

    /// <summary>
    /// The port-orientation acceptance tests (issue #101): a function/flow port renders with its
    /// glyph rotated to the border side it sits on, so the arrow crosses that border in the flow
    /// direction — a left/right-border port draws a horizontal arrow, a top/bottom-border port a
    /// vertical one. Verified on the In-Flight <c>[PDFB] [CTX] Display Video and Play Audio</c>,
    /// whose ports previously all rendered identically oriented.
    /// </summary>
    [TestFixture]
    public class PortOrientationTestFixture
    {
        private const string DisplayVideoPdfbUid = "_gB07gLBMEeSnJaHm1OLKKw";

        private static readonly System.Xml.Linq.XNamespace Svg = "http://www.w3.org/2000/svg";

        private Diagram diagram = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagram = new DiagramBuilder().BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == DisplayVideoPdfbUid);
        }

        [Test]
        public void Verify_that_ports_are_oriented_by_their_border_side()
        {
            var ports = this.diagram.QueryAllBoxes()
                .Where(parent => parent.Children.Any(child => child.SemanticElement is Auriga.Model.Information.IPort))
                .SelectMany(parent => parent.Children
                    .Where(child => child.SemanticElement is Auriga.Model.Information.IPort)
                    .Select(port => (Parent: parent, Port: port)))
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.That(ports, Is.Not.Empty, "the functions expose ports");

                // The bug was every port rendered identically oriented; now every quarter turn occurs.
                var rotations = ports.Select(pair => pair.Port.Style.Resolved.ImageRotation).Distinct().ToList();
                Assert.That(rotations, Is.EquivalentTo(new double[] { 0, 90, 180, 270 }), "ports occupy all four border orientations");

                // A horizontal-arrow rotation (90/270) sits on a left/right border; a vertical one
                // (0/180) on a top/bottom border. At a corner the two are equidistant, so the check
                // is a tolerant "no nearer opposite border".
                foreach (var (parent, port) in ports)
                {
                    var (toLeftRight, toTopBottom) = BorderDistances(parent, port);
                    if (port.Style.Resolved.ImageRotation is 90 or 270)
                    {
                        Assert.That(toLeftRight, Is.LessThanOrEqualTo(toTopBottom + 0.001), "a horizontal-arrow port sits on a left/right border");
                    }
                    else
                    {
                        Assert.That(toTopBottom, Is.LessThanOrEqualTo(toLeftRight + 0.001), "a vertical-arrow port sits on a top/bottom border");
                    }
                }
            });
        }

        [Test]
        public void Verify_that_the_rotation_reaches_the_exported_svg()
        {
            var document = System.Xml.Linq.XDocument.Parse(new SvgExporter().Export(this.diagram));
            var transforms = document.Descendants(Svg + "image")
                .Select(image => (string?)image.Attribute("transform"))
                .Where(transform => transform != null)
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.That(transforms, Has.Some.Matches<string?>(transform => transform!.StartsWith("rotate(90 ")), "a right-border port image is rotated a quarter turn");
                Assert.That(transforms, Has.Some.Matches<string?>(transform => transform!.StartsWith("rotate(270 ")), "a left-border port image is rotated three quarter turns");
            });
        }

        private static (double LeftRight, double TopBottom) BorderDistances(Box parent, Box port)
        {
            var centreX = port.Position.X + ((port.Width ?? 0) / 2);
            var centreY = port.Position.Y + ((port.Height ?? 0) / 2);
            var toLeftRight = Math.Min(Math.Abs(centreX - parent.Position.X), Math.Abs(centreX - (parent.Position.X + (parent.Width ?? 0))));
            var toTopBottom = Math.Min(Math.Abs(centreY - parent.Position.Y), Math.Abs(centreY - (parent.Position.Y + (parent.Height ?? 0))));
            return (toLeftRight, toTopBottom);
        }
    }
}
