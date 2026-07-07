// ------------------------------------------------------------------------------------------------
// <copyright file="ScaffoldTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Tests
{
    using System.IO;

    using NUnit.Framework;

    /// <summary>
    /// Placeholder test fixture proving the test infrastructure runs and the vendored
    /// .ecore input files are available; replaced by real tests as the generator is
    /// implemented (issues #6-#8).
    /// </summary>
    [TestFixture]
    public class ScaffoldTestFixture
    {
        [Test]
        public void Verify_that_the_vendored_ecore_files_are_copied_to_the_output()
        {
            var ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore");

            Assert.That(Directory.GetFiles(ecoreDirectory, "*.ecore"), Has.Length.EqualTo(21));
        }
    }
}
