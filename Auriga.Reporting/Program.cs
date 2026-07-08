// ------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting
{
    using System;
    using System.IO;

    using ECoreNetto.Reporting.Generators;

    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// The command-line entry point: renders the Capella metamodel as an HTML report from the vendored
    /// <c>.ecore</c> files, using the ECoreNetto <see cref="HtmlReportGenerator"/> — the same report
    /// generator used by the sibling projects (uml4net, SysML2.NET).
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Runs the report generator.
        /// </summary>
        /// <param name="args">
        /// the command-line arguments: <c>--ecore &lt;dir&gt;</c> (the vendored <c>.ecore</c> directory,
        /// default <c>resources/ecore</c>) and <c>--output &lt;file.html&gt;</c> (the HTML report file,
        /// default <c>report/index.html</c>)
        /// </param>
        /// <returns>zero on success; a non-zero code on failure</returns>
        public static int Main(string[] args)
        {
            var ecoreDirectory = Option(args, "--ecore") ?? Path.Combine("resources", "ecore");
            var outputFile = Option(args, "--output") ?? Path.Combine("report", "index.html");

            if (!Directory.Exists(ecoreDirectory))
            {
                Console.Error.WriteLine($"Ecore directory not found: '{ecoreDirectory}'.");
                Console.Error.WriteLine("Usage: Auriga.Reporting [--ecore <dir>] [--output <file.html>]");
                return 1;
            }

            try
            {
                var input = new DirectoryInfo(Path.GetFullPath(ecoreDirectory));
                var output = new FileInfo(Path.GetFullPath(outputFile));
                output.Directory?.Create();

                var generator = new HtmlReportGenerator(NullLoggerFactory.Instance);
                generator.GenerateCombinedReport(input, output);

                Console.WriteLine($"Capella metamodel HTML report written to '{output.FullName}'.");
                return 0;
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine($"Report generation failed: {exception.Message}");
                return 1;
            }
        }

        /// <summary>
        /// Returns the value that follows the named <c>--option</c> in the arguments, or <c>null</c> when
        /// the option is absent or has no value.
        /// </summary>
        /// <param name="args">the command-line arguments</param>
        /// <param name="name">the option name (e.g. <c>--ecore</c>)</param>
        /// <returns>the option value, or <c>null</c></returns>
        private static string? Option(string[] args, string name)
        {
            for (var i = 0; i < args.Length - 1; i++)
            {
                if (string.Equals(args[i], name, StringComparison.Ordinal))
                {
                    return args[i + 1];
                }
            }

            return null;
        }
    }
}
