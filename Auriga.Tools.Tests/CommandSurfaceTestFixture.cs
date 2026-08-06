// ------------------------------------------------------------------------------------------------
// <copyright file="CommandSurfaceTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Tests
{
    using System.CommandLine;
    using System.IO;
    using System.Linq;

    using Auriga.Tools.Commands;
    using Auriga.Tools.Presentation;
    using Auriga.Tools.Resources;

    using NUnit.Framework;

    /// <summary>
    /// Pins the command line itself. Option names are the tool's contract — they end up in other
    /// people's scripts and CI jobs — so renaming one should fail here rather than silently break a
    /// caller after release.
    /// </summary>
    [TestFixture]
    public class CommandSurfaceTestFixture
    {
        [Test]
        public void Verify_that_export_carries_the_options_it_documents()
        {
            var command = new ExportCommand();
            var options = command.Options.Select(option => option.Name).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(command.Name, Is.EqualTo("export"));
                Assert.That(command.Arguments.Select(argument => argument.Name), Does.Contain("model"));
                Assert.That(options, Is.SupersetOf(new[] { "--output", "--format", "--scale", "--dpi", "--background", "--quality", "--open", "--name", "--no-logo", "--log-level" }));

                Assert.That(command.Options.Single(option => option.Name == "--output").Aliases, Does.Contain("-o"));
                Assert.That(command.Options.Single(option => option.Name == "--format").Aliases, Does.Contain("-f"));
                Assert.That(command.Options.Single(option => option.Name == "--name").Aliases, Does.Contain("-n"));
            });
        }

        [Test]
        public void Verify_that_list_carries_the_options_it_documents()
        {
            var command = new ListCommand();

            Assert.Multiple(() =>
            {
                Assert.That(command.Name, Is.EqualTo("list"));
                Assert.That(command.Arguments.Select(argument => argument.Name), Does.Contain("model"));
                Assert.That(command.Options.Select(option => option.Name), Is.SupersetOf(new[] { "--name", "--no-logo", "--log-level" }));
            });
        }

        [Test]
        public void Verify_that_the_defaults_are_the_documented_ones()
        {
            var parsed = new ExportCommand().Parse("model.aird");

            Assert.Multiple(() =>
            {
                Assert.That(parsed.GetValue<FileInfo>("model")!.Name, Is.EqualTo("model.aird"));
                Assert.That(parsed.GetValue<string>("--format"), Is.EqualTo("svg,png"));
                Assert.That(parsed.GetValue<DirectoryInfo>("--output")!.Name, Is.EqualTo("auriga-export"));
                Assert.That(parsed.GetValue<double>("--scale"), Is.EqualTo(1));
                Assert.That(parsed.GetValue<int>("--quality"), Is.EqualTo(90));
                Assert.That(parsed.GetValue<bool>("--no-logo"), Is.False);
            });
        }

        [Test]
        public void Verify_that_the_splash_screen_carries_the_running_version()
        {
            var logo = ResourceLoader.QueryLogo();

            Assert.Multiple(() =>
            {
                Assert.That(logo, Does.Contain("AURIGA TOOLS version:"));
                Assert.That(logo, Does.Not.Contain("aurigaToolsVersion"), "the placeholder is substituted");
                Assert.That(logo, Does.Contain(ResourceLoader.QueryVersion()));
                Assert.That(logo, Does.Contain("stariongroup.eu"));
                Assert.That(() => ResourceLoader.LoadEmbeddedResource("Auriga.Tools.Resources.nothing.txt"), Throws.Exception);
                Assert.That(() => ResourceLoader.LoadEmbeddedResource(string.Empty), Throws.ArgumentException);
            });
        }

        [Test]
        public void Verify_that_a_diagram_name_is_escaped_before_it_reaches_the_console()
        {
            // Capella names are full of square brackets, which are Spectre's markup delimiters.
            Assert.Multiple(() =>
            {
                Assert.That(Ui.Escape("[SAB] High Level System Overview"), Does.Not.StartWith("[SAB]"));
                Assert.That(Ui.Escape("[SAB]"), Is.EqualTo("[[SAB]]"));
                Assert.That(Ui.Escape(null), Is.Empty);
            });
        }

        [Test]
        public void Verify_that_sizes_and_durations_read_the_way_a_person_expects()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Ui.Size(512), Is.EqualTo("512 B"));
                Assert.That(Ui.Size(2048), Is.EqualTo("2 KB"));
                Assert.That(Ui.Size(1536 * 1024), Is.EqualTo("1.5 MB"));

                Assert.That(Ui.Duration(System.TimeSpan.FromMilliseconds(373)), Is.EqualTo("373 ms"));
                Assert.That(Ui.Duration(System.TimeSpan.FromSeconds(5)), Is.EqualTo("5.0 s"));
            });
        }
    }
}
