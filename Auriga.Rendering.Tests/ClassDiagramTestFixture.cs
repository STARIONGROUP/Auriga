// ------------------------------------------------------------------------------------------------
// <copyright file="ClassDiagramTestFixture.cs" company="Starion Group S.A.">
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

    using Auriga.Xmi;

    using NUnit.Framework;

    /// <summary>
    /// The visual-acceptance tests for the <c>[CDB] In-Flight Entertainment Dictionary</c> class
    /// diagram of the In-Flight Entertainment System (issue #86): its classes and enumeration are
    /// <c>DNodeList</c> containers Capella auto-sizes from their content — the builder synthesizes
    /// the size, stacks the <c>DNodeListElement</c> rows below the title compartment, draws the
    /// title separator, and surfaces the association multiplicities as edge end labels.
    /// </summary>
    [TestFixture]
    public class ClassDiagramTestFixture
    {
        /// <summary>
        /// The builder under test, composed with the default per-kind builders.
        /// </summary>
        private readonly DiagramBuilder diagramBuilder = new();

        /// <summary>
        /// The built <c>[CDB] In-Flight Entertainment Dictionary</c> diagram.
        /// </summary>
        private Diagram diagram = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagram = this.diagramBuilder.BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == "_I_i0sLZ4EeS6m7-8Vqqevw");
        }

        [Test]
        public void Verify_that_a_class_lays_out_as_a_sized_list_container()
        {
            var passenger = this.diagram.Boxes.Single(box => box.Identifier == "_LWQ0fLZ4EeS6m7-8Vqqevw");
            var items = passenger.Children.Where(child => child.SiriusElement is Auriga.Diagram.Diagram.IDNodeListElement).ToList();
            var separator = passenger.Children.Single(child => child.Identifier == "_LWQ0fLZ4EeS6m7-8Vqqevw-title-separator");

            Assert.Multiple(() =>
            {
                Assert.That(passenger.Width, Is.Not.Null.And.GreaterThan(50), "the width is synthesized from the content");
                Assert.That(passenger.Height, Is.Not.Null.And.GreaterThan(40), "the height covers title and rows");

                Assert.That(items, Has.Count.EqualTo(2), "name and firstName");
                Assert.That(items[0].Position.X, Is.EqualTo(passenger.Position.X + 6), "rows indent from the container edge");
                Assert.That(items[1].Position.Y, Is.GreaterThan(items[0].Position.Y), "rows stack downward");
                Assert.That(items[0].Style.Resolved.FillColor, Is.Null, "rows are transparent");
                Assert.That(items[0].Style.Resolved.StrokeWidth, Is.Zero);
                Assert.That(items[0].Label!.Position, Is.Not.Null, "row labels are left-aligned single lines");
                Assert.That(items[0].Label!.Width, Is.Null, "row labels do not wrap");

                Assert.That(separator.Style.Resolved.Shape, Is.EqualTo(ShapeKind.Line), "the title separator rule");
                Assert.That(separator.Width, Is.EqualTo(passenger.Width));
                Assert.That(separator.Height, Is.Zero);

                Assert.That(passenger.Label!.Position, Is.Not.Null, "the title centers in its own compartment, not the whole box");
                Assert.That(passenger.Label!.IconPath, Is.EqualTo("Class.png"), "the class's metaclass icon");
                Assert.That(items[0].Label!.IconPath, Is.EqualTo("Property.png"), "the property's metaclass icon");
            });
        }

        [Test]
        public void Verify_that_the_enumeration_and_the_multiplicities_render()
        {
            var enumeration = this.diagram.Boxes.Single(box => box.Identifier == "_LWalcLZ4EeS6m7-8Vqqevw");
            var literals = enumeration.Children.Where(child => child.SiriusElement is Auriga.Diagram.Diagram.IDNodeListElement).ToList();
            var transports = this.diagram.Edges.Single(edge => edge.SiriusElement?.Id == "_krZhIIoOEeaQmcRqIfTB6w");

            Assert.Multiple(() =>
            {
                Assert.That(literals, Has.Count.EqualTo(3), "BUSINESS, PREMIUM and ECONOMY");
                Assert.That(literals.Select(literal => literal.Position.Y), Is.Ordered.Ascending);

                Assert.That(transports.Label!.Text, Is.EqualTo("transports"));
                Assert.That(transports.EndLabel!.Text, Is.EqualTo("[1..*]"), "the association multiplicity, trimmed");
                Assert.That(transports.BeginLabel, Is.Null, "no begin label persisted");
                Assert.That(transports.Label!.IconPath, Is.EqualTo("Association.png"), "the association's metaclass icon");
            });
        }
    }
}
