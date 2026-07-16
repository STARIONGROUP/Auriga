// ------------------------------------------------------------------------------------------------
// <copyright file="AurigaElementExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Extensions.Tests
{
    using Auriga.Core;
    using System.Linq;

    using Auriga.Extensions;

    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="AurigaElementExtensions"/>: containment navigation and typed subtree queries.
    /// </summary>
    [TestFixture]
    public class AurigaElementExtensionsTestFixture : CoffeeMachineModelTestFixture
    {
        [Test]
        public void Verify_that_the_test_model_loaded_with_all_references_resolved()
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
                Assert.That(functions, Has.All.InstanceOf<Auriga.Model.Fa.IAbstractFunction>());
                Assert.That(functions, Has.Some.InstanceOf<Auriga.Model.Ctx.ISystemFunction>());
            });
        }

        [Test]
        public void Verify_that_QueryAllComponents_returns_the_layer_components()
        {
            var components = this.project.SystemAnalysis!.QueryAllComponents().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(components, Is.Not.Empty);
                Assert.That(components, Has.All.InstanceOf<Auriga.Model.Cs.IComponent>());
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
        public void Verify_that_the_extensions_guard_against_a_null_receiver()
        {
            IAurigaElement element = null!;

            Assert.Multiple(() =>
            {
                Assert.That(() => element.QueryAncestors(), Throws.ArgumentNullException);
                Assert.That(() => element.QueryRoot(), Throws.ArgumentNullException);
                Assert.That(() => element.IsContainedIn(this.project.Project!), Throws.ArgumentNullException);
                Assert.That(() => element.QueryAllFunctions(), Throws.ArgumentNullException);
                Assert.That(() => element.QueryAllComponents(), Throws.ArgumentNullException);
            });
        }
    }
}
