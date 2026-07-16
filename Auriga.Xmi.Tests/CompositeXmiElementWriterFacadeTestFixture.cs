// ------------------------------------------------------------------------------------------------
// <copyright file="CompositeXmiElementWriterFacadeTestFixture.cs" company="Starion Group S.A.">
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
    using Auriga.Xmi.Core.Writers;

    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the <see cref="CompositeXmiElementWriterFacade"/>: that it routes an element to the
    /// constituent facade that can write its runtime type and reports an unwritable type with a message
    /// that names the configured facades.
    /// </summary>
    [TestFixture]
    public class CompositeXmiElementWriterFacadeTestFixture
    {
        private Mock<IXmiElementWriterFacade> capellaFacade = new Mock<IXmiElementWriterFacade>();

        private Mock<IXmiElementWriterFacade> siriusFacade = new Mock<IXmiElementWriterFacade>();

        private CompositeXmiElementWriterFacade composite = new CompositeXmiElementWriterFacade(new Mock<IXmiElementWriterFacade>().Object);

        [SetUp]
        public void SetUp()
        {
            this.capellaFacade = new Mock<IXmiElementWriterFacade>();
            this.siriusFacade = new Mock<IXmiElementWriterFacade>();
            this.composite = new CompositeXmiElementWriterFacade(this.capellaFacade.Object, this.siriusFacade.Object);
        }

        [Test]
        public void Verify_that_the_constructor_guards_its_arguments()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => new CompositeXmiElementWriterFacade(null!), Throws.ArgumentNullException);
                Assert.That(() => new CompositeXmiElementWriterFacade(), Throws.ArgumentException);
            });
        }

        [Test]
        public void Verify_that_can_write_is_the_union_of_the_constituents()
        {
            var element = new Mock<IAurigaElement>().Object;
            this.siriusFacade.Setup(facade => facade.CanWrite(element)).Returns(true);

            Assert.That(this.composite.CanWrite(element), Is.True);
        }

        [Test]
        public void Verify_that_an_element_is_written_by_the_facade_that_owns_its_type()
        {
            var element = new Mock<IAurigaElement>().Object;
            var context = new Mock<IXmiWriteContext>().Object;
            this.capellaFacade.Setup(facade => facade.CanWrite(element)).Returns(false);
            this.siriusFacade.Setup(facade => facade.CanWrite(element)).Returns(true);

            this.composite.WriteElement(null!, element, "ownedViews", context);

            this.siriusFacade.Verify(facade => facade.WriteElement(It.IsAny<XmlWriter>(), element, "ownedViews", context), Times.Once);
            this.capellaFacade.Verify(
                facade => facade.WriteElement(It.IsAny<XmlWriter>(), It.IsAny<IAurigaElement>(), It.IsAny<string>(), It.IsAny<IXmiWriteContext>()),
                Times.Never);
        }

        [Test]
        public void Verify_that_resolve_writer_routes_to_the_owning_facade()
        {
            var element = new Mock<IAurigaElement>().Object;
            var writer = new Mock<IXmiElementWriter>().Object;
            this.capellaFacade.Setup(facade => facade.CanWrite(element)).Returns(true);
            this.capellaFacade.Setup(facade => facade.ResolveWriter(element)).Returns(writer);

            Assert.That(this.composite.ResolveWriter(element), Is.SameAs(writer));
        }

        [Test]
        public void Verify_that_an_unwritable_type_reports_the_configured_facades()
        {
            var element = new Mock<IAurigaElement>().Object;

            Assert.That(
                () => this.composite.ResolveWriter(element),
                Throws.InvalidOperationException.With.Message.Contains("No XMI writer is registered"));
        }
    }
}
