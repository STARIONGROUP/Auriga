// ------------------------------------------------------------------------------------------------
// <copyright file="CompositeXmiReaderFacadeTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System;
    using System.Xml;

    using Auriga.Core;
    using Auriga.Xmi.Core.Readers;

    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the <see cref="CompositeXmiReaderFacade"/>: that it routes a type key to the
    /// constituent facade that can read it, forwards namespace registrations to every constituent,
    /// delegates type-key resolution to the first constituent, and reports an unreadable type with a
    /// message that names the configured facades.
    /// </summary>
    [TestFixture]
    public class CompositeXmiReaderFacadeTestFixture
    {
        private Mock<IXmiReaderFacade> capellaFacade = new Mock<IXmiReaderFacade>();

        private Mock<IXmiReaderFacade> siriusFacade = new Mock<IXmiReaderFacade>();

        private CompositeXmiReaderFacade composite = new CompositeXmiReaderFacade(new Mock<IXmiReaderFacade>().Object);

        [SetUp]
        public void SetUp()
        {
            this.capellaFacade = new Mock<IXmiReaderFacade>();
            this.siriusFacade = new Mock<IXmiReaderFacade>();
            this.composite = new CompositeXmiReaderFacade(this.capellaFacade.Object, this.siriusFacade.Object);
        }

        [Test]
        public void Verify_that_the_constructor_guards_its_arguments()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => new CompositeXmiReaderFacade(null!), Throws.ArgumentNullException);
                Assert.That(() => new CompositeXmiReaderFacade(), Throws.ArgumentException);
            });
        }

        [Test]
        public void Verify_that_an_element_is_routed_to_the_facade_that_can_read_its_type()
        {
            var element = new Mock<IAurigaElement>().Object;
            this.capellaFacade.Setup(facade => facade.CanRead("viewpoint:DAnalysis")).Returns(false);
            this.siriusFacade.Setup(facade => facade.CanRead("viewpoint:DAnalysis")).Returns(true);
            this.siriusFacade
                .Setup(facade => facade.QueryElement(It.IsAny<XmlReader>(), "doc.aird", "ns", "viewpoint:DAnalysis"))
                .Returns(element);

            var result = this.composite.QueryElement(null!, "doc.aird", "ns", "viewpoint:DAnalysis");

            Assert.That(result, Is.SameAs(element));
            this.capellaFacade.Verify(
                facade => facade.QueryElement(It.IsAny<XmlReader>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public void Verify_that_an_unreadable_type_reports_the_configured_facades()
        {
            this.capellaFacade.Setup(facade => facade.CanRead(It.IsAny<string>())).Returns(false);
            this.siriusFacade.Setup(facade => facade.CanRead(It.IsAny<string>())).Returns(false);

            Assert.That(
                () => this.composite.QueryElement(null!, "doc", "ns", "unknown:Type"),
                Throws.InvalidOperationException.With.Message.Contains("unknown:Type"));
        }

        [Test]
        public void Verify_that_can_read_is_the_union_of_the_constituents()
        {
            this.capellaFacade.Setup(facade => facade.CanRead("pa:PhysicalFunction")).Returns(true);
            this.siriusFacade.Setup(facade => facade.CanRead("viewpoint:DAnalysis")).Returns(true);

            Assert.Multiple(() =>
            {
                Assert.That(this.composite.CanRead("pa:PhysicalFunction"), Is.True);
                Assert.That(this.composite.CanRead("viewpoint:DAnalysis"), Is.True);
                Assert.That(this.composite.CanRead("unknown:Type"), Is.False);
            });
        }

        [Test]
        public void Verify_that_namespace_registrations_are_forwarded_to_every_constituent()
        {
            this.composite.RegisterNamespace("pa", "http://www.polarsys.org/capella/core/pa/7.0.0");

            this.capellaFacade.Verify(facade => facade.RegisterNamespace("pa", "http://www.polarsys.org/capella/core/pa/7.0.0"), Times.Once);
            this.siriusFacade.Verify(facade => facade.RegisterNamespace("pa", "http://www.polarsys.org/capella/core/pa/7.0.0"), Times.Once);
        }

        [Test]
        public void Verify_that_type_key_resolution_is_delegated_to_the_first_constituent()
        {
            this.capellaFacade.Setup(facade => facade.ResolveTypeKey(It.IsAny<XmlReader>())).Returns("pa:PhysicalFunction");

            Assert.That(this.composite.ResolveTypeKey(null!), Is.EqualTo("pa:PhysicalFunction"));
            this.siriusFacade.Verify(facade => facade.ResolveTypeKey(It.IsAny<XmlReader>()), Times.Never);
        }

        [Test]
        public void Verify_that_a_resolved_type_key_is_used_when_no_explicit_key_is_supplied()
        {
            var element = new Mock<IAurigaElement>().Object;
            this.capellaFacade.Setup(facade => facade.ResolveTypeKey(It.IsAny<XmlReader>())).Returns("pa:PhysicalFunction");
            this.capellaFacade.Setup(facade => facade.CanRead("pa:PhysicalFunction")).Returns(true);
            this.capellaFacade
                .Setup(facade => facade.QueryElement(It.IsAny<XmlReader>(), "doc.capella", "ns", "pa:PhysicalFunction"))
                .Returns(element);

            var result = this.composite.QueryElement(null!, "doc.capella", "ns");

            Assert.That(result, Is.SameAs(element));
        }
    }
}
