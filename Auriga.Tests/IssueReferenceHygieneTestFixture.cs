// ------------------------------------------------------------------------------------------------
// <copyright file="IssueReferenceHygieneTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    using NUnit.Framework;

    /// <summary>
    /// Guards against GitHub issue references creeping back into code comments. The commit that
    /// introduces a line already carries its issue number through the commit message and the pull
    /// request, so repeating it in the source is redundant and rots as issues are closed, split or
    /// renumbered. A comment should explain what the code does, and why, in prose that stands on its own.
    ///
    /// <para>Documentation is exempt and deliberately not scanned: in <c>TestData/README.md</c>,
    /// <c>docs/</c> and <c>NOTICE</c> the citation is the point. Only <c>*.cs</c> and the Handlebars
    /// templates are checked — a reference added to a template propagates into hundreds of generated
    /// files, which is the case most worth catching early.</para>
    /// </summary>
    [TestFixture]
    public class IssueReferenceHygieneTestFixture
    {
        /// <summary>
        /// A GitHub issue reference: a hash followed by one to four digits, bounded so it does not match
        /// a hex colour such as <c>#0000FF</c> or a longer numeric literal.
        /// </summary>
        private static readonly Regex IssueReference = new Regex(@"(?<![\w#])#\d{1,4}\b", RegexOptions.Compiled);

        [Test]
        public void Verify_that_no_source_file_references_a_github_issue()
        {
            var root = SolutionRoot();

            var offenders = new List<string>();

            foreach (var file in Directory.EnumerateFiles(root, "*.*", SearchOption.AllDirectories))
            {
                if (!file.EndsWith(".cs", System.StringComparison.Ordinal) && !file.EndsWith(".hbs", System.StringComparison.Ordinal))
                {
                    continue;
                }

                if (file.Contains($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}", System.StringComparison.Ordinal)
                    || file.Contains($"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}", System.StringComparison.Ordinal))
                {
                    continue;
                }

                var lines = File.ReadAllLines(file);
                for (var i = 0; i < lines.Length; i++)
                {
                    if (IssueReference.IsMatch(lines[i]))
                    {
                        offenders.Add($"{Path.GetRelativePath(root, file)}:{i + 1}: {lines[i].Trim()}");
                    }
                }
            }

            Assert.That(
                offenders,
                Is.Empty,
                "GitHub issue references belong in commit messages, pull requests and documentation — not in code comments:\n  "
                + string.Join("\n  ", offenders.Take(20)));
        }

        /// <summary>
        /// Walks up from the test output directory to the folder holding <c>Auriga.sln</c>.
        /// </summary>
        /// <returns>the solution root</returns>
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
