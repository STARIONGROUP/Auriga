// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System.IO;
    using System.Linq;

    using NUnit.Framework;

    /// <summary>
    /// Tests the <see cref="XmiReader"/> against the minimal hand-crafted <c>.melodymodeller</c> fixture
    /// (issue #4): every element must load into a correctly-typed object with its attribute values and
    /// intra-file cross-references resolved (issue #10).
    /// </summary>
    [TestFixture]
    public class XmiReaderTestFixture
    {
        private const string Project = "a0000000-0000-4000-8000-000000000001";
        private const string SystemEngineering = "a0000000-0000-4000-8000-000000000002";
        private const string PhysicalArchitecture = "a0000000-0000-4000-8000-000000000003";
        private const string RootPhysicalFunction = "a0000000-0000-4000-8000-000000000011";
        private const string AcquireSensorData = "a0000000-0000-4000-8000-000000000012";
        private const string Fop1 = "a0000000-0000-4000-8000-000000000013";
        private const string Fip1 = "a0000000-0000-4000-8000-000000000015";
        private const string FunctionalExchange = "a0000000-0000-4000-8000-000000000016";
        private const string PartPhysicalSystem = "a0000000-0000-4000-8000-000000000021";
        private const string PhysicalSystem = "a0000000-0000-4000-8000-000000000022";
        private const string ControllerNode = "a0000000-0000-4000-8000-000000000024";
        private const string ControlSoftware = "a0000000-0000-4000-8000-000000000026";
        private const string SensorNode = "a0000000-0000-4000-8000-000000000030";
        private const string FunctionalAllocation = "a0000000-0000-4000-8000-000000000029";
        private const string PhysicalLink = "a0000000-0000-4000-8000-000000000033";
        private const string Pp1 = "a0000000-0000-4000-8000-000000000028";
        private const string Pp2 = "a0000000-0000-4000-8000-000000000031";

        private XmiReaderResult result = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "minimal.melodymodeller");
            this.result = XmiReaderBuilder.Create().Build().Read(path);
        }

        [Test]
        public void Verify_that_every_identified_element_is_read()
        {
            Assert.That(this.result.Elements, Has.Count.EqualTo(25));
        }

        [Test]
        public void Verify_that_the_root_is_a_named_project()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.result.Root, Is.InstanceOf<Auriga.Capellamodeller.IProject>());
                Assert.That(((Auriga.Capellamodeller.IProject)this.result.Root).Name, Is.EqualTo("Minimal"));
                Assert.That(this.result.Root.Id, Is.EqualTo(Project));
            });
        }

        [Test]
        public void Verify_that_elements_are_instantiated_as_their_concrete_types()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.result.Elements[SystemEngineering], Is.InstanceOf<Auriga.Capellamodeller.ISystemEngineering>());
                Assert.That(this.result.Elements[PhysicalArchitecture], Is.InstanceOf<Auriga.Pa.IPhysicalArchitecture>());
                Assert.That(this.result.Elements[RootPhysicalFunction], Is.InstanceOf<Auriga.Pa.IPhysicalFunction>());
                Assert.That(this.result.Elements[PhysicalSystem], Is.InstanceOf<Auriga.Pa.IPhysicalComponent>());
                Assert.That(this.result.Elements[PartPhysicalSystem], Is.InstanceOf<Auriga.Cs.IPart>());
                Assert.That(this.result.Elements[FunctionalExchange], Is.InstanceOf<Auriga.Fa.IFunctionalExchange>());
                Assert.That(this.result.Elements[Fop1], Is.InstanceOf<Auriga.Fa.IFunctionOutputPort>());
                Assert.That(this.result.Elements[Fip1], Is.InstanceOf<Auriga.Fa.IFunctionInputPort>());
                Assert.That(this.result.Elements[PhysicalLink], Is.InstanceOf<Auriga.Cs.IPhysicalLink>());
                Assert.That(this.result.Elements[Pp1], Is.InstanceOf<Auriga.Cs.IPhysicalPort>());
            });
        }

        [Test]
        public void Verify_that_concrete_type_counts_match_the_fixture()
        {
            var elements = this.result.Elements.Values.ToList();

            Assert.Multiple(() =>
            {
                Assert.That(elements.OfType<Auriga.Pa.IPhysicalComponent>().Count(), Is.EqualTo(4));
                Assert.That(elements.OfType<Auriga.Pa.IPhysicalFunction>().Count(), Is.EqualTo(3));
                Assert.That(elements.OfType<Auriga.Cs.IPart>().Count(), Is.EqualTo(4));
                Assert.That(elements.OfType<Auriga.Cs.IPhysicalPort>().Count(), Is.EqualTo(2));
                Assert.That(elements.OfType<Auriga.Fa.IFunctionalExchange>().Count(), Is.EqualTo(1));
            });
        }

        [Test]
        public void Verify_that_string_attributes_are_populated()
        {
            var acquire = (Auriga.Pa.IPhysicalFunction)this.result.Elements[AcquireSensorData];

            Assert.That(acquire.Name, Is.EqualTo("Acquire Sensor Data"));
        }

        [Test]
        public void Verify_that_enum_attributes_are_parsed()
        {
            Assert.Multiple(() =>
            {
                Assert.That(((Auriga.Pa.IPhysicalComponent)this.result.Elements[ControllerNode]).Nature, Is.EqualTo(Auriga.Pa.PhysicalComponentNature.NODE));
                Assert.That(((Auriga.Pa.IPhysicalComponent)this.result.Elements[ControlSoftware]).Nature, Is.EqualTo(Auriga.Pa.PhysicalComponentNature.BEHAVIOR));
                Assert.That(((Auriga.Pa.IPhysicalComponent)this.result.Elements[SensorNode]).Nature, Is.EqualTo(Auriga.Pa.PhysicalComponentNature.NODE));
            });
        }

        [Test]
        public void Verify_that_single_valued_references_are_resolved()
        {
            var exchange = (Auriga.Fa.IFunctionalExchange)this.result.Elements[FunctionalExchange];

            Assert.Multiple(() =>
            {
                Assert.That(exchange.Source, Is.SameAs(this.result.Elements[Fop1]));
                Assert.That(exchange.Target, Is.SameAs(this.result.Elements[Fip1]));
            });
        }

        [Test]
        public void Verify_that_a_part_abstract_type_reference_is_resolved()
        {
            var part = (Auriga.Cs.IPart)this.result.Elements[PartPhysicalSystem];

            Assert.That(part.AbstractType, Is.SameAs(this.result.Elements[PhysicalSystem]));
        }

        [Test]
        public void Verify_that_functional_allocation_references_are_resolved()
        {
            var allocation = (Auriga.Fa.IComponentFunctionalAllocation)this.result.Elements[FunctionalAllocation];

            Assert.Multiple(() =>
            {
                Assert.That(allocation.SourceElement, Is.SameAs(this.result.Elements[ControlSoftware]));
                Assert.That(allocation.TargetElement, Is.SameAs(this.result.Elements[AcquireSensorData]));
            });
        }

        [Test]
        public void Verify_that_multi_valued_references_are_resolved()
        {
            var link = (Auriga.Cs.IPhysicalLink)this.result.Elements[PhysicalLink];

            Assert.That(link.LinkEnds, Has.Some.SameAs(this.result.Elements[Pp1]).Or.Some.SameAs(this.result.Elements[Pp2]));
        }
    }
}
