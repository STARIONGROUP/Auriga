// ------------------------------------------------------------------------------------------------
// <copyright file="QueryExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Extensions.Tests
{
    using System.IO;
    using System.Linq;

    using Auriga.Extensions;
    using Auriga.Xmi;

    using NUnit.Framework;

    /// <summary>
    /// Exercises the <see cref="Auriga.Extensions"/> query extension methods against the coffee-machine
    /// demo model: containment navigation, function/component enumeration, component-functional
    /// allocation, function and component ports, functional exchanges, and cross-layer realization.
    /// </summary>
    [TestFixture]
    public class QueryExtensionsTestFixture
    {
        private CapellaProject project = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "coffee-machine-demo.capella");
            this.project = CapellaProject.Load(path);
        }

        [Test]
        public void Verify_that_the_model_loaded_with_all_references_resolved()
        {
            Assert.That(this.project.UnresolvedReferences, Is.Empty);
        }

        [Test]
        public void Verify_that_QueryAllFunctions_returns_the_layer_functions()
        {
            var functions = this.project.SystemAnalysis!.QueryAllFunctions().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(functions, Is.Not.Empty);
                Assert.That(functions, Has.All.InstanceOf<Auriga.Fa.IAbstractFunction>());
                Assert.That(functions, Has.Some.InstanceOf<Auriga.Ctx.ISystemFunction>());
            });
        }

        [Test]
        public void Verify_that_QueryAllComponents_returns_the_layer_components()
        {
            var components = this.project.SystemAnalysis!.QueryAllComponents().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(components, Is.Not.Empty);
                Assert.That(components, Has.All.InstanceOf<Auriga.Cs.IComponent>());
            });
        }

        [Test]
        public void Verify_that_a_function_walks_up_to_the_project_root()
        {
            var function = this.project.SystemAnalysis!.QueryAllFunctions().First();

            Assert.Multiple(() =>
            {
                Assert.That(function.QueryRoot(), Is.SameAs(this.project.Project));
                Assert.That(function.IsContainedIn(this.project.SystemAnalysis!), Is.True);
                Assert.That(function.QueryAncestors(), Does.Contain(this.project.SystemAnalysis));
            });
        }

        [Test]
        public void Verify_that_component_functional_allocation_is_symmetric()
        {
            var candidate = this.project.SystemAnalysis!.QueryAllComponents()
                .FirstOrDefault(component => component.QueryAllocatedFunctions().Any());

            Assert.That(candidate, Is.Not.Null, "expected a component with allocated functions");

            var block = candidate!;
            var allocatedFunctions = block.QueryAllocatedFunctions().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(allocatedFunctions, Is.Not.Empty);

                foreach (var function in allocatedFunctions)
                {
                    Assert.That(function.IsAllocatedTo(block), Is.True);
                    Assert.That(function.QueryAllocatingBlocks(), Does.Contain(block));
                }
            });
        }

        [Test]
        public void Verify_that_a_functional_exchange_links_its_source_and_target_functions()
        {
            var exchanges = this.project.Project!.QueryAllContainedElements()
                .OfType<Auriga.Fa.IFunctionalExchange>()
                .ToList();

            Assert.That(exchanges, Is.Not.Empty);

            Assert.Multiple(() =>
            {
                foreach (var exchange in exchanges)
                {
                    Assert.That(exchange.QuerySourceFunction(), Is.InstanceOf<Auriga.Fa.IAbstractFunction>());
                    Assert.That(exchange.QueryTargetFunction(), Is.InstanceOf<Auriga.Fa.IAbstractFunction>());
                }
            });
        }

        [Test]
        public void Verify_that_a_function_reports_its_ports()
        {
            var function = this.project.Project!.QueryAllFunctions()
                .FirstOrDefault(candidate => candidate.QueryFunctionPorts().Any());

            Assert.That(function, Is.Not.Null, "expected a function that owns ports");
            Assert.That(function!.QueryFunctionPorts(), Has.All.InstanceOf<Auriga.Fa.IFunctionPort>());
        }

        [Test]
        public void Verify_that_a_component_reports_its_ports()
        {
            var component = this.project.Project!.QueryAllComponents()
                .FirstOrDefault(candidate => candidate.QueryComponentPorts().Any());

            Assert.That(component, Is.Not.Null, "expected a component that owns ports");
            Assert.That(component!.QueryComponentPorts(), Has.All.InstanceOf<Auriga.Fa.IComponentPort>());
        }

        [Test]
        public void Verify_that_function_realization_is_symmetric_across_layers()
        {
            var realizing = this.project.Project!.QueryAllFunctions()
                .FirstOrDefault(function => function.QueryRealizedFunctions().Any());

            Assert.That(realizing, Is.Not.Null, "expected a function that realizes another");

            var realized = realizing!.QueryRealizedFunctions().First();

            Assert.Multiple(() =>
            {
                Assert.That(realized, Is.Not.SameAs(realizing));
                Assert.That(realized.QueryRealizingFunctions(), Does.Contain(realizing));
            });
        }

        [Test]
        public void Verify_that_component_realization_is_symmetric_across_layers()
        {
            var realizing = this.project.Project!.QueryAllComponents()
                .FirstOrDefault(component => component.QueryRealizedComponents().Any());

            Assert.That(realizing, Is.Not.Null, "expected a component that realizes another");

            var realized = realizing!.QueryRealizedComponents().First();

            Assert.Multiple(() =>
            {
                Assert.That(realized, Is.Not.SameAs(realizing));
                Assert.That(realized.QueryRealizingComponents(), Does.Contain(realizing));
            });
        }

        [Test]
        public void Verify_that_the_extensions_guard_against_a_null_receiver()
        {
            IAurigaElement element = null!;
            Auriga.Fa.IAbstractFunction function = null!;
            Auriga.Fa.IAbstractFunctionalBlock block = null!;
            Auriga.Cs.IComponent component = null!;
            Auriga.Fa.IFunctionalExchange exchange = null!;

            Assert.Multiple(() =>
            {
                Assert.That(() => element.QueryAncestors(), Throws.ArgumentNullException);
                Assert.That(() => element.QueryRoot(), Throws.ArgumentNullException);
                Assert.That(() => element.QueryAllFunctions(), Throws.ArgumentNullException);
                Assert.That(() => element.QueryAllComponents(), Throws.ArgumentNullException);
                Assert.That(() => function.QueryFunctionPorts(), Throws.ArgumentNullException);
                Assert.That(() => function.QueryAllocatingBlocks(), Throws.ArgumentNullException);
                Assert.That(() => function.QueryRealizedFunctions(), Throws.ArgumentNullException);
                Assert.That(() => function.QueryRealizingFunctions(), Throws.ArgumentNullException);
                Assert.That(() => block.QueryAllocatedFunctions(), Throws.ArgumentNullException);
                Assert.That(() => component.QueryComponentPorts(), Throws.ArgumentNullException);
                Assert.That(() => component.QueryRealizedComponents(), Throws.ArgumentNullException);
                Assert.That(() => component.QueryRealizingComponents(), Throws.ArgumentNullException);
                Assert.That(() => exchange.QuerySourceFunction(), Throws.ArgumentNullException);
                Assert.That(() => exchange.QueryTargetFunction(), Throws.ArgumentNullException);
            });
        }
    }
}
