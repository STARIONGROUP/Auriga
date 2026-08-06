// ------------------------------------------------------------------------------------------------
// <copyright file="ProgramTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Tests
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using NUnit.Framework;

    /// <summary>
    /// Runs the tool the way a user does — through <see cref="Program.Main"/>, over a real Capella
    /// model, with nothing mocked. The other fixtures check that the pieces are wired and that the
    /// options parse; this one is the only test that would notice the host failing to build, a
    /// service missing a registration, or a lifetime being disposed too early.
    /// </summary>
    [TestFixture]
    public class ProgramTestFixture
    {
        private string model = string.Empty;

        [SetUp]
        public void SetUp()
        {
            this.model = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "coffee-machine-demo.aird");
        }

        [Test]
        public async Task Verify_that_the_tool_lists_a_model()
        {
            var exitCode = await Program.Main(new[] { "list", this.model, "--no-logo", "--log-level", "Warning" });

            Assert.That(exitCode, Is.EqualTo(0));
        }

        [Test]
        public async Task Verify_that_the_tool_exports_a_model()
        {
            var output = this.Output("program-export");

            var exitCode = await Program.Main(new[]
            {
                "export", this.model,
                "--output", output.FullName,
                "--format", "svg,png",
                "--no-logo",
                "--log-level", "Warning",
            });

            output.Refresh();

            Assert.Multiple(() =>
            {
                Assert.That(exitCode, Is.EqualTo(0));
                Assert.That(output.Exists, Is.True);
                Assert.That(output.EnumerateFiles("*.svg").Count(), Is.EqualTo(6), "one per representation of the coffee-machine model");
                Assert.That(output.EnumerateFiles("*.png").Count(), Is.EqualTo(6));
            });
        }

        [Test]
        public async Task Verify_that_the_export_options_reach_the_output()
        {
            var output = this.Output("program-options");

            var exitCode = await Program.Main(new[]
            {
                "export", this.model,
                "--output", output.FullName,
                "--format", "jpeg",
                "--dpi", "192",
                "--background", "#FFFFFF",
                "--name", "[SAB]*",
                "--no-logo",
                "--log-level", "Warning",
            });

            output.Refresh();
            var written = output.EnumerateFiles().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(exitCode, Is.EqualTo(0));
                Assert.That(written, Has.Count.EqualTo(1), "one representation of that model is a [SAB]");
                Assert.That(written[0].Extension, Is.EqualTo(".jpg"));
                Assert.That(File.ReadAllBytes(written[0].FullName).Take(3), Is.EqualTo(new byte[] { 0xFF, 0xD8, 0xFF }));
            });
        }

        [Test]
        public async Task Verify_that_a_model_that_is_not_there_is_reported_rather_than_thrown()
        {
            var exitCode = await Program.Main(new[]
            {
                "export", Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "no-such-model.aird"),
                "--no-logo",
                "--log-level", "Warning",
            });

            Assert.That(exitCode, Is.EqualTo(-1));
        }

        [Test]
        public async Task Verify_that_an_unknown_format_is_reported_rather_than_thrown()
        {
            var exitCode = await Program.Main(new[]
            {
                "export", this.model,
                "--output", this.Output("program-bad-format").FullName,
                "--format", "bmp",
                "--no-logo",
                "--log-level", "Warning",
            });

            Assert.That(exitCode, Is.EqualTo(-1));
        }

        [Test]
        public async Task Verify_that_the_help_and_the_version_are_answered()
        {
            // MultipleAsync, not Multiple: an async lambda passed to Multiple binds to the Action
            // overload, runs as async void and is never awaited, so nothing inside it can fail.
            await Assert.MultipleAsync(async () =>
            {
                Assert.That(await Program.Main(new[] { "--help" }), Is.EqualTo(0));
                Assert.That(await Program.Main(new[] { "export", "--help" }), Is.EqualTo(0));
                Assert.That(await Program.Main(new[] { "list", "--help" }), Is.EqualTo(0));
                Assert.That(await Program.Main(new[] { "--version" }), Is.EqualTo(0));
            });
        }

        /// <summary>
        /// A per-test output directory under the work directory.
        /// </summary>
        /// <param name="name">the test's own folder</param>
        /// <returns>the directory</returns>
        private DirectoryInfo Output(string name)
        {
            var directory = new DirectoryInfo(Path.Combine(TestContext.CurrentContext.WorkDirectory, "tools", name));

            if (directory.Exists)
            {
                directory.Delete(true);
            }

            return directory;
        }
    }
}
