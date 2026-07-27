// ------------------------------------------------------------------------------------------------
// <copyright file="ReadmeSampleTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using NUnit.Framework;

    /// <summary>
    /// The drift guard for the README's code samples. <c>Auriga.Samples</c> compiles those samples, so
    /// the build already catches a signature change that invalidates them — but only for as long as the
    /// two are the same code. This fixture asserts that: every C# block fenced in <c>README.md</c> must
    /// appear verbatim in the sample project, so editing one without the other fails.
    /// </summary>
    [TestFixture]
    public class ReadmeSampleTestFixture
    {
        /// <summary>
        /// Matches a using directive that imports a namespace, as opposed to a <c>using var</c>
        /// statement — the former is a file-level concern the samples hold outside the method bodies,
        /// the latter is part of the sample itself.
        /// </summary>
        private static bool IsNamespaceImport(string line)
        {
            return line.StartsWith("using ", StringComparison.Ordinal)
                   && line.EndsWith(';')
                   && !line.Contains('=')
                   && !line.Contains('(');
        }

        [Test]
        public void Verify_that_every_readme_sample_is_compiled_by_the_samples_project()
        {
            var root = SolutionRoot();
            var samples = SignificantLines(File.ReadAllText(Path.Combine(root, "Auriga.Samples", "ReadmeSamples.cs")));
            var blocks = CSharpBlocks(File.ReadAllText(Path.Combine(root, "README.md")));

            Assert.That(blocks, Is.Not.Empty, "the README carries at least one C# sample");

            Assert.Multiple(() =>
            {
                foreach (var block in blocks)
                {
                    var expected = block.Where(line => !IsNamespaceImport(line)).ToList();

                    Assert.That(
                        IsContiguousIn(samples, expected),
                        Is.True,
                        $"the README sample starting '{expected.FirstOrDefault()}' is not compiled verbatim by Auriga.Samples");
                }
            });
        }

        /// <summary>
        /// The bodies of the <c>csharp</c> fenced blocks of a markdown document.
        /// </summary>
        /// <param name="markdown">the markdown text</param>
        /// <returns>each block as its list of significant lines</returns>
        private static List<List<string>> CSharpBlocks(string markdown)
        {
            var blocks = new List<List<string>>();
            var current = new List<string>();
            var inside = false;

            foreach (var raw in Lines(markdown))
            {
                var line = raw.Trim();

                if (line == "```csharp")
                {
                    inside = true;
                    current = new List<string>();
                    continue;
                }

                if (inside && line == "```")
                {
                    inside = false;
                    blocks.Add(current);
                    continue;
                }

                if (inside && line.Length > 0)
                {
                    current.Add(line);
                }
            }

            return blocks;
        }

        /// <summary>
        /// The trimmed, non-empty lines of a source text — the form in which the sample and the README
        /// are compared, so that indentation and blank lines may differ between them.
        /// </summary>
        /// <param name="text">the source text</param>
        /// <returns>the significant lines</returns>
        private static List<string> SignificantLines(string text)
        {
            return Lines(text)
                .Select(line => line.Trim())
                .Where(line => line.Length > 0)
                .ToList();
        }

        /// <summary>
        /// Splits a text into lines, independent of the checkout's line endings.
        /// </summary>
        /// <param name="text">the text to split</param>
        /// <returns>the lines</returns>
        private static string[] Lines(string text)
        {
            return text.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');
        }

        /// <summary>
        /// Whether the expected lines appear in order and without interruption in the sample lines.
        /// </summary>
        /// <param name="samples">the sample project's significant lines</param>
        /// <param name="expected">the significant lines of one README block</param>
        /// <returns>true when the block is present verbatim</returns>
        private static bool IsContiguousIn(List<string> samples, List<string> expected)
        {
            if (expected.Count == 0 || expected.Count > samples.Count)
            {
                return false;
            }

            for (var start = 0; start <= samples.Count - expected.Count; start++)
            {
                if (!expected.Where((line, offset) => samples[start + offset] != line).Any())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The repository root, located by walking up from the test directory to the solution file.
        /// </summary>
        /// <returns>the absolute path of the repository root</returns>
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
