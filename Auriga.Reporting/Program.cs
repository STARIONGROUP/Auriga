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

    /// <summary>
    /// The command-line entry point: renders the Capella metamodel HTML report from the vendored
    /// <c>.ecore</c> files into an output directory.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Runs the report generator.
        /// </summary>
        /// <param name="args">
        /// the command-line arguments: <c>--ecore &lt;dir&gt;</c> (the vendored <c>.ecore</c> directory,
        /// default <c>resources/ecore</c>) and <c>--output &lt;dir&gt;</c> (the site output directory,
        /// default <c>report-output</c>)
        /// </param>
        /// <returns>zero on success; a non-zero code on failure</returns>
        public static int Main(string[] args)
        {
            var ecoreDirectory = Option(args, "--ecore") ?? Path.Combine("resources", "ecore");
            var outputDirectory = Option(args, "--output") ?? "report-output";

            if (!Directory.Exists(ecoreDirectory))
            {
                Console.Error.WriteLine($"Ecore directory not found: '{ecoreDirectory}'.");
                Console.Error.WriteLine("Usage: Auriga.Reporting [--ecore <dir>] [--output <dir>]");
                return 1;
            }

            // The metamodel loader resolves each .ecore file as an absolute URI, so give it an absolute
            // directory regardless of the (possibly relative) path supplied on the command line.
            ecoreDirectory = Path.GetFullPath(ecoreDirectory);

            try
            {
                var generator = new HtmlReportGenerator(ecoreDirectory);
                generator.Write(outputDirectory);

                Console.WriteLine($"Capella metamodel report written to '{Path.GetFullPath(outputDirectory)}'.");
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
