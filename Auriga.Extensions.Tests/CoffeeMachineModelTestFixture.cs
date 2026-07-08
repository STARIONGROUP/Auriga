// ------------------------------------------------------------------------------------------------
// <copyright file="CoffeeMachineModelTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Extensions.Tests
{
    using System.IO;

    using Auriga.Xmi;

    using NUnit.Framework;

    /// <summary>
    /// Base fixture for the query-extension test fixtures: loads the coffee-machine demo model once per
    /// derived fixture and exposes it as <see cref="project"/>.
    /// </summary>
    public abstract class CoffeeMachineModelTestFixture
    {
        /// <summary>
        /// The loaded coffee-machine project the query extensions are exercised against.
        /// </summary>
        protected CapellaProject project = null!;

        [OneTimeSetUp]
        public void LoadModel()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "coffee-machine-demo.capella");
            this.project = CapellaProject.Load(path);
        }
    }
}
