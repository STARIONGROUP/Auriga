// ------------------------------------------------------------------------------------------------
// <copyright file="SiriusObjectModelTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Tests
{
    using System.Linq;

    using Auriga.Sirius.Diagram;
    using Auriga.Sirius.Viewpoint;

    using NUnit.Framework;

    /// <summary>
    /// Exercises the generated <c>Auriga.Sirius</c> object model: that its containment features are wired
    /// through the shared <see cref="Auriga.ContainerList{T}"/> (setting the child's
    /// <see cref="Auriga.IAurigaElement.Container"/> and surfacing it from
    /// <see cref="Auriga.IAurigaElement.QueryContainedElements"/>) exactly as the Capella object model is,
    /// since both are produced by the same generator over the reused <see cref="Auriga.AurigaElement"/> base.
    /// </summary>
    [TestFixture]
    public class SiriusObjectModelTestFixture
    {
        [Test]
        public void Verify_that_a_containment_list_sets_the_container_and_surfaces_the_child()
        {
            var analysis = new DAnalysis();
            var view = new DView();

            analysis.OwnedViews.Add(view);

            Assert.Multiple(() =>
            {
                Assert.That(view.Container, Is.SameAs(analysis));
                Assert.That(analysis.OwnedViews, Has.Member(view));
                Assert.That(analysis.QueryContainedElements(), Has.Member(view));
            });
        }

        [Test]
        public void Verify_that_a_multi_level_containment_tree_is_navigable()
        {
            var analysis = new DAnalysis();
            var view = new DView();
            var descriptor = new DRepresentationDescriptor();

            analysis.OwnedViews.Add(view);
            view.OwnedRepresentationDescriptors.Add(descriptor);

            Assert.Multiple(() =>
            {
                Assert.That(descriptor.Container, Is.SameAs(view));
                Assert.That(view.Container, Is.SameAs(analysis));
                Assert.That(view.QueryContainedElements(), Has.Member(descriptor));
            });
        }

        [Test]
        public void Verify_that_scalar_properties_and_generated_enums_are_usable()
        {
            var node = new DNode
            {
                Name = "coffee",
                Uid = "_abc",
            };

            var style = new EdgeStyle
            {
                LineStyle = LineStyle.Dash,
            };

            Assert.Multiple(() =>
            {
                Assert.That(node.Name, Is.EqualTo("coffee"));
                Assert.That(node.Uid, Is.EqualTo("_abc"));
                Assert.That(node, Is.InstanceOf<IDNode>());
                Assert.That(style.LineStyle, Is.EqualTo(LineStyle.Dash));
            });
        }
    }
}
