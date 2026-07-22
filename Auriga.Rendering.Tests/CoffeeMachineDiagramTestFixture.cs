// ------------------------------------------------------------------------------------------------
// <copyright file="CoffeeMachineDiagramTestFixture.cs" company="Starion Group S.A.">
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
    /// The end-to-end acceptance test for the intermediate diagram model (issue #55): the real
    /// coffee-machine project is loaded through the <see cref="IAirdModelLoader"/> (diagrams,
    /// fragments and the co-loaded Capella semantic model), and every representation builds into a
    /// <see cref="Diagram"/> whose box coordinates, label geometry and edge routes match the
    /// persisted GMF layout, with the Sirius and semantic back-links in place.
    /// </summary>
    [TestFixture]
    public class CoffeeMachineDiagramTestFixture
    {
        private const string MakeCoffeeNodeUid = "_OLzagFucEe2iJbuWznnyfw";

        private const string FirstRepresentationUid = "_J1uyIFucEe2iJbuWznnyfw";

        private const string FunctionalExchangeEdgeUid = "_XKSYcFucEe2iJbuWznnyfw";

        /// <summary>
        /// The builder under test, composed with the default per-kind builders.
        /// </summary>
        private readonly DiagramBuilder diagramBuilder = new();

        /// <summary>
        /// The exporter the export round-trip tests drive.
        /// </summary>
        private readonly SvgExporter svgExporter = new();

        private List<Diagram> diagrams = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "coffee-machine-demo.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagrams = this.diagramBuilder.BuildAll(result.Elements.Values).ToList();
        }

        [Test]
        public void Verify_that_every_representation_builds_into_a_populated_model()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.diagrams, Has.Count.EqualTo(6), "four diagrams and two sequence diagrams");

                // 544 notation nodes fold down to the boxes that display a distinct Sirius element;
                // the rest are label and compartment auxiliaries contributing geometry, not boxes.
                Assert.That(this.diagrams.Sum(diagram => diagram.QueryAllBoxes().Count()), Is.GreaterThan(100), "the boxes of the whole project");
                Assert.That(this.diagrams.Sum(diagram => diagram.Edges.Count), Is.GreaterThan(40), "the edges of the whole project");
                Assert.That(
                    this.diagrams.SelectMany(diagram => diagram.Edges).Where(edge => edge.Source != null && edge.Target != null),
                    Has.All.Property("Route").Not.Empty,
                    "every edge between mapped boxes has a route");
            });
        }

        [Test]
        public void Verify_that_a_box_carries_the_persisted_absolute_geometry()
        {
            var box = this.FindBox(MakeCoffeeNodeUid);

            Assert.Multiple(() =>
            {
                // <layoutConstraint xsi:type="notation:Bounds" x="380" y="237" width="41" height="31"/>
                // on a top-level node: relative equals absolute.
                Assert.That(box.Position, Is.EqualTo(new Point(380, 237)));
                Assert.That(box.Width, Is.EqualTo(41));
                Assert.That(box.Height, Is.EqualTo(31));

                // The label node persists <layoutConstraint x="-9" y="32"/> relative to its box.
                Assert.That(box.Label!.Text, Is.EqualTo("make coffee"));
                Assert.That(box.Label.Position, Is.EqualTo(new Point(371, 269)));
            });
        }

        [Test]
        public void Verify_that_a_box_exposes_its_sirius_and_semantic_back_links()
        {
            var box = this.FindBox(MakeCoffeeNodeUid);

            Assert.Multiple(() =>
            {
                Assert.That(box.SiriusElement, Is.InstanceOf<Auriga.Diagram.Diagram.IDNode>());
                Assert.That(box.SiriusElement!.Id, Is.EqualTo(MakeCoffeeNodeUid));
                Assert.That(box.NotationView.Element, Is.SameAs(box.SiriusElement), "the notation view displays the Sirius element");

                // The loader co-loaded the .capella, so the DNode's target resolved to a typed
                // Capella element read from the semantic document.
                Assert.That(box.SemanticElement, Is.InstanceOf<Auriga.Core.IAurigaElement>());
                Assert.That(((Auriga.Core.IAurigaElement)box.SemanticElement!).SourceDocument, Is.EqualTo("coffee-machine-demo.capella"));
                Assert.That(box.Style.SiriusStyle, Is.Not.Null, "the DNode carries its owned style");
            });
        }

        [Test]
        public void Verify_that_an_edge_routes_between_its_boxes_from_the_persisted_layout()
        {
            var diagram = this.diagrams.Single(d => d.Identifier == FirstRepresentationUid);
            var edge = diagram.Edges.Single(e => e.SiriusElement?.Id == FunctionalExchangeEdgeUid);

            Assert.Multiple(() =>
            {
                Assert.That(edge.Source!.SiriusElement!.Id, Is.EqualTo(MakeCoffeeNodeUid), "the edge starts at the make-coffee box");
                Assert.That(edge.Target, Is.Not.Null);
                Assert.That(edge.SemanticElement, Is.InstanceOf<Auriga.Core.IAurigaElement>(), "the DEdge's target resolved into the co-loaded Capella model");

                // A functional exchange renders a solid filled arrowhead, the metamodel default an
                // unpersisted targetArrow resolves to — never the open chevron of the ecore literal.
                Assert.That(edge.Style.Resolved.TargetArrow, Is.EqualTo(Auriga.Diagram.Diagram.EdgeArrows.InputFillClosedArrow), "the exchange arrowhead is filled");

                // sourceAnchor (0.0, 0.3225806451612903) of the 41x31 box at (380, 237) is
                // (380, 247) on the box's left edge; the edge heads away from the box, so the
                // slidable-anchor endpoint is the reference point itself.
                Assert.That(edge.Route, Is.Not.Empty);
                Assert.That(edge.Route[0].X, Is.EqualTo(380).Within(0.0001));
                Assert.That(edge.Route[0].Y, Is.EqualTo(247).Within(0.0001));
            });
        }

        [Test]
        public void Verify_that_styles_resolve_from_the_persisted_diagram()
        {
            var box = this.FindBox(MakeCoffeeNodeUid);
            var allEdges = this.diagrams.SelectMany(diagram => diagram.Edges).ToList();

            Assert.Multiple(() =>
            {
                // The node's notation ShapeStyle persists fontName="Ubuntu" fontHeight="8".
                Assert.That(box.Style.Resolved.FontName, Is.EqualTo("Ubuntu"));
                Assert.That(box.Style.Resolved.FontSize, Is.EqualTo(8));

                // One DEdge persists an EdgeStyle with strokeColor="114,73,110" lineStyle="dash".
                Assert.That(
                    allEdges,
                    Has.Some.Matches<Edge>(edge => edge.Style.Resolved.StrokeColor == new Color(114, 73, 110) && edge.Style.Resolved.Pattern == LinePattern.Dash),
                    "the purple dashed edge resolves its persisted style");

                // The Capella actor/capability icons are WorkspaceImage styles carrying their path.
                Assert.That(
                    this.diagrams.SelectMany(diagram => diagram.QueryAllBoxes()),
                    Has.Some.Matches<Box>(candidate => candidate.Style.Resolved.ImagePath != null),
                    "workspace-image styles carry their path");
            });
        }

        [Test]
        public void Verify_that_border_node_ports_render_without_name_labels()
        {
            var allBoxes = this.diagrams.SelectMany(diagram => diagram.QueryAllBoxes()).ToList();

            var ports = allBoxes.Where(box => box.SemanticElement is Auriga.Model.Information.IPort).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(ports, Is.Not.Empty, "the functions expose ports");
                Assert.That(ports, Has.All.Matches<Box>(port => port.Label == null), "a port renders as a glyph, with no name label");

                // No FIP/FOP/CP/PP port name survives as a rendered label anywhere in the project.
                Assert.That(
                    allBoxes.Where(box => box.Label != null).Select(box => box.Label!.Text),
                    Has.None.Matches<string>(text => System.Text.RegularExpressions.Regex.IsMatch(text, @"^(FIP|FOP|CP|PP)\s*\d*$")),
                    "no bare port-name label remains");

                // Only ports lose their label: ordinary node labels (and the border-node labels of
                // sequence executions/state fragments, covered by the sequence fixture) still render.
                Assert.That(
                    allBoxes.Where(box => box.Label != null).Select(box => box.Label!.Text),
                    Has.Some.EqualTo("make coffee"),
                    "non-port labels still render");
            });
        }

        [Test]
        public void Verify_that_every_diagram_exports_to_well_formed_svg()
        {
            Assert.Multiple(() =>
            {
                foreach (var diagram in this.diagrams)
                {
                    var text = this.svgExporter.Export(diagram);
                    var document = System.Xml.Linq.XDocument.Parse(text);
                    var ns = document.Root!.Name.Namespace;

                    Assert.That(diagram.Name, Is.Not.Null.And.Not.Empty, $"the descriptor names representation {diagram.Identifier}");
                    Assert.That(document.Root.Name.LocalName, Is.EqualTo("svg"), diagram.Identifier);
                    Assert.That(document.Root.Attribute("viewBox"), Is.Not.Null, diagram.Identifier);
                    Assert.That(
                        document.Descendants(ns + "rect").Count() + document.Descendants(ns + "path").Count(),
                        Is.GreaterThan(0),
                        $"{diagram.Identifier} renders visible content");
                }

                // Across the whole project the exports mirror the model: one rect or inlined
                // workspace image per box, one non-marker path per routed edge, and the labels.
                var documents = this.diagrams
                    .Select(diagram => System.Xml.Linq.XDocument.Parse(this.svgExporter.Export(diagram)))
                    .ToList();
                var svgNs = (System.Xml.Linq.XNamespace)"http://www.w3.org/2000/svg";
                Assert.That(
                    documents.Sum(d => d.Descendants(svgNs + "rect").Count() + d.Descendants(svgNs + "image").Count()),
                    Is.GreaterThan(100),
                    "the project's boxes");
                Assert.That(documents.Sum(d => d.Descendants(svgNs + "image").Count()), Is.GreaterThan(10), "the project's workspace images render as images");
                Assert.That(documents.Sum(d => d.Descendants(svgNs + "path").Count(p => p.Parent!.Name.LocalName != "marker")), Is.GreaterThan(40), "the project's edges");
                Assert.That(documents.Sum(d => d.Descendants(svgNs + "text").Count()), Is.GreaterThan(90), "the project's labels (state-machine pseudo-states and regions render glyph-only, without a label)");
            });
        }

        /// <summary>
        /// Finds the single box built for the Sirius element with the supplied uid, across all
        /// diagrams of the project.
        /// </summary>
        /// <param name="siriusUid">the Sirius representation element's uid</param>
        /// <returns>the box</returns>
        private Box FindBox(string siriusUid)
        {
            return this.diagrams.SelectMany(diagram => diagram.QueryAllBoxes()).Single(box => box.Identifier == siriusUid);
        }
    }
}
