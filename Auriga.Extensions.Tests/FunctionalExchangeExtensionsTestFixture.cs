// ------------------------------------------------------------------------------------------------
// <copyright file="FunctionalExchangeExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    /// Tests for <see cref="FunctionalExchangeExtensions"/>: resolving an exchange to its source and
    /// target functions.
    /// </summary>
    [TestFixture]
    public class FunctionalExchangeExtensionsTestFixture : CoffeeMachineModelTestFixture
    {
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
        public void Verify_that_the_extensions_guard_against_a_null_receiver()
        {
            Auriga.Fa.IFunctionalExchange exchange = null!;

            Assert.Multiple(() =>
            {
                Assert.That(() => exchange.QuerySourceFunction(), Throws.ArgumentNullException);
                Assert.That(() => exchange.QueryTargetFunction(), Throws.ArgumentNullException);
            });
        }
    }
}
