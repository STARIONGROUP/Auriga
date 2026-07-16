// ------------------------------------------------------------------------------------------------
// <copyright file="AbstractFunctionalBlockExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    /// Tests for <see cref="AbstractFunctionalBlockExtensions"/>: the functions allocated to a block.
    /// </summary>
    [TestFixture]
    public class AbstractFunctionalBlockExtensionsTestFixture : CoffeeMachineModelTestFixture
    {
        [Test]
        public void Verify_that_QueryAllocatedFunctions_returns_the_allocated_functions()
        {
            var candidate = this.project.SystemAnalysis!.QueryAllComponents()
                .FirstOrDefault(component => component.QueryAllocatedFunctions().Any());

            Assert.That(candidate, Is.Not.Null, "expected a component with allocated functions");

            var block = candidate!;

            Assert.That(
                block.QueryAllocatedFunctions(),
                Is.Not.Empty.And.All.InstanceOf<Auriga.Model.Fa.IAbstractFunction>());
        }

        [Test]
        public void Verify_that_the_extension_guards_against_a_null_receiver()
        {
            Auriga.Model.Fa.IAbstractFunctionalBlock block = null!;

            Assert.That(() => block.QueryAllocatedFunctions(), Throws.ArgumentNullException);
        }
    }
}
