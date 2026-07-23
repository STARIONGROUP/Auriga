// ------------------------------------------------------------------------------------------------
// <copyright file="LibraryReferenceTestFixture.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using Auriga.Core;
    using Auriga.Model.Capellacore;
    using Auriga.Model.Capellamodeller;

    using NUnit.Framework;

    /// <summary>
    /// End-to-end acceptance for issue #68: a Capella project that references an element in a sibling
    /// <b>library</b> project through a <c>platform:/resource/&lt;projectName&gt;/…</c> href. The workspace
    /// registry resolves the declared project name (read from the sibling's <c>.project</c>, which differs
    /// from its folder name) to the library document, the reader co-loads that document into the same
    /// session, and the reference resolves to a typed library element. An href to an unknown project stays
    /// reported as an unresolved reference rather than being silently dropped or aborting the load (#54).
    /// </summary>
    [TestFixture]
    public class LibraryReferenceTestFixture
    {
        private string temporaryRoot = null!;

        [SetUp]
        public void SetUp()
        {
            this.temporaryRoot = Path.Combine(Path.GetTempPath(), "auriga-library-ref-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(this.temporaryRoot);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(this.temporaryRoot))
            {
                Directory.Delete(this.temporaryRoot, recursive: true);
            }
        }

        [Test]
        public void Verify_that_a_platform_resource_library_reference_resolves_to_a_typed_element()
        {
            var result = XmiReaderBuilder.Create().BuildCapellaModelLoader().Load(ClientProjectPath());

            var project = (IProject)result.Root;

            Assert.Multiple(() =>
            {
                // The status href crossed into the sibling library and resolved to the typed literal there.
                Assert.That(project.Status, Is.Not.Null, "the platform:/resource library reference resolved");
                Assert.That(project.Status, Is.InstanceOf<IEnumerationPropertyLiteral>());
                Assert.That(((Auriga.Model.Modellingcore.IAbstractNamedElement)project.Status).Name, Is.EqualTo("APPROVED"));

                // The resolved literal is the one contributed by the co-loaded library document — named
                // relative to the client project's own folder (a sibling traversal).
                Assert.That(
                    ((IAurigaElement)project.Status).SourceDocument,
                    Is.EqualTo("../capella-library/library.capella"));

                // The library document joined the session: its elements are present under that source.
                Assert.That(
                    result.Elements.Values.Any(element => element.SourceDocument == "../capella-library/library.capella"),
                    Is.True,
                    "the sibling library document was co-loaded");

                // A resolved reference is not a dangling one.
                Assert.That(
                    result.UnresolvedReferences.Any(reference => reference.PropertyName == "Status"),
                    Is.False,
                    "the resolved library reference is not reported as unresolved");
            });
        }

        [Test]
        public void Verify_that_a_reference_to_an_unknown_library_project_stays_reported()
        {
            // A stand-alone client whose href names a project that is in no sibling folder: the load must
            // survive and the reference must be reported, not silently dropped.
            var clientDirectory = Path.Combine(this.temporaryRoot, "client");
            Directory.CreateDirectory(clientDirectory);
            WriteProjectDescriptor(clientDirectory, "OrphanClient");

            File.WriteAllText(
                Path.Combine(clientDirectory, "client.capella"),
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<org.polarsys.capella.core.data.capellamodeller:Project xmi:version='2.0' " +
                "xmlns:xmi='http://www.omg.org/XMI' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' " +
                "xmlns:org.polarsys.capella.core.data.capellacore='http://www.polarsys.org/capella/core/core/6.0.0' " +
                "xmlns:org.polarsys.capella.core.data.capellamodeller='http://www.polarsys.org/capella/core/modeller/6.0.0' " +
                "id='orphan-client' name='OrphanClient'>" +
                "<status xsi:type='org.polarsys.capella.core.data.capellacore:EnumerationPropertyLiteral' " +
                "href='platform:/resource/NoSuchLibrary/library.capella#missing-literal'/>" +
                "</org.polarsys.capella.core.data.capellamodeller:Project>");

            var result = XmiReaderBuilder.Create().BuildCapellaModelLoader().Load(Path.Combine(clientDirectory, "client.capella"));

            var project = (IProject)result.Root;

            Assert.Multiple(() =>
            {
                Assert.That(project.Status, Is.Null, "an unknown library reference does not resolve");
                Assert.That(
                    result.UnresolvedReferences.Any(reference => reference.PropertyName == "Status"),
                    Is.True,
                    "the unresolved library reference is reported, not dropped");
            });
        }

        private static string ClientProjectPath()
        {
            return Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                "TestData", "library-workspace", "library-client", "client.capella");
        }

        private static void WriteProjectDescriptor(string directory, string declaredName)
        {
            var descriptor = $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<projectDescription>\n\t<name>{declaredName}</name>\n</projectDescription>\n";
            File.WriteAllText(Path.Combine(directory, ".project"), descriptor);
        }
    }
}
