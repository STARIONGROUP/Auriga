// ------------------------------------------------------------------------------------------------
// <copyright file="StyleResolverTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Notation = Auriga.Diagram.Notation;
    using SiriusDiagram = Auriga.Diagram.Diagram;

    /// <summary>
    /// Tests the <see cref="StyleResolver"/> and <see cref="Color"/> against hand-built styles: the
    /// Sirius/GMF color encodings, the precedence (palette defaults, then notation styles, then the
    /// Sirius owned style), the Capella default palette fallbacks, and the no-throw guarantee for
    /// unknown or malformed styles.
    /// </summary>
    [TestFixture]
    public class StyleResolverTestFixture
    {
        /// <summary>
        /// The resolver under test, composed with the default Capella palette.
        /// </summary>
        private readonly IStyleResolver styleResolver = new StyleResolver();

        [Test]
        public void Verify_the_color_encodings()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Color.TryParse("150, 177,218", out var parsed), Is.True);
                Assert.That(parsed, Is.EqualTo(new Color(150, 177, 218)));
                Assert.That(Color.TryParse("1,2", out _), Is.False);
                Assert.That(Color.TryParse("256,0,0", out _), Is.False);
                Assert.That(Color.TryParse(null, out _), Is.False);

                // GMF packs blue<<16 | green<<8 | red: 30<<16 | 20<<8 | 10 = 1971210.
                Assert.That(Color.FromNotationColor(1971210), Is.EqualTo(new Color(10, 20, 30)));
                Assert.That(Color.FromNotationColor(16777215), Is.EqualTo(new Color(255, 255, 255)));

                Assert.That(new Color(150, 177, 218).ToHex(), Is.EqualTo("#96B1DA"));
                Assert.That(new Color(9, 92, 46).ToString(), Is.EqualTo("#095C2E"));
                Assert.That(new Color(1, 2, 3), Is.Not.EqualTo(new Color(1, 2, 4)));
                Assert.That(new Color(1, 2, 3) == new Color(1, 2, 3), Is.True);
                Assert.That(new Color(1, 2, 3) != new Color(3, 2, 1), Is.True);
                Assert.That(new Color(1, 2, 3).Equals((object)new Color(1, 2, 3)), Is.True);
                Assert.That(new Color(1, 2, 3).Equals("not a color"), Is.False);
                Assert.That(new Color(1, 2, 3).GetHashCode(), Is.EqualTo(new Color(1, 2, 3).GetHashCode()));
            });
        }

        [Test]
        public void Verify_that_the_resolver_guards_its_arguments()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => this.styleResolver.Resolve((Box)null!), Throws.ArgumentNullException);
                Assert.That(() => this.styleResolver.Resolve((Edge)null!), Throws.ArgumentNullException);
                Assert.That(() => new StyleResolver(null!), Throws.ArgumentNullException);
            });
        }

        [Test]
        public void Verify_that_a_sirius_square_style_resolves()
        {
            var square = new SiriusDiagram.Square
            {
                Color = "255,252,183",
                BorderColor = "123,105,79",
                BorderSize = 2,
                BorderLineStyle = SiriusDiagram.LineStyle.Dot,
                LabelColor = "1,2,3",
                LabelSize = 10,
            };
            square.LabelFormat.Add(Auriga.Diagram.Viewpoint.FontFormat.Bold);
            square.LabelFormat.Add(Auriga.Diagram.Viewpoint.FontFormat.Underline);

            var resolved = this.styleResolver.Resolve(BoxWith(square));

            Assert.Multiple(() =>
            {
                Assert.That(resolved.FillColor, Is.EqualTo(new Color(255, 252, 183)));
                Assert.That(resolved.StrokeColor, Is.EqualTo(new Color(123, 105, 79)));
                Assert.That(resolved.StrokeWidth, Is.EqualTo(2));
                Assert.That(resolved.Pattern, Is.EqualTo(LinePattern.Dot));
                Assert.That(resolved.FontColor, Is.EqualTo(new Color(1, 2, 3)));
                Assert.That(resolved.FontSize, Is.EqualTo(10));
                Assert.That(resolved.Bold, Is.True);
                Assert.That(resolved.Underline, Is.True);
                Assert.That(resolved.Italic, Is.False);
            });
        }

        [Test]
        public void Verify_that_a_flat_container_style_resolves_its_gradient()
        {
            var flat = new SiriusDiagram.FlatContainerStyle
            {
                BackgroundColor = "249,248,245",
                ForegroundColor = "242,238,225",
                BorderColor = "69,69,69",
                BorderSize = 1,
            };

            var resolved = this.styleResolver.Resolve(BoxWith(flat));

            Assert.Multiple(() =>
            {
                Assert.That(resolved.FillColor, Is.EqualTo(new Color(249, 248, 245)));
                Assert.That(resolved.GradientColor, Is.EqualTo(new Color(242, 238, 225)));
                Assert.That(resolved.StrokeColor, Is.EqualTo(new Color(69, 69, 69)));
            });
        }

        [Test]
        public void Verify_that_every_shape_style_resolves_its_fill()
        {
            // Each concrete Sirius node style names its fill differently; all must resolve.
            var fill = new Color(9, 8, 7);

            var shapes = new Auriga.Diagram.Viewpoint.IStyle[]
            {
                new SiriusDiagram.Ellipse { Color = "9,8,7" },
                new SiriusDiagram.Lozenge { Color = "9,8,7" },
                new SiriusDiagram.BundledImage { Color = "9,8,7" },
                new SiriusDiagram.Note { Color = "9,8,7" },
                new SiriusDiagram.Dot { BackgroundColor = "9,8,7" },
                new SiriusDiagram.ShapeContainerStyle { BackgroundColor = "9,8,7" },
            };

            Assert.Multiple(() =>
            {
                foreach (var shape in shapes)
                {
                    Assert.That(this.styleResolver.Resolve(BoxWith(shape)).FillColor, Is.EqualTo(fill), shape.GetType().Name);
                }

                // The elliptic styles resolve their outline shape; everything else stays rectangular.
                Assert.That(this.styleResolver.Resolve(BoxWith(new SiriusDiagram.Ellipse())).Shape, Is.EqualTo(ShapeKind.Ellipse));
                Assert.That(this.styleResolver.Resolve(BoxWith(new SiriusDiagram.Dot())).Shape, Is.EqualTo(ShapeKind.Ellipse));
                Assert.That(this.styleResolver.Resolve(BoxWith(new SiriusDiagram.Square())).Shape, Is.EqualTo(ShapeKind.Rectangle));
            });
        }

        [Test]
        public void Verify_that_a_workspace_image_style_resolves_its_path()
        {
            var image = new SiriusDiagram.WorkspaceImage { WorkspacePath = "/plugin/images/Actor.svg" };

            var resolved = this.styleResolver.Resolve(BoxWith(image));

            Assert.That(resolved.ImagePath, Is.EqualTo("/plugin/images/Actor.svg"));
        }

        [Test]
        public void Verify_that_a_sirius_edge_style_resolves()
        {
            var edgeStyle = new SiriusDiagram.EdgeStyle
            {
                StrokeColor = "114,73,110",
                Size = 3,
                LineStyle = SiriusDiagram.LineStyle.Dash,
                SourceArrow = SiriusDiagram.EdgeArrows.Diamond,
                TargetArrow = SiriusDiagram.EdgeArrows.InputArrow,
                CenterLabelStyle = new SiriusDiagram.CenterLabelStyle { LabelColor = "5,6,7" },
            };

            var resolved = this.styleResolver.Resolve(EdgeWith(edgeStyle));

            Assert.Multiple(() =>
            {
                Assert.That(resolved.StrokeColor, Is.EqualTo(new Color(114, 73, 110)));
                Assert.That(resolved.StrokeWidth, Is.EqualTo(3));
                Assert.That(resolved.Pattern, Is.EqualTo(LinePattern.Dash));
                Assert.That(resolved.SourceArrow, Is.EqualTo(SiriusDiagram.EdgeArrows.Diamond));
                Assert.That(resolved.TargetArrow, Is.EqualTo(SiriusDiagram.EdgeArrows.InputArrow));
                Assert.That(resolved.FontColor, Is.EqualTo(new Color(5, 6, 7)));
            });
        }

        [Test]
        public void Verify_that_notation_styles_apply_without_a_sirius_style()
        {
            var shapeStyle = new Notation.ShapeStyle
            {
                FontName = "Ubuntu",
                FontHeight = 12,
                Bold = true,
                FontColor = 1971210,

                // packed blue<<16|green<<8|red for (40, 30, 20) and (90, 80, 70)
                FillColor = (20 << 16) | (30 << 8) | 40,
                LineColor = (70 << 16) | (80 << 8) | 90,
                LineWidth = 4,
            };

            var resolved = this.styleResolver.Resolve(BoxWith(null, shapeStyle));

            Assert.Multiple(() =>
            {
                Assert.That(resolved.FontName, Is.EqualTo("Ubuntu"));
                Assert.That(resolved.FontSize, Is.EqualTo(12));
                Assert.That(resolved.Bold, Is.True);
                Assert.That(resolved.FontColor, Is.EqualTo(new Color(10, 20, 30)));
                Assert.That(resolved.FillColor, Is.EqualTo(new Color(40, 30, 20)));
                Assert.That(resolved.StrokeColor, Is.EqualTo(new Color(90, 80, 70)));
                Assert.That(resolved.StrokeWidth, Is.EqualTo(4));
            });
        }

        [Test]
        public void Verify_that_a_present_sirius_style_wins_with_its_metamodel_defaults()
        {
            var shapeStyle = new Notation.ShapeStyle
            {
                FontName = "Ubuntu",
                FontHeight = 12,
                FontColor = 1971210,
                LineColor = (70 << 16) | (80 << 8) | 90,
            };

            // A Sirius owned style carries its metamodel defaults even for attributes the file does
            // not serialize (EMF default semantics, #76): labelSize 8, labelColor and borderColor
            // black. When the style is present those defaulted values win over the notation
            // fallbacks; only properties without a Sirius counterpart (the font family) keep the
            // notation values.
            var square = new SiriusDiagram.Square { Color = "1,1,1" };

            var resolved = this.styleResolver.Resolve(BoxWith(square, shapeStyle));

            Assert.Multiple(() =>
            {
                Assert.That(resolved.FillColor, Is.EqualTo(new Color(1, 1, 1)), "the Sirius fill wins over the notation fill");
                Assert.That(resolved.FontName, Is.EqualTo("Ubuntu"), "no Sirius counterpart: the notation font family survives");
                Assert.That(resolved.FontSize, Is.EqualTo(8), "the Sirius default label size");
                Assert.That(resolved.FontColor, Is.EqualTo(new Color(0, 0, 0)), "the Sirius default label color");
                Assert.That(resolved.StrokeColor, Is.EqualTo(new Color(0, 0, 0)), "the Sirius default border color");
            });
        }

        [Test]
        public void Verify_the_capella_palette_fallbacks()
        {
            Assert.Multiple(() =>
            {
                var function = this.styleResolver.Resolve(BoxFor(new Auriga.Model.Ctx.SystemFunction()));
                Assert.That(function.FillColor, Is.EqualTo(new Color(197, 255, 166)), "function green");
                Assert.That(function.StrokeColor, Is.EqualTo(new Color(77, 137, 20)));

                var component = this.styleResolver.Resolve(BoxFor(new Auriga.Model.La.LogicalComponent()));
                Assert.That(component.FillColor, Is.EqualTo(new Color(150, 177, 218)), "component blue");

                var activity = this.styleResolver.Resolve(BoxFor(new Auriga.Model.Oa.OperationalActivity()));
                Assert.That(activity.FillColor, Is.EqualTo(new Color(247, 218, 116)), "activity orange");

                var unknown = this.styleResolver.Resolve(BoxFor(new object()));
                Assert.That(unknown.FillColor, Is.Null, "an unknown type stays unfilled");
                Assert.That(unknown.StrokeColor, Is.EqualTo(new Color(0, 0, 0)));

                var physicalLink = this.styleResolver.Resolve(EdgeFor(new Auriga.Model.Cs.PhysicalLink()));
                Assert.That(physicalLink.StrokeColor, Is.EqualTo(new Color(239, 41, 41)), "physical link red");
                Assert.That(physicalLink.StrokeWidth, Is.EqualTo(2));

                var plainEdge = this.styleResolver.Resolve(EdgeFor(null));
                Assert.That(plainEdge.StrokeColor, Is.EqualTo(new Color(0, 0, 0)));
                Assert.That(plainEdge.StrokeWidth, Is.EqualTo(1));
            });
        }

        [Test]
        public void Verify_that_font_flags_label_formats_and_solid_lines_resolve()
        {
            var shapeStyle = new Notation.ShapeStyle { Italic = true, Underline = true, StrikeThrough = true };
            var box = this.styleResolver.Resolve(BoxWith(null, shapeStyle));

            var centerLabel = new SiriusDiagram.CenterLabelStyle { LabelSize = 0 };
            centerLabel.LabelFormat.Add(Auriga.Diagram.Viewpoint.FontFormat.Bold);
            centerLabel.LabelFormat.Add(Auriga.Diagram.Viewpoint.FontFormat.Italic);
            centerLabel.LabelFormat.Add(Auriga.Diagram.Viewpoint.FontFormat.Underline);
            centerLabel.LabelFormat.Add(Auriga.Diagram.Viewpoint.FontFormat.Strike_through);

            var edgeStyle = new SiriusDiagram.EdgeStyle
            {
                Size = 0,
                LineStyle = SiriusDiagram.LineStyle.Solid,
                CenterLabelStyle = centerLabel,
            };

            var edge = this.styleResolver.Resolve(EdgeWith(edgeStyle));

            Assert.Multiple(() =>
            {
                Assert.That(box.Italic, Is.True);
                Assert.That(box.Underline, Is.True);
                Assert.That(box.StrikeThrough, Is.True);

                Assert.That(edge.Pattern, Is.EqualTo(LinePattern.Solid));
                Assert.That(edge.StrokeWidth, Is.EqualTo(1), "a zero size does not override the hairline default");
                Assert.That(edge.Bold, Is.True);
                Assert.That(edge.Italic, Is.True);
                Assert.That(edge.Underline, Is.True);
                Assert.That(edge.StrikeThrough, Is.True);
            });
        }

        [Test]
        public void Verify_that_unknown_and_malformed_styles_fall_back_without_throwing()
        {
            // A style type the resolver has no case for, and a square with malformed color values:
            // both must resolve to the defaults rather than throw.
            var exotic = new SiriusDiagram.GaugeCompositeStyle();
            var malformed = new SiriusDiagram.Square { Color = "not-a-color", BorderColor = string.Empty };

            Assert.Multiple(() =>
            {
                Assert.That(() => this.styleResolver.Resolve(BoxWith(exotic)), Throws.Nothing);
                var resolved = this.styleResolver.Resolve(BoxWith(malformed));
                Assert.That(resolved.FillColor, Is.Null);
                Assert.That(resolved.StrokeColor, Is.EqualTo(new Color(0, 0, 0)));
                Assert.That(resolved.Pattern, Is.EqualTo(LinePattern.Solid));
            });
        }

        /// <summary>
        /// Builds a box carrying the supplied styling sources and no semantic element.
        /// </summary>
        /// <param name="siriusStyle">the Sirius owned style, or <c>null</c></param>
        /// <param name="notationStyles">the notation styles</param>
        /// <returns>the box</returns>
        private static Box BoxWith(Auriga.Diagram.Viewpoint.IStyle? siriusStyle, params Notation.IStyle[] notationStyles)
        {
            return new Box("box", new Point(0, 0), new Notation.Node(), new Style(siriusStyle, new List<Notation.IStyle>(notationStyles)));
        }

        /// <summary>
        /// Builds an unstyled box representing the supplied semantic element, so only the palette
        /// fallback applies.
        /// </summary>
        /// <param name="semanticElement">the semantic element</param>
        /// <returns>the box</returns>
        private static Box BoxFor(object? semanticElement)
        {
            var box = BoxWith(null);
            box.SemanticElement = semanticElement;
            return box;
        }

        /// <summary>
        /// Builds an edge carrying the supplied styling sources and no semantic element.
        /// </summary>
        /// <param name="siriusStyle">the Sirius owned style, or <c>null</c></param>
        /// <returns>the edge</returns>
        private static Edge EdgeWith(Auriga.Diagram.Viewpoint.IStyle? siriusStyle)
        {
            return new Edge("edge", new List<Point>(), new Notation.Edge(), new Style(siriusStyle, new List<Notation.IStyle>()));
        }

        /// <summary>
        /// Builds an unstyled edge representing the supplied semantic element, so only the palette
        /// fallback applies.
        /// </summary>
        /// <param name="semanticElement">the semantic element</param>
        /// <returns>the edge</returns>
        private static Edge EdgeFor(object? semanticElement)
        {
            var edge = EdgeWith(null);
            edge.SemanticElement = semanticElement;
            return edge;
        }
    }
}
