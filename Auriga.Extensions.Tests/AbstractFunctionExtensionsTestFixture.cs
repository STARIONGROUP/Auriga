// ------------------------------------------------------------------------------------------------
// <copyright file="AbstractFunctionExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    /// Tests for <see cref="AbstractFunctionExtensions"/>: function ports, component allocation, and
    /// cross-layer function realization.
    /// </summary>
    [TestFixture]
    public class AbstractFunctionExtensionsTestFixture : CoffeeMachineModelTestFixture
    {
        [Test]
        public void Verify_that_a_function_reports_its_ports()
        {
            var function = this.project.Project!.QueryAllFunctions()
                .FirstOrDefault(candidate => candidate.QueryFunctionPorts().Any());

            Assert.That(function, Is.Not.Null, "expected a function that owns ports");
            Assert.That(function!.QueryFunctionPorts(), Has.All.InstanceOf<Auriga.Fa.IFunctionPort>());
        }

        [Test]
        public void Verify_that_allocation_navigation_is_symmetric()
        {
            var candidate = this.project.SystemAnalysis!.QueryAllFunctions()
                .FirstOrDefault(function => function.QueryAllocatingBlocks().Any());

            Assert.That(candidate, Is.Not.Null, "expected a function allocated to a block");

            var function = candidate!;
            var blocks = function.QueryAllocatingBlocks().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(blocks, Is.Not.Empty);

                foreach (var block in blocks)
                {
                    Assert.That(function.IsAllocatedTo(block), Is.True);
                    Assert.That(block.QueryAllocatedFunctions(), Does.Contain(function));
                }
            });
        }

        [Test]
        public void Verify_that_function_realization_is_symmetric_across_layers()
        {
            var candidate = this.project.Project!.QueryAllFunctions()
                .FirstOrDefault(function => function.QueryRealizedFunctions().Any());

            Assert.That(candidate, Is.Not.Null, "expected a function that realizes another");

            var realizing = candidate!;
            var realized = realizing.QueryRealizedFunctions().First();

            Assert.Multiple(() =>
            {
                Assert.That(realized, Is.Not.SameAs(realizing));
                Assert.That(realized.QueryRealizingFunctions(), Does.Contain(realizing));
            });
        }

        [Test]
        public void Verify_that_the_extensions_guard_against_a_null_receiver()
        {
            Auriga.Fa.IAbstractFunction function = null!;
            var block = this.project.SystemAnalysis!.QueryAllComponents().First();

            Assert.Multiple(() =>
            {
                Assert.That(() => function.QueryFunctionPorts(), Throws.ArgumentNullException);
                Assert.That(() => function.QueryAllocatingBlocks(), Throws.ArgumentNullException);
                Assert.That(() => function.IsAllocatedTo(block), Throws.ArgumentNullException);
                Assert.That(() => function.QueryRealizedFunctions(), Throws.ArgumentNullException);
                Assert.That(() => function.QueryRealizingFunctions(), Throws.ArgumentNullException);
            });
        }
    }
}
