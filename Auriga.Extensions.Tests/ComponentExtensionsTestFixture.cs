// ------------------------------------------------------------------------------------------------
// <copyright file="ComponentExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Extensions.Tests
{
    using System.Linq;

    using Auriga.Extensions;

    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="ComponentExtensions"/>: component ports and cross-layer component realization.
    /// </summary>
    [TestFixture]
    public class ComponentExtensionsTestFixture : CoffeeMachineModelTestFixture
    {
        [Test]
        public void Verify_that_a_component_reports_its_ports()
        {
            var component = this.project.Project!.QueryAllComponents()
                .FirstOrDefault(candidate => candidate.QueryComponentPorts().Any());

            Assert.That(component, Is.Not.Null, "expected a component that owns ports");
            Assert.That(component!.QueryComponentPorts(), Has.All.InstanceOf<Auriga.Model.Fa.IComponentPort>());
        }

        [Test]
        public void Verify_that_component_realization_is_symmetric_across_layers()
        {
            var candidate = this.project.Project!.QueryAllComponents()
                .FirstOrDefault(component => component.QueryRealizedComponents().Any());

            Assert.That(candidate, Is.Not.Null, "expected a component that realizes another");

            var realizing = candidate!;
            var realized = realizing.QueryRealizedComponents().First();

            Assert.Multiple(() =>
            {
                Assert.That(realized, Is.Not.SameAs(realizing));
                Assert.That(realized.QueryRealizingComponents(), Does.Contain(realizing));
            });
        }

        [Test]
        public void Verify_that_the_extensions_guard_against_a_null_receiver()
        {
            Auriga.Model.Cs.IComponent component = null!;

            Assert.Multiple(() =>
            {
                Assert.That(() => component.QueryComponentPorts(), Throws.ArgumentNullException);
                Assert.That(() => component.QueryRealizedComponents(), Throws.ArgumentNullException);
                Assert.That(() => component.QueryRealizingComponents(), Throws.ArgumentNullException);
            });
        }
    }
}
