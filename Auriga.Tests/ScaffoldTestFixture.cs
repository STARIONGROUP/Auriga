// ------------------------------------------------------------------------------------------------
// <copyright file="ScaffoldTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tests
{
    using System.Reflection;

    using NUnit.Framework;

    /// <summary>
    /// Smoke-test fixture proving the test infrastructure runs and the Auriga library
    /// assembly is referenced; expanded with real tests as the Auriga object model is
    /// generated (issues #6-#8).
    /// </summary>
    [TestFixture]
    public class ScaffoldTestFixture
    {
        [Test]
        public void Verify_that_the_Auriga_assembly_is_available()
        {
            var assembly = Assembly.Load("Auriga");

            Assert.That(assembly.GetName().Name, Is.EqualTo("Auriga"));
        }
    }
}
