// ------------------------------------------------------------------------------------------------
// <copyright file="CapellaProjectTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System.IO;

    using NUnit.Framework;

    /// <summary>
    /// Exercises <see cref="CapellaProject"/>, the architecture-layer facade: navigating
    /// <c>project.&lt;Layer&gt;</c> reaches the correct layer roots, and absent layers surface as
    /// <c>null</c>.
    /// </summary>
    [TestFixture]
    public class CapellaProjectTestFixture
    {
        [Test]
        [TestCase("coffee-machine-demo.capella")]
        [TestCase("in-flight-entertainment-system.capella")]
        public void Verify_that_every_architecture_layer_is_reachable(string fileName)
        {
            var project = CapellaProject.Load(ModelFile(fileName));

            Assert.Multiple(() =>
            {
                Assert.That(project.Project, Is.InstanceOf<Auriga.Capellamodeller.IProject>());
                Assert.That(project.SystemEngineering, Is.Not.Null);
                Assert.That(project.OperationalAnalysis, Is.InstanceOf<Auriga.Oa.IOperationalAnalysis>());
                Assert.That(project.SystemAnalysis, Is.InstanceOf<Auriga.Ctx.ISystemAnalysis>());
                Assert.That(project.LogicalArchitecture, Is.InstanceOf<Auriga.La.ILogicalArchitecture>());
                Assert.That(project.PhysicalArchitecture, Is.InstanceOf<Auriga.Pa.IPhysicalArchitecture>());
                Assert.That(project.Epbs, Is.InstanceOf<Auriga.Epbs.IEPBSArchitecture>());
            });
        }

        [Test]
        public void Verify_that_a_layer_accessor_returns_the_system_engineering_architecture()
        {
            var project = CapellaProject.Load(ModelFile("coffee-machine-demo.capella"));

            Assert.Multiple(() =>
            {
                // The accessor returns the very architecture held by the SystemEngineering (not a copy),
                // and containment navigation (#15) walks back up to it.
                Assert.That(
                    project.SystemEngineering!.OwnedArchitectures,
                    Does.Contain(project.LogicalArchitecture));
                Assert.That(project.LogicalArchitecture!.Container, Is.SameAs(project.SystemEngineering));
            });
        }

        [Test]
        public void Verify_that_an_absent_layer_returns_null()
        {
            // The minimal model has only a physical architecture under its SystemEngineering.
            var project = CapellaProject.Load(ModelFile("minimal.melodymodeller"));

            Assert.Multiple(() =>
            {
                Assert.That(project.SystemEngineering, Is.Not.Null);
                Assert.That(project.PhysicalArchitecture, Is.Not.Null);
                Assert.That(project.OperationalAnalysis, Is.Null);
                Assert.That(project.SystemAnalysis, Is.Null);
                Assert.That(project.LogicalArchitecture, Is.Null);
                Assert.That(project.Epbs, Is.Null);
            });
        }

        [Test]
        public void Verify_that_the_wrapper_exposes_the_underlying_graph()
        {
            var project = CapellaProject.Load(ModelFile("coffee-machine-demo.capella"));

            Assert.Multiple(() =>
            {
                Assert.That(project.Elements, Is.Not.Empty);
                Assert.That(project.UnresolvedReferences, Is.Empty);
            });
        }

        [Test]
        public void Verify_that_the_constructor_rejects_a_null_result()
        {
            Assert.That(() => new CapellaProject(null!), Throws.ArgumentNullException);
        }

        private static string ModelFile(string fileName)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", fileName);
        }
    }
}
