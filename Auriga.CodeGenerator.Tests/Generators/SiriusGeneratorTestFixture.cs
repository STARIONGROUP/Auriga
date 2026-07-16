// ------------------------------------------------------------------------------------------------
// <copyright file="SiriusGeneratorTestFixture.cs" company="Starion Group S.A.">
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

    using NUnit.Framework;

    /// <summary>
    /// Tests that the same generators drive the Sirius/GMF metamodel (<c>resources/ecore-sirius</c>,
    /// issue #52) into the <c>Auriga.Diagram</c> object model and <c>Auriga.Xmi.Diagram</c>
    /// readers/writers — the <c>Diagram</c> sub-trees of the same <c>Auriga</c> and <c>Auriga.Xmi</c>
    /// projects that carry the Capella <c>Model</c> output. The classifier counts are the ground truth
    /// from <c>docs/sirius-metamodel-inventory.md</c> (issue #51): 454 EClasses and 39 EEnums across 20
    /// packages.
    /// </summary>
    [TestFixture]
    public class SiriusGeneratorTestFixture
    {
        private const string SiriusRootNamespace = "Auriga.Diagram";

        private const string SiriusXmiRootNamespace = "Auriga.Xmi.Diagram";

        private const string SiriusOutputSubfolder = "Diagram";

        private const int ExpectedInterfaceCount = 454;

        private const int ExpectedEnumCount = 39;

        private string ecoreDirectory = string.Empty;

        private IReadOnlyDictionary<string, string> files = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void SetUp()
        {
            this.ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore-sirius");
            this.files = new CorePocoGenerator(this.ecoreDirectory, SiriusRootNamespace, SiriusOutputSubfolder).Generate();
        }

        [Test]
        public void Verify_that_generation_is_deterministic()
        {
            var second = new CorePocoGenerator(this.ecoreDirectory, SiriusRootNamespace, SiriusOutputSubfolder).Generate();

            Assert.That(second, Is.EqualTo(this.files));
        }

        [Test]
        public void Verify_that_the_whole_metamodel_is_generated()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Count("AutoGenInterfaces/"), Is.EqualTo(ExpectedInterfaceCount), "interfaces");
                Assert.That(Count("AutoGenEnumeration/"), Is.EqualTo(ExpectedEnumCount), "enums");
                Assert.That(Count("AutoGenClasses/"), Is.GreaterThan(0), "classes");
            });
        }

        [Test]
        public void Verify_that_generated_types_use_the_sirius_root_namespace()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.files.Keys, Has.Some.StartsWith("AutoGenInterfaces/Diagram/Viewpoint/"));
                Assert.That(this.files.Values, Has.All.Contain("namespace Auriga.Diagram."));
            });
        }

        [Test]
        public void Verify_that_the_committed_object_model_matches_the_generator()
        {
            AssertCommittedMatchesGenerated("Auriga", this.files);
        }

        [Test]
        public void Verify_that_the_committed_xmi_readers_match_the_generator()
        {
            var readers = new XmiReaderGenerator(this.ecoreDirectory, SiriusRootNamespace, SiriusXmiRootNamespace, SiriusOutputSubfolder).Generate();
            AssertCommittedMatchesGenerated("Auriga.Xmi", readers);
        }

        [Test]
        public void Verify_that_the_committed_xmi_writers_match_the_generator()
        {
            var writers = new XmiWriterGenerator(this.ecoreDirectory, SiriusRootNamespace, SiriusXmiRootNamespace, SiriusOutputSubfolder).Generate();
            AssertCommittedMatchesGenerated("Auriga.Xmi", writers);
        }

        /// <summary>
        /// Regenerates the committed Sirius object model into the <c>Diagram</c> sub-trees of the
        /// <c>Auriga</c> project. Run explicitly after changing the generator or a template, then review
        /// the diff and commit.
        /// </summary>
        [Test]
        [Explicit("Regenerates the committed Sirius object model in the Auriga project.")]
        public void Regenerate_sirius_object_model()
        {
            var aurigaProject = Path.Combine(SolutionRoot(), "Auriga");
            new CorePocoGenerator(this.ecoreDirectory, SiriusRootNamespace, SiriusOutputSubfolder).Write(aurigaProject);
        }

        /// <summary>
        /// Regenerates the committed Sirius XMI readers into the <c>Diagram</c> sub-tree of the
        /// <c>Auriga.Xmi</c> project.
        /// </summary>
        [Test]
        [Explicit("Regenerates the committed Sirius XMI readers in the Auriga.Xmi project.")]
        public void Regenerate_sirius_xmi_readers()
        {
            var xmiProject = Path.Combine(SolutionRoot(), "Auriga.Xmi");
            new XmiReaderGenerator(this.ecoreDirectory, SiriusRootNamespace, SiriusXmiRootNamespace, SiriusOutputSubfolder).Write(xmiProject);
        }

        /// <summary>
        /// Regenerates the committed Sirius XMI writers into the <c>Diagram</c> sub-tree of the
        /// <c>Auriga.Xmi</c> project.
        /// </summary>
        [Test]
        [Explicit("Regenerates the committed Sirius XMI writers in the Auriga.Xmi project.")]
        public void Regenerate_sirius_xmi_writers()
        {
            var xmiProject = Path.Combine(SolutionRoot(), "Auriga.Xmi");
            new XmiWriterGenerator(this.ecoreDirectory, SiriusRootNamespace, SiriusXmiRootNamespace, SiriusOutputSubfolder).Write(xmiProject);
        }

        private int Count(string prefix)
        {
            return this.files.Keys.Count(k => k.StartsWith(prefix, System.StringComparison.Ordinal));
        }

        /// <summary>
        /// The drift guard: asserts every generated file matches the committed file in the project (content,
        /// LF-normalized) and that no stale generated files linger in the produced sub-trees. The stale scan
        /// is scoped to the first two path segments (e.g. <c>AutoGenClasses/Diagram</c>), never the whole
        /// <c>AutoGen*</c> root, because the same project also carries the other metamodel's generated code
        /// under its own sub-folder. Fails when the committed Sirius code is out of date with the generator
        /// or a template.
        /// </summary>
        /// <param name="projectFolder">the project directory (relative to the solution root)</param>
        /// <param name="generated">the freshly-generated path-keyed file contents</param>
        private static void AssertCommittedMatchesGenerated(string projectFolder, IReadOnlyDictionary<string, string> generated)
        {
            var projectRoot = Path.Combine(SolutionRoot(), projectFolder);
            var problems = new List<string>();

            foreach (var file in generated)
            {
                var path = Path.Combine(projectRoot, file.Key.Replace('/', Path.DirectorySeparatorChar));

                if (!File.Exists(path))
                {
                    problems.Add($"missing committed file: {file.Key}");
                    continue;
                }

                if (File.ReadAllText(path).Replace("\r\n", "\n") != file.Value)
                {
                    problems.Add($"out of date: {file.Key}");
                }
            }

            foreach (var folder in generated.Keys.Select(k => string.Join('/', k.Split('/').Take(2))).Distinct())
            {
                var directory = Path.Combine(projectRoot, folder.Replace('/', Path.DirectorySeparatorChar));

                if (!Directory.Exists(directory))
                {
                    continue;
                }

                foreach (var committed in Directory.GetFiles(directory, "*.cs", SearchOption.AllDirectories))
                {
                    var relative = Path.GetRelativePath(projectRoot, committed).Replace(Path.DirectorySeparatorChar, '/');

                    if (!generated.ContainsKey(relative))
                    {
                        problems.Add($"stale committed file: {relative}");
                    }
                }
            }

            Assert.That(problems, Is.Empty, "The committed Sirius generated code is out of date; run the Regenerate_sirius_* tests and commit the result.");
        }

        private static string SolutionRoot()
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "Auriga.sln")))
            {
                directory = directory.Parent;
            }

            Assert.That(directory, Is.Not.Null, "could not locate the solution root");
            return directory!.FullName;
        }
    }
}
