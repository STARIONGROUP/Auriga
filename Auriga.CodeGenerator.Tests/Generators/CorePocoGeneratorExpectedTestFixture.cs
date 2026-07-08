// ------------------------------------------------------------------------------------------------
// <copyright file="ExpectedObjectModelTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Tests.Generators
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Auriga.CodeGenerator.Generators;
    using Auriga.CodeGenerator.Tests.Expected;

    using NUnit.Framework;

    /// <summary>
    /// Golden-file tests (the uml4net/SysML2.NET pattern): for every "interesting class" the code
    /// generator produces is compared byte-for-byte against a hand-reviewed expected file committed
    /// under <c>Expected/</c>. The interesting classes are the ones ECoreNetto's <c>ModelInspector</c>
    /// flags as covering all type and multiplicity variations. Re-run <see cref="Regenerate_expected_files"/>
    /// after an intended generator change to refresh the golden files, then review the diff.
    /// </summary>
    [TestFixture]
    public class CorePocoGeneratorExpectedTestFixture
    {
        private const string ExpectedEnumeration = "PhysicalComponentNature";

        private string expectedDirectory = string.Empty;

        private IReadOnlyDictionary<string, string> files = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void SetUp()
        {
            var ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore");
            this.files = new CorePocoGenerator(ecoreDirectory).Generate();
            this.expectedDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Expected");
        }

        [Test]
        [TestCaseSource(typeof(ExpectedAllClasses))]
        public void Verify_that_the_expected_interface_is_generated(string className)
        {
            var generated = this.Generated($"I{className}.cs");
            var expected = File.ReadAllText(Path.Combine(this.expectedDirectory, "AutoGenInterfaces", $"I{className}.cs"));

            Assert.That(Normalize(generated), Is.EqualTo(Normalize(expected)));
        }

        [Test]
        [TestCaseSource(typeof(ExpectedConcreteClasses))]
        public void Verify_that_the_expected_class_is_generated(string className)
        {
            var generated = this.Generated($"{className}.cs");
            var expected = File.ReadAllText(Path.Combine(this.expectedDirectory, "AutoGenClasses", $"{className}.cs"));

            Assert.That(Normalize(generated), Is.EqualTo(Normalize(expected)));
        }

        [Test]
        public void Verify_that_the_expected_enumeration_is_generated()
        {
            var generated = this.Generated($"{ExpectedEnumeration}.cs");
            var expected = File.ReadAllText(Path.Combine(this.expectedDirectory, "AutoGenEnumeration", $"{ExpectedEnumeration}.cs"));

            Assert.That(Normalize(generated), Is.EqualTo(Normalize(expected)));
        }

        /// <summary>
        /// Rewrites the committed golden files under <c>Expected/</c> from the current generator output.
        /// Run this explicitly after an intended template/generator change, review the diff and commit.
        /// </summary>
        [Test]
        [Explicit("Regenerates the committed Expected golden files.")]
        public void Regenerate_expected_files()
        {
            // Anchor on the test project's .csproj (an ancestor of the bin output directory) so the golden
            // files are written into the source tree rather than the copied Expected folder under bin.
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "Auriga.CodeGenerator.Tests.csproj")))
            {
                directory = directory.Parent;
            }

            Assert.That(directory, Is.Not.Null, "could not locate the test project directory");
            var expected = Path.Combine(directory!.FullName, "Expected");

            foreach (var className in new ExpectedAllClasses())
            {
                this.WriteGolden(expected, "AutoGenInterfaces", $"I{className}.cs");
            }

            foreach (var className in new ExpectedConcreteClasses())
            {
                this.WriteGolden(expected, "AutoGenClasses", $"{className}.cs");
            }

            this.WriteGolden(expected, "AutoGenEnumeration", $"{ExpectedEnumeration}.cs");
        }

        private void WriteGolden(string expectedDirectory, string folder, string fileName)
        {
            var target = Path.Combine(expectedDirectory, folder);
            Directory.CreateDirectory(target);
            File.WriteAllText(Path.Combine(target, fileName), this.Generated(fileName));
        }

        private string Generated(string fileName)
        {
            var key = this.files.Keys.Single(k => Path.GetFileName(k) == fileName);
            return this.files[key];
        }

        private static string Normalize(string text)
        {
            return text.Replace("\r\n", "\n");
        }
    }
}
