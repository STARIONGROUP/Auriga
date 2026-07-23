// ------------------------------------------------------------------------------------------------
// <copyright file="WorkspaceProjectRegistryTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System;
    using System.IO;

    using Auriga.Xmi.Core;

    using NUnit.Framework;

    /// <summary>
    /// Unit tests for <see cref="WorkspaceProjectRegistry"/>: the mapping of Eclipse workspace project
    /// names to folders that resolves <c>platform:/resource/&lt;projectName&gt;/…</c> library hrefs. The
    /// tests build a throw-away workspace on disk (sibling project folders each carrying a <c>.project</c>
    /// whose declared name differs from its folder name) and assert the sibling scan, explicit-registration
    /// precedence, the canonical name relative to the anchor, and the rejection of unknown projects and of
    /// every non-<c>platform:/resource</c> href form.
    /// </summary>
    [TestFixture]
    public class WorkspaceProjectRegistryTestFixture
    {
        private string workspaceRoot = null!;
        private string clientDirectory = null!;
        private string libraryDirectory = null!;

        [SetUp]
        public void SetUp()
        {
            this.workspaceRoot = Path.Combine(Path.GetTempPath(), "auriga-workspace-" + Guid.NewGuid().ToString("N"));
            this.clientDirectory = Path.Combine(this.workspaceRoot, "library-client");
            this.libraryDirectory = Path.Combine(this.workspaceRoot, "capella-library");

            Directory.CreateDirectory(this.clientDirectory);
            Directory.CreateDirectory(this.libraryDirectory);

            WriteProjectDescriptor(this.clientDirectory, "CapellaLibraryClient");
            WriteProjectDescriptor(this.libraryDirectory, "CapellaLibraryFixture");
            File.WriteAllText(Path.Combine(this.libraryDirectory, "library.capella"), "<root/>");
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(this.workspaceRoot))
            {
                Directory.Delete(this.workspaceRoot, recursive: true);
            }
        }

        [Test]
        public void Verify_that_the_sibling_scan_resolves_a_project_by_its_declared_name()
        {
            var registry = new WorkspaceProjectRegistry();
            registry.SetAnchorDirectory(this.clientDirectory);

            var resolved = registry.TryResolveDocument(
                "platform:/resource/CapellaLibraryFixture/library.capella", out var canonicalName, out var fullPath);

            Assert.Multiple(() =>
            {
                Assert.That(resolved, Is.True);
                Assert.That(canonicalName, Is.EqualTo("../capella-library/library.capella"));
                Assert.That(fullPath, Is.EqualTo(Path.Combine(this.libraryDirectory, "library.capella")));
            });
        }

        [Test]
        public void Verify_that_an_unknown_project_is_not_resolved()
        {
            var registry = new WorkspaceProjectRegistry();
            registry.SetAnchorDirectory(this.clientDirectory);

            var resolved = registry.TryResolveDocument(
                "platform:/resource/NoSuchProject/library.capella", out _, out _);

            Assert.That(resolved, Is.False);
        }

        [Test]
        public void Verify_that_a_non_platform_href_is_not_resolved()
        {
            var registry = new WorkspaceProjectRegistry();
            registry.SetAnchorDirectory(this.clientDirectory);

            Assert.Multiple(() =>
            {
                Assert.That(registry.TryResolveDocument("../sysmodel.capella", out _, out _), Is.False);
                Assert.That(registry.TryResolveDocument("platform:/plugin/tooling/model.odesign", out _, out _), Is.False);
            });
        }

        [Test]
        public void Verify_that_an_explicit_registration_takes_precedence_over_the_scan()
        {
            var overrideDirectory = Path.Combine(this.workspaceRoot, "override-library");
            Directory.CreateDirectory(overrideDirectory);

            var registry = new WorkspaceProjectRegistry();
            registry.SetAnchorDirectory(this.clientDirectory);
            registry.Register("CapellaLibraryFixture", overrideDirectory);

            var resolved = registry.TryResolveDocument(
                "platform:/resource/CapellaLibraryFixture/library.capella", out _, out var fullPath);

            Assert.Multiple(() =>
            {
                Assert.That(resolved, Is.True);
                Assert.That(fullPath, Is.EqualTo(Path.Combine(overrideDirectory, "library.capella")));
            });
        }

        [Test]
        public void Verify_that_an_explicit_registration_resolves_without_any_anchor()
        {
            var registry = new WorkspaceProjectRegistry();
            registry.Register("CapellaLibraryFixture", this.libraryDirectory);

            var resolved = registry.TryResolveDocument(
                "platform:/resource/CapellaLibraryFixture/library.capella", out _, out var fullPath);

            Assert.Multiple(() =>
            {
                Assert.That(resolved, Is.True);
                Assert.That(fullPath, Is.EqualTo(Path.Combine(this.libraryDirectory, "library.capella")));
            });
        }

        [Test]
        public void Verify_that_moving_the_anchor_rescans_the_new_workspace()
        {
            var registry = new WorkspaceProjectRegistry();

            // A directory outside the workspace has no sibling projects, so nothing resolves there.
            registry.SetAnchorDirectory(Path.GetTempPath());
            Assert.That(registry.TryResolveDocument("platform:/resource/CapellaLibraryFixture/library.capella", out _, out _), Is.False);

            // Re-anchoring inside the workspace picks up the sibling library project.
            registry.SetAnchorDirectory(this.clientDirectory);
            Assert.That(registry.TryResolveDocument("platform:/resource/CapellaLibraryFixture/library.capella", out _, out _), Is.True);
        }

        private static void WriteProjectDescriptor(string directory, string declaredName)
        {
            var descriptor = $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<projectDescription>\n\t<name>\n\t\t{declaredName}\n\t</name>\n</projectDescription>\n";
            File.WriteAllText(Path.Combine(directory, ".project"), descriptor);
        }
    }
}
